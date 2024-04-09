using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelManagement.dbContextdemo;
using HostelManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace HostelManagement.Services
{
    public class StudentMethods
    {
        private readonly ApplicationDbContext dbContext;
        public StudentMethods(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Student>> GetAllStudentDetails()
        {
            return await dbContext.student.ToListAsync();
        }

        public async Task<string> AddStudent(Student student)
        {
            dbContext.student.Add(student);
            await dbContext.SaveChangesAsync();
            return "student  Created";
        }

        public async Task<string> UpdateStudentDetails(int id, Student patients)
        {
            var existingPatient = await dbContext.student.FindAsync(id);
            if (existingPatient == null)
            {
                return "Student Not Found";
            }

            existingPatient.Name = patients.Name;
            await dbContext.SaveChangesAsync();
            return "Student Details Updated Successfully";
        }

        public async Task<string> DeleteStudent(int id)
        {
            var existingPatient = await dbContext.student.FindAsync(id);
            if (existingPatient == null)
            {
                return "Student Not Found";
            }

            dbContext.student.Remove(existingPatient);
            await dbContext.SaveChangesAsync();
            return "student Deleted Successfully";
        }

        public async Task<List<Student>> SearchStudentByID(int id,string name)
        {
            return await dbContext.student.Where(p => p.Id == id && p.Name==name).ToListAsync();
        }

        public async Task<IEnumerable<Hostel>> GetAllHostels()
        {
            return await dbContext.hostel.ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAvailableRooms(int hostelId)
        {
            return await dbContext.rooom.Include(a=>a.hostel).Where(r => r.HostelId == hostelId && r.Avilable).ToListAsync();
        }
    }
}
