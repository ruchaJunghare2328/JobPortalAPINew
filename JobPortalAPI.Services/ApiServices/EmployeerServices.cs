using Microsoft.AspNetCore.Mvc;
using JopPortalAPI.Core.ModelDtos;
using JopPortalAPI.Core.Repository;
using JopPortalAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalAPI.Services.Interfaces;
using JobPortalAPI.Core.Repository;
using JobPortalAPI.Core.ModelDtos;

namespace JobPortalAPI.Services.ApiServices
{
    public class EmployeerServices : IEmployeerServices
    {
        EmployeerRepository _employeerRepository;
        public EmployeerServices(EmployeerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }
        public async Task<IActionResult> EmpMaster(EmployeerDto model)
        {
            return await _employeerRepository.EmpMaster(model);

        }
        
        public async Task<IActionResult> SetFeatured(EmployeerDto model)
        {
            return await _employeerRepository.SetFeatured(model);

        }
        public async Task<IActionResult> SetBookmark(EmployeerDto model)
        {
            return await _employeerRepository.SetBookmark(model);

        }
        public async Task<IActionResult> Get(EmployeerDto model)
        {
            return await _employeerRepository.Get(model);

        }
        public async Task<IActionResult> Email(EmployeerDto model)
        {
            return await _employeerRepository.Email(model);

        }

        public async Task<IActionResult> GetNotificationMsg(EmployeerDto model)
        {
            return await _employeerRepository.GetNotificationMsg(model);

        }

        public async Task<IActionResult> FeaturedGet(EmployeerDto model)
        {
            return await _employeerRepository.FeaturedGet(model);

        }
        public async Task<IActionResult> BookmarkGet(EmployeerDto model)
        {
            return await _employeerRepository.BookmarkGet(model);

        }

        public async Task<IActionResult> UpdatestausEmp(EmployeerDto model)
        {
            return await _employeerRepository.UpdatestausEmp(model);

        }
        public async Task<IActionResult> Shuffle(EmployeerDto model)
        {
            return await _employeerRepository.Shuffle(model);

        }

        public async Task<IActionResult> GetEmailId(EmailConfigureDto model)
        {
            return await _employeerRepository.GetEmailId(model);

        }
    }
}
