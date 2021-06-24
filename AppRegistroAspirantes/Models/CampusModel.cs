using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppRegistroAspirantes.Models
{
    public class CampusModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Correo")]
        [Required]
        public string Correo { get; set; }
        [Display(Name = "Teléfono")]
        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]{7}", ErrorMessage = "El campo de cumplir con el formato 000-0000000")]
        public string Telefono { get; set; }
        [Display(Name = "Localidad")]
        [Required]
        public int IdLocalidad { get; set; }
        [Display(Name = "Calle")]
        [Required]
        public string Calle { get; set; }
        [Display(Name = "No. Exterior")]
        [Required]
        public string NoExt { get; set; }
        [Display(Name = "No. Interior")]
        [Required]
        public string NoInt { get; set; }
        [Display(Name = "Colonia")]
        [Required]
        public string Colonia { get; set; }
        [Display(Name = "Sitio web")]
        [Required]
        [DataType(DataType.Url)]
        public string UrlCampus { get; set; }
        public int NumAspirantes { get; set; }
        [Display(Name = "Banco")]
        [Required]
        public int IdBanco { get; set; }
        [Display(Name = "Nombre de cuenta")]
        [Required]
        public string NombreCuenta { get; set; }
        [Display(Name = "Número de cuenta")]
        [Required]
        public string NoCuenta { get; set; }
        [Display(Name = "No. de convenio")]
        [Required]
        public string NoConvenio { get; set; }
        [Display(Name = "Clave interbancaria")]
        [Required]
        public string ClabeInterbancaria { get; set; }

        public int IdPais { get; set; }
        [Display(Name = "Código Postal")]
        [Required]
        public int CodigoPostal { get; set; }

        public string Localidad { get; set; }
        public string Banco { get; set; }
        public string Pais { get; set; }
    }
}