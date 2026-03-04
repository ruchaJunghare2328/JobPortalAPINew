using JobPortalAPI.Core.ModelDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Services.Interfaces
{
    public interface ICandidateService
    {
        public Task<IActionResult> InsertCanInfo(CandidateDto model);
        public Task<IActionResult> Getresume(ResumeResponseDto model);
        public Task<IActionResult> GetEdit(ResumeResponseDto model);
        public Task<IActionResult> Get(CandidateDto model);
        public Task<IActionResult> Get1(CandidateDto model);
        public Task<IActionResult> GetAlert(CandidateDto model);
        public Task<IActionResult> AllGetresume(ResumeResponseDto model);
    }
}
