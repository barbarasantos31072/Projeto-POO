using System;
using System.Collections.Generic;
using System.Data.Common;

namespace ProjetoFinal.Classes
{
    public class SistemaGestaoFinancas
    {
        private List<Utilizador> utilizadores = new List<Utilizador>();
        private List<Receita> receitas = new List<Receita>();
        private List<Despesa> despesas = new List<Despesa>();
        private Utilizador? utilizadorAtual;

        //Criar Conta
        public static CriarConta(int id)
        {
            Console.WriteLine("\n=== CRIAR CONTA ===");
            Console.WriteLine("1 - Administrador");
            Console.WriteLine("2 - Utilizador");
            Console.Write("Escolha um perfil: ");

            string opcao = Console.ReadLine();

            if (opcao == "1")
            {

                Perfil 1 = User;
                Utilizador CriarConta();
            }
            else if (opcao == "2")
            {
                // MenuAdministrador(novoUser);
            }
            else
            {
                Console.WriteLine("Perfil inválido!");
            }
        }
        //Adicionar Transação
        public void AdicionarTransacao()
        {
            Console.WriteLine("\n=== ADICIONAR TRANSAÇÃO ===");
            Console.WriteLine("Digite um número");
            Console.WriteLine("1 - Receita");
            Console.WriteLine("2 - Despesa");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            if (opcao == "1")
            {
                Receita.CriarReceita();
            }
            else if (opcao == "2")
            {
                Despesa.CriarDespesa();
            }
            else
            {
                Console.WriteLine("Opção inválida! Deve escolher 1 ou 2.");
                return;
            }
        }
    }




}

