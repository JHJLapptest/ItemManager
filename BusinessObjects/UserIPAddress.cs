using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DatabaseHelper;

namespace BusinessObjects
{
    class UserIPAddress
    {
        #region Private Members
        private string _IPAddress;
        private string _TrustedIP;
        private Guid _UserID;
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
        public string TrustedIP
        {
            get
            {
                return _TrustedIP;
            }
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



        public bool UserIPInsert(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblUserInsert";
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
        public UserIPAddress()
        {
            _IPAddress = string.Empty;
            _TrustedIP = string.Empty;
            _UserID = Guid.Empty;
        }
    }
}
