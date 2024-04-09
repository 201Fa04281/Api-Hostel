using HostelManagement.Models;
using HostelManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.controllers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomMethods _methods;
        public RoomController(RoomMethods methods)
        {
            _methods = methods;
        }

        [HttpGet]
        public List<Room> GetAllRoomDetails()
        {
            return _methods.GetAllRoomDetails();
        }
        [HttpPost]
        public string AddRoom(Room appointments)
        {
          
            return _methods.AddRoom(appointments);
        }
        [HttpPut("{id}")]
        public async Task<string> UpdateRoomDetails(int id, Room patient)
        {
            return await _methods.UpdateRoomDetails(id, patient);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteRoomDetails(int id)
        {
            return await _methods.DeleteRoom(id);
        }

        [HttpGet("{id}")]
        public async Task<List<Room>> SearchRoomByID(int id)
        {
            return await _methods.SearchRoomByID(id);
        }
    }
}
