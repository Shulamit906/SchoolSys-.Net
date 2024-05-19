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
  public class CourseController : ControllerBase
  {
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;
    public CourseController(ICourseService courseService, IMapper mapper)
    {
      _courseService = courseService;
      _mapper = mapper;
    }

    // GET: api/<CourseController>
    [HttpGet]
    public ActionResult Get()
    {
      var list = _courseService.Get();
      var listDto = list.Select(u => _mapper.Map<CourseDto>(u));
      return Ok(listDto);
    }

    // GET api/<CourseController>/5
    [HttpGet("{id}")]
    public ActionResult<Course> Get(int id)
    {
      var c = _courseService.GetById(id);
      var courseDto = _mapper.Map<CourseDto>(c);
      return Ok(courseDto);
    }

    // POST api/<CourseController>
    [HttpPost]
    public async Task Post([FromBody] CoursePostModel course)
    {
      var courseToAdd = _mapper.Map<Course>(course);
      var addedCourse = await _courseService.AddAsync(courseToAdd);
      var courseDto = _mapper.Map<CourseDto>(addedCourse);
    }

    // PUT api/<CourseController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] CoursePostModel course)
    {
      var existCourse = _courseService.GetById(id);
      if (existCourse is null)
      {
        return NotFound();
      }
      _mapper.Map(course, existCourse);
      await _courseService.UpdateAsync(id, existCourse);

      return Ok(_mapper.Map<CourseDto>(existCourse));
    }

    // DELETE api/<CourseController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
      await _courseService.DeleteAsync(id);
    }
  }
}
