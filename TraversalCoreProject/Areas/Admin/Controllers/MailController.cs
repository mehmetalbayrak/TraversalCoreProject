using DocumentFormat.OpenXml.Drawing.Charts;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequestModel mailRequestModel)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Traversal Core Admin","metesanapi@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",mailRequestModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequestModel.Subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequestModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("metesanapi@gmail.com", "");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
