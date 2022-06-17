using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Dominio;
using ObligatorioP3.Models;
using Microsoft.AspNetCore.Http;

namespace ObligatorioP3.Controllers
{
    public class TipoController : Controller
    {
        RepositorioTipo repositorio = new RepositorioTipo(new Connection());
        Sistema unS = Sistema.Instancia;

        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                ViewBag.Mensaje = "No hay Tipos de Planta disponibles";
                return View(repositorio.Get());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Alta()
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {

                return View(new Tipo());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(Tipo unTipo)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {

                if (unTipo.IsValid())
                {
                    if (unS.ValidarAlfabeticoTipo(unTipo) && unS.ValidarDescripcion(unTipo))
                    {
                        try
                        {
                            repositorio.Insert(unTipo);
                            return RedirectToAction(nameof(Index));
                        }
                        catch (Exception e)
                        {
                            var ex = e.Message;
                            if (ex.Contains("duplicate key"))
                            {
                                return RedirectToAction("ErrorAltaTipo", "Tipo");
                            }
                        }
                    }

                    return RedirectToAction("ErrorAltaTipo", "Tipo");

                }
                else
                {
                    return View(new Models.ErrorViewModel());
                }

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Delete(string nombre)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                Tipo unTipo = repositorio.GetByName(nombre);
                return View(unTipo);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Tipo unTipo, IFormCollection collection)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                try
                {
                    repositorio.Delete(unTipo.Nombre);
                    return RedirectToAction(nameof(Index));
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

        public ActionResult Edit(string nombre)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                Tipo unTipo = repositorio.GetByName(nombre);
                return View(unTipo);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tipo unTipo)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {

                if (unTipo.IsValid())
                {
                    try
                    {
                        repositorio.Update(unTipo);
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View("Error", new ErrorViewModel());
                    }
                }
                else
                {
                    return View(new Models.ErrorViewModel());
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult BuscarTipo(string nomTipo)
        {
            if (HttpContext.Session.GetString("Mail") != null)
            {
                
                try
                {
                    ViewBag.Tipo = repositorio.GetByName(nomTipo);
                    
                }
                catch
                {
                    ViewBag.Mensaje = "No hay un tipos de nombre  " + nomTipo + ".";
                    
                }

                return View();


            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult ErrorAltaTipo()
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



    }
}
