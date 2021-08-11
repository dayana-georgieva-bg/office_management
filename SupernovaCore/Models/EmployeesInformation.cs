using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SupernovaCore.Models
{
    [Table("Employees_information")]
    public partial class EmployeesInformation
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public int? MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        [Column("CompanyResourcesId")]
        [ForeignKey("CompanyResourcesId")]
        public int? CompanyResourcesId { get; set; }

        public virtual CompanyResource CompanyResources { get; set; }
    }
}
