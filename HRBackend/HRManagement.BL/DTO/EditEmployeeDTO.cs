using HRManagement.DAL.Data.Enums;

namespace HRManagement.BL.DTO
{
    public class EditEmployeeDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string SIN { get; set; }
        public string Phone { get; set; }
        public Status IsActive { get; set; } = Status.Active;

    }
}
