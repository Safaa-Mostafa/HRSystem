using HRManagement.DAL.Data.Context;
using HRManagement.DAL.Repositories.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Printing;
using System;
using Microsoft.EntityFrameworkCore;
using HRManagement.DAL.Data.Models;

namespace HRManagement.DAL.Repositories.Employee
{
    public class EmployeeRepository : GenericRepository<HRManagement.DAL.Data.Models.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<HRManagement.DAL.Data.Models.Employee>> SearchEmployeesAsync(string searchTerm, int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                throw new ArgumentException("Page number and page size must be greater than zero.");
            }

            var skip = (pageNumber - 1) * pageSize;

            var employees = await _context.Employees
                .Where(e => e.Name.Contains(searchTerm) || e.SIN.Contains(searchTerm) || e.Phone.Contains(searchTerm))
                .OrderBy(e=>e.Name)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return employees;
        }
        public async Task<IEnumerable<HRManagement.DAL.Data.Models.Employee>> GetAllEmpsAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                throw new ArgumentException("Page number and page size must be greater than zero.");
            }

            var skip = (pageNumber - 1) * pageSize;

            return await _context.Set<HRManagement.DAL.Data.Models.Employee>()
                .AsNoTracking()
                .OrderBy(e=>e.Name)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }

    }
}