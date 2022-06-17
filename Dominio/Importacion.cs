using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Importacion : Compra
    {

        
        #region Atributos
        public double ImpuestoImportacion { get; set; }
        public bool EsOrigenAmericaDelSur { get; set; }
        public double PorcentajeDescuento { get; set; }
        public string MedidasSanitarias { get; set; }
        #endregion


        
        
        #region Constructor
        public Importacion(DateTime fecha, double ImpuestoImportacion, bool EsOrigenAmericaDelSur, double PorcentajeDescuento, string MedidasSanitarias) : base(fecha)
        {
            this.ImpuestoImportacion = ImpuestoImportacion;
            this.EsOrigenAmericaDelSur = EsOrigenAmericaDelSur;
            this.PorcentajeDescuento = PorcentajeDescuento;
            this.MedidasSanitarias = MedidasSanitarias;
        }
        #endregion
    }
}
