using System.Numerics;

namespace SchoolSis.Utilities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        ///////////
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }
    }
}
