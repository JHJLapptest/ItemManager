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
        private User user;
        private string _IPAddress;
        private bool _TrustedIP;
        private Guid _UserID;
        public static string pin;
        private string _Email;
        private string a4;
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
                    base.IsDirty = true;
                }
            }
        }
        public bool TrustedIP
        {
            get
            {
                return _TrustedIP;
            }
            set
            {
                _TrustedIP = value;
                base.IsDirty = true;
            }
        }
        public Guid UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                if (_UserID != value)
                {
                    _UserID = value;
                    base.IsDirty = true;
                }
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

        public UserIPAddress Save()
        {
            Database database = new Database("ItemManager");
            //_UserID = ParentID;

            bool result = true;
            if (base.IsNew == true && base.IsDirty == true)
            {
                result = Insert(database);
            }
            else if (base.Deleted == true && base.IsDirty == true)
            {
                result = Delete(database);
            }
            else if (base.IsNew == false && base.IsDirty == true/* && IsSavable() == true*/)
            {
                result = Update(database);
            }
            if (result == true)
            {
                base.IsNew = false;
                base.IsDirty = false;
            }
            return this;
        }
        public bool IsSavable()
        {
            bool result = false;

            if (base.IsDirty == true )
            {
                result = true;
            }
            return result;
        }

        public void InitializeBusinessData(DataRow dr)
        {
            _IPAddress = dr["IPAddress"].ToString();
            _TrustedIP = (bool)dr["TrustedIP"];
            _UserID = (Guid)dr["UserID"];

        }

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
                database.Command.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress;
                database.Command.Parameters.Add("TrustedIP", SqlDbType.Bit).Value = _TrustedIP;
                database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;

                base.Initialize(database, Guid.Empty);
                database.ExecuteNonQueryJ();
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
                database.ExecuteNonQueryJ();
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
                database.ExecuteNonQueryJ();
                base.Initialize(database.Command);
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }
        public UserIPAddress SearchIP()
        {
            //bool result = true;
            //try
            //{
            Database database = new Database("ItemManager");
            DataTable dt = new DataTable();
            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblUserIPGetByStatus";
            database.Command.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = _IPAddress;
            //database.Command.Parameters.Add("TrustedIP", SqlDbType.Bit).Value = _TrustedIP;
            database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;

            dt = database.ExecuteQuery();
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                base.Initialize(dr);
                InitializeBusinessData(dr);
                base.IsNew = false;
                base.IsDirty = false;
                return this;
            }
            else return this;
                

                //base.Initialize(database, Guid.Empty);
                //database.ExecuteNonQueryJ();
                //base.Initialize(database.Command);
            //}
            //catch
            //{
            //    //result = false;
            //    throw;
            //}
            //return this;
        }

        public void ConfirmIP(string email)
        {
            //user = new User();
            //user = user.GetById(_UserID);
            _Email = email;
            EmailConfig emailConfig = new EmailConfig();
            emailConfig = emailConfig.GetByName("gmail");
            SendEmail se = new SendEmail();
            se.Email = emailConfig.Email;
            se.Password = emailConfig.Password;
            se.Host = emailConfig.Host;
            se.Port = emailConfig.Port;
            pin = GenerateRandomNo().ToString();
            string body = string.Format("Here is your code to authorize this IP address ("+_IPAddress+") as a Trusted IP \n" + pin);
            se.Send("JHJLapptest@gmail.com", _Email, "Authorize this IP", body);
        }
        public string GetPublicIP()
        {
            try
            {
                string url = "http://checkip.dyndns.org";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] a = response.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                _IPAddress = a3[0];
            }
            catch
            {
                //MessageBox.Show("Connection status: Offline", "Error!");
            }
            return _IPAddress;
        }
        public UserIPAddress()
        {
            _IPAddress = string.Empty;
            _TrustedIP = false;
            _UserID = Guid.Empty;
        }
    }
}
