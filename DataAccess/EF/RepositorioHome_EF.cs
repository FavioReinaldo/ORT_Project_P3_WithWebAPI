using DataAccess.EF;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class RepositorioHome_EF
    {
        public RepositorioHome_EF() { }





        public string PrecargaUsuarios()
        {
            try
            {

                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    string mensaje = "";
                    if (validarUsuarioRepetido("Usuario1@mail.com") || validarUsuarioRepetido("Usuario2@mail.com") || validarUsuarioRepetido("Usuario3@mail.com"))
                    {

                        return mensaje = "Ya existen usuarios precargados";

                    }
                    else
                    {


                        Usuario usu1 = new Usuario();
                        usu1.Mail = "Usuario1@mail.com";
                        usu1.Password = "Usuario1";

                        Usuario usu2 = new Usuario();
                        usu2.Mail = "Usuario2@mail.com";
                        usu2.Password = "Usuario2";

                        Usuario usu3 = new Usuario();
                        usu3.Mail = "Usuario3@mail.com";
                        usu3.Password = "Usuario3";


                        dbContext.Usuarios.Add(usu1);
                        dbContext.Usuarios.Add(usu2);
                        dbContext.Usuarios.Add(usu3);
                        dbContext.SaveChanges();

                        return mensaje = "Precarga realizada correctamente";

                    }
                }

            }catch(Exception e)
            {
                throw;
            }
        }


        public bool validarUsuarioRepetido(string mail)
        {
            bool existe = false;
            try
            {

                using (LibreriaContext dbContext = new LibreriaContext())
                {
                    Usuario usu = new Usuario();
                    usu = dbContext.Usuarios.SingleOrDefault(u => u.Mail == mail);

                    if (usu != null)
                    {
                        existe = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return existe;
        }



    }
}
