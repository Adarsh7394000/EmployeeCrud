namespace EmployeeCrud.Models.DTO
{
    public class NewEmployeeDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? Salary { get; set; }
    }
}
