using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EF
{
    public class RepositorioCompra : IRepositorioCompra
    {
        public void Delete(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable Get()
        {
            ICollection<Compra> result = new List<Compra>();

            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    result = dbContext.Compras.Include(c => c.ItemCompras).ThenInclude(p => p.PlantaComprada).ToList<Compra>();
                }

            }
            catch (Exception e)
            {
                throw;
            }

            return result;
        }

        public Compra GetByName(string nombre)
        {
            throw new NotImplementedException();
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

        public void Insert(Compra obj)
        {
            throw new NotImplementedException();
        }

        public bool Insert2(Compra obj)
        {
            bool result = false;
            if (obj == null)
            {
                return result;
            }

            try
            {

                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    foreach (var item in obj.ItemCompras)
                    {
                        dbContext.Entry(item.PlantaComprada).State = EntityState.Unchanged;
                    }

                    dbContext.Compras.Add(obj);
                    result = dbContext.SaveChanges() > 0;
                }
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Compra obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetByTipo(string nombreTipo)
        {
            ICollection<Compra> compras = new List<Compra>();
            ICollection<Compra> result = new List<Compra>();

            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    compras = dbContext.Compras.ToList<Compra>();
                    foreach (var item in compras)
                    {
                        foreach (var item2 in item.ItemCompras)
                        {
                            if (item2.PlantaComprada.NombreTipo == nombreTipo)
                            {
                                if (!result.Contains(item))
                                {
                                    result.Add(item);
                                }
                            }
                        }
                    }
                }
                return result;

            }
            catch (Exception e)
            {
                throw;
            }


        }

        public int GetCantidadPlantas(string nombreTipo)
        {
            ICollection<Compra> compras = new List<Compra>();
            int result = 0;

            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    compras = dbContext.Compras.ToList<Compra>();
                    foreach (var item in compras)
                    {
                        foreach (var item2 in item.ItemCompras)
                        {
                            if (item2.PlantaComprada.NombreTipo == nombreTipo)
                            {

                                result += item2.Cantidad;
                                
                            }
                        }
                    }
                }
                return result;

            }
            catch (Exception e)
            {
                throw;
            }


        }
    }
}
