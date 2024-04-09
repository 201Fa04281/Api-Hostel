using HostelManagement.dbContextdemo;
using HostelManagement.Models;
using System;
using System.Threading.Tasks;

namespace HostelManagement.Services
{
    public class BookingMethods
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingMethods(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> BookRoom(Booking booking)
        {
            try
            {
                _dbContext.booking.Add(booking);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
    }
}
