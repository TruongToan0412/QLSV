//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public int AccountID { get; set; }
        public string FunctionID { get; set; }
        public string Description { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Function_Role Function_Role { get; set; }
    }
}
