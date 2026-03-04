using Microsoft.AspNetCore.Mvc;
using JopPortalAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JopPortalAPI.Services.Interfaces
{
	public interface IUserMasterService
	{
		public Task<IActionResult> UserMaster(UserMasterDto model);

        public Task<IActionResult> UserMaster1(UserMasterDto model);
        public Task<IActionResult> Get(UserMasterDto model);
		public Task<IActionResult> Shuffle(UserMasterDto model);
		public Task<IActionResult> GetEmailId(EmailConfigureDto model);
		
	}
}
