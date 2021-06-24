using AppRegistroAspirantes.Filters;
using AppRegistroAspirantes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppRegistroAspirantes.Controllers
{
    public class OfertaEducativaController : Controller
    {
        // GET: OfertaEducativa
       
        [Autorizacion(accion: "VER_CARRERAS")]
        public ActionResult Index()
        {
            List<CarrerasModel> listaCarreras = null;

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
            }

            ViewBag.listaCarreras = listaCarreras;
            return View();
        }

        // GET: Registro
        [Autorizacion(accion: "CREAR_CARRERAS")]
        public ActionResult Crear()
        {
            return View();
        }

        [Autorizacion(accion: "CREAR_CARRERAS")]
        [HttpPost]
        public ActionResult Crear(NuevaCarreraModel carrerasModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carrerasModel);
            }
            else
            {
                using (var bd = new RegistroAspirantesEntities())
                {
                    Carreras carrera = new Carreras();
                    carrera.Nombre = carrerasModel.Nombre;
                    carrera.Descripcion = carrerasModel.Descripcion;
                    carrera.Img = ImgToByteArray(carrerasModel.Imagen);

                    bd.Carreras.Add(carrera);

                    bd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }

        private static byte[] ImgToByteArray(HttpPostedFileBase img)
        {
            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
            var extensions = Path.GetExtension(img.FileName);
            byte[] imgData = null;

            if (allowedExtensions.Contains(extensions.ToLower()) && img.ContentLength < 2000000)
            {
                using (var binaryReader = new BinaryReader(img.InputStream))
                {
                    imgData = binaryReader.ReadBytes(img.ContentLength);
                }
                return imgData;
            }
            else
            {
                return null;
            }
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