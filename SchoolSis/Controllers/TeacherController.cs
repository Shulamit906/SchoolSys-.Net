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
  public class TeacherController : ControllerBase
  {
    private readonly ITeacherService _teacherService;
    private readonly IMapper _mapper;
    public TeacherController(ITeacherService teacherService, IMapper mapper)
    {
      _teacherService = teacherService;
      _mapper = mapper;
    }
    // GET: api/<TheacherController>
    [HttpGet]
    public ActionResult Get()
    {
      var list = _teacherService.Get();
      var listDto = list.Select(u => _mapper.Map<TeacherDto>(u));
      return Ok(listDto);
    }

    // GET api/<TheacherController>/5
    [HttpGet("{id}")]
    public ActionResult<Teacher> GetById(int id)
    {
      var t = _teacherService.GetById(id);
      var teacherDto = _mapper.Map<TeacherDto>(t);
      return Ok(teacherDto);
    }

    // POST api/<TheacherController>
    [HttpPost]
    public async Task Add([FromBody] TeacherPostModel t)
    {
      var teacherToAdd = _mapper.Map<Teacher>(t);
      var addedTeacher = await _teacherService.AddAsync(teacherToAdd);
      var teacherDto = _mapper.Map<TeacherDto>(addedTeacher);
    }

    // PUT api/<TheacherController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] TeacherPostModel t)
    {
      var existTeacher = _teacherService.GetById(id);
      if (existTeacher is null)
      {
        return NotFound();
      }
      _mapper.Map(t, existTeacher);
      await _teacherService.UpdateAsync(id, existTeacher);

      return Ok(_mapper.Map<TeacherDto>(existTeacher));
    }
    [HttpPut("{id}/{status}")]
    public async Task<ActionResult> UpdateStatus(int id, int status, [FromBody] TeacherPostModel t)
    {
      var existTeacher = _teacherService.GetById(id);
      if (existTeacher is null)
      {
        return NotFound();
      }
      _mapper.Map(t, existTeacher);
      await _teacherService.UpdateStatusAsync(id, status, existTeacher);

      return Ok(_mapper.Map<TeacherDto>(existTeacher));
    }


    // DELETE api/<TheacherController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
      await _teacherService.DeleteAsync(id);
    }
  }
}
