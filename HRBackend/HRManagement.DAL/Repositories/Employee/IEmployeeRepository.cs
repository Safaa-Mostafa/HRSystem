using HRManagement.DAL.Repositories.Generic;

namespace HRManagement.DAL.Repositories.Employee
{
    public interface IEmployeeRepository : IGenericRepository<HRManagement.DAL.Data.Models.Employee>
    {
        Task<IEnumerable<HRManagement.DAL.Data.Models.Employee>> SearchEmployeesAsync(string searchTerm, int pageNumber, int pageSize);
        Task<IEnumerable<HRManagement.DAL.Data.Models.Employee>> GetAllEmpsAsync(int pageNumber, int pageSize);
    }
}
