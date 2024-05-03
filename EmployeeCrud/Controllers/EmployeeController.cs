using EmployeeCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeCrud.Models.DTO;
namespace EmployeeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeInfoContext _context;

        public EmployeeController(EmployeeInfoContext context)
        {
            _context =context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee() { 
         
            return Ok(await _context.Employees.ToListAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult>GetEmployeeById(int id)
        {
            var data=await _context.Employees.FindAsync(id);
            if (data == null)
            {
                return NotFound("Employee with this id is not Present in database");
            }
            else
            {
               return Ok(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(NewEmployeeDto emp)
        {
            var data = new Employee
            {
                Name=emp.Name,
                Email=emp.Email,
                Salary=emp.Salary,
            };
            await _context.Employees.AddAsync(data);    
            _context.SaveChanges();
            return Ok(data);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployeeById(int id,UpdateEmployeeDto emp)
        {
            var data = await _context.Employees.FindAsync(id);
            if (data == null)
            {
                return NotFound("Employee with this id is not Present in database");
            }
            data.Name = emp.Name;
            data.Email = emp.Email; 
            await _context.SaveChangesAsync();
            return Ok("Updated Successfully");
        }
    }
}
