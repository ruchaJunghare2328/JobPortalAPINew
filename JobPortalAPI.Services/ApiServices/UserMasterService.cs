using Microsoft.AspNetCore.Mvc;
using JopPortalAPI.Core.ModelDtos;
using JopPortalAPI.Core.Repository;
using JopPortalAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JopPortalAPI.Services.ApiServices
{
	public class UserMasterService:IUserMasterService
	{

		UserMasterRepository _userMasterRepository;
		public UserMasterService(UserMasterRepository userMasterRepository)
		{
			_userMasterRepository = userMasterRepository;
		}
		public async Task<IActionResult> UserMaster(UserMasterDto model)
		{
			return await _userMasterRepository.UserMaster(model);

		}
        public async Task<IActionResult> UserMaster1(UserMasterDto model)
        {
            return await _userMasterRepository.UserMaster1(model);

        }

        public async Task<IActionResult> Get(UserMasterDto model)
		{
			return await _userMasterRepository.Get(model);

		}

		public async Task<IActionResult> Shuffle(UserMasterDto model)
		{
			return await _userMasterRepository.Shuffle(model);

		}

		public async Task<IActionResult> GetEmailId(EmailConfigureDto model)
		{
			return await _userMasterRepository.GetEmailId(model);

		}
	}
}
