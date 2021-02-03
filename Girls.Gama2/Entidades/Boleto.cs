using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Boleto
    {
        private const int DiasVencimento = 15;
        private const double Juros = 0.10;

        public Boleto(double valor, string cpf, string descricao)
        {
            Valor = valor;
            Cpf = cpf;
            DataEmissao = DateTime.Now;
            Descricao = descricao;
            Confirmacao = false;
        }

        public Guid CodigoBarra { get; set; }

        public double Valor { get; set; }

        public DateTime DataEmissao { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime DataPagamento { get; set; }

        public string Cpf { get; set; }

        public string Descricao { get; set; }

        public bool Confirmacao { get; set; }

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
    }
}
