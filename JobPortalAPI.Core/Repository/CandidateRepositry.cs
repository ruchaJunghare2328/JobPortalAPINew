using Dapper;
using JobPortalAPI.Core.ModelDtos;
using JopPortalAPI.Core.ModelDtos;
using JopPortalAPI.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalAPI.Core.Repository
{
    public class CandidateRepositry
    {
        private readonly DatabaseContext _dbContext;
        public CandidateRepositry(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> InsertCanInform(CandidateDto model)
        {

            using (var connection = _dbContext.CreateConnection())

            {
                var parameter = SetUser(model);
                try
                {



                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Candidate", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.Read<Object>().ToList();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome, 
                        Data = Model,
                        UserId = model.UserId
                    };

                    if (outcomeId == 1)
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 200
                        };
                    }
                    else if (outcomeId == 2)
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 409
                        };
                    }
                    else if (outcomeId == 3)
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 423
                        };
                    }
                    else if (outcomeId == 4)
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 424
                        };
                    }
                    else
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 400
                        };
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<IActionResult> Get(CandidateDto model)
        {
            using (var connection = _dbContext.CreateConnection())

            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var outcome = await connection.QuerySingleOrDefaultAsync<Outcome>( "proc_Candidate", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);

                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = outcome, // no data if SP doesn't return it
                        UserId = model.UserId 
                    };

                    return outcome?.OutcomeId switch
                    {
                        1 => new ObjectResult(result) { StatusCode = 200 },
                        2 => new ObjectResult(result) { StatusCode = 409 },
                        3 => new ObjectResult(result) { StatusCode = 423 },
                        4 => new ObjectResult(result) { StatusCode = 424 },
                        _ => new ObjectResult(result) { StatusCode = 400 },
                    };
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<IActionResult> Get1(CandidateDto model)
        {
            using (var connection = _dbContext.CreateConnection())

            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Candidate", parameter, commandType: CommandType.StoredProcedure);
                    var Model = queryResult.ReadSingleOrDefault<Object>();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {

                        Outcome = outcome,
                        Data = Model,
                        UserId = model.UserId

                    };
                    if (outcomeId == 1)
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 200
                        };
                    }
                    else if (outcomeId == 2)
                    {

                        return new ObjectResult(result)
                        {
                            StatusCode = 409
                        };
                    }
                    else
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 400
                        };
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        

        public async Task<IActionResult> GetAlert(CandidateDto model)
        {
            using (var connection = _dbContext.CreateConnection())

            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Candidate", parameter, commandType: CommandType.StoredProcedure);
                    var Model = queryResult.ReadSingleOrDefault<Object>();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {

                        Outcome = outcome,
                        Data = Model,
                        UserId = model.UserId

                    };
                    if (outcomeId == 1)
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 200
                        };
                    }
                    else if (outcomeId == 2)
                    {

                        return new ObjectResult(result)
                        {
                            StatusCode = 409
                        };
                    }
                    else
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 400
                        };
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<IActionResult> GetManageResume(ResumeResponseDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {

                var parameter = getUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();


                    var queryResult = await connection.QueryMultipleAsync("proc_Candidate", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.Read<Object>().ToList();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        UserId = model.UserId
                    };

                    if (outcomeId == 1)
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 400
                        };
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<IActionResult> AllGetResume(ResumeResponseDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {

                var parameter = getUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();


                    var queryResult = await connection.QueryMultipleAsync("proc_Candidate", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    //var Model = queryResult.Read<Object>().ToList();
                    var Model = queryResult.Read<ResumeResponseDto>().ToList();
                    var educations = queryResult.Read<EducationDto>().ToList();
                    var workExperiences = queryResult.Read<WorkExperienceDto>().ToList();
                    var skills = queryResult.Read<SkillDto>().ToList();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();

                    // Group related data by ResumeId
                    foreach (var models in Model)
                    {
                        models.Educations = educations.Where(e => e.ResumeId == models.Id).ToList();
                        models.WorkExperiences = workExperiences.Where(w => w.ResumeId == models.Id).ToList();
                        models.Skills = skills.Where(s => s.ResumeId == models.Id).ToList();
                    }
                    //var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        UserId = model.UserId
                    };

                    if (outcomeId == 1)
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 400
                        };
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<IActionResult> GetEdit(ResumeResponseDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = getResumebyId(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Candidate", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.ReadFirstOrDefault<object>();
                    var Model2 = queryResult.Read<Object>().ToList();
                    var Model3 = queryResult.Read<Object>().ToList();
                    var Model4 = queryResult.Read<Object>().ToList();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = new
                        {
                            Model1 = Model,
                            Educations = Model2,
                            WorkExperiences = Model3,
                            Skills = Model4
                        },
                        UserId = model.UserId
                    };

                    if (outcomeId == 1)
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new ObjectResult(result)
                        {
                            StatusCode = 400
                        };
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DynamicParameters SetUser(CandidateDto user)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@operationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@Id", user.Id, DbType.Guid);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@Name", user.Name, DbType.String);
            parameters.Add("@Email", user.Email, DbType.String);
            parameters.Add("@ProfessionTitle", user.ProfessionTitle, DbType.String);
            parameters.Add("@Location", user.Location, DbType.String);
            parameters.Add("@Web", user.Web, DbType.String);
            parameters.Add("@aboutme", user.AboutMe, DbType.String);
            parameters.Add("@DOB", user.DOB, DbType.String);
            parameters.Add("@currentindustry", user.CurrentIndustry, DbType.String);
            parameters.Add("@profilephoto", user.ProfilePhoto, DbType.String);
            parameters.Add("@Phone", user.PreHour, DbType.String);
            parameters.Add("@Age", user.Age, DbType.String);
            parameters.Add("@AlertId", user.AlertId, DbType.String);
            parameters.Add("@getjobstatus", user.statusbyemployee, DbType.String);
            parameters.Add("@CreatedDate", user.createddate, DbType.DateTime);
            parameters.Add("@ApplicationId", user.ApplicationId, DbType.Int32);
            parameters.Add("@AppliedDate", user.AppliedDate, DbType.DateTime);
            parameters.Add("@Status", user.Status, DbType.String);
            parameters.Add("@JobId", user.JobId, DbType.String);
            parameters.Add("@Resume", user.Resume, DbType.String);
            parameters.Add("@CoverLetter", user.CoverLetter, DbType.String);
         
            // Table-Valued Parameters (TVPs)
            //if (user.Educations != null && user.Educations.Any())
            //{
            //    var educationDataTable = CreateEducationDataTable(user.Educations.ToList());
            //    parameters.Add("@Educations", educationDataTable.AsTableValuedParameter("dbo.EducationType"));
            //}
            if (user.EducationTable != null && user.EducationTable.Rows.Count > 0)
            {
                parameters.Add("@Educations", user.EducationTable.AsTableValuedParameter("dbo.EducationType"));
            }

            if (user.WorkExperienceTable != null && user.WorkExperienceTable.Rows.Count > 0)
            {
                parameters.Add("@WorkExperiences", user.WorkExperienceTable.AsTableValuedParameter("dbo.WorkExperienceType"));
            }

            if (user.SkillTable != null && user.SkillTable.Rows.Count > 0)
            {
                parameters.Add("@Skills", user.SkillTable.AsTableValuedParameter("dbo.SkillType"));
            }

            //if (user.WorkExperiences != null && user.WorkExperiences.Any())
            //{
            //    var workExperienceDataTable = CreateWorkExperienceDataTable(user.WorkExperiences.ToList());
            //    parameters.Add("@WorkExperiences", workExperienceDataTable.AsTableValuedParameter("dbo.WorkExperienceType"));
            //}

            //if (user.Skills != null && user.Skills.Any())
            //{
            //    var skillDataTable = CreateSkillDataTable(user.Skills.ToList());
            //    parameters.Add("@Skills", skillDataTable.AsTableValuedParameter("dbo.SkillType"));
            //}
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;

        }

        //// Helper method to create Education DataTable for TVP
        //private DataTable CreateEducationDataTable(List<EducationDto> educations)
        //{
        //    var table = new DataTable();
        //    table.Columns.Add("Id", typeof(Guid));
        //    table.Columns.Add("ResumeId", typeof(Guid));
        //    table.Columns.Add("Degree", typeof(string));
        //    table.Columns.Add("FieldOfStudy", typeof(string));
        //    table.Columns.Add("School", typeof(string));
        //    table.Columns.Add("SchoolFrom", typeof(string));
        //    table.Columns.Add("SchoolTo", typeof(string));

        //    foreach (var education in educations)
        //    {
        //        table.Rows.Add(
        //            education.Id,
        //            education.ResumeId,
        //            education.Degree ?? string.Empty,
        //            education.fieldOfStudy ?? string.Empty,
        //            education.School ?? string.Empty,
        //            education.SchoolFrom ?? string.Empty,
        //            education.SchoolTo ?? string.Empty
        //        );
        //    }

        //    return table;
        //}

        //// Helper method to create Work Experience DataTable for TVP
        //private DataTable CreateWorkExperienceDataTable(List<WorkExperienceDto> workExperiences)
        //{
        //    var table = new DataTable();
        //    table.Columns.Add("Id", typeof(Guid));
        //    table.Columns.Add("ResumeId", typeof(Guid));
        //    table.Columns.Add("CompanyName", typeof(string));
        //    table.Columns.Add("Title", typeof(string));
        //    table.Columns.Add("CompDateFrom", typeof(string));
        //    table.Columns.Add("CompDateTo", typeof(string));
        //    foreach (var exp in workExperiences)
        //    {
        //        table.Rows.Add(
        //            exp.Id,
        //            exp.ResumeId,
        //            exp.Company_Name ?? string.Empty,
        //            exp.com_Title ?? string.Empty,
        //            exp.CompStartDate ?? string.Empty,
        //            exp.CompEndDate ?? string.Empty
        //        );
        //    }

        //    return table;
        //}

        //// Helper method to create Skill DataTable for TVP
        //private DataTable CreateSkillDataTable(List<SkillDto> skills)
        //{
        //    var table = new DataTable();
        //    table.Columns.Add("Id", typeof(Guid));
        //    table.Columns.Add("ResumeId", typeof(Guid));
        //    table.Columns.Add("SkillName", typeof(string));
        //    table.Columns.Add("SkillProficiency", typeof(string));

        //    foreach (var skill in skills)
        //    {
        //        table.Rows.Add(skill.Id, skill.ResumeId, skill.skill_Name, skill.ProficiencyPercentage);
        //    }

        //    return table;
        //}

        public DynamicParameters getUser(ResumeResponseDto user)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@operationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@Id", user.Id, DbType.Guid);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@Name", user.Name, DbType.String);
            parameters.Add("@ProfessionTitle", user.ProfessionTitle, DbType.String);
            parameters.Add("@Location", user.Location, DbType.String);
            parameters.Add("@Phone", user.PreHour, DbType.String);
            parameters.Add("@Age", user.Age, DbType.String);
            parameters.Add("@Degree", user.Degree, DbType.String);
            parameters.Add("@FieldOfStudy", user.fieldOfStudy, DbType.String);
            parameters.Add("@School", user.School, DbType.String);
            parameters.Add("@SchoolFrom", user.SchoolFrom, DbType.String);
            parameters.Add("@SchoolTo", user.SchoolTo, DbType.String);
            parameters.Add("@CompanyName", user.Company_Name, DbType.String);
            parameters.Add("@Title", user.com_Title, DbType.String);
            parameters.Add("@CompDateFrom", user.CompStartDate, DbType.String);
            parameters.Add("@CompDateTo", user.CompEndDate, DbType.String);
            parameters.Add("@SkillName", user.skill_Name, DbType.String);
            parameters.Add("@SkillProficiency", user.ProficiencyPercentage, DbType.String);
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;
        }

        public DynamicParameters getResumebyId(ResumeResponseDto user)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@operationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@Id", user.Id, DbType.Guid);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;
        }
    }
}
