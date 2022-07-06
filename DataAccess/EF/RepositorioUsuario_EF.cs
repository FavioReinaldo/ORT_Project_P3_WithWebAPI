using DataAccess.EF;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class RepositorioUsuario_EF
    {
        public RepositorioUsuario_EF() { }


        public bool ValidarUsuario(string mail, string password)
        {
            bool resultado = false;
            Usuario miUsuario = new Usuario();

            try
            {
                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    miUsuario = dbContext.Usuarios.SingleOrDefault(u => u.Mail == mail && u.Password == password);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            if (miUsuario != null)
            {
                if (miUsuario.Mail != null && miUsuario.Password != null)
                {
                    resultado = true;
                }

            }
            return resultado;
        }







    }
}
