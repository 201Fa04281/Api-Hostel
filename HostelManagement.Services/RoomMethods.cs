using HostelManagement.dbContextdemo;
using HostelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Services
{
    public class RoomMethods
    {
        private readonly ApplicationDbContext dbContext;
        public RoomMethods(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Room> GetAllRoomDetails()
        {
            return dbContext.rooom
                
                .Include(a => a.hostel)
                .Select(a => a)
                .ToList();
        }
        public string AddRoom(Room appointments)

        {
            dbContext.rooom.Add(appointments);
            dbContext.SaveChanges();
            return "Room Created";
        }

        public async Task<string> UpdateRoomDetails(int id, Room patients)
        {
            var existingPatient = await dbContext.rooom.FindAsync(id);
            if (existingPatient == null)
            {
                return "Room Not Found";
            }

            existingPatient.Occupied = patients.Occupied;
            await dbContext.SaveChangesAsync();
            return "room Details Updated Successfully";
        }

        public async Task<string> DeleteRoom(int id)
        {
            var existingPatient = await dbContext.rooom.FindAsync(id);
            if (existingPatient == null)
            {
                return "room Not Found";
            }

            dbContext.rooom.Remove(existingPatient);
            await dbContext.SaveChangesAsync();
            return "room Deleted Successfully";
        }

        public async Task<List<Room>> SearchRoomByID(int id)
        {
            return await dbContext.rooom.Where(p => p.Id == id).ToListAsync();
        }


    }
}
