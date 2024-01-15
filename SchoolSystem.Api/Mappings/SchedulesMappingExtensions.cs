namespace SchoolSystem.Api.Mappings
{
    using SchoolSystem.Contracts.Requests.Schedules;
    using SchoolSystem.Contracts.Responses;
    using SchoolSystem.Domain.Entities;

    internal static class SchedulesMappingExtensions
    {
        public static IEnumerable<GetScheduleResponse> MapToResponse(this IEnumerable<ScheduleEntity> schedules)
        {
            return schedules.Select(MapToResponse);
        }

        public static GetScheduleResponse MapToResponse(this ScheduleEntity schedule)
        {
            return new GetScheduleResponse()
            {
                Id = schedule.Id,
                Day = schedule.Day,
                StartTime = schedule.StartTime,
                FinishTime = schedule.FinishTime,
                RoomId = schedule.RoomId,
                TeacherId = schedule.TeacherId,
                StudentIds = schedule.Students.Select(x => x.Id),
            };
        }

        public static ScheduleEntity MapToEntity(this CreateScheduleRequest request)
        {
            return new ScheduleEntity()
            {
                Day = request.Day,
                StartTime = request.StartTime,
                FinishTime = request.FinishTime,
                RoomId = request.RoomId,
                TeacherId = request.TeacherId,
            };
        }

        public static ScheduleEntity MapToEntity(this UpdateScheduleRequest request, int id)
        {
            return new ScheduleEntity()
            {
                Id = id,
                Day = request.Day,
                StartTime = request.StartTime,
                FinishTime = request.FinishTime,
                Room = request.Room.MapToEntity(),
                Teacher = request.Teacher.MapToEntity(),
                Students = request.Students.MapToEntity()
            };
        }
    }
}
