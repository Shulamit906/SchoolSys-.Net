namespace SchoolSis.Utilities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int Status { get; set; }

        //////////

        public List<Course> Courses { get; set; }

    }
}
