using AutoMapper;
using Employee.API.Data;
using Employee.API.Model;

namespace Employee.API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<EmployeeData, EmployeeModel>().ReverseMap();
        }
    }
}
