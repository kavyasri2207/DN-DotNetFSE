using System;
using System.Net;
using System.Net.Mail;

namespace CustomerCommLib
{
    // Interface to ensure loose coupling
    public interface IMailSender
    {
        bool SendMail(string toAddress, string message);         
    }

    // Concrete implementation that actually hits the SMTP server
    public class MailSender : IMailSender
    {	
        public bool SendMail(string toAddress, string message)
        {
            try 
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("your_email_address@gmail.com");
                mail.To.Add(toAddress);
                mail.Subject = "Test Mail";
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception)
            {
                // In a real scenario we would log the error
                return false;
            }
        }
    }

    // Class under test using Constructor Injection
    public class CustomerComm
    {
        IMailSender _mailSender;

        // Constructor Injection makes this class easily testable via Moq!
        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            // Actual logic goes here
            // define message and mail address
            
            _mailSender.SendMail("cust123@abc.com", "Some Message");
            
            return true;
        }
    }
}
