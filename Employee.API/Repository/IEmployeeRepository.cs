using Employee.API.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace Employee.API.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployeeAsync();

        Task<EmployeeModel> GetAllEmployeeByIdAsync(int empId);

        Task<int> AddEmployeeAsync(EmployeeModel employeeModel);

        Task UpdateEmployeeAsync(int empId, EmployeeModel employeeModel);

        Task PatchEmployeeAsync(int empId, JsonPatchDocument employeePatch);

        Task DeleteEMployeeAsync(int empId);
    }
}
