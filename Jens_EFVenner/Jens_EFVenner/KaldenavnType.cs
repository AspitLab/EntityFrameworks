//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jens_EFVenner
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class KaldenavnType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KaldenavnType()
        {
            this.KaldeNavns = new ObservableCollection<KaldeNavn>();
        }
    
        public int id { get; set; }
        public string kaldenavnType1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<KaldeNavn> KaldeNavns { get; set; }
    }
}
