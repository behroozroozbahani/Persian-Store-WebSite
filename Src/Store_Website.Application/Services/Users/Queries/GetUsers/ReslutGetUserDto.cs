using Store_Website.Domain.Entities.Users;
using System.Collections.Generic;

namespace Store_Website.Application.Services.Users.Queries.GetUsers
{
    public class ReslutGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
        public List<Role> Roles { get; set; }
        public int Rows { get; set; }
    }
}
