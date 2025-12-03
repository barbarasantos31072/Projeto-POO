using System;

namespace ProjetoFinal.Classes
{
    public class Despesa : Transacao
    {
        public Despesa() { }

        public Despesa(int id, string descricao, decimal valor, DateTime data, string categoria)
            : base(id, descricao, valor, data, categoria, "Despesa")
        {
        }
    }
}
