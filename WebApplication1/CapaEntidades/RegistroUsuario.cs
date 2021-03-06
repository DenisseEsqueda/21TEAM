//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class RegistroUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegistroUsuario()
        {
            this.Trabajoes = new HashSet<Trabajo>();
        }
        
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Ingresar correo")]
        [DisplayName("Correo")]
        public string correo { get; set; }

        [Required(ErrorMessage = "Ingresar nombre de usuario")]
        [DisplayName("nombre de usuario")]
        public string nombreUsuario { get; set; }

        [Required(ErrorMessage = "Ingresar Password")]
        [DisplayName("Contraseņa")]
        [DataType(DataType.Password)]
        public string contrasena { get; set; }

        [Required(ErrorMessage = "Ingresar Password")]
        [DisplayName("Contraseņa")]
        [DataType(DataType.Password)]
        public string ConfirmarContrasena { get; set; }

        [Required(ErrorMessage = "Seleccionar tipo de usuario")]
        [DisplayName("Tipo de usuario")]
        public Nullable<int> idTipoUsuario { get; set; }
    
        public virtual TipoUsuario TipoUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trabajo> Trabajoes { get; set; }
    }
}
