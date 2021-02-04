using Girls.Gama2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Dinheiro : Pagamento, IPagamento
    {
        private const double Desconto = 0.05;

        #region Construtor
        public Dinheiro(double valor)
        {
            DescricaoCompra = "Pagamento em dinheiro";
            Valor = valor;
        }
        #endregion

        #region Props
        public string DescricaoCompra { get; set; }

        #endregion

        #region Metodos
        public void Pagar()
        {
            var desconto = Valor * Desconto;
            Valor -= desconto;
        }
        #endregion

    }
}
