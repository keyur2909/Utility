using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendMail.Models
{
	public class SMTPConfigurations
	{
		public string HostName { get; set; }
		public int PortNumber { get; set; }
		public string FromMail { get; set; }
		public string FromName { get; set; }
		public string Password { get; set; }
		public bool SSLEnabled { get; set; }
		public bool UseDefaultCredentials { get; set; }

	}
}
