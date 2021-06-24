using AppRegistroAspirantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppRegistroAspirantes.Controllers
{
    public class LocacionController : Controller
    {
        // GET: Locacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Paises()
        {
            List<PaisModel> paises = null;

            using (var bd = new RegistroAspirantesEntities())
            {
                paises = (from pais in bd.Paises
                          select new PaisModel
                          {
                              Id = pais.Id,
                              Nombre = pais.Nombre
                          }).ToList();
            }

            return Json(paises, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Localidades(int codigoPostal, int pais)
        {
            List<LocalidadModel> localidades = null;

            using (var bd = new RegistroAspirantesEntities())
            {
                localidades = (from localidad in bd.Localidades
                               where localidad.CodigoPostal == codigoPostal && localidad.IdPais == pais
                               select new LocalidadModel
                               {
                                   Id = localidad.Id,
                                   Nombre = localidad.Nombre,
                                   IdPais = localidad.IdPais,
                                   CodigoPostal = (int)localidad.CodigoPostal
                               }).ToList();
            }

            return Json(localidades, JsonRequestBehavior.AllowGet);
        }
    }
}