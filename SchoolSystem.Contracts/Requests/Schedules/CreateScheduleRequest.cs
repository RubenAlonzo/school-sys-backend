namespace SchoolSystem.Contracts.Requests.Schedules
{
    using System;
    using System.Collections.Generic;

    public class CreateScheduleRequest
    {
        public required TimeOnly StartTime { get; init; }
        public required TimeOnly FinishTime { get; init; }
        public required DayOfWeek Day { get; init; }
        public required int RoomId { get; init; }
        public required int TeacherId { get; init; }
        public IEnumerable<int> StudentIds { get; init; } = Enumerable.Empty<int>();
    }
}
