using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SumitPortfolio.Web.Interfaces;

namespace SumitPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public IActionResult Index() => View();


        public async Task<IActionResult> Error()
        {
            try
            {
                string errorMessage = "Some error occurred. Please try again.";
                var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                if (exceptionFeature != null)
                {
                    string routeWhereExceptionOccurred = exceptionFeature.Path;
                    Exception exceptionThatOccurred = exceptionFeature.Error;
                    if (exceptionThatOccurred != null)
                    {
                        errorMessage = exceptionThatOccurred.Message;
                        SendErrorEmail(exceptionThatOccurred.ToString());
                    }
                }
                var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                if (isAjax)
                    return BadRequest(new { success = false, message = errorMessage });
                else
                    return View();
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [NonAction]
        private void SendErrorEmail(string Message)
        {


            StringBuilder sb = new StringBuilder();

            sb.Append("<head>");
            sb.Append("<title></title>");
            sb.Append("</head>");
            sb.Append("<body style='font-size: 10pt; font-style: normal; font-family: Calibri' >");
            sb.Append("<table width=100% cellspacing=0 cellpadding=0 style='border:1px solid #4c7a5d;border-radius: 20px; backgroundcolor:#7655a573; ' ><tbody style='font-size: 12pt; font-style: normal; font-family: Calibri;'>");

            sb.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            sb.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            sb.Append("<tr><td colspan='2' style='padding-left:10px; font-size:15px;'>Dear Admin </td></tr>");
            sb.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            sb.Append("<tr><td colspan='2' style='padding-left:10px; font-size:15px;'>Some Error has occured </td></tr>");
            sb.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            sb.Append("<tr><td align='left' colspan='2'>");
            sb.Append("<table width='100%' cellpadding='0' cellpadding='0' style='font-family: Calibri; font-size: 12px;color:black;border-collapse:collapse'>");

            sb.Append("<tr><td  colspan='2' style='padding-left:10px; font-size:15px;'>"+Message+"</td></tr>");
            sb.Append("<tr><td   colspan='2' style='padding-left:10px;'><br/> </td></tr>");
            sb.Append("<tr><td   colspan='2' style='padding-left:10px;'><br/> </td></tr>");

            sb.Append("<tr><td   colspan='2' style='padding-left:10px;'><br/> </td></tr>");

            sb.Append("</table>");
            sb.Append("</td></tr>");

            sb.Append("<tr><td>&nbsp;</td></tr>");
            sb.Append("</tbody></table><br><br>");
            string sub = "Error Occured";
            _emailService.SendEmailWithoutBcc("sks13072003@gmail.com", sub, sb.ToString());

        }
    }
}
