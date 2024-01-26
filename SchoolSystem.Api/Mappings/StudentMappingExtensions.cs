namespace SchoolSystem.Api.Mappings
{
    using SchoolSystem.Contracts.Requests.Students;
    using SchoolSystem.Contracts.Responses;
    using SchoolSystem.Domain.Entities;

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
                Email = student.User!.Email!,
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
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
                Birthday= request.Birthday,
                FatherName = request.FatherName,
                MotherName = request.MotherName,
                User = new UserEntity() { Email = request.Email, UserName = request.Email },
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
                Birthday= request.Birthday,
                FatherName = request.FatherName,
                MotherName = request.MotherName,
                User = new UserEntity() { Email = request.Email, UserName = request.Email },
            };
        }
    }
}
