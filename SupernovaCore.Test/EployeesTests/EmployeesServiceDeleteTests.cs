using Microsoft.EntityFrameworkCore;
using Moq;
using SupernovaCore.Controllers;
using SupernovaCore.Models;
using SupernovaCore.Services;
using SupernovaCore.Test.HelperData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SupernovaCore.Test.EployeesTests
{
    public class EmployeesServiceDeleteTests
    {
        [Fact]
        public async Task Delete_DeleteEmployee_ReturnDeleted()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<Supernova_teamContext>()
                              .UseInMemoryDatabase("delete_employee");
            using var dbContext = new Supernova_teamContext(options.Options);

            var service = new EmployeesService(dbContext);

            var employee = EmployeeData.GetEmployeeData();

            // Act
            var sss = await service.EmployeeCreate(employee);

            var storedEmployeesCount = await service.GetEmployeesWithResources();
            var storedEmployee = await service.EmployeeDetails(1);

            // Assert
            Assert.Single(storedEmployeesCount);
            Assert.Equal("Toni", storedEmployee.FirstName);
            Assert.Equal("Dimitrov", storedEmployee.LastName);
            Assert.Equal(0888777666, storedEmployee.CompanyMobileNumber);

            //Act
            //var deleted = new PeopleController(dbContext, service);
            //await deleted.DeleteConfirmed(1);

            storedEmployeesCount = await service.EmployeeDeleteConfirmed();
            //Assert
            Assert.Empty(storedEmployeesCount);


        }
    }
}
