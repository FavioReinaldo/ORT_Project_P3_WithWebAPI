using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Plaza : Compra
    {
        //Atributos
        public double Iva { get; set; }
        public double Flete { get; set; }
        //Propiedades

        //constructor
        public Plaza(DateTime Fecha, double Iva, double Flete) : base(Fecha)
        {
            this.Iva = Iva;
            this.Flete = Flete;
        }
        

    }
}
