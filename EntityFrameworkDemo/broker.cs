//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class broker
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> fk_company_id { get; set; }
        public string city { get; set; }
        public Nullable<int> active { get; set; }
    
        public virtual company company { get; set; }
    }
}
