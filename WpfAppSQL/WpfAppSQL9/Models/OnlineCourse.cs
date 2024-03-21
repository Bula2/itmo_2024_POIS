using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSQL9.Models
{
    public class OnlineCourse
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string URL { get; set; }
    }
}
