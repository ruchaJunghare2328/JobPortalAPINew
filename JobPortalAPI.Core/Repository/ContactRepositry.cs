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
    public class ContactRepositry
    {
        private readonly DatabaseContext _dbContext;

        public ContactRepositry(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Contact(ContactFormDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetContactInfo(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();

                    var queryResult = await connection.QueryMultipleAsync("ContactInformation", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);

                    var Model = queryResult.ReadSingleOrDefault<dynamic>();
                    //var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = Model?.OutcomeId ?? 0;
                    var outcomeDetail = Model?.OutcomeDetail ?? string.Empty;


                    var result = new Result
                    {
                        // Outcome = outcome,
                        Data = Model,
                        //UserId = Model.UserId.ToString()

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
                            StatusCode = 402
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

            //return true; 
        }
        public DynamicParameters SetContactInfo(ContactFormDto user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@Name", user.Name, DbType.String);
            parameters.Add("@Email", user.Email, DbType.String);
            parameters.Add("@Subject", user.Subject, DbType.String);
            parameters.Add("@Message", user.Message, DbType.String);
            parameters.Add("@UserId", user.UserId, DbType.String);
            //parameters.Add("@SessionIds", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            //parameters.Add("@IpAddresss", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;

        }

    }
}
