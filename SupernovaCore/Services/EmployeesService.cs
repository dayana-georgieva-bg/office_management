using Microsoft.EntityFrameworkCore;
using SupernovaCore.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using SupernovaCore.ViewModel;

namespace SupernovaCore.Services
{
    public class EmployeesService : IEmployeesService
    {
        public async Task<SupernovaModel> EmployeeDetails(int? id)
        {
            var context = new Supernova_teamContext();

            var employeesInformation = await context.EmployeesInformations
               .Include(e => e.CompanyResources)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (employeesInformation == null)
            {
                return null;
            }

            SupernovaModel supernovaModel = new SupernovaModel()
            {
                Id = (int)id,
                FirstName = employeesInformation.FirstName,
                SecondName = employeesInformation.SecondName,
                LastName = employeesInformation.LastName,
                Address = employeesInformation.Address,
                MobileNumber = employeesInformation.MobileNumber,
                Email = employeesInformation.Email,
                Position = employeesInformation.Position,
                Birthday = employeesInformation.Birthday,
                CompanyResourcesId = (int)employeesInformation.CompanyResourcesId,
                LaptopModel = employeesInformation.CompanyResources.LaptopModel,
                MonitorModel = employeesInformation.CompanyResources.MonitorModel,
                LaptopSN = employeesInformation.CompanyResources.LaptopSN,
                MonitorSN = employeesInformation.CompanyResources.MonitorSN,
                MobilePhone = employeesInformation.CompanyResources.MobilePhone,
                CompanyMobileNumber = employeesInformation.CompanyResources.CompanyMobileNumber,
                Headphones = employeesInformation.CompanyResources.Headphones,
                OtherInfo = employeesInformation.CompanyResources.OtherInfo
            };

            return supernovaModel;
        }

        public async Task<List<EmployeesInformation>> GetEmployeesWithResources()
        {
            var context = new Supernova_teamContext();

            return await context.EmployeesInformations.Include(e => e.CompanyResources).ToListAsync();
        }
    }
}
