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
    
    public partial class EmployeeLogEntity
    {
        public int EmployeeLogID { get; set; }
        public int EmployeeID { get; set; }
        public Nullable<System.DateTime> LogInTime { get; set; }
        public Nullable<System.DateTime> LogOutTime { get; set; }
        public string LogInMachine { get; set; }
    
        public virtual EmployeeEntity EmployeeEntity { get; set; }
    }
}
