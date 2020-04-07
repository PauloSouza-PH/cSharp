using System;
using System.IO;
using System.Windows.Forms;
using NITGEN.SDK.NBioBSP;

namespace Biometria
{
    class Biometria
    {
        public void Gravar(string Arquivo, string PathSalvamento)
        {
            //Declaracao de variaveis
            NBioAPI HandleBio;
            uint Retorno = NBioAPI.Error.NONE;
            uint NenhumErro = NBioAPI.Error.NONE;
            short Dispositivo = NBioAPI.Type.DEVICE_ID.AUTO;
            NBioAPI.Type.HFIR CapturedFir;
            NBioAPI.Export export;
            NBioAPI.Type.MINCONV_DATA_TYPE tipo;
            NBioAPI.Export.EXPORT_DATA exportDados;
            NBioAPI.Type.INIT_INFO_0 initInfo0;
            //-----------------------
            //-----------------------
            HandleBio = new NBioAPI();
            Retorno = HandleBio.OpenDevice(Dispositivo);
            if (Retorno != NenhumErro)
            {
                MessageBox.Show("Erro ao cadastrar biometria", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleBio.Dispose();
                return;
            }

            Retorno = HandleBio.GetInitInfo(out initInfo0);
            if (Retorno != NenhumErro)
            {
                MessageBox.Show("Erro ao coletar informações do dispositivo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleBio.Dispose();
                return;
            }
            initInfo0.EnrollImageQuality = 90;
            initInfo0.VerifyImageQuality = 90;
            initInfo0.SecurityLevel = 7;
            Retorno = HandleBio.SetInitInfo(initInfo0);
            if (Retorno != NenhumErro)
            {
                MessageBox.Show("Erro ao setar informações iniciais do dispositivo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleBio.Dispose();
                return;
            }

            Retorno = HandleBio.Capture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out CapturedFir, NBioAPI.Type.TIMEOUT.DEFAULT, null, null);
            if (Retorno != NenhumErro)
            {
                MessageBox.Show("Erro ao cadastrar biometria", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleBio.CloseDevice(Dispositivo);
                HandleBio.Dispose();
                return;
            }

            export = new NBioAPI.Export(HandleBio);
            tipo = NBioAPI.Type.MINCONV_DATA_TYPE.MINCONV_TYPE_FDU;
            export.NBioBSPToFDx(CapturedFir, out exportDados, tipo);

            for (int f = 0; f < exportDados.FingerNum; f++)
            {
                for (int s = 0; s < exportDados.SamplesPerFinger; s++)
                {

                    try
                    {
                        FileStream fs = new FileStream(PathSalvamento + Arquivo, FileMode.OpenOrCreate, FileAccess.Write);
                        BinaryWriter fw = new BinaryWriter(fs);

                        fw.Write(exportDados.FingerData[f].Template[s].Data);

                        fw.Close();
                        fs.Close();
                    }
                    catch (FileNotFoundException e)
                    {
                        MessageBox.Show("Erro criar template biometrico\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        HandleBio.CloseDevice(Dispositivo);
                        HandleBio.Dispose();
                        return;
                    }

                }
            }
            HandleBio.CloseDevice(Dispositivo);
            HandleBio.Dispose();
        }

        public void Leitura(string Arquivo, string PathSalvamento)
        {
            NBioAPI HandleBio;
            uint Retorno = NBioAPI.Error.NONE;
            uint NenhumErro = NBioAPI.Error.NONE;
            NBioAPI.Type.MINCONV_DATA_TYPE importType;
            NBioAPI.Export m_Export;
            NBioAPI.Type.HFIR processedFIR;
            NBioAPI.Type.INIT_INFO_0 initInfo0;
            uint nSize = 0;
            byte[] minData = null;
            //-----------------------

            try
            {
                FileStream fs = new FileStream(PathSalvamento + Arquivo, FileMode.Open, FileAccess.Read);
                BinaryReader fr = new BinaryReader(fs);
                nSize = (uint)fs.Length;
                minData = new byte[nSize];
                fr.Read(minData, 0, (int)nSize);
                fr.Close();
                fs.Close();
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Erro localizar arquivo biometrico\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HandleBio = new NBioAPI();
            HandleBio.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            if (Retorno != NenhumErro)
            {
                MessageBox.Show("Erro ao verificar digital", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleBio.Dispose();
                return;
            }
            importType = NBioAPI.Type.MINCONV_DATA_TYPE.MINCONV_TYPE_FDU;
            m_Export = new NBioAPI.Export(HandleBio);
            Retorno = m_Export.FDxToNBioBSPEx(minData, nSize, importType, NBioAPI.Type.FIR_PURPOSE.VERIFY, out processedFIR);
            if (Retorno != NenhumErro)
            {
                MessageBox.Show("Erro ao verificar digital", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleBio.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                HandleBio.Dispose();
                return;
            }

            Retorno = HandleBio.GetInitInfo(out initInfo0);
            if (Retorno != NenhumErro)
            {
                MessageBox.Show("Erro ao coletar informações do dispositivo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleBio.Dispose();
                return;
            }
            initInfo0.EnrollImageQuality = 90;
            initInfo0.VerifyImageQuality = 90;
            initInfo0.SecurityLevel = 7;
            Retorno = HandleBio.SetInitInfo(initInfo0);
            if (Retorno != NenhumErro)
            {
                MessageBox.Show("Erro ao setar informações iniciais do dispositivo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleBio.Dispose();
                return;
            }

            Boolean bResult;
            Retorno = HandleBio.Verify(processedFIR, out bResult, null);
            if (Retorno != NenhumErro)
            {
                MessageBox.Show("Erro ao verificar digital", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!bResult)
                {
                    MessageBox.Show("Vendedor não autenticado", "Falha ao autenticar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        MessageBox.Show("Autenticação realizada com sucesso", "Sucesso!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                        FileStream validacao = new FileStream(Path.GetTempPath() + "Result_" + Arquivo, FileMode.CreateNew, FileAccess.Write);
                        BinaryWriter fw = new BinaryWriter(validacao);
                        fw.Write("#$&%&$*%¨$*$¨%$*&($$)$)$¨$&¨%$*$&¨#%%(*%)");
                        fw.Close();
                        validacao.Close();
                    }
                    catch (FileNotFoundException e)
                    {
                        MessageBox.Show("Erro localizar arquivo biometrico\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }

            HandleBio.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
        }
    }
}


