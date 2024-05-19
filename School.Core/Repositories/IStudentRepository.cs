using SchoolSis.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Get();
        Student GetById(int id);
        Task<Student> AddAsync(Student student);
        Task<Student> UpdateAsync(int id, Student newStudent);
        Task<Student> UpdateStatusAsync(int id, int status, Student newStudent);
        Task<Student> DeleteAsync(int id);
    }
}
