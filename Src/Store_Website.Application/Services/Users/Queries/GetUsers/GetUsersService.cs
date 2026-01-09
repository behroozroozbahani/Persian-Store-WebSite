using Microsoft.EntityFrameworkCore;
using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Application.Services.Users.Queries.GetRoles;
using Store_Website.Common;
using Store_Website.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Store_Website.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }


        public ReslutGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.Include(x => x.UserInRoles)
                                      .ThenInclude(x => x.Role)
                                      .AsQueryable();

            var roles = _context.Roles.ToList();

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName
                             .Contains(request.SearchKey) && p.Email
                             .Contains(request.SearchKey));
            }

            int rowsCount = 0;
            var usersList = users.ToPaged(request.Page, 20, out rowsCount)
                                 .Select(p => new GetUsersDto
                                 {
                                     Email = p.Email,
                                     FullName = p.FullName,
                                     Id = p.Id,
                                     IsActive = p.IsActive,
                                     RoleName = p.UserInRoles.FirstOrDefault().Role.Name,
                                     RoleId = p.UserInRoles.FirstOrDefault().Role.Id
                                 }).ToList();

            return new ReslutGetUserDto
            {
                Rows = rowsCount,
                Users = usersList,
                Roles = roles,
            };
        }
    }
}
