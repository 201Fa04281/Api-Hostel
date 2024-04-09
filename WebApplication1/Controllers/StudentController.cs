using HostelManagement.Models;
using HostelManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.controllers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       
        private readonly StudentMethods _methods;
        public StudentController(StudentMethods methods)
        {
            _methods = methods;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllstudentDetails()
        {
            return await _methods.GetAllStudentDetails();
        }
        [HttpPost]
        public async Task<ActionResult<string>> AddStudent(Student student)
        {
            try
            {
                await _methods.AddStudent(student);
                return Ok(new { message = "Student created successfully" }); // Return JSON object with success message
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" }); // Return JSON object with error message
            }
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateStudentDetails(int id, Student patient)
        {
            return await _methods.UpdateStudentDetails(id, patient);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteStudentDetails(int id)
        {
            return await _methods.DeleteStudent(id);
        }

        [HttpGet("{id}/{name}")]
        public async Task<List<Student>> SearchStudentByID(int id,string name)
        {
            return await _methods.SearchStudentByID(id,name);
        }
        [HttpGet("hostels")]
        public async Task<ActionResult<IEnumerable<Hostel>>> GetAllHostels()
        {
            var hostels = await _methods.GetAllHostels();
            return Ok(hostels);
        }

        [HttpGet("rooms/{hostelId}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAvailableRooms(int hostelId)
        {
            var rooms = await _methods.GetAvailableRooms(hostelId);
            return Ok(rooms);
        }
    }
}
