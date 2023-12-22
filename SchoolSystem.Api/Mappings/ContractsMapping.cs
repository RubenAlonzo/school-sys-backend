namespace SchoolSystem.Api.Mappings
{
    using SchoolSystem.Application.Entities;
    using SchoolSystem.Contracts.Requests.Rooms;
    using SchoolSystem.Contracts.Responses;

    public static class ContractsMapping
    {
        internal static IEnumerable<GetRoomResponse> MapToResponse(this IEnumerable<RoomEntity> rooms)
        {
            return rooms.Select(MapToResponse);
        }

        internal static GetRoomResponse MapToResponse(this RoomEntity room)
        {
            return new GetRoomResponse()
            {
                Id = room.Id,
                Capacity = room.Capacity,
                Location = room.Location,
                Name = room.Name,
            };
        }

        internal static RoomEntity MapToEntity(this CreateRoomRequest request)
        {
            return new RoomEntity()
            {
                Capacity = request.Capacity,
                Location = request.Location,
            };
        }

        internal static RoomEntity MapToEntity(this UpdateRoomRequest request, int id)
        {
            return new RoomEntity()
            {
                Id = id,
                Capacity = request.Capacity,
                Location = request.Location,
            };
        }
    }
}
