using Girls.Gama2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Televisao: Produtos, IProdutos
    {
        private const double promocao = 0.15;

        #region Construtor

        public Televisao(double preco, string marca, string modelo)
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
            Preco -= descontoPromo;
        }
        #endregion
    }
}
