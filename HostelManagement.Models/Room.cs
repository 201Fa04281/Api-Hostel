using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int Occupied { get; set; }
        public bool Avilable { get; set; }

        [ForeignKey("Hostel")] public int HostelId { get; set; }  // Foreign key property for hostel
        public Hostel? hostel { get; set; }  // Reference to hostel
    }
}
