using DataAccess.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioP3.Controllers
{
    public class CompraController : Controller
    {

        RepositorioCompra repositorio = new RepositorioCompra();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListarComprasTipo(string nombreTipo)
        {
            if (nombreTipo != null && nombreTipo != "")
            {

                try
                {
                    ViewBag.Cantidad = repositorio.GetCantidadPlantas(nombreTipo);
                    return View(repositorio.GetByTipo(nombreTipo));
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            ViewBag.Mensaje = "Los datos no son correctos";
            return View();


        }
    }
}
