//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gapura.Models
{
    using System;
    
    public partial class SPR_Products_Result
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string UnitName { get; set; }
        public string Specs { get; set; }
        public Nullable<int> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public string FirstInputDate { get; set; }
    }
}
