using AutoMapper;
using HRManagement.BL.DTO;
using HRManagement.DAL.Data.Enums;
using HRManagement.DAL.Data.Models;
using HRManagement.DAL.UnitOfWork;

namespace HRManagement.BL.Managers.Employee
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetEmployeeDTO>> GetAllEmployeesAsync(int pageNumber, int pageSize)
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllEmpsAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<GetEmployeeDTO>>(employees);
        }
        public async Task ActiveEmployee(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            employee.IsActive = Status.Active;
            await _unitOfWork.EmployeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

        }
        public async Task DeActiveEmployee(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            employee.IsActive = Status.Deactive;
            await _unitOfWork.EmployeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

        }
        public async Task<GetEmployeeDTO> Add(AddEmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<AddEmployeeDTO, HRManagement.DAL.Data.Models.Employee>(employeeDTO);
            await _unitOfWork.EmployeeRepository.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            var employeeResult = _mapper.Map<HRManagement.DAL.Data.Models.Employee, GetEmployeeDTO>(employee);
            return employeeResult;
        }
        public async Task Delete(int id)
        {

            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception("employee Not Found !");
            }
            await _unitOfWork.EmployeeRepository.DeleteAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<GetEmployeeDTO> GetById(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception("the employee not found!");
            }
            var result = _mapper.Map<GetEmployeeDTO>(employee);
            return result;
        }
        public async Task<GetEmployeeDTO> Update(int id, EditEmployeeDTO editEmployeeDTO)
        {
            var existingEmployee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (existingEmployee is null) throw new KeyNotFoundException("Employee not found");
            _mapper.Map(editEmployeeDTO, existingEmployee);
            var updatedEmployee = await _unitOfWork.EmployeeRepository.UpdateAsync(existingEmployee);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<GetEmployeeDTO>(updatedEmployee);
            return result;
        }
        public async Task<IEnumerable<GetEmployeeDTO>> SearchEmployeesAsync(string searchTerm, int pageNumber, int pageSize)
        {
            if (searchTerm == null)
            {
                var employees = await _unitOfWork.EmployeeRepository.GetAllAsync(pageNumber, pageSize);
                var employeeDTOs = _mapper.Map<IEnumerable<GetEmployeeDTO>>(employees);
                return employeeDTOs;
            }
            else
            {
                var employees = await _unitOfWork.EmployeeRepository.SearchEmployeesAsync(searchTerm, pageNumber, pageSize);
            var employeeDTOs = _mapper.Map<IEnumerable<GetEmployeeDTO>>(employees);
            return employeeDTOs;
            }
        }

        public async Task<IEnumerable<GetEmployeeDTO>> GetAll(int pageNumber, int pageSize)
        {
            var employess = await _unitOfWork.EmployeeRepository.GetAllAsync(pageNumber, pageSize);
            var employeeDTOs = _mapper.Map<IEnumerable<GetEmployeeDTO>>(employess);
            return employeeDTOs;
        }
    }
}
