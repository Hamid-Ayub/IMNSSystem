//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMNS.ServiceModel.Service.DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerEntity
    {
        public CustomerEntity()
        {
            this.ProductExportEntities = new HashSet<ProductExportEntity>();
        }
    
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<ProductExportEntity> ProductExportEntities { get; set; }
    }
}
