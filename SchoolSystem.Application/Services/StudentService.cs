namespace SchoolSystem.Application.Services
{
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class StudentService : IStudentService
    {
        private static readonly List<StudentEntity> _students = new List<StudentEntity>();
        private int _index = 1;
        public Task CreateAsync(StudentEntity student)
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

        public Task<IEnumerable<StudentEntity>> GetAsync()
        {
            return Task.FromResult(_students.AsEnumerable());
        }

        public Task<StudentEntity?> GetByIdAsync(int id)
        {
            return Task.FromResult(_students.FirstOrDefault(x => x.Id == id));
        }

        public Task<StudentEntity?> UpdateAsync(StudentEntity student)
        {
            var currentStudent = _students.FirstOrDefault(x => x.Id == student.Id);
            if (currentStudent is null) return Task.FromResult<StudentEntity?>(null);
            _students.Remove(currentStudent);
            _students.Add(student);
            return Task.FromResult<StudentEntity?>(student);
        }
    }
}
