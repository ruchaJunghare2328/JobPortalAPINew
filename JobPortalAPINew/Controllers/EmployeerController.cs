using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using JopPortalAPI.Core.ModelDtos;
using JopPortalAPI.Services.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Data;
using LicenseContext = OfficeOpenXml.LicenseContext;
using DataTable = System.Data.DataTable;
using Task = System.Threading.Tasks.Task;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using common;
using CsvHelper.Configuration;
using CsvHelper;
using JopPortalAPI.Services.ApiServices;
using System.Globalization;
using JopPortalAPI.Controllers;
using JobPortalAPI.Services.Interfaces;
using JobPortalAPI.Core.ModelDtos;
using JobPortalAPI.Services.ApiServices;
using DocumentFormat.OpenXml.InkML;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExampleFilterAttribute]
    public class EmployeerController : ControllerBase
    {
        // public IConfiguration _configuration;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmployeerController> _logger;
        public readonly IEmployeerServices _employeemaster;

        public EmployeerController(ILogger<EmployeerController> logger, IConfiguration configuration, IEmployeerServices empmaster)
        {
            _logger = logger;
            _configuration = configuration;
            _employeemaster = empmaster;
        }


        [HttpGet("MangageJob")]
        public async Task<IActionResult> GetAll([FromQuery] EmployeerDto user)
        {
            try
            {

                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "GetAll";
                var createduser = await _employeemaster.EmpMaster(user);
                return createduser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("LatestJob")]
        public async Task<IActionResult> LatestJob([FromQuery] EmployeerDto user)
        {
            try
            {

                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "GetAllLatestJob";
                var createduser = await _employeemaster.EmpMaster(user);
                return createduser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetJob")]
        public async Task<IActionResult> GetJob([FromQuery] EmployeerDto user)
        {
            try
            {

                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "GetByIdJob";
                var createduser = await _employeemaster.EmpMaster(user);
                return createduser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("SimilarJobs")]
        public async Task<IActionResult> SimilarJobs([FromQuery] EmployeerDto user)
        {
            try
            {

                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "GetAllSimilarJob";
                var createduser = await _employeemaster.EmpMaster(user);
                return createduser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "Get";
            try
            {
                var parameter = await _employeemaster.Get(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetallappliedCandidatedata")]
        public async Task<IActionResult> GetallappliedCandidatedata([FromQuery] EmployeerDto user)
        {
            try
            {

                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "GetallappliedCandidatedata";
                var createduser = await _employeemaster.EmpMaster(user);
                return createduser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetappliedCandidatedata")]
        public async Task<IActionResult> GetappliedCandidatedata([FromQuery] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetappliedCandidatedata";
            try
            {
                var parameter = await _employeemaster.Get(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetNotificationCount")]
        public async Task<IActionResult> GetNotificationCount([FromQuery] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetNotificationCount";
            try
            {
                var parameter = await _employeemaster.Get(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetCandidateAlertCount")]
        public async Task<IActionResult> GetCandidateAlertCount([FromQuery] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetCandidateAlertCount";
            try
            {
                var parameter = await _employeemaster.Get(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("StausEmp")]
        public async Task<IActionResult> StausEmp([FromBody] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "JobAlert";
            try
            {
                var parameter = await _employeemaster.UpdatestausEmp(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("NotificationMsg")]
        public async Task<IActionResult> NotificationMsg([FromQuery] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetMsgData";
            try
            {
                var parameter = await _employeemaster.GetNotificationMsg(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpPost("EmpViewNotification")]
        public async Task<IActionResult> ViewNotification([FromBody] EmployeerDto user)
        {
            try
            {
                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "EmpViewNotification";

                dynamic createduser = await _employeemaster.EmpMaster(user);
                var outcomeidvalue = createduser.Value.Outcome.OutcomeId;

                return createduser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("FeaturedJobupdate")]
        public async Task<IActionResult> FeaturedJobupdate([FromBody] EmployeerDto user)
        {
            try
            {
                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "SetFeaturedJobs";

                dynamic createduser = await _employeemaster.SetFeatured(user);
                var outcomeidvalue = createduser.Value.Outcome.OutcomeId;

                return createduser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("BookmarkJobupdate")]
        public async Task<IActionResult> BookmarkJobupdate([FromBody] EmployeerDto user)
        {
            try
            {
                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }

                user.BaseModel.OperationType = "SetBookMarkJobs";

                dynamic createduser = await _employeemaster.SetFeatured(user);
                var outcomeidvalue = createduser.Value.Outcome.OutcomeId;

                return createduser;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("GetFeatures")]
        public async Task<IActionResult> GetFeatures([FromQuery] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetFeatured";
            try
            {
                var parameter = await _employeemaster.FeaturedGet(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }


       
        [HttpGet("GetBookmark")]
        public async Task<IActionResult> GetBookmark([FromQuery] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetBookmark";
            try
            {
                var parameter = await _employeemaster.BookmarkGet(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetRole")]  //new
        public async Task<IActionResult> Getrole([FromQuery] EmployeerDto user)
        {

            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "GetRole";
            try
            {
                var parameter = await _employeemaster.Get(user);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }  // new    dd

        [HttpPost("AddJob")]
        public async Task<IActionResult> AddJob([FromBody] EmployeerDto user)
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
                    user.um_updateddate = DateTime.Now;
                    user.BaseModel.OperationType = "Update";
                }
                dynamic createduser = await _employeemaster.EmpMaster(user);
                var outcomeidvalue = createduser.Value.Outcome.OutcomeId;
                //if (outcomeidvalue == 1)
                //{

                //	var datavalue = createduser.Value.Outcome.OutcomeDetail;

                //	await SendNo(datavalue);
                //}

                return createduser;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("Shuffle")]
        public async Task<IActionResult> Shuffle([FromQuery] EmployeerDto user)
        {
            try
            {


                if (user.BaseModel == null)
                {
                    user.BaseModel = new BaseModel();
                }
                user.BaseModel.OperationType = "Shuffle";

                dynamic createduser = await _employeemaster.EmpMaster(user);
                var outcomeidvalue = createduser.Value.Outcome.OutcomeId;


                return createduser;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //private async Task SendNo(dynamic datavalue2)
        //{

        //    string[] parts = datavalue2.Split(';');
        //    string userpassword = "";
        //    string username = "";
        //    string title = "Login Credentials";
        //    string email = "";
        //    if (parts.Length == 3)
        //    {
        //        userpassword = parts[0]; // Extract the password part
        //        email = parts[1];    // Extract the email part
        //        username = parts[2];    // Extract the email part

        //        // Now you can use the password and email variables as needed

        //    }
        //    string htmlContent = "<div style=\"font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;\">" +
        //                "<div style=\"max-width: 600px; margin: 0 auto; background-color: #fff; padding: 20px; border-radius: 5px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\">" +
        //                    "<div style=\"text-align: center;\">" +
        //                        "<h1 style=\"margin: 0; font-size: 28px;\">LMS</h1>" +
        //                    "</div>" +
        //                    "<div style=\"text-align: center; margin-top: 20px;\">" +
        //                        "<h2 style=\"margin: 0;\">Get started</h2>" +
        //                        "<p style=\"margin: 10px 0; font-size: 16px;\">Your account has been created on the LMS. Below are your system generated credentials.</p>" +
        //                        "<p style=\"margin: 10px 0; font-size: 16px;\">Please use this credentials for login</p>" +
        //                        "<div style=\"text-align: center; margin-top: 20px;\">" +
        //                            "<p style=\"margin: 5px 0; font-size: 16px;\"><strong>Username:</strong> " + username + " </p>" +
        //                            "<p style=\"margin: 5px 0; font-size: 16px;\"><strong>Password:</strong> " + userpassword + " </p>" +
        //                        "</div>" +

        //                    "</div>" +
        //                "</div>" +
        //            "</div>";

        //    // Split email addresses
        //    EmailConfigureDto user = new EmailConfigureDto();
        //    dynamic emailDetails = await _employeemaster.GetEmailId(user);





        //    if (emailDetails != null)
        //    {
        //        // Use the retrieved email configuration details to send the email
        //        var message = new MimeMessage();
        //        message.From.Add(new MailboxAddress("Rensa Tubes", emailDetails.Value.Data.email)); // set your email
        //        message.To.Add(new MailboxAddress(null, email.Trim()));

        //        message.Subject = title;
        //        var bodyBuilder = new BodyBuilder();
        //        bodyBuilder.HtmlBody = htmlContent;
        //        message.Body = bodyBuilder.ToMessageBody();

        //        try
        //        {
        //            using (var client = new SmtpClient())
        //            {
        //                // Connect to the SMTP server and send the email
        //                client.Connect(emailDetails.Value.Data.smtp_server, emailDetails.Value.Data.smtp_port, false);
        //                client.Authenticate(emailDetails.Value.Data.email, emailDetails.Value.Data.password);
        //                client.Send(message);
        //                client.Disconnect(true);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle SMTP client errors
        //            Console.WriteLine($"Failed to send email: {ex.Message}");
        //        }
        //    }
        //    else
        //    {
        //        // Handle case where email configuration details are not found
        //        Console.WriteLine("Email configuration details not found.");
        //    }



        //}



        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] EmployeerDto user)
        {
            if (user.BaseModel == null)
            {
                user.BaseModel = new BaseModel();
            }

            user.BaseModel.OperationType = "Delete";
            var usertDetails = await _employeemaster.EmpMaster(user);
            return usertDetails;
        }

        [HttpGet("Email")]
        public async Task<IActionResult> Email([FromQuery] EmployeerDto user)
        {
            try
            {
                if (user.BaseModel == null)
                    user.BaseModel = new BaseModel();

                user.BaseModel.OperationType = "JobAlert";

                var result = await _employeemaster.Email(user);

                if (result is ObjectResult objectResult && objectResult.StatusCode == 200)
                {
                    //  Send email after approval
                    //SendApprovalMail(user.Email);
                    var resultData = objectResult.Value as Result;
                    if (result is ObjectResult objectResult1 && objectResult.StatusCode == 200)
                    {
                        var dataList = ((Result)objectResult.Value).Data as List<dynamic>;
                        var firstRecord = dataList?.FirstOrDefault();

                        if (firstRecord != null)
                        {
                            string candidateEmail = firstRecord.um_EmailId;
                            string candidateName = firstRecord.CanName;
                            string jobTitle = firstRecord.Slug;
                            //   string hrName = user.Name;
                            string ComapnyName = firstRecord.Name;
                            // Check if the candidate email is valid before sending
                            if (!string.IsNullOrWhiteSpace(candidateEmail))
                            {
                                SendApprovalMail(candidateEmail, candidateName, ComapnyName, jobTitle);
                            }
                        }
                    }
                    //if (resultData != null && resultData.Data is List<object> dataList)
                    //{
                    //    // Deserialize the object list to your actual DTO
                    //    var json = JsonConvert.SerializeObject(dataList.FirstOrDefault());
                    //    var model = JsonConvert.DeserializeObject<EmployeerDto>(json);

                    //    if (!string.IsNullOrEmpty(model?.Email))
                    //    {
                    //        SendApprovalMail(model.Email);
                    //    }
                    //}
                }

                return result;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error in MangageJob");
                return StatusCode(500, "Internal Server Error");
            }
        }

        //private void SendApprovalMail(string toEmail)
        //{
        //    try
        //    {
        //        var smtpClient = new System.Net.Mail.SmtpClient(_configuration["MailSettings:Host"])
        //        {
        //            Port = int.Parse(_configuration["MailSettings:Port"]),
        //            Credentials = new System.Net.NetworkCredential(
        //                _configuration["MailSettings:Username"],
        //                _configuration["MailSettings:Password"]
        //            ),
        //            EnableSsl = true,
        //        };

        //        var mail = new System.Net.Mail.MailMessage
        //        {
        //            From = new System.Net.Mail.MailAddress(_configuration["MailSettings:Username"]),
        //            Subject = "Job Application Approved",
        //            Body = "<p>Your application has been approved by the HR team.</p>",
        //            IsBodyHtml = true,
        //        };
        //        mail.To.Add(toEmail);

        //        smtpClient.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error while sending approval email");
        //    }
        //}

        //private void SendApprovalMail(string candidateEmail, string candidateName, string companyName, string jobTitle)
        //{
        //    try
        //    {
        //        var smtpClient = new System.Net.Mail.SmtpClient(_configuration["MailSettings:Host"])
        //        {
        //            Port = int.Parse(_configuration["MailSettings:Port"]),
        //            Credentials = new NetworkCredential(
        //                _configuration["MailSettings:Username"],
        //                _configuration["MailSettings:Password"]
        //            ),
        //            EnableSsl = bool.Parse(_configuration["MailSettings:EnableSsl"])
        //        };

        //        var fromAddress = new MailAddress(_configuration["MailSettings:Username"], companyName);
        //        var mail = new MailMessage
        //        {
        //            From = fromAddress,
        //            Subject = "Your Job Application has been Approved",
        //            Body = $@"
        //        <p>Dear {candidateName},</p>
        //        <p>Congratulations! Your application for the position <strong>{jobTitle}</strong> has been approved by {companyName}.</p>
        //        <p>We will contact you soon with further steps.</p>
        //        <br />
        //        <p>Regards,<br />{companyName} HR Team</p>",
        //            IsBodyHtml = true
        //        };

        //        mail.To.Add(candidateEmail);
        //        smtpClient.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error while sending approval email");
        //    }
        //}
        private async Task SendApprovalMail(string candidateEmail, string candidateName, string companyName, string jobTitle)
        {
            try
            {
                var apiKey = _configuration["SendGrid:ApiKey"];
                var fromEmail = _configuration["SendGrid:FromEmail"];
                var fromName = _configuration["SendGrid:FromName"];

                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(fromEmail, companyName); // You can override name with company name
                var to = new EmailAddress(candidateEmail);

                var subject = "Your Job Application has been Approved";
                var htmlContent = $@"
            <p>Dear {candidateName},</p>
            <p>Congratulations! Your application for the position <strong>{jobTitle}</strong> has been approved by {companyName}.</p>
            <p>We will contact you soon with further steps.</p>
            <br />
            <p>Regards,<br />{companyName} HR Team</p>";

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent: "", htmlContent: htmlContent);
                var response = await client.SendEmailAsync(msg);

                if ((int)response.StatusCode >= 400)
                {
                    _logger.LogError("Failed to send email: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending approval email");
            }
        }


    }


}

