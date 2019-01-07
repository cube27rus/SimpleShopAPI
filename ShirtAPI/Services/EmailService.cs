using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using ShirtAPI.DB.Models;

namespace ShirtAPI.Services
{
    public class EmailService
    {
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", ""));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("", "");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        public static async Task SendOrderMail(OrderDTO order)
        {
            var total = order.ClothesList.Select(x => x.Price).Sum();
            StringBuilder content = new StringBuilder($@"
                <h3 style='color: darkblue'>New order received!</h3>
                <table style='border: 1px solid #333;'>
                    <tbody>
                        <tr>
                            <th style='border: 1px solid black; padding: 10px;'>Email</th>
                            <th style='border: 1px solid black; padding: 10px;'>Phone</th>
                            <th style='border: 1px solid black; padding: 10px;'>FullName</th>
                            <th style='border: 1px solid black; padding: 10px;'>City</th>
                            <th style='border: 1px solid black; padding: 10px;'>Address</th>
                            <th style='border: 1px solid black; padding: 10px;'>PostalCode</th>
                            <th style='border: 1px solid black; padding: 10px;'>Message</th>
                        </tr>
                        <tr>
                            <td style='border: 1px solid black; padding: 10px;'>{order.Email}</td>
                            <td style='border: 1px solid black; padding: 10px;'>{order.Phone}</td>
                            <td style='border: 1px solid black; padding: 10px;'>{order.FullName}</td>
                            <td style='border: 1px solid black; padding: 10px;'>{order.City}</td>
                            <td style='border: 1px solid black; padding: 10px;'>{order.Address}</td>
                            <td style='border: 1px solid black; padding: 10px;'>{order.PostalCode}</td>
                            <td style='border: 1px solid black; padding: 10px;'>{order.Message}</td>
                        </tr>
                    </tbody>
                </table>
                <br><hr><br>");
            content.Append($@"<table style='border: 2px solid darkblue;'> <tbody>");
            content.Append($@"<tr>
                                <th style='border: 1px solid black; padding: 10px;'>Id</th>
                                <th style='border: 1px solid black; padding: 10px;'>Title</th>
                                <th style='border: 1px solid black; padding: 10px;'>Size</th>
                                <th style='border: 1px solid black; padding: 10px;'>Price</th>
                                <th style='border: 1px solid black; padding: 10px;'>TypeName</th>
                            </tr>");
            foreach (var cloth in order.ClothesList)
            {
                content.Append($@"<tr>
                                    <td style='border: 1px solid black; padding: 10px;'>{cloth.Id}</td>
                                    <td style='border: 1px solid black; padding: 10px;'>{cloth.Title}</td>
                                    <td style='border: 1px solid black; padding: 10px;'>{cloth.Size}</td>
                                    <td style='border: 1px solid black; padding: 10px;'>{cloth.Price}</td>
                                    <td style='border: 1px solid black; padding: 10px;'>{cloth.TypeName}</td>
                                </tr>");
            }
            content.Append("</tbody> </table>");
            content.Append($@"<h4>Итого: {total} руб.<h4>");

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("", ""));
            emailMessage.To.Add(new MailboxAddress("", ""));
            emailMessage.Subject = "New order received";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = content.ToString()
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("", "");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
