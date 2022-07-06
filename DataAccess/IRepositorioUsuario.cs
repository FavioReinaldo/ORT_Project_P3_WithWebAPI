using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Dominio;

namespace DataAccess
{
    interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        bool ValidarUsuario(string mail, string password);
    }
}
