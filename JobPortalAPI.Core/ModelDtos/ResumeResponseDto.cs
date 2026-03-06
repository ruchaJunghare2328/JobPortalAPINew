using JopPortalAPI.Core.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Core.ModelDtos
{
    public class ResumeResponseDto
    {
        public BaseModel? BaseModel { get; set; }
        public Guid? Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? ProfessionTitle { get; set; }
        public string? Location { get; set; }
         public string? LocationName { get; set; }
        public string? Web { get; set; }
        public decimal PreHour { get; set; }
        public int Age { get; set; }
        public string? Degree { get; set; }
        public string? fieldOfStudy { get; set; }
        public string? School { get; set; }
        public string? SchoolFrom { get; set; }
        public string? SchoolTo { get; set; }
        public string? Company_Name { get; set; }
        public string? com_Title { get; set; }
        public string? CompStartDate { get; set; }
        public string? CompEndDate { get; set; }
        public string? skill_Name { get; set; }
        public string? Aboutme { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? ProficiencyPercentage { get; set; }
        public ICollection<EducationDto> Educations { get; set; } = new List<EducationDto>();
        public ICollection<WorkExperienceDto> WorkExperiences { get; set; } = new List<WorkExperienceDto>();
        public ICollection<SkillDto> Skills { get; set; } = new List<SkillDto>();
    }
  
    
}
