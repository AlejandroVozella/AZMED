//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersimosMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Facturas
    {
        public int id { get; set; }
        [Required]
        public Nullable<decimal> Monto { get; set; }
        [Required]
        public Nullable<int> Paciente { get; set; }
    
        public virtual Pacientes Pacientes { get; set; }
    }
}
