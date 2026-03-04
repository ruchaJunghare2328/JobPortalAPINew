using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JopPortalAPI.Core.ModelDtos;


namespace JobPortalAPI.Core.ModelDtos
{
    public class EmployeerDto
    {
        public BaseModel? BaseModel { get; set; }
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
        public string? CompanyId { get; set; }
        public string? RoleName { get; set; }
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? slug { get; set; }
        public string? CategoryId { get; set; }
        public string? Email { get; set; }

        public DateTime? um_updateddate { get; set; }
        public string? TitleId { get; set; }
        public string? Description { get; set; }
        public string? TypeofJob  { get; set; }
        public string? Introduce { get; set; }
        public string? ObjectTarget { get; set; }
        public string? Experience { get; set; }
        public string?  LOGOFile { get; set; }
        public string?  JobId { get; set; }
        public string? NotificationId { get; set; }
         public string? ApplicationId { get; set; }
        public string? Popular { get; set; }


        public string? um_isactive { get; set; }
        public string? ProvinceId { get; set; }
        public string? TimeId { get; set; }

        public string? MinSalary { get; set; }
        public string? MaxSalary { get; set; }
        public DateTime? um_createddate { get; set; }
        public string? EmailId { get; set; }
        public string? Location { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string? Website { get; set; }
        public string? Tagline1 { get; set; }
        public string? Featured { get; set; } = "0";
        public string? Bookmark { get; set; } = "0";
        public string? Tagline2 { get; set; }
        public string? statusbyemployee { get; set; }
        public DataTable? DataTable { get; set; }
    }
}
