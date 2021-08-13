using System;
using System.Collections.Generic;

#nullable disable

namespace SupernovaCore.Models
{
    public partial class CompanyResource
    {
        public int Id { get; set; }
        public string LaptopModel { get; set; }
        public string MonitorModel { get; set; }
        public string LaptopSn { get; set; }
        public string MonitorSn { get; set; }
        public string MobilePhone { get; set; }
        public int? CompanyMobileNumber { get; set; }
        public string Headphones { get; set; }
        public string OtherInfo { get; set; }
        public int? EmployeeId { get; set; }

        public virtual EmployeesInformation EmployeesInformation { get; set; }
    }
}
