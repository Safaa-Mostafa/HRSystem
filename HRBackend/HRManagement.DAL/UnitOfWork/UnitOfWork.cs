using HRManagement.DAL.Data.Context;
using HRManagement.DAL.Repositories.Employee;

namespace HRManagement.DAL.UnitOfWork
{
    public class unitOfWork: IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public IEmployeeRepository EmployeeRepository { get; }

        public unitOfWork(IEmployeeRepository employeeRepository, ApplicationDbContext context)
        {
            EmployeeRepository = employeeRepository;
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
