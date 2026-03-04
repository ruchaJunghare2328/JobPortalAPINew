using JopPortalAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Core.ModelDtos
{
    public class PaymentRequest
    {
        public BaseModel? BaseModel { get; set; }
        public int? Amount { get; set; }
        public string? Duration { get; set; } 
        public string? PlanName { get; set; }
        public string? RoleId { get; set; }
        public string? UserId { get; set; }
        public string? CompanyId { get; set; }
       
    }
    public class PaymentVerifyDto
    {
        public BaseModel? BaseModel { get; set; }
        public string? razorpay_payment_id { get; set; }
        public string? razorpay_order_id { get; set; }
        public string? razorpay_signature { get; set; }
        public int PaymentStatus { get; set; }
        public string? UserId { get; set; }
        public string? CompanyId { get; set; }
    }
}
