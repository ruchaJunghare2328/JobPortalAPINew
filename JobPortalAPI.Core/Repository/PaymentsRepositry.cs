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
    public  class PaymentsRepositry
    {
        private readonly DatabaseContext _dbContext;

        public PaymentsRepositry(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> CreateOrder(PaymentRequest model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetOrder(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();

                    var queryResult = await connection.QueryMultipleAsync("proc_UserMaster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);

                    var Model = queryResult.ReadFirstOrDefault<dynamic>();
                    var outcome = queryResult.ReadFirstOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;

                    string UserId = string.Empty;
                    if (((IDictionary<string, object>)Model).TryGetValue("UserId", out var userIdValue))
                    {
                        UserId = userIdValue?.ToString() ?? string.Empty;
                    }

                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        UserId = Model.UserId.ToString()

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
        public async Task<IActionResult> Payment(PaymentVerifyDto model)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameter = SetPayment(model);
                try
                {
                    var sqlConnection = (Microsoft.Data.SqlClient.SqlConnection)connection;
                    await sqlConnection.OpenAsync();

                    var queryResult = await connection.QueryMultipleAsync("proc_UserMaster", parameter, commandType: CommandType.StoredProcedure, commandTimeout: 300);

                    var Model = queryResult.ReadSingleOrDefault<dynamic>();
                    var outcome = queryResult.ReadSingleOrDefault<Outcome>();
                    var outcomeId = outcome?.OutcomeId ?? 0;
                    var outcomeDetail = outcome?.OutcomeDetail ?? string.Empty;

                    string UserId = string.Empty;
                    if (((IDictionary<string, object>)Model).TryGetValue("UserId", out var userIdValue))
                    {
                        UserId = userIdValue?.ToString() ?? string.Empty;
                    }

                    var result = new Result
                    {
                        Outcome = outcome,
                        Data = Model,
                        UserId = Model.UserId.ToString()

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

        public DynamicParameters SetPayment(PaymentVerifyDto user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@CompanyId", user.CompanyId, DbType.String);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@razorpay_order_id", user.razorpay_order_id, DbType.String);
            parameters.Add("@razorpay_payment_id", user.razorpay_payment_id, DbType.String);
            parameters.Add("@razorpay_signature", user.razorpay_signature, DbType.String);
            parameters.Add("@PaymentStatus", user.PaymentStatus, DbType.Int32);
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;

        }

        public DynamicParameters SetOrder(PaymentRequest user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OperationType", user.BaseModel.OperationType, DbType.String);
            parameters.Add("@PlanName", user.PlanName, DbType.String);
            parameters.Add("@UserId", user.UserId, DbType.String);
            parameters.Add("@PlanDuration", user.Duration, DbType.String);
            parameters.Add("@CompanyId", user.CompanyId, DbType.String);
            parameters.Add("@OutcomeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OutcomeDetail", dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
            return parameters;

        }

    }
}
