using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class RepositorioFichasCuidados : IRepositorioFichaCuidados
    {

        private IDbConnection _con;


        public RepositorioFichasCuidados(IDbConnection connection)
        {
            this._con = connection;
        }

        public void Delete(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable Get()
        {
            throw new NotImplementedException();
        }

        public FichaCuidados GetByName(string nombre)
        {
            FichaCuidados unaFicha = null;
            IDbCommand command = _con.CreateCommand();
            command.CommandText = @"SELECT * FROM FichaCuidados WHERE NombreCientifico = @NombreCientifico";
            command.Parameters.Add(new SqlParameter("@NombreCientifico", nombre));
            try
            {
                _con.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    FichaCuidados ficha = new FichaCuidados();
                    unaFicha = ficha;
                    unaFicha.FrecuenciaRiego = (string)reader["FrecuenciaRiego"];
                    unaFicha.Illuminacion = (string)reader["Illuminacion"];
                    unaFicha.Temperatura = (int)reader["Temperatura"];
                }




            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _con.Close();
                _con.Dispose();
                command.Dispose();
            }
            return unaFicha;
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

        

        public void Insert(FichaCuidados obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(FichaCuidados obj)
        {
            throw new NotImplementedException();
        }

       

        FichaCuidados IRepositorio<FichaCuidados>.GetByName(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
