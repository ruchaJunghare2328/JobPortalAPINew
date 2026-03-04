using JobPortalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JopPortalAPI.Core.ModelDtos;
using JobPortalAPI.Core.ModelDtos;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDashboardController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILogger<EmpDashboardController> _logger;
        public readonly IEmpDashboardService _employeemaster;

        public EmpDashboardController(ILogger<EmpDashboardController> logger, IConfiguration configuration, IEmpDashboardService empmaster)
        {
            _logger = logger;
            _configuration = configuration;
            _employeemaster = empmaster;
        }

        [HttpGet("GetEmpDashboard")]
        public async Task<IActionResult> GetEmpDashboard([FromQuery] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "Get";
            try
            {
                var parameter = await _employeemaster.Get(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
