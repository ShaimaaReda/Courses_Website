using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace courses.Models
{
    public class Course
    {
        public int Id { get; set; }

        [DisplayName("Course Name")]
        [Required(ErrorMessage = "You Have to provide a valid name.")]
        [MinLength(2, ErrorMessage = "Name must't be less than 2 char")]
        [MaxLength(40, ErrorMessage = "Name must't exceed 20 char")]
        public string CourseName { get; set; }


        [DisplayName("Total Hours")]
        [Required(ErrorMessage = "You Have to provide a valid name.")]
        public int TotalHours { get; set; }


        [DisplayName("Start Course")]
        public DateTime StartCourse { get; set; }
        public int Cost { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

    }
}
