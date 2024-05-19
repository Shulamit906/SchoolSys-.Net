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
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
                _studentRepository = studentRepository;
        }
        public IEnumerable<Student> Get() => _studentRepository.Get().Where(e => e.Status == 1);


        public Student GetById(int id) => _studentRepository.GetById(id);

        public async Task<Student> AddAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            return student;
        }

        public async Task<Student> UpdateAsync(int id, Student newStudent) => await _studentRepository.UpdateAsync(id, newStudent);



        public async Task<Student> UpdateStatusAsync(int id, int status, Student newStudent) => await _studentRepository.UpdateStatusAsync(id,status,newStudent);


        public async Task<Student> DeleteAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }


    }
}
