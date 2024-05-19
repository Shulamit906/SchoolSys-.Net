using School.Core.Repositories;
using SchoolSis;
using SchoolSis.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Repositories
{
    public class CourseRepository: ICourseRepository
    {
   
        private readonly DataContext _context;
        public CourseRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> Get()
        {
            return _context.Courses;
        }
        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }
        public async Task<Course> AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }
        public async Task<Course> UpdateAsync(int id, Course course)
        {

            Course c = _context.Courses.Find(id);
            if (c != null)
            {
                c.Name = course.Name;
                c.Description = course.Description; 
            }
            await _context.SaveChangesAsync();
            return c;
           
        }
        public async Task<Course> DeleteAsync(int id)
        {
            Course c = _context.Courses.Find(id);
           
            _context.Courses.Remove(c);
            await _context.SaveChangesAsync();
            return c;
            
        }
    }
}
