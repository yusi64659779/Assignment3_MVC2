//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment3_MVC2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tomato
    {
        public int Form_ID { get; set; }
        public int Veg_ID { get; set; }
        public string Form { get; set; }
        public Nullable<decimal> Average_Retail_Price_Dollars { get; set; }
        public string Price_Unit { get; set; }
        public Nullable<decimal> Preparation_yield_Factor { get; set; }
        public Nullable<decimal> Size_Cup_Equivalent { get; set; }
        public string Size_Unit { get; set; }
        public Nullable<decimal> Average_Price_Per_Cup_Dollars { get; set; }
    
        public virtual Vegetable Vegetable { get; set; }
    }
}
