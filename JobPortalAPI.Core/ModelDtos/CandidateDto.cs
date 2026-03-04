using JopPortalAPI.Core.ModelDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Core.ModelDtos
{
    public class CandidateDto
    {
        public CandidateDto()
        {
            // Initialize collections to empty lists to avoid null reference exceptions
            Educations = new List<EducationDto>();
            WorkExperiences = new List<WorkExperienceDto>();
            Skills = new List<SkillDto>();
        }
        public BaseModel? BaseModel { get; set; }
        public string? UserId { get; set; }
        public Guid? Id { get; set; }

        //Basic information
        public string? Name { get; set; }
        public string? Email { get; set; } 
        public string? ProfessionTitle { get; set; }
        public string? Location { get; set; }
        public string? Web { get; set; }
        public string? AboutMe { get; set; }
        public string? CurrentIndustry { get; set; }
        public string? ProfilePhoto { get; set; }
        public decimal? PreHour { get; set; }
        public int? Age { get; set; }
        public string? AlertId { get; set; }
        
        public bool? IsRead { get; set; }

        // Navigation properties (for related data)
        // public ICollection<EducationDto> Educations { get; set; }
        public List<EducationDto> Educations { get; set; }

        public List<WorkExperienceDto> WorkExperiences { get; set; }
        public List<SkillDto> Skills { get; set; }
        // public ICollection<WorkExperienceDto> WorkExperiences { get; set; }
        //public ICollection<SkillDto> Skills { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
       // public DataTable? DataTable { get; set; }
        public DataTable? EducationTable { get; set; }
        public DataTable? WorkExperienceTable { get; set; }
        public DataTable? SkillTable { get; set; }
        //JOB APPLICATION
        public int? ApplicationId { get; set; }
        public DateTime? AppliedDate { get; set; }
        public string? Status { get; set; }
        public string? JobId { get; set; }
        public string? Resume { get; set; }
        public string? statusbyemployee { get; set; }
        public string? CoverLetter { get; set; }

    }
 
    public class EducationDto
    {
        //Education
        public Guid Id { get; set; }
        public Guid ResumeId { get; set; }
        public string? Degree { get; set; }
        public string? FieldofStudy { get; set; }
        public string? School { get; set; }
        public string? SchoolFrom { get; set; }
        public string? SchoolTo { get; set; }
        public string? EducationDescription { get; set; }
    }

    public class WorkExperienceDto
    {

        //WorkExperience
        public Guid Id { get; set; }
        public Guid ResumeId { get; set; }
        public string? CompanyName { get; set; }
        public string? Title { get; set; }
        public string? CompDateFrom { get; set; }
        public string? CompDateTo { get; set; }
        public string? WorkDescription { get; set; }
    }
    public class SkillDto
    {

        //Skills
        public Guid Id { get; set; }
        public Guid ResumeId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillProficiency { get; set; }

    }

}
