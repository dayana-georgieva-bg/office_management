using Microsoft.EntityFrameworkCore;
using SupernovaCore.Models;
using SupernovaCore.Services;
using SupernovaCore.Test.HelperData;
using System.Threading.Tasks;
using Xunit;

namespace SupernovaCore.Test.EployeesTests
{
    public class EmployeesServiceCreateTests
    {
        [Fact]
        public async Task CreatePost_CreateNewEmployee_ReturnCorrectInformation()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<Supernova_teamContext>()
                              .UseInMemoryDatabase("create_employee");
            using var dbContext = new Supernova_teamContext(options.Options);

            var service = new EmployeesService(dbContext);

            var employee = EmployeeData.GetEmployeeData();

            // Act
            await service.EmployeeCreate(employee);

            var storedEmployeesCount = await service.GetEmployeesWithResources();
            var storedEmployee = await service.EmployeeDetails(1);

            // Assert
            Assert.Single(storedEmployeesCount);
            Assert.Equal("Toni", storedEmployee.FirstName);
            Assert.Equal("Dimitrov", storedEmployee.LastName);
            Assert.Equal(0888777666, storedEmployee.CompanyMobileNumber);
        }
    }
}
