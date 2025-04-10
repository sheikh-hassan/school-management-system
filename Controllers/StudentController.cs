using Microsoft.AspNetCore.Mvc;
using MyJwtAuthApp.Data;
using MyJwtAuthApp.Models;
using Microsoft.AspNetCore.Authorization;


namespace MyJwtAuthApp.Controllers
{   [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Students.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student updatedStudent)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            student.Name = updatedStudent.Name;
            student.Class = updatedStudent.Class;
            student.RollNo = updatedStudent.RollNo;
            student.Email = updatedStudent.Email;

            _context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok("Deleted successfully");
        }
    }
}
