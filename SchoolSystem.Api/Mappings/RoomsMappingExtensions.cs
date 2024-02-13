namespace SchoolSystem.Api.Mappings
{
    using SchoolSystem.Persistence.Options;
    using SchoolSystem.Contracts.Requests.Rooms;
    using SchoolSystem.Contracts.Responses;
    using SchoolSystem.Domain.Entities;

    public static class RoomsMappingExtensions
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
        
        internal static RoomEntity MapToEntity(this GetRoomResponse response)
        {
            return new RoomEntity()
            {
                Id = response.Id,
                Capacity = response.Capacity,
                Location = response.Location,
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

        internal static GetAllRoomsOption MapToOption(this GetAllRoomsRequest request)
        {
            return new()
            {
                Capacity = request.Capacity,
                Location = request.Location,
                SortField = request.SortBy?.Trim('+', '-'),
                SortOrder = request.SortBy is null ? SortOrder.UnSorted :
                    request.SortBy.StartsWith('-') ? SortOrder.Descending : SortOrder.Ascending,
            };
        }
    }
}
