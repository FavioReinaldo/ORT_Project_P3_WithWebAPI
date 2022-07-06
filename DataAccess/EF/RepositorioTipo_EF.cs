using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace DataAccess.EF
{
    public class RepositorioTipo_EF : IRepositorioTipo
    {

        public RepositorioTipo_EF()
        {

        }


        public void Delete(string Clave) // hay que modificar porque antes pasabamos un "string nombre"
        {
            //bool result = false;

            try
            {
                Tipo tipo = this.GetByName(Clave);
                if (tipo != null)
                {
                    using (LibreriaContext dbContext = new LibreriaContext())
                    {
                        dbContext.Tipos.Remove(tipo);
                        //result = dbContext.SaveChanges() > 0;
                        dbContext.SaveChanges();

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            //return result;
        }

        public IEnumerable Get()
        {
            ICollection<Tipo> result = new List<Tipo>();

            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    result = dbContext.Tipos.ToList<Tipo>();

                }

            }
            catch (Exception e)
            {
                throw;
            }

            return result;
        }

        public Tipo GetByName(string nombre)
        {
            try
            {

                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    Tipo result = dbContext.Tipos.SingleOrDefault(t => t.Nombre == nombre);
                    return result;

                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public object GetDeXCentimetrosOMas(double miAlturaMinima)
        {
            throw new NotImplementedException();
        }

        public object GetMasBajasQueXCentimetros(double miAlturaMaxima)
        {
            throw new NotImplementedException();
        }

        public object GetPorAmbiente(string miAmbiente)
        {
            throw new NotImplementedException();
        }

        public void Insert(Tipo nuevoTipo)
        {
            Tipo tipo = new Tipo();
            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    tipo = dbContext.Tipos.SingleOrDefault<Tipo>(t => t.Nombre == nuevoTipo.Nombre);

                    if (tipo == null)
                    {
                        dbContext.Add<Tipo>(nuevoTipo);
                        //result = dbContext.SaveChanges() > 0;
                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                throw;
            }

            //return result;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Tipo tipo) //revisar por qué se genera doble en la bd
        {
            //bool result = false;
            try
            {

                using (LibreriaContext dbContext = new LibreriaContext())
                {

                    dbContext.Update<Tipo>(tipo);
                    //result = _dbContext.SaveChanges() > 0;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            //return result;
        }
    }
}
