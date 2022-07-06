using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Compra //Esta clase debería ser abstracta pero por problemas en el alta de compras (precisamos instanciar una compra) lo cambiamos
    {

        #region Atributos
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<ItemCompras> ItemCompras { get; set; } = new List<ItemCompras>();

        #endregion


        #region Constructor
        public Compra()
        {

        }
        #endregion


    }
}
