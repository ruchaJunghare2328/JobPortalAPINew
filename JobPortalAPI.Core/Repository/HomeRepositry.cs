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
using static JobPortalAPI.Core.ModelDtos.HomeDto;

namespace JobPortalAPI.Core.Repository
{
    public class HomeRepositry
    {
        private readonly DatabaseContext _dbContext;

        public HomeRepositry(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Getloc(JobLocation  model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = Setuser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("Proc_Home", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.Read<Object>().ToList(); 
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        UserId = model.UserId,
                        SessionId = model.SessionId,
                        IpAddress = model.IpAddress
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


        public async Task<IActionResult> GetCat(Category model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetCategories(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("Proc_Home", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.Read<Object>().ToList();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        UserId = model.UserId,
                        SessionId = model.SessionId,
                        IpAddress = model.IpAddress
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
        public async Task<IActionResult> GetCom(JobLocation model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = Setuser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("Proc_Home", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.Read<Object>().ToList();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        UserId = model.UserId,
                        SessionId = model.SessionId,
                        IpAddress = model.IpAddress
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

        public async Task<IActionResult> Gettitle(JobLocation model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = Setuser(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("Proc_Home", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.Read<Object>().ToList();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        UserId = model.UserId,
                        SessionId = model.SessionId,
                        IpAddress = model.IpAddress
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
        public async Task<IActionResult> GetSearchJobs(HomeDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = searchjobs(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();
                    var queryResult = await connection.QueryMultipleAsync("Proc_Home", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    var Model = queryResult.Read<Object>().ToList(); 
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;
                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        UserId = model.UserId,
                        SessionId = model.SessionId,
                        IpAddress = model.IpAddress
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

        public DynamicParameters Setuser(JobLocation user)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@roleid", user.roleid, DbType.String);
            return parameters;

        }

        public DynamicParameters SetCategories(Category user)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;

        }

        public DynamicParameters searchjobs(HomeDto user)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@LocationId", user.LocationId, DbType.String);
            parameters.Add("@CategoryId", user.CategoryId, DbType.String);
            parameters.Add("@Companyname", user.CompanyName, DbType.String);
            parameters.Add("@Jobtitle", user.JobTitle, DbType.String);
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;

        }
    }
}
