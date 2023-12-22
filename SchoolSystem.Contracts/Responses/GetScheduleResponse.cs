namespace SchoolSystem.Contracts.Responses
{
    using System;
    using System.Collections.Generic;

    public class GetScheduleResponse
    {
        public required int Id { get; init; }
        public required DateTime StartTime { get; init; }
        public required DateTime FinishTime { get; init; }
        public required DayOfWeek Day { get; init; }
        public required GetRoomResponse Room { get; init; }
        public required GetTeacherResponse Teacher { get; init; }
        public List<GetStudentResponse> Students { get; init; } = new();
    }
}
