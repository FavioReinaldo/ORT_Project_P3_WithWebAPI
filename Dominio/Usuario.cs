using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        #region Atributos    
        public string Mail { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructores
        //*************** METODO CONSTRUCTOR DE USUARIO ***************
        public Usuario(string mail, string password)
        {
            this.Mail = mail;
            this.Password = password;
        }
        public Usuario()
        {
            //Constructor por defecto
        }
        #endregion



        #region Metodo Validar Password
        public bool ValidarPassword(string miPassword)
        {
            bool passwordValido = false;
            bool hayDigito = false;
            bool hayMayuscula = false;
            bool hayMinuscula = false;
            int i = 0;

            if (miPassword.Length >= 6)
            {
                //verificación de mayúscula, minúscula y dígito
                while (!passwordValido && i < miPassword.Length)
                {
                    Char Caracter = miPassword[i];
                    if (Char.IsUpper(Caracter))
                    { hayMayuscula = true; }
                    if (Char.IsDigit(Caracter))
                    { hayDigito = true; }
                    if (Char.IsLower(Caracter))
                    { hayMinuscula = true; }

                    if (hayMinuscula && hayMayuscula && hayDigito)
                    { passwordValido = true; }

                    i++;
                }
            }

            return passwordValido;
        }
        #endregion

    }
}
