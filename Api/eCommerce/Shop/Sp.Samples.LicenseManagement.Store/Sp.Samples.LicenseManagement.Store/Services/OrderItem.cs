//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sp.Samples.LicenseManagement.Store.Services
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderItem
    {
        public int OrderItemNo { get; set; }
        public int PurchaseRecordId { get; set; }
        public string ActivationKey { get; set; }
        public string LicenseId { get; set; }
    
        public virtual PurchaseRecord PurchaseRecord { get; set; }
    }
}
