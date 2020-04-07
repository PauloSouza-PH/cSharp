using System.Windows.Forms;

namespace Biometria
{
    class Program
    {
        static void Main(string[] argumento)
        {
            if (argumento.Length < 3)
            {
                MessageBox.Show("Rotina não recebeu nenhum parametro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (argumento[1].Length <= 1)
            {
                MessageBox.Show("Erro ao receber segundo parametro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (argumento[2].Length <= 1)
            {
                MessageBox.Show("Erro ao receber terceiro parametro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Arquivo = argumento[1];
            string PathSalvamento = argumento[2];

            Biometria biometria = new Biometria();

            if (argumento[0] == "GRAVAR")
            {
                biometria.Gravar(Arquivo, PathSalvamento);
            }
            else if (argumento[0] == "LER")
            {
                biometria.Leitura(Arquivo, PathSalvamento);
            }
        }

    }

}