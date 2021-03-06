﻿using ByteBank.Modelos.dbSys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.SistemaInterno
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cgc { get; private set; }
        public DateTime Nascimento { get; set; }
        public static int TotalClientes
        {
            get
            {
                int _total = 0;
                using (var contexto = new ByteBankContext())
                {
                    _total = contexto.Cliente.Count();
                }
                return _total;
            }
            private set { }
        }
        public List<ContaCorrente> ContaCorrente { get; set; }

        public Cliente(string cgc, string nome)
        {
            Cgc = cgc ?? throw new ArgumentOutOfRangeException(nameof(cgc));
            Nome = nome;
        }

        public static void Persistir(params Cliente[] cliente)
        {
            using (var contexto = new ByteBankContext())
            {
                foreach (Cliente item in cliente)
                {
                    contexto.Cliente.Add(item);
                    Console.WriteLine($"Cliente {item.Nome} sendo adicionado ao banco de dados");
                }
                contexto.SaveChanges();
            }
        }

        public static Cliente GetCliente(string cpf)
        {

            Cliente cliente = null;
            using (var contexto = new ByteBankContext())
            {
                cliente = contexto
                    .Cliente
                    .Include(c => c.ContaCorrente)
                    .ThenInclude(m => m.Movimentacoes)
                    .Where(Cliente => Cliente.Cgc == cpf)
                    .First();
            }
            return cliente;
        }

        public static IList<Cliente> GetClientes(string cpf = "", int id = 0)
        {

            IList<Cliente> ListClientes;
            using (var contexto = new ByteBankContext())
            {
                ListClientes = contexto.Cliente.ToList();
            }

            IEnumerable<Cliente> filtros = null;
            if (!String.IsNullOrEmpty(cpf))
            {
                filtros = ListClientes.Where(Cliente => Cliente.Cgc.Trim() == cpf.Trim());
            }

            if (id > 0)
            {
                filtros = ListClientes.Where(Cliente => Cliente.Id == id);
            }

            if (filtros != null)
                ListClientes = filtros.ToList() as IList<Cliente>;

            return ListClientes;
        }

        public void Update()
        {
            using (var contexto = new ByteBankContext())
            {
                contexto.Cliente.Update(this);
                contexto.SaveChanges();
                Console.WriteLine($"Cliente {this.Nome} atualizado");
            }
        }

        public static void Remove(Cliente cliente)
        {
            using (var contexto = new ByteBankContext())
            {
                contexto.Cliente.Remove(cliente);
                contexto.SaveChanges();
            }
            Console.WriteLine($"Cliente removido\n{cliente}");
        }

        public override string ToString()
        {
            return $"Cliente:\t{Nome.Trim()}\tCPF:\t{Cgc.Trim()}";
        }

    }
}
