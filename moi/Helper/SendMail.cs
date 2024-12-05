using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace moi.Helper
{
    public class SendMail
    {
        public static bool SendEmail(string to, string subject, string body, string attachFile)
        {
            try
            {
                // Tạo một thể hiện của lớp ConstantHelper
                ConstantHelper constantHelper = new ConstantHelper();

                // Sử dụng thể hiện này để truy cập các thành viên không tĩnh của lớp ConstantHelper
                MailMessage msg = new MailMessage(constantHelper.emailSender, to, subject, body);

                using (var client = new SmtpClient(constantHelper.hostEmail, constantHelper.portEmail))
                {
                    client.EnableSsl = true;

                    if(!string.IsNullOrEmpty(attachFile))
                    {
                        Attachment attachment = new Attachment(attachFile);
                        msg.Attachments.Add(attachment);
                    }    
                    NetworkCredential credential = new NetworkCredential(constantHelper.emailSender, constantHelper.passwordSender);
                    client.UseDefaultCredentials = false;
                    client.Credentials = credential;
                    client.Send(msg);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
