using School.Core.Repositories;
using School.Core.Services;
using SchoolSis.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)=>_courseRepository = courseRepository;

        public IEnumerable<Course> Get()=>_courseRepository.Get();

        public Course GetById(int id)=>_courseRepository.GetById(id);

        public async Task<Course> AddAsync(Course course)
        {
            await _courseRepository.AddAsync(course);
            return course;
        }
        public async Task<Course> UpdateAsync(int id,  Course course)=> await _courseRepository.UpdateAsync(id, course);

        public async Task<Course> DeleteAsync(int id)
        {
           return await _courseRepository.DeleteAsync(id); 
        }
      
    }
}
