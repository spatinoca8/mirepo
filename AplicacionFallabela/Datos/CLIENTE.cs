//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENTE
    {
        public CLIENTE()
        {
            this.PEDIDOS = new HashSet<PEDIDOS>();
        }
    
        public int CLIE_CONT { get; set; }
        public Nullable<int> VEND_CONT { get; set; }
        public string CLIE_NOMBRE { get; set; }
        public string CLIE_DIRECCION { get; set; }
    
        public virtual VENDEDOR VENDEDOR { get; set; }
        public virtual ICollection<PEDIDOS> PEDIDOS { get; set; }
    }
}