// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SchoolSystem.Api.Mappings;
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Contracts.Requests.Rooms;
    using System.Threading.Tasks;

    [Route("api/rooms/")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetRoomsAsync();
            var response = rooms.MapToResponse();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var room = await _roomService.GetRoomAsync(id);
            if (room == null) return NotFound();
            var response = room.MapToResponse();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomRequest request)
        {
            var room = request.MapToEntity();
            await _roomService.CreateRoomAsync(room);
            var response = room.MapToResponse();
            //return CreatedAtAction(nameof(GetAsync), new { id = room.Id }, response);
            return CreatedAtAction(nameof(Get), new { id = room.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoomRequest request)
        {
            var room = request.MapToEntity(id);
            var updatedMovie = await _roomService.UpdateRoomAsync(room);
            if (updatedMovie is null) return NotFound();
            var response = room.MapToResponse();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _roomService.DeleteRoomAsync(id);
            if (deleted is false) return NotFound();
            return Ok();
        }
    }
}
