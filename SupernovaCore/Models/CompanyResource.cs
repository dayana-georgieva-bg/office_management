using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SupernovaCore.Models
{
    [Table("CompanyResources")]
    public partial class CompanyResource
    {
        public CompanyResource()
        {
            EmployeesInformations = new HashSet<EmployeesInformation>();
        }
        [Key]
        public int Id { get; set; }
        public string LaptopModel { get; set; }
        public string MonitorModel { get; set; }
        public string LaptopSN { get; set; }
        public string MonitorSN { get; set; }
        public string MobilePhone { get; set; }
        public int? CompanyMobileNumber { get; set; }
        public string Headphones { get; set; }
        public string OtherInfo { get; set; }

        public virtual ICollection<EmployeesInformation> EmployeesInformations { get; set; }
    }
}
