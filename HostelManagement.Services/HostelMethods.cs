using HostelManagement.dbContextdemo;
using HostelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Services
{
    public class HostelMethods
    {
        private readonly ApplicationDbContext dbContext;
        public HostelMethods(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Hostel>> GetAllHostelDetails()
        {
            return await dbContext.hostel.ToListAsync();
        }

        public async Task<string> AddHostel(Hostel student)
        {
            dbContext.hostel.Add(student);
            await dbContext.SaveChangesAsync();
            return "Hostel  Created";
        }

        public async Task<string> UpdateHostelDetails(int id, Hostel patients)
        {
            var existingPatient = await dbContext.hostel.FindAsync(id);
            if (existingPatient == null)
            {
                return "Patient Not Found";
            }

            existingPatient.Name = patients.Name;
            await dbContext.SaveChangesAsync();
            return "Patient Details Updated Successfully";
        }

        public async Task<string> DeleteHostel(int id)
        {
            var existingPatient = await dbContext.hostel.FindAsync(id);
            if (existingPatient == null)
            {
                return "Patient Not Found";
            }

            dbContext.hostel.Remove(existingPatient);
            await dbContext.SaveChangesAsync();
            return "Patient Deleted Successfully";
        }

        public async Task<List<Hostel>> SearchHostelByID(int id)
        {
            return await dbContext.hostel.Where(p => p.Id == id).ToListAsync();
        }
    }
}
