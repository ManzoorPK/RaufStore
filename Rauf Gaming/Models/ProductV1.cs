//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rauf_Gaming.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductV1
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> ActualPrice { get; set; }
        public Nullable<decimal> DiscountedPrice { get; set; }
        public string Genre { get; set; }
        public string Publishers { get; set; }
        public string Platform { get; set; }
        public string tags { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public Nullable<decimal> BuyingPrice { get; set; }
    }
}
