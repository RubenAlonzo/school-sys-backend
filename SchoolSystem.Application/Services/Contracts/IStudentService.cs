namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStudentService
    {
        Task CreateAsync(StudentEntity student);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<StudentEntity>> GetAsync();
        Task<StudentEntity?> GetByIdAsync(int id);
        Task<StudentEntity?> UpdateAsync(StudentEntity student);
    }
}
