namespace SchoolSystem.Application.Services
{
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class TeacherService : ITeacherService
    {
        private static readonly List<TeacherEntity> _students = new List<TeacherEntity>();
        private int _index = 1;
        public Task CreateAsync(TeacherEntity student)
        {
            student.Id = _index++;
            _students.Add(student);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var student = _students.FirstOrDefault(x => x.Id == id);
            if (student is null) return Task.FromResult(false);
            _students.Remove(student);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<TeacherEntity>> GetAsync()
        {
            return Task.FromResult(_students.AsEnumerable());
        }

        public Task<TeacherEntity?> GetByIdAsync(int id)
        {
            return Task.FromResult(_students.FirstOrDefault(x => x.Id == id));
        }

        public Task<TeacherEntity?> UpdateAsync(TeacherEntity student)
        {
            var currentStudent = _students.FirstOrDefault(x => x.Id == student.Id);
            if (currentStudent is null) return Task.FromResult<TeacherEntity?>(null);
            _students.Remove(currentStudent);
            _students.Add(student);
            return Task.FromResult<TeacherEntity?>(student);
        }
    }
}
