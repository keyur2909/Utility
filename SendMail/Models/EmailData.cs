using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SendMail.Models
{
	public class EmailData
	{
		[Required(ErrorMessage ="Please enter your name.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please enter your email address.")]
		[EmailAddress(ErrorMessage ="Please enter valid email address.")]
		public string ToEmail { get; set; }
		[Required(ErrorMessage = "Please enter subject.")]
		public string Subject { get; set; }
		[Required(ErrorMessage = "Please enter message.")]
		public string Message { get; set; }

	}
}
