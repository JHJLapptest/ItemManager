using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailHelper
{
    public class SendEmail
    {
        #region Private Members
        private string _Host;
        private string _Email;
        private string _Password;
        private int _Port;
        #endregion

        #region Public Properties
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        public string Host
        {
            get
            {
                return _Host;
            }
            set
            {
                _Host = value;
            }
        }
        public int Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
            }
        }

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public bool Send(string from, string to, string subject, string body)
        {
            bool result = true;
            try
            {
                MailMessage message = new MailMessage(from, to, subject, body);
                NetworkCredential credentials = new NetworkCredential(_Email, _Password);
                SmtpClient smtp = new SmtpClient(_Host, _Port);
                smtp.EnableSsl = true;
                smtp.Credentials = credentials;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        #endregion
    }
}
