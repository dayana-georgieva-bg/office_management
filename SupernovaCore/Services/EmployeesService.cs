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
        private readonly Supernova_teamContext context;

        public EmployeesService(Supernova_teamContext context)
        {
            this.context = context;
        }
        public async Task<SupernovaModel> EmployeeCreate(SupernovaModel supernovaModel)
        {         
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
                Birthday = supernovaModel.Birthday
                
            };
            
                this.context.Add(employeesInformation);
                await context.SaveChangesAsync();

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
                OtherInfo = supernovaModel.OtherInfo,
                EmployeeId = employeesInformation.Id

            };

            context.Add(companyResource);
            await context.SaveChangesAsync();

            return supernovaModel;
        }

        public async Task<EmployeesInformation> EmployeeDeleteConfirmed(int? id)
        {
            var employeesInformation = await context.EmployeesInformations
                .Include(r => r.CompanyResources)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            context.EmployeesInformations.Remove(employeesInformation);
            await context.SaveChangesAsync();

            return employeesInformation;
        }

        public async Task<EmployeesInformation> EmployeeDeleteGet(int? id)
        {
            var employeesInformation = await context.EmployeesInformations
                .Include(e => e.CompanyResources)
                .FirstOrDefaultAsync(m => m.Id == id);

            return employeesInformation;
        }

        public async Task<SupernovaModel> EmployeeDetails(int? id)
        {
            var employeesInformation = await this.context.EmployeesInformations
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
                EmployeeId = (int)employeesInformation.CompanyResources.FirstOrDefault().EmployeeId,
                LaptopModel = employeesInformation.CompanyResources.FirstOrDefault().LaptopModel,
                MonitorModel = employeesInformation.CompanyResources.FirstOrDefault().MonitorModel,
                LaptopSN = employeesInformation.CompanyResources.FirstOrDefault().LaptopSn,
                MonitorSN = employeesInformation.CompanyResources.FirstOrDefault().MonitorSn,
                MobilePhone = employeesInformation.CompanyResources.FirstOrDefault().MobilePhone,
                CompanyMobileNumber = employeesInformation.CompanyResources.FirstOrDefault().CompanyMobileNumber,
                Headphones = employeesInformation.CompanyResources.FirstOrDefault().Headphones,
                OtherInfo = employeesInformation.CompanyResources.FirstOrDefault().OtherInfo
            };

            return supernovaModel;
        }

        public async Task<SupernovaModel> EmployeeEditGet(int? id)
        {
            var employeesInformation = await this.context.EmployeesInformations
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
                EmployeeId = (int)employeesInformation.CompanyResources.FirstOrDefault().EmployeeId,
                LaptopModel = employeesInformation.CompanyResources.FirstOrDefault().LaptopModel,
                MonitorModel = employeesInformation.CompanyResources.FirstOrDefault().MonitorModel,
                LaptopSN = employeesInformation.CompanyResources.FirstOrDefault().LaptopSn,
                MonitorSN = employeesInformation.CompanyResources.FirstOrDefault().MonitorSn,
                MobilePhone = employeesInformation.CompanyResources.FirstOrDefault().MobilePhone,
                CompanyMobileNumber = employeesInformation.CompanyResources.FirstOrDefault().CompanyMobileNumber,
                Headphones = employeesInformation.CompanyResources.FirstOrDefault().Headphones,
                OtherInfo = employeesInformation.CompanyResources.FirstOrDefault().OtherInfo
            };

            return supernovaModel;

        }

        public async Task<SupernovaModel> EmployeeEditPost(SupernovaModel supernovaModel, int? id)
        {
            var employeesInformation = await this.context.EmployeesInformations
                .Include(e => e.CompanyResources)
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            employeesInformation.FirstName = supernovaModel.FirstName;
            employeesInformation.SecondName = supernovaModel.SecondName;
            employeesInformation.LastName = supernovaModel.LastName;
            employeesInformation.Position = supernovaModel.Position;
            employeesInformation.Email = supernovaModel.Email;
            employeesInformation.Birthday = supernovaModel.Birthday;
            employeesInformation.Address = supernovaModel.Address;
            employeesInformation.MobileNumber = supernovaModel.MobileNumber;
            employeesInformation.CompanyResources.FirstOrDefault().EmployeeId = supernovaModel.EmployeeId;
            employeesInformation.CompanyResources.FirstOrDefault().CompanyMobileNumber = supernovaModel.CompanyMobileNumber;
            employeesInformation.CompanyResources.FirstOrDefault().Headphones = supernovaModel.Headphones;
            employeesInformation.CompanyResources.FirstOrDefault().LaptopModel = supernovaModel.LaptopModel;
            employeesInformation.CompanyResources.FirstOrDefault().LaptopSn = supernovaModel.LaptopSN;
            employeesInformation.CompanyResources.FirstOrDefault().MobilePhone = supernovaModel.MobilePhone;
            employeesInformation.CompanyResources.FirstOrDefault().MonitorModel = supernovaModel.MonitorModel;
            employeesInformation.CompanyResources.FirstOrDefault().MonitorSn = supernovaModel.MonitorSN;
            employeesInformation.CompanyResources.FirstOrDefault().OtherInfo = supernovaModel.OtherInfo;

            context.Update(employeesInformation);
            await context.SaveChangesAsync();

            return supernovaModel;
        }

        public async Task<List<EmployeesInformation>> GetEmployeesWithResources()
        {
            return await this.context.EmployeesInformations.Include(e => e.CompanyResources).ToListAsync();
        }

    }
}
