using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppRegistroAspirantes.Models
{
    public class UsuarioModel
    {
        public short Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; }
        [Required]
        [Display(Name = "Apellido materno")]
        public string ApellidoMaterno { get; set; }
        [Required]
        [Display(Name = "Correo")]
        public string Correo { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]{7}", ErrorMessage = "El campo de cumplir con el formato 000-0000000")]
        [Display(Name = "Teléfono fijo")]
        public string TelefonoFijo { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]{7}", ErrorMessage = "El campo de cumplir con el formato 000-0000000")]
        [Display(Name = "Teléfono celular")]
        public string TelefonoCelular { get; set; }
        [Required]
        [Display(Name = "Campus")]
        public int IdCampus { get; set; }
        public byte IdRol { get; set; }

        //Propiedades adcionales
        public string Campus { get; set; }
    }
}