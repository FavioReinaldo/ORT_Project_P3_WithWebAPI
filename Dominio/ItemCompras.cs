using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class ItemCompras
    {

        #region Atributos

        public int Id { get; set; }
        public Planta PlantaComprada { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompraUnidad { get; set; }
        #endregion

        

        #region Constructor
        public ItemCompras()
        {
        }
        #endregion
        //ToString

    }
}
