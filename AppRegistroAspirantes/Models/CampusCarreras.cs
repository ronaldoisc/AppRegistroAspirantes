//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppRegistroAspirantes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CampusCarreras
    {
        public int Id { get; set; }
        public int IdCampus { get; set; }
        public int IdCarrera { get; set; }
    
        public virtual Campus Campus { get; set; }
        public virtual Carreras Carreras { get; set; }
    }
}