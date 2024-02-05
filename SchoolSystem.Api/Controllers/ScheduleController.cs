namespace SchoolSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SchoolSystem.Api.Auth;
    using SchoolSystem.Api.Mappings;
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Contracts.Requests.Schedules;

    [Authorize]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [Authorize(Roles = $"{AuthConsts.Admin},{AuthConsts.Teacher}")]
        [HttpGet(ApiEndpoints.Schedule.GetAll)]
        public IActionResult GetAll()
        {
            var schedules = _scheduleService.GetAll();
            var response = schedules.MapToResponse();
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Schedule.Get)]
        public IActionResult Get(int id)
        {
            var schedule = _scheduleService.GetById(id);
            if (schedule is null) return NotFound();
            var response = schedule.MapToResponse();
            return Ok(response);
        }

        [Authorize(Roles = AuthConsts.Admin)]
        [HttpPost(ApiEndpoints.Schedule.Create)]
        public async Task<IActionResult> Create(CreateScheduleRequest request, CancellationToken cancellationToken)
        {
            var schedule = request.MapToEntity();
            await _scheduleService.CreateAsync(schedule, request.StudentIds, cancellationToken);
            var response = schedule.MapToResponse();
            return CreatedAtAction(nameof(Get), new { id = schedule.Id }, response);
        }



        [Authorize(Roles = AuthConsts.Admin)]
        [HttpPut(ApiEndpoints.Schedule.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateScheduleRequest request, CancellationToken cancellationToken)
        {
            var schedude = request.MapToEntity(id);
            var updatedSchedule = await _scheduleService.UpdateAsync(schedude, request.StudentIds, cancellationToken);
            if (updatedSchedule is null) return NotFound();
            var response = updatedSchedule.MapToResponse();
            return Ok(response);
        }

        [Authorize(Roles = AuthConsts.Admin)]
        [HttpDelete(ApiEndpoints.Schedule.Delete)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _scheduleService.DeleteAsync(id, cancellationToken);
            if (deleted is false) return NotFound();
            return Ok();
        }
    }
}
