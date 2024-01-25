namespace SchoolSystem.Domain.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public class UserEntity : IdentityUser<int>
    {
    }
}
