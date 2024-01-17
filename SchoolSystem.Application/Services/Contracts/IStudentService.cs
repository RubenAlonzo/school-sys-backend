namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStudentService
    {
        Task CreateAsync(StudentEntity student, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
        IEnumerable<StudentEntity> GetAll();
        StudentEntity? GetById(int id);
        Task<StudentEntity?> UpdateAsync(StudentEntity student, CancellationToken cancellationToken = default);
    }
}
