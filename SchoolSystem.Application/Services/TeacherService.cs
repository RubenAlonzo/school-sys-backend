﻿namespace SchoolSystem.Application.Services
{
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(TeacherEntity student)
        {
            _unitOfWork.Teachers.Add(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = _unitOfWork.Teachers.FirstOrDefault(x => x.Id == id);
            if (student is null) return false;
            _unitOfWork.Teachers.Remove(student);
            return (await _unitOfWork.SaveChangesAsync()) > 0;
        }

        public IEnumerable<TeacherEntity> GetAll()
        {
            return _unitOfWork.Teachers.GetAll();
        }

        public TeacherEntity? GetById(int id)
        {
            return _unitOfWork.Teachers.FirstOrDefault(x => x.Id == id);
        }

        public async Task<TeacherEntity?> UpdateAsync(TeacherEntity student)
        {
            var currentStudent = _unitOfWork.Teachers.FirstOrDefault(x => x.Id == student.Id);
            if (currentStudent is null) return null;
            _unitOfWork.Teachers.Remove(currentStudent);
            _unitOfWork.Teachers.Add(student);
            await _unitOfWork.SaveChangesAsync();
            return student;
        }
    }
}
