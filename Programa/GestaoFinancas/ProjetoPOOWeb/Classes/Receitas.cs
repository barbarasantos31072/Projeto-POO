using System;

namespace ProjetoFinal.Classes
{
    public class Receita : Transacao
    {
        public Receita() { }

        public Receita(int id, string descricao, decimal valor, DateTime data, string categoria)
            : base(id, descricao, valor, data, categoria, "Receita")
        {
        }
    }
}
