using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class ItemCompras
    {
        
        #region Atributos
        public Planta PlantaComprada { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompraUnidad { get; set; }
        #endregion

        

        #region Constructor
        public ItemCompras(int Cantidad, decimal PrecioCompraUnidad)
        {
            this.Cantidad = Cantidad;
            this.PrecioCompraUnidad = PrecioCompraUnidad;
        }
        #endregion
        //ToString

    }
}
