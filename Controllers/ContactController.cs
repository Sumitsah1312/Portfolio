using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SumitPortfolio.Models;
using SumitPortfolio.Web.Interfaces;

namespace SumitPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;
        public ContactController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> ConnectMessage(ConnectForm model)
        {
            SendMessage(model.FirstName + (model.LastName!=null?" "+model.LastName:""), model.Email??"", model.Mobile??"", model.Message??"");
            return RedirectToAction("Index", "Home");
        }

                [NonAction]
        private void SendMessage(string Name, string EmailId,string Mobile, string Message)
        {
            

            StringBuilder sb = new StringBuilder();

            sb.Append("<head>");
            sb.Append("<title></title>");
            sb.Append("</head>");
            sb.Append("<body style='font-size: 10pt; font-style: normal; font-family: Calibri' >");
            sb.Append("<table width=100% cellspacing=0 cellpadding=0 style='border:1px solid #4c7a5d;border-radius: 20px; backgroundcolor:#7655a573; ' ><tbody style='font-size: 12pt; font-style: normal; font-family: Calibri;'>");
            
            sb.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            sb.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            sb.Append("<tr><td colspan='2' style='padding-left:10px; font-size:15px;'>" + Name + " wants to connect with you. </td></tr>");
            sb.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            sb.Append("<tr><td align='left' colspan='2'>");
            sb.Append("<table width='100%' cellpadding='0' cellpadding='0' style='font-family: Calibri; font-size: 12px;color:black;border-collapse:collapse'>");

            sb.Append("<tr><td  colspan='2' style='padding-left:10px; font-size:15px;'><strong>Email : </strong>" + EmailId + "</td></tr>");
            sb.Append("<tr><td   colspan='2' style='padding-left:10px;'><br/> </td></tr>");
            sb.Append("<tr><td  colspan='2' style='padding-left:10px; font-size:15px;'><strong>Mobile : </strong>" + Mobile + "</td></tr>");
            sb.Append("<tr><td   colspan='2' style='padding-left:10px;'><br/> </td></tr>");
            sb.Append("<tr><td  colspan='2' style='padding-left:10px; font-size:15px;'> "+Message+"</td></tr>");
            sb.Append("<tr><td   colspan='2' style='padding-left:10px;'><br/> </td></tr>");

            sb.Append("<tr><td   colspan='2' style='padding-left:10px;'><br/> </td></tr>");

            sb.Append("</table>");
            sb.Append("</td></tr>");
            
            sb.Append("<tr><td>&nbsp;</td></tr>");
            sb.Append("</tbody></table><br><br>");
            string sub = Name +" wants to connect with you.";
            _emailService.SendEmailWithoutBcc("sks13072003@gmail.com", sub, sb.ToString());
            
        }

    }
}
