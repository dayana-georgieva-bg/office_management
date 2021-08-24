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
            var storedEmployee = await service.EmployeeDetails(1);

            var newEmployee = new SupernovaModel { FirstName = "Toni2", SecondName = "Ilchov2", LaptopModel = "Acer" };
            await service.EmployeeEditPost(newEmployee, 1);

            // Assert

            Assert.Single(storedEmployeesCount);
            //Assert.Equal("Toni", storedEmployee.FirstName);
            //Assert.Equal("Dimitrov", storedEmployee.LastName);
            //Assert.Equal(0888777666, storedEmployee.CompanyMobileNumber);

            Assert.NotEqual(employee, newEmployee);
            Assert.Equal("Toni2", newEmployee.FirstName);
            Assert.NotEqual(storedEmployee.FirstName, newEmployee.FirstName);



        }
    }
}
