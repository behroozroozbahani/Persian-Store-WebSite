using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Common.Dto;
using System.Linq;

namespace Store_Website.Application.Services.Users.Commands.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;

        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEdituserDto request)
        {
            var user = _context.Users.Find(request.UserId);
            var userInRole = _context.UserInRoles
                                     .SingleOrDefault(x => x.UserId == request.UserId);

            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.FullName = request.Fullname;
            user.Email = request.Email;
            userInRole.RoleId = request.RoleId;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };
        }
    }
}
