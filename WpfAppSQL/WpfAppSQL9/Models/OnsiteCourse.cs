using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSQL9.Models
{
    public class OnsiteCourse
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [Required]
        [MaxLength(50)]
        public string Days { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
