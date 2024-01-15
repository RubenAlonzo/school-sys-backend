namespace SchoolSystem.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class ScheduleEntity
    {
        public int Id { get; set; }
        public required TimeOnly StartTime { get; set; }
        public required TimeOnly FinishTime { get; set; }
        public required DayOfWeek Day { get; set; }
        public int RoomId { get; set; }
        public RoomEntity? Room { get; set; }
        public int TeacherId { get; set; }
        public TeacherEntity? Teacher { get; set; }
        public IEnumerable<StudentEntity> Students { get; set; } = Enumerable.Empty<StudentEntity>();
    }
}
