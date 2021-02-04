using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Pagamento
    {
        #region Construtor
        public Pagamento()
        {
            Id = new Guid();
        }
        #endregion

        #region Props
        public Guid Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool Confirmacao { get; set; }
        public string Cpf { get; set; }
        #endregion

    }
}
