using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{

    public class Planta
    {
        #region Atributos
        public string  NombreTipo { get; set; }
        public string NombreCientifico { get; set; }
        public string NombresVulgares { get; set; }
        public string Descripcion { get; set; }
        public string Ambiente { get; set; }
        public int  AlturaMaxima { get; set; }
        public string FotoPlanta { get; set; }
        public FichaCuidados FichaCuidados { get; set; }
        #endregion



        public Planta(string NombreTipo, string NombresVulgares, string NombreCientifico, string Descripcion, string Ambiente, int AlturaMaxima, string FotoPlanta)
        {
            this.NombreTipo = NombreTipo;
            this.NombresVulgares = NombresVulgares;
            this.NombreCientifico = NombreCientifico;
            this.Descripcion = Descripcion;
            this.Ambiente = Ambiente;
            this.AlturaMaxima = AlturaMaxima;
            this.FotoPlanta = FotoPlanta;
        }
        
        public Planta()
        {
            //Constructor por defecto
        }
        public bool ValidarPlanta(string NombreCientifico)
        {
            bool retorno = false;
            //falta validaciones (solo alfabeticos)
            if (NombreCientifico != null)
            {
                NombreCientifico.Trim();
                retorno = true;
            }




            return retorno;
        }


        public bool ValidarDescripcion(string miDescripcion)
        {
            bool retorno = false;

            if (miDescripcion.Length < 500 && miDescripcion.Length > 10)
            {
                retorno = true;
            }

            return retorno;
        }
        //public override bool Equals(object obj)
        //{
        //    Planta unaP = obj as Planta;
        //    return obj != null && nombreCientifico == unaP.NombreCientifico;

        //}

        public bool IsValid()
        {
            return !(string.IsNullOrEmpty(this.NombreTipo) || string.IsNullOrEmpty(this.NombresVulgares) || string.IsNullOrEmpty(this.NombreCientifico) || string.IsNullOrEmpty(this.Descripcion) || string.IsNullOrEmpty(this.Ambiente) || string.IsNullOrEmpty(this.FotoPlanta)) || this.AlturaMaxima > 0;
            
        }

    }
}
