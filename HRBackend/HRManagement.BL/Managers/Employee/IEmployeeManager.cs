using HRManagement.BL.DTO;

namespace HRManagement.BL.Managers.Employee
{
    public interface IEmployeeManager
    {

        Task<GetEmployeeDTO> GetById(int id);
        Task<GetEmployeeDTO> Add(AddEmployeeDTO employeeDTO);
        Task<GetEmployeeDTO> Update(int id, EditEmployeeDTO employeeUpdateDTO);
        Task Delete(int id);
        Task ActiveEmployee(int id);
        Task<IEnumerable<GetEmployeeDTO>> SearchEmployeesAsync(string searchTerm, int pageNumber, int pageSize);
        Task<IEnumerable<GetEmployeeDTO>> GetAll(int pageNumber, int pageSize);
        Task DeActiveEmployee(int id);
    }
}
