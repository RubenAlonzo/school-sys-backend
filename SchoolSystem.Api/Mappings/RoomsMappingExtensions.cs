﻿namespace SchoolSystem.Api.Mappings
{
    using SchoolSystem.Persistence.Options;
    using SchoolSystem.Contracts.Requests.Rooms;
    using SchoolSystem.Contracts.Responses;
    using SchoolSystem.Domain.Entities;

    public static class RoomsMappingExtensions
    {
        internal static GetRoomResponse MapToResponse(this IEnumerable<RoomEntity> rooms, int page, int pageSize, int count)
        {
            return new GetRoomResponse()
            {
                Items = rooms.Select(MapToResponse),
                Page = page,
                PageSize = pageSize,
                Total = count,
            };
        }

        internal static RoomResponse MapToResponse(this RoomEntity room)
        {
            return new RoomResponse()
            {
                Id = room.Id,
                Capacity = room.Capacity,
                Location = room.Location,
                Name = room.Name,
            };
        }
        
        internal static RoomEntity MapToEntity(this RoomResponse response)
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
                Page = request.Page,
                PageSize = request.PageSize,
            };
        }
    }
}
