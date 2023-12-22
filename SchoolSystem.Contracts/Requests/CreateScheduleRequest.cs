namespace SchoolSystem.Contracts.Requests
{
    using SchoolSystem.Contracts.Responses;
    using System;
    using System.Collections.Generic;

    internal class CreateScheduleRequest
    {
        public required DateTime StartTime { get; init; }
        public required DateTime FinishTime { get; init; }
        public required DayOfWeek Day { get; init; }
        public required GetRoomResponse Room { get; init; }
        public required GetTeacherResponse Teacher { get; init; }
        public List<GetStudentResponse> Students { get; init; } = new();
    }
}
