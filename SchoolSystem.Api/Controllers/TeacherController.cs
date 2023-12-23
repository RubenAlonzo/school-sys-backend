﻿namespace SchoolSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SchoolSystem.Api.Mappings;
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Contracts.Requests.Teachers;

    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet(ApiEndpoints.Users.Teachers.GetAll)]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAsync();
            var response = teachers.MapToRespone();
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Users.Teachers.Get)]
        public async Task<IActionResult> Get(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            if (teacher is null) return NotFound();
            var response = teacher.MapToRespone();
            return Ok(response);
        }

        [HttpPost(ApiEndpoints.Users.Teachers.Create)]
        public async Task<IActionResult> Create(CreateTeacherRequest request)
        {
            var teacher = request.MapToEntity();
            await _teacherService.CreateAsync(teacher);
            var response = teacher.MapToRespone();
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPost(ApiEndpoints.Users.Teachers.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateTeacherRequest  
            request)
        {
            var teacher = request.MapToEntity(id);
            await _teacherService.UpdateAsync(teacher);
            if (teacher is null) return NotFound();
            var response = teacher.MapToRespone();
            return Ok(response);
        }

        [HttpPost(ApiEndpoints.Users.Teachers.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _teacherService.DeleteAsync(id);
            if (deleted is false) return NotFound();
            return Ok();
        }
    }
}
