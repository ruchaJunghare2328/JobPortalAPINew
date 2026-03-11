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
    public class ContactController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILogger<ContactController> _logger;
        public readonly IContactService _contactService;
        private readonly DatabaseContext _dbContext;
        public ContactController(ILogger<ContactController> logger, IConfiguration configuration, IContactService contactService, DatabaseContext dbContext)
        {
            _logger = logger;
            _configuration = configuration;
            _contactService = contactService;
            _dbContext = dbContext;

        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ContactFormDto user)
        {
            try
            {
                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                 user.BaseModel.OperationType = "InsertContactInfo";
                
               
                dynamic createduser = await _contactService.ContactInfo(user);
                var outcomeidvalue = createduser?.Value?.Outcome?.OutcomeId;


                return createduser;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
