//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Data.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderDetaile
    {
        public int id { get; set; }
        public Nullable<int> productId { get; set; }
        public Nullable<System.DateTime> cDate { get; set; }
        public Nullable<int> amount { get; set; }
        public Nullable<int> orderId { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<double> totalPrice { get; set; }
        public Nullable<bool> isActive { get; set; }
    
        public virtual product product { get; set; }
        public virtual order order { get; set; }
    }
}