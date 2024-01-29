namespace SchoolSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SchoolSystem.Api.Mappings;
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Contracts.Requests.Teachers;

    [Authorize]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet(ApiEndpoints.Users.Teachers.GetAll)]
        public IActionResult GetAllTeachers()
        {
            var teachers = _teacherService.GetAll();
            var response = teachers.MapToRespone();
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Users.Teachers.Get)]
        public IActionResult Get(int id)
        {
            var teacher = _teacherService.GetById(id);
            if (teacher is null) return NotFound();
            var response = teacher.MapToRespone();
            return Ok(response);
        }

        [HttpPost(ApiEndpoints.Users.Teachers.Create)]
        public async Task<IActionResult> Create(CreateTeacherRequest request, CancellationToken cancellationToken)
        {
            var teacher = request.MapToEntity();
            await _teacherService.CreateAsync(teacher, cancellationToken);
            var response = teacher.MapToRespone();
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut(ApiEndpoints.Users.Teachers.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateTeacherRequest  
            request, CancellationToken cancellationToken)
        {
            var teacher = request.MapToEntity(id);
            await _teacherService.UpdateAsync(teacher, cancellationToken);
            if (teacher is null) return NotFound();
            var response = teacher.MapToRespone();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Users.Teachers.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            var deleted = await _teacherService.DeleteAsync(id, cancellationToken);
            if (deleted is false) return NotFound();
            return Ok();
        }
    }
}
