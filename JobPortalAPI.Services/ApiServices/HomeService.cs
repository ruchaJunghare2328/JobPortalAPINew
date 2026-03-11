using JobPortalAPI.Core.ModelDtos;
using JobPortalAPI.Core.Repository;
using JobPortalAPI.Services.Interfaces;
using JopPortalAPI.Core.ModelDtos;
using JopPortalAPI.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortalAPI.Core.ModelDtos.HomeDto;

namespace JobPortalAPI.Services.ApiServices
{
    public class HomeService:IHomeService
    {
        HomeRepositry _homeRepositry;
        public HomeService(HomeRepositry homeRepositry)
        {
            _homeRepositry = homeRepositry;
        }
        public async Task<IActionResult> Get(JobLocation  model)
        {
            return await _homeRepositry.Getloc(model);

        }
        public async Task<IActionResult> Getjobtiltle(JobLocation model)
        {
            return await _homeRepositry.GetCom(model);

        }
        public async Task<IActionResult> Getcomapanyname(JobLocation model)
        {
            return await _homeRepositry.Gettitle(model);

        }

        public async Task<IActionResult> GetSearch(HomeDto model)
        {
            return await _homeRepositry.GetSearchJobs(model);

        }

        public async Task<IActionResult> Gets(Category model)
        {
            return await _homeRepositry.GetCat(model);

        }

        public async Task<IActionResult> Homedata(HomeDto model)
        {
            return await _homeRepositry.Homedata(model);

        }
    }
}
