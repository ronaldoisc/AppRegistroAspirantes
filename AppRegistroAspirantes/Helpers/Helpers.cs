using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppRegistroAspirantes.Models;
namespace AppRegistroAspirantes.Helpers
{
	public class Helpers
	{
        public static List<SelectListItem> ObtenerGeneros()
        {
            List<SelectListItem> listaGeneros = null;

            using (var bd = new RegistroAspirantesEntities())
            {
                listaGeneros = (from genero in bd.Generos
                                select new SelectListItem
                                {
                                    Text = genero.Descripcion,
                                    Value = genero.Id

                                }).ToList();
                listaGeneros.Insert(0, new SelectListItem { Text = "--Seleccione su genero--", Value = "" });
            }

            return listaGeneros;
        }
        public static List<SelectListItem> ObtenerGradosEstudio()
        {
            List<SelectListItem> listaGradosEstudio = null;
            using (var bd = new RegistroAspirantesEntities())
            {
                listaGradosEstudio = (from grados in bd.GradosEstudio
                                      select new SelectListItem
                                      {
                                          Text = grados.Descripcion,
                                          Value = grados.Id.ToString()

                                      }).ToList();
                listaGradosEstudio.Insert(0, new SelectListItem { Text = "--Seleccione su último grado de estudios--", Value = "" });
            }

            return listaGradosEstudio;
        }

        public static List<SelectListItem> ObtenerPaises()
        {
            List<SelectListItem> paises = null;

            using (var bd = new RegistroAspirantesEntities())
            {
                paises = (from pais in bd.Paises
                          select new SelectListItem
                          {
                              Value = pais.Id.ToString(),
                              Text = pais.Nombre
                          }).ToList();
            }

            return paises;
        }

        public static List<SelectListItem> ObtenerLocalidades(int codigoPostal, int pais)
        {

            List<SelectListItem> localidades = null;

            using (var bd = new RegistroAspirantesEntities())
            {
                localidades = (from localidad in bd.Localidades
                               where localidad.CodigoPostal == codigoPostal && localidad.IdPais == pais
                               select new SelectListItem
                               {
                                   Value = localidad.Id.ToString(),
                                   Text = localidad.Nombre
                               }).ToList();
            }

            localidades.Insert(0, new SelectListItem { Value = "", Text = "--Seleccione una localidad--" });

            return localidades;
        }

        public static List<SelectListItem> ObtenerBancos()
        {
            List<SelectListItem> bancos = null;

            using (var bd = new RegistroAspirantesEntities())
            {
                bancos = (from banco in bd.Bancos
                          select new SelectListItem
                          {
                              Value = banco.Id.ToString(),
                              Text = banco.Nombre
                          }).ToList();
            }

            return bancos;
        }

        public static byte[] ImgToByteArray(HttpPostedFileBase img)
        {

            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
            var extension = Path.GetExtension(img.FileName);
            byte[] imgData = null;

            if (allowedExtensions.Contains(extension.ToLower()) && img.ContentLength < 2000000)
            {
                using (var binaryReader = new BinaryReader(img.InputStream))
                {
                    imgData = binaryReader.ReadBytes(img.ContentLength);
                    binaryReader.Close();
                }
                return imgData;
            }
            else
            {
                return null;

            }


        }

        public static byte[] PDFToByteArray(HttpPostedFileBase pdf)
        {


            byte[] pdfData = null;

            if (pdf.ContentLength < 2000000)
            {
                using (var binaryReader = new BinaryReader(pdf.InputStream))
                {
                    pdfData = binaryReader.ReadBytes(pdf.ContentLength);

                }

                return pdfData;
            }
            else
            {
                return null;
            }
        }
    }
}