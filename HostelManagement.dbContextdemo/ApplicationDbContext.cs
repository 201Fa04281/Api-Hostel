using Microsoft.EntityFrameworkCore;
using HostelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.dbContextdemo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> student {  get; set; }
        public DbSet<Hostel> hostel { get; set; }
        public DbSet<Room> rooom { get; set; }
        public DbSet<Booking> booking { get; set; }

    }
}
