using Girls.Gama2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Geladeira : Produtos, IProdutos
    {
        private const double promocao = 0.15;
        private const double desconto = 100;


        #region Construtor
        public Geladeira(double preco, string marca, string modelo)
        {
            Preco = preco;
            Marca = marca;
            Modelo = modelo;
        }
        #endregion

        #region Metodos
        public void Promocao()
        {
            var descontoPromo = Preco * promocao;
            Preco -= (desconto + descontoPromo);
        }
        #endregion

    }
}
