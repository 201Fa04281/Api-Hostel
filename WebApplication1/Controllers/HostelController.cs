using HostelManagement.Models;
using HostelManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.controllers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HostelController : ControllerBase
    {
        private readonly HostelMethods _methods;
        public HostelController(HostelMethods methods)
        {
            _methods = methods;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hostel>>> GetAllHostelDetails()
        {
            return await _methods.GetAllHostelDetails();
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddHostel(Hostel student)
        {
            return await _methods.AddHostel(student);
        }
        [HttpPut("{id}")]
        public async Task<string> UpdateHostelDetails(int id, Hostel patient)
        {
            return await _methods.UpdateHostelDetails(id, patient);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteHostelDetails(int id)
        {
            return await _methods.DeleteHostel(id);
        }

        [HttpGet("{id}")]
        public async Task<List<Hostel>> SearchHostelByID(int id)
        {
            return await _methods.SearchHostelByID(id);
        }

    }
}
