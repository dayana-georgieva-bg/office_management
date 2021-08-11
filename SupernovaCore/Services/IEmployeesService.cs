
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
    }
}
