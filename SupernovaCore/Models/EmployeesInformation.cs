using System;
using System.Collections.Generic;

#nullable disable

namespace SupernovaCore.Models
{
    public partial class EmployeesInformation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public int? MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public int ResourceId { get; set; }

        public virtual CompanyResource CompanyResources { get; set; }
    }
}
