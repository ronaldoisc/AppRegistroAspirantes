using AppRegistroAspirantes.Filters;
using AppRegistroAspirantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppRegistroAspirantes.Controllers
{
    public class CampusController : Controller
    {
        // GET: Campus
      

        [Autorizacion(accion: "VER_CAMPUS")]

        public ActionResult Index()
        {
            List<CampusModel> campus = null;
            AdministradorModel admin = (AdministradorModel)HttpContext.Session["ADMINISTRADOR"];

            if (admin.IdCampus > 0)
            {
                using (var bd = new RegistroAspirantesEntities())
                {
                    campus = (from cmp in bd.Campus
                              where cmp.Id == admin.IdCampus
                              select new CampusModel
                              {
                                  Id = cmp.Id,
                                  Nombre = cmp.Nombre,
                                  Correo = cmp.Correo,
                                  Telefono = cmp.Telefono,
                                  IdLocalidad = cmp.IdLocalidad,
                                  Calle = cmp.Calle,
                                  NoExt = cmp.NoExt,
                                  NoInt = cmp.NoInt,
                                  Colonia = cmp.Colonia,
                                  UrlCampus = cmp.UrlCampus,
                                  NumAspirantes = cmp.NumAspirantes,
                                  IdBanco = cmp.IdBanco,
                                  NombreCuenta = cmp.NombreCuenta,
                                  NoConvenio = cmp.NoConvenio,
                                  ClabeInterbancaria = cmp.ClabeInterbancaria,
                              }).ToList();
                }

                ViewBag.campus = campus;
            }
            else
            {
                using (var bd = new RegistroAspirantesEntities())
                {
                    campus = (from cmp in bd.Campus
                              select new CampusModel
                              {
                                  Id = cmp.Id,
                                  Nombre = cmp.Nombre,
                                  Correo = cmp.Correo,
                                  Telefono = cmp.Telefono,
                                  IdLocalidad = cmp.IdLocalidad,
                                  Calle = cmp.Calle,
                                  NoExt = cmp.NoExt,
                                  NoInt = cmp.NoInt,
                                  Colonia = cmp.Colonia,
                                  UrlCampus = cmp.UrlCampus,
                                  NumAspirantes = cmp.NumAspirantes,
                                  IdBanco = cmp.IdBanco,
                                  NombreCuenta = cmp.NombreCuenta,
                                  NoConvenio = cmp.NoConvenio,
                                  ClabeInterbancaria = cmp.ClabeInterbancaria,
                              }).ToList();
                }

                ViewBag.campus = campus;
            }
            ViewBag.adminRol = admin.IdRol;
            return View();
        }

        [Autorizacion(accion: "CREAR_CAMPUS")]
        public ActionResult Crear()
        {
            return View();
        }

        [Autorizacion(accion: "CREAR_CAMPUS")]
        [HttpPost]
        public ActionResult Crear(CampusModel campusModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = ModelState.Values;
                return View();
            }
            else
            {
                using (var bd = new RegistroAspirantesEntities())
                {
                    Campus campus = new Campus
                    {
                        Nombre = campusModel.Nombre,
                        Correo = campusModel.Correo,
                        Telefono = campusModel.Telefono,
                        IdLocalidad = campusModel.IdLocalidad,
                        Calle = campusModel.Calle,
                        NoExt = campusModel.NoInt,
                        NoInt = campusModel.NoInt,
                        Colonia = campusModel.Colonia,
                        UrlCampus = campusModel.UrlCampus,
                        NumAspirantes = 0,
                        IdBanco = campusModel.IdBanco,
                        NombreCuenta = campusModel.NombreCuenta,
                        NoCuenta = campusModel.NoCuenta,
                        NoConvenio = campusModel.NoConvenio,
                        ClabeInterbancaria = campusModel.ClabeInterbancaria,
                    };

                    bd.Campus.Add(campus);
                    bd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
          
        }


        public ActionResult Ver(int id)
        {
            CampusModel campusModel = null;

            using (var bd = new RegistroAspirantesEntities())
            {
                Campus campus = bd.Campus.Find(id);
                campusModel = new CampusModel
                {
                    Nombre = campus.Nombre,
                    Correo = campus.Correo,
                    Telefono = campus.Telefono,
                    IdLocalidad = campus.IdLocalidad,
                    Calle = campus.Calle,
                    NoExt = campus.NoInt,
                    NoInt = campus.NoInt,
                    Colonia = campus.Colonia,
                    UrlCampus = campus.UrlCampus,
                    NumAspirantes = campus.NumAspirantes,
                    IdBanco = campus.IdBanco,
                    NombreCuenta = campus.NombreCuenta,
                    NoCuenta = campus.NoCuenta,
                    NoConvenio = campus.NoConvenio,
                    ClabeInterbancaria = campus.ClabeInterbancaria,
                    CodigoPostal = (int)bd.Localidades.Find(campus.IdLocalidad).CodigoPostal,
                    IdPais = bd.Localidades.Find(campus.IdLocalidad).IdPais,
                    Localidad = bd.Localidades.Find(campus.IdLocalidad).Nombre,
                    Banco = bd.Bancos.Find(campus.IdBanco).Nombre,
                };
            }

            return View(campusModel);
        }

        public ActionResult Actualizar(int id)
        {
            CampusModel campusModel = null;

            using (var bd = new RegistroAspirantesEntities())
            {
                Campus campus = bd.Campus.Find(id);
                campusModel = new CampusModel
                {
                    Nombre = campus.Nombre,
                    Correo = campus.Correo,
                    Telefono = campus.Telefono,
                    IdLocalidad = campus.IdLocalidad,
                    Calle = campus.Calle,
                    NoExt = campus.NoInt,
                    NoInt = campus.NoInt,
                    Colonia = campus.Colonia,
                    UrlCampus = campus.UrlCampus,
                    NumAspirantes = campus.NumAspirantes,
                    IdBanco = campus.IdBanco,
                    NombreCuenta = campus.NombreCuenta,
                    NoCuenta = campus.NoCuenta,
                    NoConvenio = campus.NoConvenio,
                    ClabeInterbancaria = campus.ClabeInterbancaria,
                    CodigoPostal = (int)bd.Localidades.Find(campus.IdLocalidad).CodigoPostal,
                    IdPais = bd.Localidades.Find(campus.IdLocalidad).IdPais
                };
            }

            return View(campusModel);
        }

        [HttpPost]
        public ActionResult Actualizar(CampusModel campusModel)
        {
            if (!ModelState.IsValid)
            {
                return View(campusModel);
            }
            else
            {
                using (var bd = new RegistroAspirantesEntities())
                {
                    Campus campus = bd.Campus.Find(campusModel.Id);
                    campus.Nombre = campusModel.Nombre;
                    campus.Correo = campusModel.Correo;
                    campus.Telefono = campusModel.Telefono;
                    campus.IdLocalidad = campusModel.IdLocalidad;
                    campus.Calle = campusModel.Calle;
                    campus.NoExt = campusModel.NoInt;
                    campus.NoInt = campusModel.NoInt;
                    campus.Colonia = campusModel.Colonia;
                    campus.UrlCampus = campusModel.UrlCampus;
                    campus.NumAspirantes = 0;
                    campus.IdBanco = campusModel.IdBanco;
                    campus.NombreCuenta = campusModel.NombreCuenta;
                    campus.NoCuenta = campusModel.NoCuenta;
                    campus.NoConvenio = campusModel.NoConvenio;
                    campus.ClabeInterbancaria = campusModel.ClabeInterbancaria;
                    bd.SaveChanges();

                }

                return RedirectToAction("Index");
            }
           
        }
    }
}