using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSQL9.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
