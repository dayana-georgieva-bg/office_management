using Microsoft.EntityFrameworkCore;
using SupernovaCore.Models;
using SupernovaCore.Services;
using SupernovaCore.Test.HelperData;
using SupernovaCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SupernovaCore.Test.EployeesTests
{
    public class EmployeesServiceEditTests
    {
        [Fact]
        public async Task EditPost_EditEmployee_ReturnUpdatedRecord()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<Supernova_teamContext>()
                              .UseInMemoryDatabase("edit_employee");
            using var dbContext = new Supernova_teamContext(options.Options);

            var service = new EmployeesService(dbContext);

            var employee = EmployeeData.GetEmployeeData();

            // Act
            await service.EmployeeCreate(employee);

            var storedEmployeesCount = await service.GetEmployeesWithResources();
            //var initiallyStoredEmployee = (await service.GetEmployeesWithResources())
            //    .FirstOrDefault();

            var initiallyStoredEmployee = await service.EmployeeDetails(1);

            // Assert
            Assert.Single(storedEmployeesCount);
            Assert.Equal("Toni", initiallyStoredEmployee.FirstName);
            Assert.Equal("Il.", initiallyStoredEmployee.SecondName);
            Assert.Equal("Dimitrov", initiallyStoredEmployee.LastName);
            Assert.Equal(new DateTime(1990, 08, 08), initiallyStoredEmployee.Birthday);
            Assert.Equal(0888777666, initiallyStoredEmployee.CompanyMobileNumber);

            // Arrange
            var newInfoEmployee = new SupernovaModel
            {
                FirstName = "Toni2",
                SecondName = "Ilchov2",
                LastName = "Dimitrov2",
                Address = "Sofia, Flat mountain street",
                Birthday = new DateTime(1970, 01, 01),
                LaptopModel = "Acer",
                CompanyMobileNumber = 0888111111
            };

            // Act
            await service.EmployeeEditPost(newInfoEmployee, 1);

            // I check if I edited but not create second employee, just in case
            storedEmployeesCount = await service.GetEmployeesWithResources();

            // Get edited employee from DB
            var editedEmployee = (await service.GetEmployeesWithResources())
                .FirstOrDefault();

            // Assert
            Assert.Single(storedEmployeesCount);
            Assert.Equal("Toni2", editedEmployee.FirstName);
            Assert.Equal("Ilchov2", editedEmployee.SecondName);
            Assert.Equal("Dimitrov2", editedEmployee.LastName);
            Assert.Equal(new DateTime(1970, 01, 01), editedEmployee.Birthday);
        }
    }
}
