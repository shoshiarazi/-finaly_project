//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KavimToColander
    {
        public int KavimToColanderID { get; set; }
        public long TimeId { get; set; }
        public int ColanderToDriverID { get; set; }
    
        public virtual ColanderToDriver ColanderToDriver { get; set; }
        public virtual KavTime KavTime { get; set; }
    }
}
