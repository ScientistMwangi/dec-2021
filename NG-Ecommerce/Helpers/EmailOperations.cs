using EcommerceCore.DataLayer;
using EcommerceCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using static EcommerceCore.Models.EcommerceConstants;

namespace NG_Ecommerce.Helpers
{
    public static class EmailOperations
    {
        public static void EmailSend(EcommerceDbContext _context, string to, string subject, string body)
        {
            // Disable logging on file
            //string localdir = AppDomain.CurrentDomain.BaseDirectory + "\\RCMErrorLog";
            //FileStream fs = new FileStream(localdir + "\\ServiceErrorALL.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            //StreamWriter m_streamWriter = new StreamWriter(fs);

            // Keep email logs
            var emailLog = new EmailLog();

            var Params = _context.SystemParameters.Where(p => p.ParameterType == "Email").ToList();
            var emailsender = Params.Where(p => p.ParameterName == "emailSender").FirstOrDefault().ParameterValue;
            var smtpAddress = Params.Where(p => p.ParameterName == "emailsmtpAddress").FirstOrDefault().ParameterValue;//Params.FirstOrDefault(o => o.ParameterName == "").ParameterValue;
            var portNumber = Params.Where(p => p.ParameterName == "emailportNumber").FirstOrDefault().ParameterValue;// Params.FirstOrDefault(o => o.ParameterName == "emailportNumber").ParameterValue;
            var enableSSL = Params.Where(p => p.ParameterName == "emailenableSSl").FirstOrDefault().ParameterValue; //Params.FirstOrDefault(o => o.ParameterName == "emailenableSSl").ParameterValue;
            var password = Params.Where(p => p.ParameterName == "emailpassword").FirstOrDefault().ParameterValue; //Params.FirstOrDefault(o => o.ParameterName == "emailpassword").ParameterValue;

            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(to));
            mail.From = new MailAddress(emailsender);
            mail.Subject = subject;
            mail.Body = body;

            // Fill logs
            emailLog.DateCreated = DateTime.Now;
            emailLog.EmailTo = mail.To.ToString();
            emailLog.EmailContent = body;
            emailLog.CreatedBy = "System";


            //if (item.attachment != null)
            //{
            //    MemoryStream memoryStream = new MemoryStream(item.attachment);
            //    Attachment mailAttachment = new Attachment(memoryStream, item.attachment_name, "application/pdf");
            //    mail.Attachments.Add(mailAttachment);
            //}

            mail.IsBodyHtml = true;
            // Can set to false, if you are sending pure text.
            try
            {
                using (SmtpClient smtp = new SmtpClient(smtpAddress, int.Parse(portNumber)))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = bool.Parse(enableSSL);
                    smtp.Credentials = new NetworkCredential(emailsender.Trim(), password.Trim());
                    // smtp.DeliveryMethod = SmtpDeliveryMethod.Network;ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                    smtp.Send(mail);
                    //var query = string.Format("update NotificationMessages set sent=1,datesent='{0}' where id={1}", DateTime.Now, item.Id);
                    //new Db().Database.ExecuteSqlCommand(query, new object[] { });
                    emailLog.EmailStatus = EmailStatus.Sent;
                }
            }
            catch(Exception e)
            {
                emailLog.EmailStatus = EmailStatus.Failed;
                emailLog.ExceptionIssue = e.Message;
            }

            _context.Add(emailLog);
            _context.SaveChanges();

        }

        public static List<string> GetSubjectAndBoday(EmailTemplateType type, EcommerceDbContext _context)
        {
            var list = new List<string>();
            var emailTemplate = _context.EmailTemplates.Where(t => t.TemplateType == type).FirstOrDefault();
            list.Add(emailTemplate.Subject);
            list.Add(emailTemplate.EmailBody);
            return list;
        }
    }
}