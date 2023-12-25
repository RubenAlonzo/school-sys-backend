namespace SchoolSystem.Api.Mappings
{
    using SchoolSystem.Application.Entities;
    using SchoolSystem.Contracts.Requests.Schedules;
    using SchoolSystem.Contracts.Responses;

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
                Room = schedule.Room.MapToResponse(),
                Teacher = schedule.Teacher.MapToRespone(),
                Students = schedule.Students.MapToRespone(),
            };
        }

        public static ScheduleEntity MapToEntity(this CreateScheduleRequest request)
        {
            return new ScheduleEntity()
            {
                Day = request.Day,
                StartTime = request.StartTime,
                FinishTime = request.FinishTime,
                Room = request.Room.MapToEntity(),
                Teacher = request.Teacher.MapToEntity(),
                Students = request.Students.MapToEntity()
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
