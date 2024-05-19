using School.Core.Repositories;
using SchoolSis.Utilities;
using SchoolSis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }
        static int id = 4;
 
        public IEnumerable<Student> Get()
        {
            return _context.Students;
        }
        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }
        public async Task<Student> AddAsync( Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> UpdateAsync(int id,  Student newStudent)
        {
            Student st = _context.Students.Find(id);
            if (st != null)
            { 
                st.Name = newStudent.Name;
                st.Age = newStudent.Age;
                st.Status = newStudent.Status;
            }
            await _context.SaveChangesAsync();
            return st;
        }
      
        public async Task<Student> UpdateStatusAsync(int id, int status, Student newStudent)
        {
            Student st = _context.Students.Find(id);
            if (st == null)
            {
                st.Name = newStudent.Name;
                st.Age = newStudent.Age;
                st.Status = status;
            }
            await _context.SaveChangesAsync();
            return st;
        }
        public async Task<Student> DeleteAsync(int id)
        {
            Student st = _context.Students.Find(id);
            _context.Students.Remove(st);
            await _context.SaveChangesAsync();
            return st;
        }
    }
}
