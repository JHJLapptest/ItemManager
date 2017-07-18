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
    public class UserIPAddress : HeaderData
    {
        #region Private Members
        private string _IPAddress;
        private bool _TrustedIP;
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
        private bool Update(Database database)
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
        private bool Delete(Database database)
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

        public UserIPAddress()
        {
            _IPAddress = string.Empty;
            _TrustedIP = false;
            _UserID = Guid.Empty;
        }
    }
}
