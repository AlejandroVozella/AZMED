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

    public partial class Turnos
    {
        public int id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public Nullable<int> IdPaciente { get; set; }
        [Required]
        public Nullable<int> idProfesional { get; set; }
        [Required]
        public Nullable<System.DateTime> Fecha { get; set; }
        [Required]

        public virtual Pacientes Pacientes { get; set; }
        [Required]
        public virtual Profesionales Profesionales { get; set; }
    }
}
