using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppSQL9.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public int? Administrator { get; set; }

        [ForeignKey("Administrator")]
        public Person DepartmentAdministrator { get; set; }

        // Связь с курсами
        public ICollection<Course> Courses { get; set; }
    }
}
