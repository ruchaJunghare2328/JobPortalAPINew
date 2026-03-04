using Microsoft.AspNetCore.Mvc;
using JopPortalAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalAPI.Core.ModelDtos;

namespace JobPortalAPI.Services.Interfaces
{
    public interface IEmployeerServices
    {
        public Task<IActionResult> EmpMaster(EmployeerDto model);
        public Task<IActionResult> Get(EmployeerDto model);
        public Task<IActionResult> Shuffle(EmployeerDto model);
        public Task<IActionResult> GetEmailId(EmailConfigureDto model);
        public Task<IActionResult> UpdatestausEmp(EmployeerDto model);
        public  Task<IActionResult> SetFeatured(EmployeerDto model);
        public Task<IActionResult> Email(EmployeerDto model);
        public  Task<IActionResult> SetBookmark(EmployeerDto model);
        public  Task<IActionResult> FeaturedGet(EmployeerDto model);
        public Task<IActionResult> BookmarkGet(EmployeerDto model);
        public Task<IActionResult> GetNotificationMsg(EmployeerDto model);
    }
}
