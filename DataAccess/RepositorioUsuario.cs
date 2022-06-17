using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        IDbConnection _conn = null;
        public RepositorioUsuario(IDbConnection connection)
        {
            _conn = connection;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable Get()
        {
            throw new NotImplementedException();
        }

        /*public IEnumerable GetUsuario(string mail, string password)
        {
            ICollection<Usuario> result = new List<Usuario>();
            IDbCommand command = _conn.CreateCommand();
            command.CommandText = $"Select * From dbo.Usuario where Mail = {mail} AND Password = {password}";

            try
            {
                _conn.Open();
                using IDataReader reader = command.ExecuteReader();
                Usuario usuario = null;
                while (reader.Read())
                {
                    Usuario unUsuario = new Usuario();
                    usuario = unUsuario;
                    usuario.Mail = (string)reader["Mail"];
                    usuario.Password = (string)reader["Password"];
                    result.Add(usuario);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                if (_conn != null)
                {
                    _conn.Close();
                    _conn.Dispose();
                }

            }
            return result;
        }*/
        public bool ValidarUsuario(string mail, string password)
        {
            bool resultado = false;
            Usuario miUsuario = new Usuario();
            IDbCommand command = _conn.CreateCommand();
            command.CommandText = $"Select * From dbo.Usuario where mail = '{mail}' AND password = '{password}'";

            try
            {
                _conn.Open();
                using IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    miUsuario.Mail = (string)reader["mail"];
                    miUsuario.Password = (string)reader["password"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                if (_conn != null)
                {
                    _conn.Close();
                    _conn.Dispose();
                }

            }
            if (miUsuario.Mail != null && miUsuario.Password != null)
            {
                resultado = true;
            }
            return resultado;
        }
        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public object GetMasBajasQueXCentimetros(double miAlturaMaxima)
        {
            throw new NotImplementedException();
        }

        public object GetDeXCentimetrosOMas(double miAlturaMinima)
        {
            throw new NotImplementedException();
        }

        public object GetPorAmbiente(string miAmbiente)
        {
            throw new NotImplementedException();
        }

        public Usuario GetByName(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Delete(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
