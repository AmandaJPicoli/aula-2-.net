using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public class Produtos
    {

        #region Construtor
        public Produtos()
        {
            Id = Guid.NewGuid();
        }

        #endregion

        #region Props
        public Guid Id { get; set; }
        public double Preco { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        #endregion

    }
}
