using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppRegistroAspirantes.Filters;
using AppRegistroAspirantes.Models;
namespace AppRegistroAspirantes.Controllers
{
    public class SolicitanteController : Controller
    {
        // GET: Solicitante
        public ActionResult Index()
        {
            return View();
        }

        List<CampusAsignadoModel> listacampus = null;
        public ActionResult getCampus(int IdCarrera)
        {


            using (var bd = new RegistroAspirantesEntities())
            {
                listacampus = (from campusCarrera in bd.CampusCarreras
                               join campus in bd.Campus
                               on campusCarrera.IdCampus
                               equals campus.Id

                               where campusCarrera.IdCarrera == IdCarrera
                               select new CampusAsignadoModel
                               {
                                  Nombre=campus.Nombre,
                                   Id=campus.Id
                                   
                                    

                               }).ToList();
            }

            return Json(listacampus, JsonRequestBehavior.AllowGet);
        }


        List<CarrerasModel> listaCarreras = null;
        public ActionResult Registrar()
        {
            ViewBag.listaGeneros = Helpers.Helpers.ObtenerGeneros();
            ViewBag.listaGradosEstudio = Helpers.Helpers.ObtenerGradosEstudio();

            using (var bd = new RegistroAspirantesEntities())
            {
                listaCarreras = (from carreras in bd.Carreras

                                 select new CarrerasModel
                                 {
                                     Id = carreras.Id,
                                     Nombre = carreras.Nombre,
                                     Descripcion = carreras.Descripcion,
                                     Imagen = carreras.Img


                                 }).ToList();


                var modelo = new SolicitanteModel();

                modelo.carreras = listaCarreras;

                return View(modelo);
            }
        }

        [HttpPost]
        public ActionResult Registrar(SolicitanteModel model)
        {

               if (!ModelState.IsValid)
               {
                ViewBag.listaGeneros = Helpers.Helpers.ObtenerGeneros();
                ViewBag.listaGradosEstudio = Helpers.Helpers.ObtenerGradosEstudio();
                return View(model);
                }
            
                using (var bd = new RegistroAspirantesEntities())
                {
                    Solicitantes oSolicitante = new Solicitantes();

                oSolicitante.Nombre = model.Nombre;
                oSolicitante.ApellidoPaterno = model.ApellidoPaterno;
                oSolicitante.ApellidoMaterno = model.ApellidoMaterno;
                oSolicitante.IdGenero = model.IdGenero;
                oSolicitante.FechaNacimiento = model.FechaNacimiento;
                oSolicitante.CURP = model.CURP;
                oSolicitante.Foto = Helpers.Helpers.ImgToByteArray(model.Imagen);
                oSolicitante.IdPais = model.IdPais;
                oSolicitante.IdLocalidad = model.IdLocalidad;
                oSolicitante.Correo = model.Correo;
                oSolicitante.TelefonoFijo = model.TelefonoFijo;
                oSolicitante.TelefonoCelular = model.TelefonoCelular;
                oSolicitante.IdGradoEstudios = model.IdGradoEstudios;
                oSolicitante.EscuelaProcedencia = model.EscuelaProcedencia;
                oSolicitante.Identificacion = Helpers.Helpers.PDFToByteArray(model.INE);
                oSolicitante.CertificadoBachillerato = Helpers.Helpers.PDFToByteArray(model.Certificado);
                oSolicitante.IdCarrera = model.IdCarrera;
                oSolicitante.IdCampus = model.IdCampus;
                oSolicitante.EstatusPago = false;
                bd.Solicitantes.Add(oSolicitante);
                bd.SaveChanges();

                
            }


            return RedirectToAction("Index");
        }


        [Autorizacion(accion: "VER_SOLICITANTES")]
        public ActionResult ListaSolicitantes()
        {
            List<SolicitanteModel> solicitantes = null;
            AdministradorModel admin = (AdministradorModel)HttpContext.Session["ADMINISTRADOR"];

            using (var bd = new RegistroAspirantesEntities())
            {
                solicitantes = (from s in bd.Solicitantes
                                join genero in bd.Generos on s.IdGenero equals genero.Id
                                join pais in bd.Paises on s.IdPais equals pais.Id
                                join localidad in bd.Localidades on s.IdLocalidad equals localidad.Id
                                join gradoEstudios in bd.GradosEstudio on s.IdGradoEstudios equals gradoEstudios.Id
                                join campus in bd.Campus on s.IdCampus equals campus.Id
                                join carrera in bd.Carreras on s.IdCarrera equals carrera.Id
                                select new SolicitanteModel
                          {
                              Id = s.Id,
                              Nombre = s.Nombre,
                              ApellidoPaterno = s.ApellidoPaterno,
                              ApellidoMaterno = s.ApellidoMaterno,
                              IdGenero = s.IdGenero,
                              Genero = s.Generos.Descripcion,
                              FechaNacimiento = s.FechaNacimiento,
                              CURP = s.CURP,
                              Foto = s.Foto,
                              IdPais = s.IdPais,
                              Pais = s.Paises.Nombre,
                              IdLocalidad = s.IdLocalidad,
                              Localidad = s.Localidades.Nombre,
                              Correo = s.Correo,
                              TelefonoFijo = s.TelefonoFijo,
                              TelefonoCelular = s.TelefonoCelular,
                              IdGradoEstudios = s.IdGradoEstudios,
                              GradoEstudios = s.GradosEstudio.Descripcion,
                              EscuelaProcedencia = s.EscuelaProcedencia,
                              IdCampus = s.IdCampus,
                              CampusAsignado = s.Campus.Nombre,
                              IdCarrera = s.IdCarrera,
                              Carrera = s.Carreras.Nombre,
                              Identificacion = s.Identificacion,
                              CertificadoBachillerato = s.CertificadoBachillerato,
                              EstatusPago = s.EstatusPago
                          }).ToList();
            }

            ViewBag.solicitantes = solicitantes;

            ViewBag.adminRol = admin.IdRol;
            return View();
        }

        [Autorizacion(accion: "VER_SOLICITANTES")]
        public ActionResult Ver(int id)
        {
            SolicitanteModel solicitanteModel = null;

            using (var bd = new RegistroAspirantesEntities())
            {
                Solicitantes s = bd.Solicitantes.Find(id);
                solicitanteModel = new SolicitanteModel
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    ApellidoPaterno = s.ApellidoPaterno,
                    ApellidoMaterno = s.ApellidoMaterno,
                    IdGenero = s.IdGenero,
                    Genero = s.Generos.Descripcion,
                    FechaNacimiento = s.FechaNacimiento,
                    CURP = s.CURP,
                    Foto = s.Foto,
                    IdPais = s.IdPais,
                    Pais = s.Paises.Nombre,
                    IdLocalidad = s.IdLocalidad,
                    Localidad = s.Localidades.Nombre,
                    Correo = s.Correo,
                    TelefonoFijo = s.TelefonoFijo,
                    TelefonoCelular = s.TelefonoCelular,
                    IdGradoEstudios = s.IdGradoEstudios,
                    GradoEstudios = s.GradosEstudio.Descripcion,
                    EscuelaProcedencia = s.EscuelaProcedencia,
                    IdCampus = s.IdCampus,
                    CampusAsignado = s.Campus.Nombre,
                    IdCarrera = s.IdCarrera,
                    Carrera = s.Carreras.Nombre,
                    Identificacion = s.Identificacion,
                    CertificadoBachillerato = s.CertificadoBachillerato,
                    EstatusPago = s.EstatusPago
                };
            }

            return View(solicitanteModel);
        }

        public FileContentResult GetImg(int id)//convertimos el arrreglo de bytes a imagen para mostrarla
        {
            using (var bd = new RegistroAspirantesEntities())
            {
                byte[] byteArray = bd.Solicitantes.Find(id).Foto;
                if (byteArray != null)
                {
                    return new FileContentResult(byteArray, "image/jpeg");
                }
                else
                {
                    return null;
                }
            }

        }

        public FileContentResult GetImgCarreras(int id)//convertimos el arrreglo de bytes a imagen para mostrarla
        {
            using (var bd = new RegistroAspirantesEntities())
            {
                byte[] byteArray = bd.Carreras.Find(id).Img;
                if (byteArray != null)
                {
                    return new FileContentResult(byteArray, "image/jpeg");
                }
                else
                {
                    return null;
                }
            }

        }
    }
}