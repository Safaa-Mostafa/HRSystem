using HRManagement.DAL.Repositories.Employee;

namespace HRManagement.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }

        Task SaveChangesAsync();

    }

}
