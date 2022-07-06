using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace DataAccess.EF
{
    public class RepositorioPlanta_EF : IRepositorioPlanta
    {

        public void Insert(Planta p)
        {
            bool result = false;
            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    dbContext.Plantas.Add(p);
                    result = dbContext.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {

            }
            //return result;
        }

        public IEnumerable GetPorTexto(string miTexto)
        {
            ICollection<Planta> result = new List<Planta>();
            
            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    result = dbContext.Plantas.Where(p => p.NombreCientifico.Contains(miTexto) || p.NombresVulgares.Contains(miTexto)).ToList();

                }


            }
            catch (Exception)
            {

                throw;
            }
            return result; ;
        }





        public void Delete(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable Get()
        {
            ICollection<Planta> result = new List<Planta>();

            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    result = dbContext.Plantas.ToList<Planta>();

                }
            }
            catch (Exception e)
            {

                throw;
            }

            return result;
        }

        public Planta GetByName(string nombre)
        {
            Planta result = null;
            try
            {

                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    result = dbContext.Plantas.SingleOrDefault(p => p.NombreCientifico == nombre);

                }
            }catch(Exception e)
            {
                throw;
            }

            return result;
        }

        public IEnumerable GetPorTipo(string miTipo)
        {
            ICollection<Planta> result = new List<Planta>();

            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    result = dbContext.Plantas.Where<Planta>(p => p.NombreTipo == miTipo).ToList();
                }



            }
            catch (Exception)
            {

                throw;
            }
            return result; ;
        }





        public IEnumerable GetDeXCentimetrosOMas(int miAlturaMaxima)
        {
            ICollection<Planta> result = new List<Planta>();


            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    result = dbContext.Plantas.Where<Planta>(p => p.AlturaMaxima > miAlturaMaxima).ToList<Planta>();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public object GetDeXCentimetrosOMas(double miAlturaMinima)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetMasBajasQueXCentimetros(int miAlturaMaxima)
        {
            ICollection<Planta> result = new List<Planta>();


            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    result = dbContext.Plantas.Where<Planta>(p => p.AlturaMaxima < miAlturaMaxima).ToList<Planta>();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public object GetMasBajasQueXCentimetros(double miAlturaMaxima)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetPorAmbiente(string miAmbiente)
        {
            ICollection<Planta> result = new List<Planta>();

            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    result = dbContext.Plantas.Where<Planta>(p => p.Ambiente == miAmbiente).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return result; ;
        }


        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Planta obj)
        {
            throw new NotImplementedException();
        }

        object IRepositorio<Planta>.GetPorAmbiente(string miAmbiente)
        {
            throw new NotImplementedException();
        }
    }
}
