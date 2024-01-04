namespace SchoolSystem.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class ScheduleEntity
    {
        public int Id { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime FinishTime { get; set; }
        public required DayOfWeek Day { get; set; }
        public required RoomEntity Room { get; set; }
        public required TeacherEntity Teacher { get; set; }
        public IEnumerable<StudentEntity> Students { get; set; } = Enumerable.Empty<StudentEntity>();
    }
}
