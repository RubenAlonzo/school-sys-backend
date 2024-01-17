namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITeacherService
    {
        Task CreateAsync(TeacherEntity teacher, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
        IEnumerable<TeacherEntity> GetAll();
        TeacherEntity? GetById(int id);
        Task<TeacherEntity?> UpdateAsync(TeacherEntity teacher, CancellationToken cancellationToken = default);
    }
}
