using System;

namespace Util
{
    public class Utilidades
    {
        public int GetIdade(DateTime nascimento) {
            int idade = DateTime.Now.Year - nascimento.Year;
            if (DateTime.Now.Month < nascimento.Month || DateTime.Now.Month == nascimento.Month && DateTime.Now.Day < nascimento.Day) {
                idade--;   
            }

            return idade; 
        }
    }
}