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
    
    public partial class Exchange
    {
        public int ExchangeId { get; set; }
        public string Platform { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> StorePrice { get; set; }
        public Nullable<decimal> BuyingPrice { get; set; }
    }
}