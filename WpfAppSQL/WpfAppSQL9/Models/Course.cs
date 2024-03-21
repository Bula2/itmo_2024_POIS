using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSQL9.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        public Department Department { get; set; } // Связь с отделом
    }
}
