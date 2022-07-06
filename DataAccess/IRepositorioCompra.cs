using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EF
{
    public interface IRepositorioCompra : IRepositorio<Compra>
    {
        bool Insert2(Compra obj);
    }
}
