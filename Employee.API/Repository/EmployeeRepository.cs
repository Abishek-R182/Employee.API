using AutoMapper;
using Employee.API.Data;
using Employee.API.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeModel>> GetAllEmployeeAsync()
        {
            var records = await _context.Employees.ToListAsync();

            return _mapper.Map<List<EmployeeModel>>(records);
        }

        public async Task<EmployeeModel> GetAllEmployeeByIdAsync(int empId)
        {
            var records = await _context.Employees.FindAsync(empId);
            return _mapper.Map<EmployeeModel>(records);
        }

        public async Task<int> AddEmployeeAsync(EmployeeModel employeeModel)
        {
            var employee = new EmployeeData()
            {
                EmployeeName = employeeModel.EmployeeName,
                EmployeeAge = employeeModel.EmployeeAge,
                salary = employeeModel.salary,
                city = employeeModel.city,
                country = employeeModel.country,
                state = employeeModel.state,
                Designation = employeeModel.Designation,
                PhoneNo = employeeModel.PhoneNo
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task UpdateEmployeeAsync(int empId, EmployeeModel employeeModel)
        {
            var employee = new EmployeeData()
            {
                Id = empId,
                EmployeeName = employeeModel.EmployeeName,
                EmployeeAge = employeeModel.EmployeeAge,
                salary = employeeModel.salary,
                city = employeeModel.city,
                country = employeeModel.country,
                state = employeeModel.state,
                Designation = employeeModel.Designation,
                PhoneNo = employeeModel.PhoneNo
            };

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

        }

        public async Task PatchEmployeeAsync(int empId, JsonPatchDocument employeePatch)
        {
            var record = await _context.Employees.FindAsync(empId);
            if (record != null)
            {
                employeePatch.ApplyTo(record);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteEMployeeAsync(int empId)
        {
            var emp = new EmployeeData()
            {
                Id = empId
            };

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();

        }
    }
}
