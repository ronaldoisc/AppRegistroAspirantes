using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppRegistroAspirantes.Models
{
    public class NuevaCarreraModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la Carrera")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Descripción de la Carrera")]
        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Imagen")]
        [Required]
        public HttpPostedFileBase Imagen { get; set; }
    }
}