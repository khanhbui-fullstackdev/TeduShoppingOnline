using System.Net.Mail;
using System.Text;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Common.Helpers
{
    public class MailHelper
    {
        public static bool SendMail(string toEmail, string subject, string content)
        {
            try
            {
                var host = ConfigHelper.GetByKey(CommonConstants.SMTPHost);
                var port = int.Parse(ConfigHelper.GetByKey(CommonConstants.SMTPPort));
                var fromEmail = ConfigHelper.GetByKey(CommonConstants.FromEmailAddress);
                var password = ConfigHelper.GetByKey(CommonConstants.FromEmailPassword);
                var fromName = ConfigHelper.GetByKey(CommonConstants.FromName);

                var smtpClient = new SmtpClient(host, port)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 100000
                };

                var mail = new MailMessage
                {
                    Body = content,
                    Subject = subject,
                    From = new MailAddress(fromEmail, fromName)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                smtpClient.Send(mail);

                return true;
            }
            catch (SmtpException smex)
            {

                return false;
            }
        }
    }
}
