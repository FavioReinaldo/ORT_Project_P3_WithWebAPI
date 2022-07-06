using Dominio;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObligatorioP3.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DataAccess.EF;

namespace ObligatorioP3.Controllers
{
    public class PlantaController : Controller
    {
        RepositorioPlanta_EF repositorio_ef = new RepositorioPlanta_EF();
        RepositorioTipo_EF repositorio_efT = new RepositorioTipo_EF();

        RepositorioPlanta repositorio = new RepositorioPlanta(new Connection());
        RepositorioTipo repositorio1 = new RepositorioTipo(new Connection());
        RepositorioFichasCuidados repositorio2 = new RepositorioFichasCuidados(new Connection());

        //private readonly IRepositorioPlanta _repoPlanta;

       /*
        public PlantaController(IRepositorioPlanta repoAutor)
        {
            _repoPlanta = repoAutor;
        }
       */


        private IWebHostEnvironment _environment;
        public PlantaController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Alta()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                ViewBag.Tipos = repositorio_efT.Get();
                return View(new Planta());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(Planta unaPlanta, IFormFile imagen)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                if (unaPlanta.IsValid())
                {
                    try
                    {
                        GuardarImagen(imagen, unaPlanta);
                        //repositorio.Insert(unaPlanta);

                        //_repoPlanta.Insert(unaPlanta);
                        repositorio_ef.Insert(unaPlanta);
                        return RedirectToAction(nameof(ListarPlanta));
                    }
                    catch
                    {
                        return View("Error", new ErrorViewModel());
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Error en los campos ingresados";
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        private bool GuardarImagen(IFormFile imagen, Planta unaPlanta)
        {

            if (imagen == null || unaPlanta == null)
                return false;

            string rutaFisicaWwwRoot = _environment.WebRootPath;

            string nombreImagen = imagen.FileName;
            string rutaFisicaFoto = Path.Combine
            (rutaFisicaWwwRoot, "imagenes", "fotos", nombreImagen);

            try
            {

                using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                {

                    imagen.CopyTo(f);
                }

                unaPlanta.FotoPlanta = nombreImagen;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IActionResult VisualisarImagen(string nombre)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                try
                {
                    Planta unaPlanta = repositorio.GetByName(nombre);
                    return View(unaPlanta);
                }
                catch
                {
                    return View("Error", new Models.ErrorViewModel());
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public IActionResult ListarPlanta()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                try
                {
                    ViewBag.Mensaje = "No hay Plantas disponibles";
                    return View(repositorio_ef.Get());
                }
                catch
                {
                    return View("Error", new Models.ErrorViewModel());
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult FichaCuidados(string nombre)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                try
                {
                    FichaCuidados unaFicha = repositorio2.GetByName(nombre);
                    return View(unaFicha);
                }
                catch
                {
                    ViewBag.Mensaje = "Esta planta no tiene Ficha de cuidados.";
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult ListarPlantaMasBajaQueXCentimetrosIndex()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult ListarPlantaMasBajaQueXCentimetros(int miAlturaMaxima)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {

                if (miAlturaMaxima > 0)
                {
                    try
                    {

                        return View(repositorio_ef.GetMasBajasQueXCentimetros(miAlturaMaxima));

                    }
                    catch
                    {
                        ViewBag.Mensaje = "No hay plantas para mostrar que cumplan con el filtro";
                        return View();

                    }

                }
                ViewBag.Mensaje = "Los datos ingresados no son correctos";
                return View("ListarPlanta");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }


        public IActionResult ListarPlantaDeXCentimetrosOMasIndex()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult ListarPlantaDeXCentimetrosOMas(int miAlturaMinima)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {

                if (miAlturaMinima > 0)
                {
                    try
                    {
                        
                        return View(repositorio_ef.GetDeXCentimetrosOMas(miAlturaMinima));

                    }
                    catch
                    {
                        ViewBag.Mensaje = "No hay plantas para mostrar que cumplan con el filtro";
                        return View();
                    }

                }
                ViewBag.Mensaje = "Los datos ingresados no son correctos";
                return View("ListarPlanta");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public IActionResult ListarPlantaPorAmbienteIndex()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public IActionResult ListarPlantaPorAmbiente(string miAmbiente)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {

                if (miAmbiente != null && miAmbiente != "")
                {
                    try
                    {
                        return View(repositorio_ef.GetPorAmbiente(miAmbiente));

                    }
                    catch
                    {
                        ViewBag.Mensaje = "No hay plantas para mostrar que cumplan con el filtro";
                        return View();
                    }

                }
                ViewBag.Mensaje = "Los datos ingresados no son correctos";
                return View("ListarPlanta");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public IActionResult ListarPlantaPorTipoIndex()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                try
                {
                    ViewBag.Tipos = repositorio_efT.Get();
                    return View();

                }
                catch
                {
                    return View("Error", new Models.ErrorViewModel());
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult ListarPlantaPorTipo(string NombreTipo)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {

                if (NombreTipo != null && NombreTipo != "")
                {
                    try
                    {
                        return View(repositorio_ef.GetPorTipo(NombreTipo));

                    }
                    catch
                    {
                        ViewBag.Mensaje = "No hay plantas para mostrar que cumplan con el filtro";
                        return View();

                    }

                }
                ViewBag.Mensaje = "Los datos ingresados no son correctos";
                return View("ListarPlanta");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult ListarPlantaPorTextoIndex()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult ListarPlantaPorTexto(string miTexto)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                try
                {
                    return View(repositorio_ef.GetPorTexto(miTexto));

                }
                catch
                {
                    ViewBag.Mensaje = "No hay plantas para mostrar que cumplan con el filtro";
                    return View();

                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }



    }
}
