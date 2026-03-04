using common;
using JobPortalAPI.Core.ModelDtos;
using JobPortalAPI.Services.Interfaces;
using JopPortalAPI.Core.ModelDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExampleFilterAttribute]
    public class CandidateController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ILogger<CandidateController> _logger;
        public readonly ICandidateService _candidateService;

        public CandidateController(ILogger<CandidateController> logger, IConfiguration configuration, ICandidateService candidateService)
        {
            _logger = logger;
            _configuration = configuration;
            _candidateService = candidateService;
        }


        [HttpPost("AddResume")]
        public async Task<IActionResult> Insert([FromBody] CandidateDto user)
        {
            try
            {
                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                if (user.Id == null)
                {
                    user.BaseModel.OperationType = "Insert";
                }
                else
                {
                    user.updateddate = DateTime.Now;
                    user.BaseModel.OperationType = "Update";
                }
                DataTable educationTable = new DataTable();
                educationTable.Columns.Add("Id", typeof(Guid));
                educationTable.Columns.Add("ResumeId", typeof(Guid));
                educationTable.Columns.Add("degree", typeof(string));
                educationTable.Columns.Add("fieldOfStudy", typeof(string));
                educationTable.Columns.Add("school", typeof(string));
                educationTable.Columns.Add("schoolFrom", typeof(string));
                educationTable.Columns.Add("schoolTo", typeof(string));
                educationTable.Columns.Add("educationDescription", typeof(string));

                foreach (var education in user.Educations)
                {
                    educationTable.Rows.Add(
                        education.Id,
                        education.ResumeId,
                        education.Degree ?? string.Empty,
                        education.FieldofStudy ?? string.Empty,
                        education.School ?? string.Empty,
                        education.SchoolFrom ?? string.Empty,
                        education.SchoolTo ?? string.Empty,
                        education.EducationDescription ?? string.Empty
                    );
                }

                DataTable workExperienceTable = new DataTable();
                workExperienceTable.Columns.Add("Id", typeof(Guid));
                workExperienceTable.Columns.Add("ResumeId", typeof(Guid));
                workExperienceTable.Columns.Add("comapny_Name", typeof(string));
                workExperienceTable.Columns.Add("com_Title", typeof(string));
                workExperienceTable.Columns.Add("compStartDate", typeof(string));
                workExperienceTable.Columns.Add("compEndDate", typeof(string));
                workExperienceTable.Columns.Add("workDescription", typeof(string));

                foreach (var workex in user.WorkExperiences)
                {
                    workExperienceTable.Rows.Add(
                        workex.Id,
                        workex.ResumeId,
                        workex.CompanyName ?? string.Empty,
                        workex.Title ?? string.Empty,
                        workex.CompDateFrom ?? string.Empty,
                        workex.CompDateTo ?? string.Empty,
                        workex.WorkDescription ?? string.Empty
                    );
                }

                DataTable skillTable = new DataTable();
                skillTable.Columns.Add("Id", typeof(Guid));
                skillTable.Columns.Add("ResumeId", typeof(Guid));
                skillTable.Columns.Add("skill_Name", typeof(string));
                skillTable.Columns.Add("proficiencyPercentage", typeof(string));

                foreach (var skill in user.Skills)
                {
                    skillTable.Rows.Add(
                        skill.Id,
                        skill.ResumeId,
                        skill.SkillName ?? string.Empty,
                        skill.SkillProficiency ?? string.Empty
                    );
                }


                // Optional: Clear out raw lists
                user.Educations = null;
                user.WorkExperiences = null;
                user.Skills = null;
                user.EducationTable = educationTable;
                user.WorkExperienceTable = workExperienceTable;
                user.SkillTable = skillTable;
                dynamic createduser = await _candidateService.InsertCanInfo(user);
                var outcomeidvalue = createduser.Value.Outcome.OutcomeId;
                return createduser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("UpdateAlert")]
        public async Task<IActionResult> UpdateAlert([FromBody] CandidateDto user)
        {
            try
            {
                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

               
                user.BaseModel.OperationType = "UpdateAlert";
                   
                dynamic createduser = await _candidateService.InsertCanInfo(user);
                var outcomeidvalue = createduser.Value.Outcome.OutcomeId;
                return createduser;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("GetManageResume")]
        public async Task<IActionResult> GetManageResume([FromQuery] ResumeResponseDto user)
        {
            try
            {
                 
                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "GetbyId";
                var createduser = await _candidateService.GetEdit(user);
                return createduser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetResume")]
        public async Task<IActionResult> GetResume([FromQuery] CandidateDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetResume";
            try
            {
                var parameter = await _candidateService.Get1(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("GetAllResume")]
        public async Task<IActionResult> GetAllResume([FromQuery] ResumeResponseDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "AllResume";
            try
            {
                var parameter = await _candidateService.AllGetresume(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetJobAlert")]
        public async Task<IActionResult> GetJobAlert([FromQuery] CandidateDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "CandidateJobAlert";
            try
            {
                var parameter = await _candidateService.GetAlert(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

         
       
        [HttpGet("GetallJobAlert")]
        public async Task<IActionResult> GetallJobAlert([FromQuery] CandidateDto user)
        {
            try
            {

                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "GetallJobAlert";
                var createduser = await _candidateService.InsertCanInfo(user);
                return createduser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
         

        [HttpPost("Apply")]
        public async Task<IActionResult> Apply([FromBody] CandidateDto application)
        {
            try
            {
                if (application.BaseModel == null)
                {
                    application.BaseModel = new BaseModel();
                }

                // Set operation type
                if (application.ApplicationId == null || application.ApplicationId == 0)
                {
                    application.AppliedDate = DateTime.Now;
                    application.Status = "Pending";
                    application.BaseModel.OperationType = "JobApplyInsert";
                }


                // Call service layer
                dynamic response = await _candidateService.InsertCanInfo(application);
                var outcomeId = response.Value.Outcome.OutcomeId;

                // Optional: handle response logic (email, notification, etc.)

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpPost("AddResume")]
        //public async Task<IActionResult> Edit([FromBody] CandidateDto user)
        //{
        //    try
        //    {
        //        if (user.BaseModel == null)
        //        {
        //            user.BaseModel = new BaseModel();
        //        }

        //        if (user.Id == null)
        //        {
        //            user.BaseModel.OperationType = "Insert";
        //        }
        //        else
        //        {
        //            user.updateddate = DateTime.Now;
        //            user.BaseModel.OperationType = "Update";
        //        }
        //        dynamic createduser = await _candidateService.InsertCanInfo(user);
        //        var outcomeidvalue = createduser.Value.Outcome.OutcomeId;
        //        //if (outcomeidvalue == 1)
        //        //{

        //        //	var datavalue = createduser.Value.Outcome.OutcomeDetail;

        //        //	await SendNo(datavalue);
        //        //}

        //        return createduser;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost("AddResumeWithFile")]
        //public async Task<IActionResult> InsertWithFile([FromForm] CandidateDto user, [FromForm] IFormFile resumeFile)
        //{
        //    try
        //    {
        //        if (user.BaseModel == null)
        //        {
        //            user.BaseModel = new BaseModel();
        //        }

        //        if (user.Id == null)
        //        {
        //            user.BaseModel.OperationType = "Insert";
        //        }
        //        else
        //        {
        //            user.updateddate = DateTime.Now;
        //            user.BaseModel.OperationType = "Update";
        //        }

        //        if (resumeFile != null && resumeFile.Length > 0)
        //        {
        //            // Save the PDF file to disk or cloud storage
        //            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resumes");
        //            if (!Directory.Exists(uploadsFolder))
        //                Directory.CreateDirectory(uploadsFolder);

        //            var filePath = Path.Combine(uploadsFolder, resumeFile.FileName);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await resumeFile.CopyToAsync(stream);
        //            }

        //            // Optionally, save the file path in the user model
        //            user.ResumePath = filePath;  
        //        }

        //        dynamic createduser = await _candidateService.InsertCanInfo(user);
        //        return Ok(createduser);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}


        [HttpGet("ManageResume")]
        public async Task<IActionResult> GetAll([FromQuery] ResumeResponseDto user)
        {
            try
            {

                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "Get";
                var createduser = await _candidateService.Getresume(user);
                return createduser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
