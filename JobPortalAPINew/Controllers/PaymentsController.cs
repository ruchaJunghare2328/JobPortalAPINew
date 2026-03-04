using common;
using JobPortalAPI.Core.ModelDtos;
using JobPortalAPI.Services.Interfaces;
using JopPortalAPI.Core.ModelDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using JopPortalAPI.Controllers;
using JopPortalAPI.DataAccess.Context;
using JopPortalAPI.Services.Interfaces;
using JopPortalAPI.Services.ApiServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DocumentFormat.OpenXml.Spreadsheet;


[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly string key = "YOUR_KEY_ID";
    private readonly string secret = "YOUR_SECRET";

    private readonly IConfiguration _configuration;
    private readonly ILogger<PaymentsController> _logger;
    public readonly IPaymentsServices _paymentservices;
    private readonly DatabaseContext _dbContext;

    public PaymentsController(IConfiguration configuration, ILogger<PaymentsController> logger, IPaymentsServices paymentservices, DatabaseContext dbContext)
    {
        _logger = logger;
        _configuration = configuration;
        _paymentservices = paymentservices;
        _dbContext = dbContext;
    }
    [HttpPost("create-order")]

    public async Task<IActionResult> CreateOrder([FromBody] PaymentRequest paymentRequest)
    {
        try
        {
            string key = _configuration["Razorpay:Key"];
            string secret = _configuration["Razorpay:Secret"];

            RazorpayClient client = new RazorpayClient(key, secret);

            Dictionary<string, object> options = new Dictionary<string, object>
            {
                { "amount", paymentRequest.Amount * 100 }, // amount in paise
                { "currency", "INR" },
                { "receipt", Guid.NewGuid().ToString() },
                { "payment_capture", 1 },
                 {
                "notes", new Dictionary<string, string>
                {
                    { "Duration", paymentRequest.Duration },
                    { "PlanName", paymentRequest.PlanName },
                    { "UserId", paymentRequest.UserId },
                    { "CompanyId", paymentRequest.CompanyId },
                    { "RoleId", paymentRequest.RoleId }
                }
            }
            };

            Razorpay.Api.Order order = client.Order.Create(options);
            if (paymentRequest.BaseModel == null)
            {
                paymentRequest.BaseModel = new BaseModel();
            }
            paymentRequest.BaseModel.OperationType = "UpdateCompany";
            var outcome = await _paymentservices.CreateOrder(paymentRequest);

            return Ok(new
            {
                orderId = order["id"].ToString(),
                amount = paymentRequest.Amount,
                key = key,
                duration = paymentRequest.Duration,
                planname = paymentRequest.PlanName,
                currency = "INR",
                userid = paymentRequest.UserId,
                companyid = paymentRequest.CompanyId,
                roleid = paymentRequest.RoleId
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    [HttpPost("verify")]
    public async Task<IActionResult> Verify([FromBody] PaymentVerifyDto verifyDto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(verifyDto.razorpay_order_id) ||
           string.IsNullOrWhiteSpace(verifyDto.razorpay_payment_id) ||
           string.IsNullOrWhiteSpace(verifyDto.razorpay_signature))
            {
                verifyDto.PaymentStatus = 0;
                return BadRequest("Missing required Razorpay payment details.");
            }

            verifyDto.PaymentStatus = 1;
            Dictionary<string, string> attributes = new Dictionary<string, string>
                {
                    { "razorpay_order_id", verifyDto.razorpay_order_id },
                    { "razorpay_payment_id", verifyDto.razorpay_payment_id },
                    { "razorpay_signature", verifyDto.razorpay_signature }
                };

            Utils.verifyPaymentSignature(attributes);
            if (verifyDto.BaseModel == null)
            {
                verifyDto.BaseModel = new BaseModel();
            }
            verifyDto.BaseModel.OperationType = "UpdateCompany";
            var outcome = await _paymentservices.Payment(verifyDto);


            return Ok(new
            {
                message = "Payment verified successfully.",
                //razorpay_order_id = verifyDto.razorpay_order_id,
                //razorpay_payment_id = verifyDto.razorpay_payment_id,
                //razorpay_signature = verifyDto.razorpay_signature
            });
        }
        catch (Exception)
        {
            return BadRequest("Payment verification failed.");
        }
    }
}


