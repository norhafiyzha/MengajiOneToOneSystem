//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MengajiOneToOneSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClassRecord
    {
        public string class_id { get; set; }
        public string t_id { get; set; }
        public string u_id { get; set; }
    
        public virtual Teacher Teacher { get; set; }
        public virtual User User { get; set; }
    }
}
