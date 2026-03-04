using JobPortalAPI.Core.ModelDtos;
using JobPortalAPI.Core.Repository;
using JobPortalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Services.ApiServices
{
    public class CandidateService:ICandidateService
    {
        CandidateRepositry _candidateRepositry;
        public CandidateService(CandidateRepositry candidateRepositry)
        {
            _candidateRepositry = candidateRepositry;
        }
        public async Task<IActionResult> InsertCanInfo(CandidateDto model)
        {
            return await _candidateRepositry.InsertCanInform(model);

        }

        public async Task<IActionResult> Getresume(ResumeResponseDto model)
        {
            return await _candidateRepositry.GetManageResume(model);

        }

        public async Task<IActionResult> AllGetresume(ResumeResponseDto model)
        {
            return await _candidateRepositry.AllGetResume(model);

        }
        public async Task<IActionResult> Get(CandidateDto model)
        {
            return await _candidateRepositry.Get(model);

        }
        public async Task<IActionResult> GetAlert(CandidateDto model)
        {
            return await _candidateRepositry.GetAlert(model);

        }
        public async Task<IActionResult> Get1(CandidateDto model)
        {
            return await _candidateRepositry.Get1(model);

        }
        
        public async Task<IActionResult> GetEdit(ResumeResponseDto model)
        {
            return await _candidateRepositry.GetEdit(model);

        }
    }
}
