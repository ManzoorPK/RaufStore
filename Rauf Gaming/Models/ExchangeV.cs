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
    
    public partial class ExchangeV
    {
        public string ClientGame { get; set; }
        public Nullable<decimal> ClientGameActualPrice { get; set; }
        public Nullable<decimal> ClientGameDisPrice { get; set; }
        public string StoreGame { get; set; }
        public Nullable<decimal> StoreGameActualPrice { get; set; }
        public Nullable<decimal> StoreGameDisPrice { get; set; }
        public int ExchangeId { get; set; }
        public string Email { get; set; }
        public string ClientName { get; set; }
        public Nullable<decimal> Payment { get; set; }
        public string Type { get; set; }
    }
}
