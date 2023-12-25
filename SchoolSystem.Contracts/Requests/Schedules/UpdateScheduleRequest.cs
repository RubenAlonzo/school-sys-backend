﻿namespace SchoolSystem.Contracts.Requests.Schedules
{
    using SchoolSystem.Contracts.Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UpdateScheduleRequest
    {
        public required DateTime StartTime { get; init; }
        public required DateTime FinishTime { get; init; }
        public required DayOfWeek Day { get; init; }
        public required GetRoomResponse Room { get; init; }
        public required GetTeacherResponse Teacher { get; init; }
        public IEnumerable<GetStudentResponse> Students { get; init; } = Enumerable.Empty<GetStudentResponse>();
    }
}
