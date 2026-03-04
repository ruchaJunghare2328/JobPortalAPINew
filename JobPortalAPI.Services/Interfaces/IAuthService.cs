using Microsoft.AspNetCore.Mvc;
using JopPortalAPI.Core.ModelDtos;


namespace JopPortalAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<IActionResult> VerifyUser(LoginDto model);
        public Task<IActionResult> ChangePassword(LoginDto model);
        public Task<IActionResult> ForgotPassword(LoginDto model);
        public Task<IActionResult> UserMaster(LoginDto model);
    }
}
