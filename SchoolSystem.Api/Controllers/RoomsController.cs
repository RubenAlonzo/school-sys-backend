namespace SchoolSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SchoolSystem.Api.Mappings;
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Contracts.Requests.Rooms;
    using System.Threading.Tasks;

    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet(ApiEndpoints.Rooms.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAsync();
            var response = rooms.MapToResponse();
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Rooms.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null) return NotFound();
            var response = room.MapToResponse();
            return Ok(response);
        }

        [HttpPost(ApiEndpoints.Rooms.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRoomRequest request)
        {
            var room = request.MapToEntity();
            await _roomService.CreateAsync(room);
            var response = room.MapToResponse();
            return CreatedAtAction(nameof(Get), new { id = room.Id }, response);
        }

        [HttpPut(ApiEndpoints.Rooms.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoomRequest request)
        {
            var room = request.MapToEntity(id);
            var updatedMovie = await _roomService.UpdateAsync(room);
            if (updatedMovie is null) return NotFound();
            var response = room.MapToResponse();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Rooms.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _roomService.DeleteAsync(id);
            if (deleted is false) return NotFound();
            return Ok();
        }
    }
}
