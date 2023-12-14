using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace courses.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        [DisplayName("Image")]
        [ValidateNever]
        public string ImagePath { get; set; }

    }
}
   