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
    public class EmpDashboardService: IEmpDashboardService
    {
        EmpDashboardRepositry _employeerRepository;
        public EmpDashboardService(EmpDashboardRepositry employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }
        public async Task<IActionResult> Get(EmployeerDto model)
        {
            return await _employeerRepository.Get(model);

        }
    }
}
