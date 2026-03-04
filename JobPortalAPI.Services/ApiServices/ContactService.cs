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

namespace JobPortalAPI.Services.ApiServices
{
    public class ContactService: IContactService
    {
        ContactRepositry _contactRepositry;
        public ContactService(ContactRepositry contactRepositry)
        {
            _contactRepositry = contactRepositry;
        }
        public async Task<IActionResult> ContactInfo(ContactFormDto model)
        {
            return await _contactRepositry.Contact(model);

        }
    }
}
