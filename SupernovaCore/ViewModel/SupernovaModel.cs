using Microsoft.EntityFrameworkCore;
using SupernovaCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SupernovaCore.ViewModel
{
    public class SupernovaModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public Nullable<int> MobileNumber { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string LaptopModel { get; set; }
        public string MonitorModel { get; set; }
        public string LaptopSN { get; set; }
        public string MonitorSN { get; set; }
        public string MobilePhone { get; set; }
        public Nullable<int> CompanyMobileNumber { get; set; }
        public string Headphones { get; set; }
        public string OtherInfo { get; set; }
        public int ResourceId { get; set; }

        public virtual EmployeesInformation Employees_information { get; set; }

        public virtual CompanyResource Company_Resource { get; set; }
        public virtual DbSet<EmployeesInformation> Employees_InformationDB { get; set; }
        public virtual DbSet<CompanyResource> CompanyResourcesDB { get; set; }
    }
}
