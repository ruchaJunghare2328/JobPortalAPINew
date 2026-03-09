using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JopPortalAPI.Core.ModelDtos;
using JopPortalAPI.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalAPI.Core.ModelDtos;

namespace JobPortalAPI.Core.Repository
{
    public class EmployeerRepository
    {
        private readonly DatabaseContext _dbContext;
        public EmployeerRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> EmpMaster(EmployeerDto model)
        {

            using (var connection = _dbContext.CreateConnection())

            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
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

        public async Task<IActionResult> SetFeatured(EmployeerDto model)
        {

            using (var connection = _dbContext.CreateConnection())

            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
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

        public async Task<IActionResult> SetBookmark(EmployeerDto model)
        {

            using (var connection = _dbContext.CreateConnection())

            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
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
        public async Task<IActionResult> Shuffle(EmployeerDto model)
        {

            using (var connection = _dbContext.CreateConnection())

            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
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

        public async Task<IActionResult> Get(EmployeerDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
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


        public async Task<IActionResult> GetNotificationMsg(EmployeerDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.Read<Object>();
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
        public async Task<IActionResult> FeaturedGet(EmployeerDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
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

        public async Task<IActionResult> BookmarkGet(EmployeerDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
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

        public async Task<IActionResult> UpdatestausEmp(EmployeerDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetUser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
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
        public async Task<IActionResult> GetEmailId(EmailConfigureDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                //Guid? userIdValue = (Guid)user.UserId;
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();



                    var queryResult = await connection.QueryMultipleAsync("ProcEmailConfigure", commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.ReadSingleOrDefault<Object>();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    //var IDMail = outcome?.IDMail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        //UserId = model.UserId
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
        public async Task<IActionResult> Email(EmployeerDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetUser(model);

                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();

                    var queryResult = await connection.QueryMultipleAsync("proc_Employeraster", parameter,commandType: CommandType.StoredProcedure,commandTimeout: 300);

                    var modelList = queryResult.Read<object>().ToList();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();

                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = modelList,
                        UserId = model.UserId
                    };

                    int outcomeId = outcome?.OutcomeId ?? 0;

                    return new ObjectResult(result)
                    {
                        StatusCode = outcomeId switch
                        {
                            1 => 200,
                            2 => 409,
                            3 => 423,
                            4 => 424,
                            _ => 400
                        }
                    };
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public DynamicParameters SetUser(EmployeerDto user)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@Id", user.Id, DbType.Guid);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@Email", user.Email, DbType.String);
            parameters.Add("@roleid", user.RoleId, DbType.String);
            parameters.Add("@companyId", user.CompanyId, DbType.String);
            parameters.Add("@Name", user.Name, DbType.String);
            parameters.Add("@slug", user.slug, DbType.String);
            parameters.Add("@CategoryId", user.CategoryId, DbType.String);
            parameters.Add("@TitleId", user.TitleId, DbType.String);
            parameters.Add("@Description", user.Description, DbType.String);
            parameters.Add("@Introduce", user.Introduce, DbType.String);
            parameters.Add("@ObjectTarget", user.ObjectTarget, DbType.String);
            parameters.Add("@Experience", user.Experience, DbType.String);
            parameters.Add("@Popular", user.Popular, DbType.String);
            parameters.Add("@ProvinceId", user.ProvinceId, DbType.String);
            parameters.Add("@TimeId", user.TimeId, DbType.String);
            parameters.Add("@MinSalary", user.MinSalary, DbType.String);
            parameters.Add("@MaxSalary", user.MaxSalary, DbType.String);  
            parameters.Add("@Location", user.Location, DbType.String);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@EmailId", user.EmailId, DbType.String);
            parameters.Add("@Website", user.Website, DbType.String);
            parameters.Add("@Tagline1", user.Tagline1, DbType.String);
            parameters.Add("@featured", user.Featured, DbType.String); 
            parameters.Add("@TypeofJob", user.TypeofJob, DbType.String);
            parameters.Add("@bookmark", user.Featured, DbType.String);
            parameters.Add("@Tagline2", user.Tagline1, DbType.String);
            parameters.Add("@LOGOFile", user.LOGOFile, DbType.String);
            parameters.Add("@JobId", user.JobId, DbType.String);
            parameters.Add("@NotificationId", user.NotificationId, DbType.String);
            parameters.Add("@ApplicationId", user.ApplicationId, DbType.String);
            parameters.Add("@um_isactive", user.um_isactive, DbType.String);
            parameters.Add("@ClosingDate", user.ClosingDate, DbType.DateTime);
            parameters.Add("@um_createddate", user.um_createddate, DbType.DateTime);
            parameters.Add("@um_updateddate", user.um_updateddate, DbType.DateTime);
            parameters.Add("@StatusByEmployee", user.StatusByEmployee, DbType.String);
            if (user.DataTable != null && user.DataTable.Rows.Count > 0)
            {
                parameters.Add("@UserMaster", user.DataTable.AsTableValuedParameter("[dbo].[tbl_UserMaster]"));
            }
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;

        }
    }
}
