using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                    oSolicitante.IdCampus = 1;
                    oSolicitante.EstatusPago = false;
                    bd.Solicitantes.Add(oSolicitante);
                    bd.SaveChanges();

                
            }


            return RedirectToAction("Index");
        }





        public FileContentResult GetImg(int id)//convertimos el arrreglo de bytes a imagen para mostrarla
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