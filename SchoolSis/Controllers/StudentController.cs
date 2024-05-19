using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Core.DTOs;
using School.Core.Services;
using School.Service;
using SchoolSis.API.Models;
using SchoolSis.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolSis.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class StudentController : ControllerBase
  {

    // GET: api/<StudentsController>
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;

    public StudentController(IStudentService studentService, IMapper mapper)
    {
      _studentService = studentService;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult Get()
    {
      var list = _studentService.Get();
      var listDto = list.Select(u => _mapper.Map<StudentDto>(u));
      return Ok(listDto);
    }

    // GET api/<StudentsController>/5
    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id)
    {
      var s = _studentService.GetById(id);
      var studentDto = _mapper.Map<StudentDto>(s);
      return Ok(studentDto);
    }

    // POST api/<StudentsController>
    [HttpPost]
    public async Task Post([FromBody] StudentPostModel student)
    {
      var studentToAdd = _mapper.Map<Student>(student);
      var addedStudent = await _studentService.AddAsync(studentToAdd);
      var studentDto = _mapper.Map<StudentDto>(addedStudent);

    }

    // PUT api/<StudentsController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] StudentPostModel newStudent)
    {

      var existStudent = _studentService.GetById(id);
      if (existStudent is null)
      {
        return NotFound();
      }
      _mapper.Map(newStudent, existStudent);
      _studentService.UpdateAsync(id, existStudent);

      return Ok(_mapper.Map<StudentDto>(existStudent));
    }
    [HttpPut("{id}/{status}")]
    public ActionResult Put(int id, int status, [FromBody] StudentPostModel newStudent)
    {

      var existStudent = _studentService.GetById(id);
      if (existStudent is null)
      {
        return NotFound();
      }
      _mapper.Map(newStudent, existStudent);
      _studentService.UpdateStatusAsync(id, status, existStudent);

      return Ok(_mapper.Map<StudentDto>(existStudent));
    }

    // DELETE api/<StudentsController>/5
    [HttpDelete("{id}")]

    public async Task Delete(int id)
    {
      await _studentService.DeleteAsync(id);
    }
  }
}
