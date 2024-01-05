namespace SchoolSystem.Application.Services
{
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(StudentEntity student)
        {
            _unitOfWork.Students.Add(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = _unitOfWork.Students.FirstOrDefault(x => x.Id == id);
            if (student is null) return false;
            _unitOfWork.Students.Remove(student);

            return (await _unitOfWork.SaveChangesAsync()) > 0;
        }

        public IEnumerable<StudentEntity> GetAll()
        {
            return _unitOfWork.Students.GetAll();
        }

        public StudentEntity? GetById(int id)
        {
            return _unitOfWork.Students.FirstOrDefault(x => x.Id == id));
        }

        public async Task<StudentEntity?> UpdateAsync(StudentEntity student)
        {
            var currentStudent = _unitOfWork.Students.FirstOrDefault(x => x.Id == student.Id);
            if (currentStudent is null) return null;
            _unitOfWork.Students.Remove(currentStudent);
            _unitOfWork.Students.Add(student);
            await _unitOfWork.SaveChangesAsync();
            return student;
        }
    }
}
