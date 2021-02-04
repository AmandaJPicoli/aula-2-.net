using Girls.Gama2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Boleto : Pagamento, IPagamento
    {
        private const int DiasVencimento = 15;
        private const double Juros = 0.10;

        #region Construtor
        public Boleto(double valor, string cpf, string descricao)
        {
            Valor = valor;
            Cpf = cpf;
            Descricao = descricao;
            DataEmissao = DateTime.Now;
        }
        #endregion

        #region Props
        public Guid CodigoBarra { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Descricao { get; set; }
        #endregion

        #region Metodos
        public void GerarBoleto()
        {
            CodigoBarra = Guid.NewGuid();
            DataVencimento = DataEmissao.AddDays(DiasVencimento);
        }

        public bool EstaPago()
        {
            return Confirmacao;
        }

        public bool EstaVencido()
        {
            return DataVencimento < DateTime.Now;
        }

        public void CalcularJuros()
        {
            var taxa = Valor * Juros;
            Valor += taxa;
        }

        public void Pagar()
        {
            DataPagamento = DateTime.Now;
            Confirmacao = true;
        }

        #endregion

    }
}
