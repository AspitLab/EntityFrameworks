//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moeller_EFVenner
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Photo
    {
        public int id { get; set; }
        public int venId { get; set; }
        public string photoName { get; set; }
    
        public virtual MainVenneTabel MainVenneTabel { get; set; }
    }
}
