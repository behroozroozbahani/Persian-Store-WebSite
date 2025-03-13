using Store_Website.Common.Dto;
using System.Text;
using System.Threading.Tasks;

namespace Store_Website.Application.Services.Users.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(string Username, string Password);
    }
}
