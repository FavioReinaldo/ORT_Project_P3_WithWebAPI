using System;
using System.Collections.Generic;

namespace Dominio
{
    public abstract class Compra
    {
        
        #region Atributos
        public DateTime Fecha { get; set; }
        public List<ItemCompras> Compras = new List<ItemCompras>();
    #endregion


    #region Constructor
    public Compra(DateTime Fecha)
        {
            this.Fecha = Fecha;
            
        }
        #endregion

    }
}
