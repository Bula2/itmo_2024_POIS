

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfAppSQL9.Models
{
    public class CourseInstructor
    {
        [Key]
        public int CourseID { get; set; }
        [ForeignKey("PersonID")]
        public int PersonID { get; set; }
    }
}