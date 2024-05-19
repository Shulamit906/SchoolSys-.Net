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
    public class TeacherRepository: ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context)
        {
           _context = context;
        }
        static int id = 4;
        
        public IEnumerable<Teacher> Get()
        {
            return _context.Teachers;
        }
        public Teacher GetById(int id)
        {
           return _context.Teachers.ToList().Find(item => item.Id == id);
        }
        public async Task<Teacher> AddAsync( Teacher t)
        {
            _context.Teachers.Add(t);
            await _context.SaveChangesAsync();
            return t;
        }
        public async Task<Teacher> UpdateAsync(int id, Teacher t)
        {
            Teacher te = _context.Teachers.Find(id);
            if (te != null)
            {
                te.Name = t.Name;
                te.Subject = t.Subject;
                te.Status = t.Status;
            }
            await _context.SaveChangesAsync();
            return te;
        }
     
        public async Task<Teacher> UpdateStatusAsync(int id, int status, Teacher t)
        {
            Teacher te = _context.Teachers.Find(id);
            if (te != null)
            {
                _context.Teachers.Remove(te);
                te.Name = t.Name;
                te.Subject = t.Subject;
                te.Status = status;
                
            }
            await _context.SaveChangesAsync();
            return t;
        }
        public async Task<Teacher> DeleteAsync(int id)
        {
            Teacher te = _context.Teachers.Find(id);
            _context.Teachers.Remove(te);
            await _context.SaveChangesAsync();
            return te;
        }
    }
}
