//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegistroUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegistroUsuario()
        {
            this.Trabajoes = new HashSet<Trabajo>();
        }
    
        public int idUsuario { get; set; }
        public string correo { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasena { get; set; }
        public string ConfirmarContrasena { get; set; }
        public Nullable<int> idTipoUsuario { get; set; }
    
        public virtual TipoUsuario TipoUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trabajo> Trabajoes { get; set; }
    }
}