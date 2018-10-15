using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Dtos
{
    public class UserDto
    {
        public long? UserId { get; set; }
        public string Username { get; set; }
        public long? RoleId { get; set; }
        public string Password { get; set; }
    }
}