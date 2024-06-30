using OnlineStore.BLL.DTOs.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<AuthResponseDto> LoginAsync(UserLoginDto userLoginDto);
    }
}
