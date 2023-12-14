namespace courses.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string  Email { get; set; }
        public string  Phone { get; set; }

        public Course Course { get; set; }
    }
}
