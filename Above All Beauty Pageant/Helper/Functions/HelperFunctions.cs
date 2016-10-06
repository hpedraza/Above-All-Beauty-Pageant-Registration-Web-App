using Above_All_Beauty_Pageant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Above_All_Beauty_Pageant.Helper.Functions
{
    public class HelperFunctions
    {
        public object[] getEnumDisplayAnnotaion(AgeGroup group, int num)
        {
            var enumType = group.GetType();
            var enumValue = Enum.GetName(enumType, num);
            var member = enumType.GetMember(enumValue)[0];

            return member.GetCustomAttributes(typeof(DisplayAttribute), false);
        }

        
        public void SendEmailNotification(string email , string participantName)
        {

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "mail.aboveallbeautypageant.net";
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("do_not_reply@aboveallbeautypageant.net", "Steph233_");

            MailMessage mailMessage = new MailMessage("do_not_reply@aboveallbeautypageant.net", email);
            mailMessage.Subject = string.Format("Thank you for registering {0}", participantName);
            mailMessage.Body = "Thank you for registering, we look forward to having a fun competitive beauty pageant!";

            client.Send(mailMessage);

        }
    }
}