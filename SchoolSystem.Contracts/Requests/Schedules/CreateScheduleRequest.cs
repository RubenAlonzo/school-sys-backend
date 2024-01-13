namespace SchoolSystem.Contracts.Requests.Schedules
{
    using SchoolSystem.Contracts.Responses;
    using System;
    using System.Collections.Generic;

    public class CreateScheduleRequest
    {
        public required TimeOnly StartTime { get; init; }
        public required TimeOnly FinishTime { get; init; }
        public required DayOfWeek Day { get; init; }
        public required GetRoomResponse Room { get; init; }
        public required GetTeacherResponse Teacher { get; init; }
        public IEnumerable<GetStudentResponse> Students { get; init; } = Enumerable.Empty<GetStudentResponse>();
    }
}
