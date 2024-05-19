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
    public class TeacherService: ITeacherService
    {
        private readonly ITeacherRepository _repository;
        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Teacher> Get() => _repository.Get().Where(e => e.Status == 1);
        public Teacher GetById(int id) => _repository.GetById(id);
        public async Task<Teacher> AddAsync(Teacher t)
        {
            await _repository.AddAsync(t);
            return t;
        }
        public async Task<Teacher> UpdateAsync(int id, Teacher t)=>await _repository.UpdateAsync(id, t);
       
        public async Task<Teacher> UpdateStatusAsync(int id, int status, Teacher t)=> await _repository.UpdateStatusAsync(id,status,t);
        public async Task<Teacher> DeleteAsync(int id)
        {
           return await _repository.DeleteAsync(id);
        }
    }
}
