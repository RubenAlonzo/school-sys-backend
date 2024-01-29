namespace SchoolSystem.Api.Mappings
{
    using SchoolSystem.Contracts.Requests.Teachers;
    using SchoolSystem.Contracts.Responses;
    using SchoolSystem.Domain.Entities;

    internal static class TeacherMappingExtensions
    {
        internal static IEnumerable<GetTeacherResponse> MapToRespone(this IEnumerable<TeacherEntity> teachers)
        {
            return teachers.Select(MapToRespone);
        }

        internal static GetTeacherResponse MapToRespone(this TeacherEntity teacher)
        {
            return new GetTeacherResponse
            {
                Address = teacher.Address,
                Id = teacher.Id,
                Email = teacher.User!.Email!,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Subject = teacher.Subject,
                Expertise = teacher.Expertise,
            };
        }
        internal static TeacherEntity MapToEntity(this GetTeacherResponse response)
        {
            return new TeacherEntity
            {
                Address = response.Address,
                Id = response.Id,
                FirstName = response.FirstName,
                LastName = response.LastName,
                Subject = response.Subject,
                Expertise = response.Expertise,
            };
        }

        internal static TeacherEntity MapToEntity(this CreateTeacherRequest request)
        {
            return new TeacherEntity
            {
                Address = request.Address,
                User = new UserEntity() { Email = request.Email, UserName = request.Email },
                FirstName = request.FirstName,
                LastName = request.LastName,
                Subject = request.Subject,
                Expertise = request.Expertise,
            };
        }

        internal static TeacherEntity MapToEntity(this UpdateTeacherRequest request, int id)
        {
            return new TeacherEntity
            {
                Id = id,
                User = new UserEntity() { Email = request.Email, UserName = request.Email },
                Address = request.Address,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Subject = request.Subject,
                Expertise = request.Expertise,
            };
        }
    }
}
