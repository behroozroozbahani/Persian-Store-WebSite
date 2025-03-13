using System.Collections;

namespace Store_Website.Application.Services.Users.Commands.EditUser
{
    public class RequestEdituserDto
    {
        public long UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
