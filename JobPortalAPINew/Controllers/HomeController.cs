using common;
using DocumentFormat.OpenXml.Spreadsheet;
using JobPortalAPI.Core.ModelDtos;
using JobPortalAPI.Services.Interfaces;
using JopPortalAPI.Controllers;
using JopPortalAPI.Core.ModelDtos;
using JopPortalAPI.DataAccess.Context;
using JopPortalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExampleFilterAttribute]
    public class HomeController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        public readonly IHomeService _homeService;
        private readonly DatabaseContext _dbContext;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IHomeService homeService, DatabaseContext dbContext)
        {
            _logger = logger;
            _configuration = configuration;
            _homeService = homeService;
            _dbContext = dbContext;

        } 

        [HttpGet("GetLocation")]  
        public async Task<IActionResult> Getlocation([FromQuery] JobLocation user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetALLLocations";
            try
            {
                var parameter = await _homeService.Get(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetCategories")]  
        public async Task<IActionResult> Getcategories([FromQuery] Category user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetALLCategories";
            try
            {
                var parameter = await _homeService.Gets(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetCompanyName")]
        public async Task<IActionResult> GetCompanyName([FromQuery] JobLocation user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetALLCompanyName";
            try
            {
                var parameter = await _homeService.Getcomapanyname(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetJobTitle")]
        public async Task<IActionResult> GetJobTitle([FromQuery] JobLocation user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetALLJobTitle";
            try
            {
                var parameter = await _homeService.Getjobtiltle(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("AddContactUsInfo")]
        public async Task<IActionResult> AddContactUsInfo([FromBody] HomeDto user)
        {
            try
            {
                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                 
                    user.BaseModel.OperationType = "AddContactUsInfo";
                 
                dynamic createduser = await _homeService.Homedata(user);
                var outcomeidvalue = createduser.Value.Outcome.OutcomeId;
                //if (outcomeidvalue == 1)
                //{

                //	var datavalue = createduser.Value.Outcome.OutcomeDetail;

                //	await SendNo(datavalue);
                //}

                return createduser;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("SearchJob")]
        public async Task<IActionResult> SearchJob([FromQuery] HomeDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            } 

            user.BaseModel.OperationType = "SearchJob";
            try
            {
                var parameter = await _homeService.GetSearch(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
