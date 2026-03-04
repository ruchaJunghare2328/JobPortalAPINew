using JobPortalAPI.Core.ModelDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Services.Interfaces
{
    public interface IPaymentsServices
    {
        public Task<IActionResult> Payment(PaymentVerifyDto verifyDto);
        public Task<IActionResult> CreateOrder(PaymentRequest paymentRequest);
    }
}
