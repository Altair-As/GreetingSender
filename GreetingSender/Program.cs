using GreetingSender.Data;
using System.Net.Mail;
using System;
using MimeKit;
using GreetingSender.Models;
using System.Runtime.ConstrainedExecution;
using System.Net;

using (var dbContext = new ApplicationDbContext())
{
    var emp = dbContext.Employees.First();

    List<Employee> users = dbContext.Employees.Where(c => c.DateOfBirth.DayOfYear == DateTime.Today.DayOfYear)
        .ToList();

    foreach (var user in users)
    {
        string senderEmail = "test.ivanov01@outlook.com";
        string recipientEmail = user.Email;
        string subject = "Поздравляем Вас с днём рождения";

        string htmlBody = @"
            <html>
            <head>
                <style>
                    .card {
                        display: flex;
                        align-items: center;
                        border: 1px solid #ccc;
                        border-radius: 10px;
                        background-color: #f9f9f9;
                        font-family: Arial, sans-serif;
                        width: 400px;
                    }

                    .left-side {
                        flex: 1;
                        padding: 20px;
                        box-sizing: border-box;
                    }

                    .left-side h2 {
                        font-size: 18px;
                        color: #007bff;
                        margin-bottom: 10px;
                    }

                    .left-side h1 {
                        font-size: 32px;
                        margin-bottom: 20px;
                    }

                    .left-side p {
                        font-size: 16px;
                        margin-bottom: 10px;
                    }
                </style>
            </head>
            <body>

                <div class=""card"">
                    <div class=""left-side"">
                        <h2>Дорогой " + user.Name + @"</h2>
                        <h1>С днём рождения!</h1>
                        <p>Желаем здоровья, энергии, оптимизма, удачи, благополучия, счастья, любви. Пусть семья будет для тебя надёжным тылом. Легко поднимайтесь по карьерной лестнице и получайте достойную оплату за свой труд.</p>
                        <p>С уважением ООО ""БПО""</p>
                    </div>
                </div>

    

            </body>
            </html>";

        string body = htmlBody;

        SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new NetworkCredential("test.ivanov01@outlook.com", "m123456m");

        MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);
        mailMessage.IsBodyHtml = true;

        smtpClient.Send(mailMessage);

        Console.WriteLine("Email sent successfully!");

    }
}
