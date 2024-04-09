using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        // Additional properties as needed

        // Foreign keys
        [ForeignKey("Student")] public int StudentId { get; set; }  // Foreign key property for std
        public Student? student { get; set; }  // Reference to std
        [ForeignKey("Room")] public int RoomId { get; set; }  // Foreign key property for room
        public Room? room { get; set; }  // Reference to room
    }
}
