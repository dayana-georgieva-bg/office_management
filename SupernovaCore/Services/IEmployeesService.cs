
using SupernovaCore.Models;
using SupernovaCore.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupernovaCore.Services
{
    public interface IEmployeesService
    {
        Task<List<EmployeesInformation>> GetEmployeesWithResources();

        Task<SupernovaModel> EmployeeDetails(int? id);
        Task<SupernovaModel> EmployeeEditGet(int? id);
        Task<SupernovaModel> EmployeeEditPost(SupernovaModel supernovaModel, int? id);
        Task<SupernovaModel> EmployeeCreate(SupernovaModel supernovaModel);
        Task<EmployeesInformation> EmployeeDeleteGet(int? id);
        Task<EmployeesInformation> EmployeeDeleteConfirmed(int? id);
    }
}
