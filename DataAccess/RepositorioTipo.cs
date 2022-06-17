using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using Dominio;
using System.Data.SqlClient;

namespace DataAccess
{
    public class RepositorioTipo : IRepositorioTipo
    {
        private IDbConnection _con;

        
        public RepositorioTipo(IDbConnection connection)
        {
            this._con = connection;
        }

        public void Delete(string nombre)
        {
            IDbCommand command = _con.CreateCommand();
            command.CommandText = @"DELETE Tipo WHERE Nombre = @Nombre";
            command.Parameters.Add(new SqlParameter("@Nombre", nombre));
            try
            {
                _con.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas == 0)
                    throw new Exception();


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
        }

        public IEnumerable Get()
        {
            ICollection<Tipo> result = new List<Tipo>();

             IDbCommand command = _con.CreateCommand();
            command.CommandText = "Select * FROM dbo.Tipo";
            try
            {
                _con.Open();
                using IDataReader reader = command.ExecuteReader();
                Tipo unTipo = null;
                
                while (reader.Read())
                {
                    Tipo tipo = new Tipo();
                    unTipo = tipo;
                    unTipo.Nombre = (string)reader["Nombre"];
                    unTipo.Descripcion = (string)reader["Descripcion"];

                    result.Add(unTipo);
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
            }
            return result;
        }

        public Tipo GetByName(string nombre)
        {
            Tipo unTipo = null;
            IDbCommand command = _con.CreateCommand();
            command.CommandText = @"SELECT * FROM dbo.Tipo WHERE Nombre = @Nombre";
            command.Parameters.Add(new SqlParameter("@Nombre", nombre));
            try
            {
                _con.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    Tipo tipo = new Tipo();
                    unTipo = tipo;
                    unTipo.Nombre = (string)reader["Nombre"];
                    unTipo.Descripcion = (string)reader["Descripcion"];
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
            return unTipo;
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

        public void Insert(Tipo obj)
        {
            IDbCommand command = _con.CreateCommand();
            command.CommandText = @"INSERT INTO Tipo(Nombre, Descripcion) VALUES(@Nombre, @Descripcion)";
            command.Parameters.Add(new SqlParameter("@Nombre", obj.Nombre.Trim()));
            command.Parameters.Add(new SqlParameter("@Descripcion", obj.Descripcion.Trim()));


            try
            {
                _con.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas == 0)
                    throw new Exception();
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
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Tipo obj)
        {
            IDbCommand command = _con.CreateCommand();
            command.CommandText = @"UPDATE Tipo SET Descripcion = @Descripcion WHERE  Nombre = @Nombre";
            command.Parameters.Add(new SqlParameter("@Nombre", obj.Nombre));
            command.Parameters.Add(new SqlParameter("@Descripcion", obj.Descripcion));
           
            try
            {
                _con.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas == 0)
                    throw new Exception();
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
        }
    }
}
