using AutoMapper;
using SchoolSis.API.Models;
using SchoolSis.Utilities;

namespace SchoolSis.API.Mapping
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<StudentPostModel, Student>();
            CreateMap<TeacherPostModel, Teacher>();
            CreateMap<CoursePostModel, Course>();
        }
    }
}
