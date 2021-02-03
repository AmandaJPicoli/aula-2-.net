using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Dinheiro
    {
        private const double Desconto = 0.05;
        public Dinheiro(double valor)
        {
            Valor = valor;
            DescricaoCompra = "Pagamento em dinheiro";
            DataPagamento = DateTime.Now;
        }

        public double Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public string DescricaoCompra { get; set; }


        public void DarDesconto()
        {
            var desconto = Valor * Desconto;
            Valor -= desconto;
        }
    }
}
