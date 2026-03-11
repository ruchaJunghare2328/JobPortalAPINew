using JopPortalAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Core.ModelDtos
{
    public class HomeDto
    {
        public BaseModel? BaseModel { get; set; }
        public string? SessionId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserId { get; set; }
        public string? LocationId { get; set; }
        public string? CategoryId { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }

    }
    public class JobLocation
    {
        public string? UserId { get; set; }
        public string? roleid { get; set; }
        public BaseModel? BaseModel { get; set; }
        public string? LocationName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? SessionId { get; set; }
        public string? IpAddress { get; set; }
    }
    public class Category
    {
        public string? UserId { get; set; }
        public BaseModel? BaseModel { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? SessionId { get; set; }
        public string? IpAddress { get; set; }
    }
}

