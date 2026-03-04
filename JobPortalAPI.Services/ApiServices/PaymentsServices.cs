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
    public class PaymentsServices : IPaymentsServices
    {
        PaymentsRepositry _paymentsRepositry;
        public PaymentsServices(PaymentsRepositry paymentsRepositry)
        {
            _paymentsRepositry = paymentsRepositry;
        }

        public async Task<IActionResult> CreateOrder(PaymentRequest paymentRequest)
        {
            return await _paymentsRepositry.CreateOrder(paymentRequest);

        }
        public async Task<IActionResult> Payment(PaymentVerifyDto verifyDto)
        {
            return await _paymentsRepositry.Payment(verifyDto);

        }
    }
}
