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
    
    public partial class AccionesAdministradores
    {
        public int Id { get; set; }
        public Nullable<short> IdAdministrador { get; set; }
        public Nullable<int> IdAccion { get; set; }
    
        public virtual Acciones Acciones { get; set; }
        public virtual Administradores Administradores { get; set; }
    }
}
