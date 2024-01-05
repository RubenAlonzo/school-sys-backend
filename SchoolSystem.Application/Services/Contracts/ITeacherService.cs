namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITeacherService
    {
        Task CreateAsync(TeacherEntity teacher);
        Task<bool> DeleteAsync(int id);
        IEnumerable<TeacherEntity> GetAll();
        TeacherEntity? GetById(int id);
        Task<TeacherEntity?> UpdateAsync(TeacherEntity teacher);
    }
}
