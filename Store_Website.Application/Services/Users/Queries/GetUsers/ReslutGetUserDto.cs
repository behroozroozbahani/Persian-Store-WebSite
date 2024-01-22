using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Website.Application.Services.Users.Queries.GetUsers
{
    public class ReslutGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
