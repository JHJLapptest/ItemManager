using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessObjects;
using DatabaseHelper;
using EmailHelper;

namespace BusinessObjects
{
    public class UserIPAddress : HeaderData
    {
        #region Private Members
        private string _IPAddress;
        private bool _TrustedIP;
        private Guid _UserID;
        public static string pin;
        private string _Email;
        private BrokenRuleList _BrokenRules = new BrokenRuleList();
        
        #endregion
        #region Public Properties
        public string IPAddress
        {
            get
            {
                return _IPAddress;
            }
            set
            {
                if (_IPAddress != value)
                {
                    _IPAddress = value;
                }
            }
        }
        public bool TrustedIP
        {
            get
            {
                return _TrustedIP;
            }
            //set
            //{
            //    _TrustedIP = value;
            //    return value;
            //}
        }
        public Guid UserID
        {
            get
            {
                return _UserID;
            }
        }
        

        public BrokenRuleList BrokenRules
        {
            get
            {
                return _BrokenRules;
            }
        }
        #endregion

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rng = new Random();
            return _rng.Next(_min, _max);
        }

        public bool Insert(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblUserIPInsert";
                database.Command.Parameters.Add("@DateAdded", SqlDbType.DateTime).Value = DateTime.Now;
                database.Command.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = _IPAddress;
                database.Command.Parameters.Add("@TrustedIP", SqlDbType.Bit).Value = _TrustedIP;
                database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;

                base.Initialize(database, Guid.Empty);
                database.ExecuteNonQueryJWithTransaction();
                base.Initialize(database.Command);
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;
        }
        public bool Update(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblUserIPUpdate";
                database.Command.Parameters.Add("@TrustedIP", SqlDbType.Bit).Value = _TrustedIP;
                database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;

                base.Initialize(database, base.ID);
                database.ExecuteNonQueryJWithTransaction();
                base.Initialize(database.Command);
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }
        public bool Delete(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblUserIPDelete";

                base.Initialize(database, base.ID);
                database.ExecuteNonQueryJWithTransaction();
                base.Initialize(database.Command);
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }
        public void ConfirmIP()
        {
            EmailConfig emailConfig = new EmailConfig();
            emailConfig = emailConfig.GetByName("gmail");
            SendEmail se = new SendEmail();
            se.Email = emailConfig.Email;
            se.Password = emailConfig.Password;
            se.Host = emailConfig.Host;
            se.Port = emailConfig.Port;
            pin = GenerateRandomNo().ToString();
            string body = string.Format("Here is your code to authorize this IP address ("+ ") as a Trusted IP /n" + pin);
            //se.Send("JHJLapptest@gmail.com", _Email, "Authorize this IP", body);
        }

        public UserIPAddress()
        {
            _IPAddress = string.Empty;
            _TrustedIP = false;
            _UserID = Guid.Empty;
        }
    }
}
