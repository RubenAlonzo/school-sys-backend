namespace SchoolSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SchoolSystem.Api.Mappings;
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Contracts.Requests.Rooms;
    using SchoolSystem.Contracts.Requests.Schedules;

    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet(ApiEndpoints.Schedule.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _scheduleService.GetAsync();
            var response = schedules.MapToResponse();
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Schedule.Get)]
        public async Task<IActionResult> Get(int id)
        {
            var schedule = await _scheduleService.GetByIdAsync(id);
            if (schedule is null) return NotFound();
            var response = schedule.MapToResponse();
            return Ok(response);
        }

        [HttpPost(ApiEndpoints.Schedule.Create)]
        public async Task<IActionResult> Create(CreateScheduleRequest request)
        {
            var schedule = request.MapToEntity();
            await _scheduleService.CreateAsync(schedule);
            var response = schedule.MapToResponse();
            return CreatedAtAction(nameof(Get), new { id = schedule.Id }, response);
        }



        [HttpPut(ApiEndpoints.Schedule.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateScheduleRequest request)
        {
            var schedude = request.MapToEntity(id);
            var updatedSchedule = await _scheduleService.UpdateAsync(schedude);
            if (updatedSchedule is null) return NotFound();
            var response = updatedSchedule.MapToResponse();
            return Ok(response);
        }
        
        [HttpDelete(ApiEndpoints.Schedule.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _scheduleService.DeleteAsync(id);
            if (deleted is false) return NotFound();
            return Ok();
        }
    }
}
