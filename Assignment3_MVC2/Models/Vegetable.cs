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
    
    public partial class Vegetable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vegetable()
        {
            this.Mushrooms = new HashSet<Mushroom>();
            this.Potatoes = new HashSet<Potato>();
            this.Tomatoes = new HashSet<Tomato>();
        }
    
        public int Veg_ID { get; set; }
        public int Product_ID { get; set; }
        public string Veg_Name { get; set; }
    
        public virtual Agri_Products Agri_Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mushroom> Mushrooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potato> Potatoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tomato> Tomatoes { get; set; }
    }
}
