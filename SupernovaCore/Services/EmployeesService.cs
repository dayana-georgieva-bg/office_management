using Microsoft.EntityFrameworkCore;
using SupernovaCore.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using SupernovaCore.ViewModel;
using System.Linq;
using System;

namespace SupernovaCore.Services
{
    public class EmployeesService : IEmployeesService
    {
        public async Task<SupernovaModel> EmployeeCreate(SupernovaModel supernovaModel)
        {
            var context = new Supernova_teamContext();

            CompanyResource companyResource = new CompanyResource()
            {
                Id = 0,
                LaptopModel = supernovaModel.LaptopModel,
                MonitorModel = supernovaModel.MonitorModel,
                LaptopSn = supernovaModel.LaptopSN,
                MonitorSn = supernovaModel.MonitorSN,
                MobilePhone = supernovaModel.MobilePhone,
                CompanyMobileNumber = supernovaModel.CompanyMobileNumber,
                Headphones = supernovaModel.Headphones,
                OtherInfo = supernovaModel.OtherInfo
            };
            
                 context.Add(companyResource);
                 await context.SaveChangesAsync();
            

            EmployeesInformation employeesInformation = new EmployeesInformation()
            {
                Id = 0,
                FirstName = supernovaModel.FirstName,
                SecondName = supernovaModel.SecondName,
                LastName = supernovaModel.LastName,
                Address = supernovaModel.Address,
                MobileNumber = supernovaModel.MobileNumber,
                Email = supernovaModel.Email,
                Position = supernovaModel.Position,
                Birthday = supernovaModel.Birthday,
                ResourceId = companyResource.Id
            };
            
                context.Add(employeesInformation);
                await context.SaveChangesAsync();

            return supernovaModel;
        }

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
                ResourceId = (int)employeesInformation.ResourceId,
                LaptopModel = employeesInformation.CompanyResources.LaptopModel,
                MonitorModel = employeesInformation.CompanyResources.MonitorModel,
                LaptopSN = employeesInformation.CompanyResources.LaptopSn,
                MonitorSN = employeesInformation.CompanyResources.MonitorSn,
                MobilePhone = employeesInformation.CompanyResources.MobilePhone,
                CompanyMobileNumber = employeesInformation.CompanyResources.CompanyMobileNumber,
                Headphones = employeesInformation.CompanyResources.Headphones,
                OtherInfo = employeesInformation.CompanyResources.OtherInfo
            };

            return supernovaModel;
        }

        public async Task<SupernovaModel> EmployeeEditGet(int? id)
        {
            var context = new Supernova_teamContext();
            var employeesInformation = await context.EmployeesInformations
                .Include(e => e.CompanyResources)
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

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
                ResourceId = (int)employeesInformation.ResourceId,
                LaptopModel = employeesInformation.CompanyResources.LaptopModel,
                MonitorModel = employeesInformation.CompanyResources.MonitorModel,
                LaptopSN = employeesInformation.CompanyResources.LaptopSn,
                MonitorSN = employeesInformation.CompanyResources.MonitorSn,
                MobilePhone = employeesInformation.CompanyResources.MobilePhone,
                CompanyMobileNumber = employeesInformation.CompanyResources.CompanyMobileNumber,
                Headphones = employeesInformation.CompanyResources.Headphones,
                OtherInfo = employeesInformation.CompanyResources.OtherInfo
            };

            return supernovaModel;

        }

        public async Task<SupernovaModel> EmployeeEditPost(SupernovaModel supernovaModel, int? id)
        {
            var context = new Supernova_teamContext();

            var teamContext = await context.EmployeesInformations
                .Include(e => e.CompanyResources)
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            teamContext.FirstName = supernovaModel.FirstName;
            teamContext.SecondName = supernovaModel.SecondName;
            teamContext.LastName = supernovaModel.LastName;
            teamContext.Position = supernovaModel.Position;
            teamContext.Email = supernovaModel.Email;
            teamContext.Birthday = supernovaModel.Birthday;
            teamContext.Address = supernovaModel.Address;
            teamContext.MobileNumber = supernovaModel.MobileNumber;

            teamContext.CompanyResources.CompanyMobileNumber = supernovaModel.CompanyMobileNumber;
            teamContext.CompanyResources.Headphones = supernovaModel.Headphones;
            teamContext.CompanyResources.LaptopModel = supernovaModel.LaptopModel;
            teamContext.CompanyResources.LaptopSn = supernovaModel.LaptopSN;
            teamContext.CompanyResources.MobilePhone = supernovaModel.MobilePhone;
            teamContext.CompanyResources.MonitorModel = supernovaModel.MonitorModel;
            teamContext.CompanyResources.MonitorSn = supernovaModel.MonitorSN;
            teamContext.CompanyResources.OtherInfo = supernovaModel.OtherInfo;

            context.Update(teamContext);
            await context.SaveChangesAsync();

            return supernovaModel;
        }

        public async Task<List<EmployeesInformation>> GetEmployeesWithResources()
        {
            var context = new Supernova_teamContext();

            return await context.EmployeesInformations.Include(e => e.CompanyResources).ToListAsync();
        }
    }
}
