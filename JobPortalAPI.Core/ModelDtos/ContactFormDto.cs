using JopPortalAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Core.ModelDtos
{
    public class ContactFormDto
    {
        //public string? SessionId { get; set; }
        //public string? IpAddress { get; set; }
        public string? UserId { get; set; }
        public BaseModel? BaseModel { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please provide a valid email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string? Message { get; set; }
    }
}
