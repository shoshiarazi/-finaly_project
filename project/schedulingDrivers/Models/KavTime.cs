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
    
    public partial class KavTime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KavTime()
        {
            this.KavimToColanders = new HashSet<KavimToColander>();
        }
    
        public long TimeId { get; set; }
        public long KavId { get; set; }
        public System.TimeSpan DepartureTime { get; set; }
        public long LongTime_minutes_ { get; set; }
    
        public virtual kavim kavim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KavimToColander> KavimToColanders { get; set; }
    }
}