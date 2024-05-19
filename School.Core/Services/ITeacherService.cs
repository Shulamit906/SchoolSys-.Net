using SchoolSis.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Services
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> Get();
        Teacher GetById(int id);
        Task<Teacher> AddAsync(Teacher t);
        Task<Teacher> UpdateAsync(int id, Teacher t);
        Task<Teacher> UpdateStatusAsync(int id, int status, Teacher t);
        Task<Teacher> DeleteAsync(int id);
    }
}
