namespace SchoolSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SchoolSystem.Api.Mappings;
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Contracts.Requests.Students;

    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _userService;

        public StudentController(IStudentService userService)
        {
            _userService = userService;
        }

        [HttpGet(ApiEndpoints.Users.Students.GetAll)]
        public IActionResult GetAllStudents()
        {
            var students = _userService.GetAll();
            var response = students.MapToRespone();
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Users.Students.Get)]
        public IActionResult Get(int id)
        {
            var student = _userService.GetById(id);
            if (student is null) return NotFound();
            var response = student.MapToRespone();
            return Ok(response);
        }

        [HttpPost(ApiEndpoints.Users.Students.Create)]
        public async Task<IActionResult> Create(CreateStudentRequest request)
        {
            var student = request.MapToEntity();
            await _userService.CreateAsync(student);
            var response = student.MapToRespone();
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPost(ApiEndpoints.Users.Students.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateStudentRequest request)
        {
            var student = request.MapToEntity(id);
            await _userService.UpdateAsync(student);
            if (student is null) return NotFound();
            var response = student.MapToRespone();
            return Ok(response);
        }

        [HttpPost(ApiEndpoints.Users.Students.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _userService.DeleteAsync(id);
            if(deleted is false) return NotFound();
            return Ok();
        }
    }
}
