﻿namespace SchoolSystem.Api.Mappings
{
    using SchoolSystem.Application.Entities;
    using SchoolSystem.Contracts.Requests.Students;
    using SchoolSystem.Contracts.Responses;

    public static class StudentMappingExtensions
    {
        internal static IEnumerable<GetStudentResponse> MapToRespone(this IEnumerable<StudentEntity> students)
        {
            return students.Select(MapToRespone);
        }

        internal static GetStudentResponse MapToRespone(this StudentEntity student)
        {
            return new GetStudentResponse 
            { 
                Address = student.Address,
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                RegistrationNumber = student.RegistrationNumber,
                Birthday = student.Birthday,
                FatherName = student.FatherName,
                MotherName = student.MotherName,
            };
        }

        internal static IEnumerable<StudentEntity> MapToEntity(this IEnumerable<GetStudentResponse> students)
        {
            return students.Select(MapToEntity);
        }

        internal static StudentEntity MapToEntity(this GetStudentResponse response)
        {
            return new StudentEntity
            { 
                Address = response.Address,
                Id = response.Id,
                FirstName = response.FirstName,
                LastName = response.LastName,
                Email = response.Email,
                Birthday = response.Birthday,
                FatherName = response.FatherName,
                MotherName = response.MotherName,
            };
        }

        internal static StudentEntity MapToEntity(this CreateStudentRequest request)
        {
            return new StudentEntity
            {
                Address = request.Address,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Birthday= request.Birthday,
                FatherName = request.FatherName,
                MotherName = request.MotherName,
            };
        }

        internal static StudentEntity MapToEntity(this UpdateStudentRequest request, int id)
        {
            return new StudentEntity
            {
                Id = id,
                Address = request.Address,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Birthday= request.Birthday,
                FatherName = request.FatherName,
                MotherName = request.MotherName,
            };
        }
    }
}