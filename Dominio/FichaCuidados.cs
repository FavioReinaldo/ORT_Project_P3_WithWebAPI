using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FichaCuidados
    {
        #region Atributos
        public string FrecuenciaRiego { get; set; }
        public string Illuminacion { get; set; }
        public double Temperatura { get; set; } //En la base de datos esta como float
        #endregion

        #region Constructor
        public FichaCuidados()
        {

        }
        #endregion
    }
}
