using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseHelper;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using BusinessObjects;

namespace BusinessObjects
{
    public class EmailConfig : HeaderData //Inherits HeaderData.cs
    {
        #region Private Members
        private string _Email;
        private string _Password;
        private string _Host;
        private int _Port;
        private string _Name;
        //private BrokenRuleList _BrokenRules = new BrokenRuleList();
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
                if (_Email != value)
                {
                    _Email = value;
                    base.IsDirty = true;
                }
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
                if (_Password != value)
                {
                    _Password = value;
                    base.IsDirty = true;
                }
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
                if (_Host != value)
                {
                    _Host = value;
                    base.IsDirty = true;
                }
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
                if (_Port != value)
                {
                    _Port = value;
                    base.IsDirty = true;
                }
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    base.IsDirty = true;
                }
            }
        }
        //public BrokenRuleList BrokenRules
        //{
        //    get
        //    {
        //        return _BrokenRules;
        //    }
        //}
        #endregion

        #region Private Methods
        private bool Insert(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblEmailConfigInsert";
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                database.Command.Parameters.Add("@Host", SqlDbType.VarChar).Value = Host;
                database.Command.Parameters.Add("@Port", SqlDbType.Int).Value = _Port;
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;
                
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
        private bool Update(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblEmailConfigUpdate";
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                database.Command.Parameters.Add("@Host", SqlDbType.VarChar).Value = Host;
                database.Command.Parameters.Add("@Port", SqlDbType.Int).Value = _Port;
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;

                base.Initialize(database, base.ID);
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
        private bool Delete(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblEmailConfigDelete";

                base.Initialize(database, base.ID);
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
        private bool IsValid()
        {
            bool result = true; //true unless told it's wrong
            //_BrokenRules.List.Clear();

            if (_Email == null || _Email.Trim() == string.Empty)
            {
                result = false;
                //BrokenRule br = new BrokenRule("Email cannot be empty.");
                //_BrokenRules.List.Add(br);
            }
            if (_Password == null || _Password.Trim() == string.Empty)
            {
                result = false;
                //BrokenRule br = new BrokenRule("Password cannot be empty.");
                //_BrokenRules.List.Add(br);
            }
            if (_Host == null || _Host.Trim() == string.Empty)
            {
                result = false;
                //BrokenRule br = new BrokenRule("Host cannot be empty.");
                //_BrokenRules.List.Add(br);
            }
            if (_Port == 0 || _Port > 65535)
            {
                result = false;
                //BrokenRule br = new BrokenRule("Invalid port number. Must use port 587.");
                //_BrokenRules.List.Add(br);
            }
            if (_Name == null || _Name.Trim() == string.Empty)
            {
                result = false;
                //BrokenRule br = new BrokenRule("Username cannot be empty.");
                //_BrokenRules.List.Add(br);
            }

            if (_Password == null || _Password.Trim().Contains(" "))
            {
                result = false;
                //BrokenRule br = new BrokenRule("Password cannot contain spaces.");
                //_BrokenRules.List.Add(br);
            }
            Regex regex = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
            Match match = regex.Match(_Email);
            if (!match.Success)
            {
                result = false;
                //BrokenRule br = new BrokenRule("Email is in the wrong format.");
                //_BrokenRules.List.Add(br);
            }

            return result;
        }
        #endregion

        #region Public Methods
        public EmailConfig Save()
        {
            bool result = true;
            Database database = new Database("ItemManager");
            if (base.IsNew == true && IsSavable() == true)
            {
                result = Insert(database);
            }
            else if (base.Deleted == true && base.IsDirty == true)
            {
                result = Delete(database);
            }
            else if (base.IsNew == false && IsSavable() == true)
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

            if (base.IsDirty == true && IsValid() == true)
            {
                result = true;
            }
            return result;
        }
        public void InitializeBusinessData(DataRow dr)
        {
            _Email = dr["Email"].ToString();
            _Password = dr["Password"].ToString();
            _Host = dr["Host"].ToString();
            _Port = (int)dr["Port"];
            _Name = dr["Name"].ToString();
        }
        public EmailConfig GetById(Guid id)
        {
            Database database = new Database("ItemManager");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblEmailConfigGetById";
            database.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
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
            else return null;
        }
        public EmailConfig GetByName(string name)
        {
            Database database = new Database("ItemManager");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblEmailConfigGetByName";
            database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
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
            else
            {
                return null;
            }
        }

        #endregion

        #region Construction
        public EmailConfig()
        {
            _Email = string.Empty;
            _Password = string.Empty;
            _Host = string.Empty;
            _Port = 0;
            _Name = string.Empty;
        }
        #endregion
    }
}
