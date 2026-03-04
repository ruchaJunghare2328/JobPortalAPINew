using Microsoft.AspNetCore.Mvc;
using JopPortalAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JopPortalAPI.Services.Interfaces
{
	public interface IGetWebMenuService
	{
		public Task<IActionResult> GetWebMenu(GetWebMenuDto model);
	}
}
