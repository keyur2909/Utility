using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SendMail.Services
{
	public class MailSendService
	{
        public MailSendService()
		{
		}
		public static void SendMail(EmailData user)
		{
            try
            {

                SMTPConfigurations _sMTPConfigurations = new SMTPConfigurations();
                _sMTPConfigurations.HostName = ConfigurationManager.AppSetting["SMTPConfigurations:HostName"];
                _sMTPConfigurations.PortNumber =Convert.ToInt32( ConfigurationManager.AppSetting["SMTPConfigurations:PortNumber"]);
                _sMTPConfigurations.FromMail = ConfigurationManager.AppSetting["SMTPConfigurations:FromMail"];
                _sMTPConfigurations.FromName = ConfigurationManager.AppSetting["SMTPConfigurations:FromName"];
                _sMTPConfigurations.Password = ConfigurationManager.AppSetting["SMTPConfigurations:Password"];
                _sMTPConfigurations.SSLEnabled = Convert.ToBoolean(ConfigurationManager.AppSetting["SMTPConfigurations:SSLEnabled"]);
                _sMTPConfigurations.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSetting["SMTPConfigurations:UseDefaultCredentials"]);

                var fromAddress = new MailAddress(_sMTPConfigurations.FromMail, _sMTPConfigurations.FromName);
                var toAddress = new MailAddress(user.ToEmail,user.Name);
                string fromPassword = _sMTPConfigurations.Password;
                string subject = user.Subject;
                string body = user.Message;
                string HostName = _sMTPConfigurations.HostName;
                int PostNumber = _sMTPConfigurations.PortNumber;
                bool IsSslEnabled = _sMTPConfigurations.SSLEnabled;
                bool UseDefaultCredentials = _sMTPConfigurations.UseDefaultCredentials;
                var smtp = new SmtpClient
                {
                    Host = HostName,
                    Port = PostNumber,
                    EnableSsl = IsSslEnabled,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = UseDefaultCredentials,
                    Credentials = new NetworkCredential(fromAddress.Address,fromPassword)
                };

                var message = new MailMessage(fromAddress, toAddress);
                message.Subject = subject;
                message.Body = body;

                smtp.Send(message);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
	}
}
