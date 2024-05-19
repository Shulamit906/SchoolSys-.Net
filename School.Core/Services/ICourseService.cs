using SchoolSis.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> Get();

        Course GetById(int id);

        Task<Course> AddAsync(Course course);
        
        Task<Course> UpdateAsync(int id, Course course);
       
        Task<Course> DeleteAsync(int id);
    }
}
