//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VenneDbEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class MailAdr
    {
        public int id { get; set; }
        public int venId { get; set; }
        public string mailAdr1 { get; set; }
        public int type { get; set; }
    
        public virtual MailType MailType { get; set; }
        public virtual MainVenneTabel MainVenneTabel { get; set; }
    }
}
