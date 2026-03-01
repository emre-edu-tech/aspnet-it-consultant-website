using ITCOnsultantWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace ITCOnsultantWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly MailSettings _mailSettings;
        private readonly SiteSettings _siteSettings;

        public ContactController(IOptions<MailSettings> mailSettings, IOptions<SiteSettings> siteSettings)
        {
            _mailSettings = mailSettings.Value;
            _siteSettings = siteSettings.Value;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Contact", "Home");
                // Do not forget to return the proper View (with path) and model
                // return View("Contact", model);
            }

            // Try to send the mail if sending is not successfull then catch the exception and show it to the user by using TempData array.
            try
            {
                // ContactFormModel model includes the field values coming from Contact Form
                // Prepare Email Subject
                var subject = $"[{_siteSettings.Name}] New Contact Form Submission from {model.Name}";

                // Prepare E-mail Message
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_mailSettings.SenderEmail),
                    Subject = subject,
                    Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}",
                    IsBodyHtml = false
                };

                // Add receiving email
                mailMessage.To.Add(_mailSettings.ReceiverEmail);

                // Enter Host, Port, Username, Password, Enable SSL information
                var smtpClient = new SmtpClient(_mailSettings.Server, _mailSettings.Port)
                {
                    Credentials = new NetworkCredential(_mailSettings.Username, _mailSettings.Password),
                    EnableSsl = true
                };

                // Send Mail Message
                smtpClient.Send(mailMessage);
                // Add success message to the Temprary Data
                TempData["Success"] = "Your message has been sent successfully";
            }
            catch (Exception ex)
            {
                // Add message sending error to the Temporary Data 
                TempData["Error"] = $"There was an error sending your message:  {ex.Message}";
            }

            // Always try to use the explicit controller name to avoid conflicts
            return RedirectToAction("Contact", "Home");
        }
    }
}
