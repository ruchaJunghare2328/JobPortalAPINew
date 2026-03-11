using JobPortalAPI.Core.ModelDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Services.Interfaces
{
    public interface IHomeService
    {
        public Task<IActionResult> Get(JobLocation  model);
        public Task<IActionResult> Gets(Category model);

        public Task<IActionResult> Getjobtiltle(JobLocation model);
        public Task<IActionResult> Getcomapanyname(JobLocation model);
        public Task<IActionResult> GetSearch(HomeDto model);
        public Task<IActionResult> Homedata(HomeDto model);
    }
}
