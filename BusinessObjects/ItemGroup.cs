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
    class ItemGroup : HeaderData
    {
        #region Private Members
        private string _Name;
        private Guid _UserID;
        private BrokenRuleList _BrokenRules = new BrokenRuleList();
        #endregion

        #region Public Properties
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
                    bool savable = IsSavable();
                }
            }
        }
        #endregion

        #region Private Methods
        private bool Insert(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblItemGroupInsert";
                database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;

                base.Initialize(database, Guid.Empty);
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
        private bool Update(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblItemGroupUpdate";
                database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;

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
                database.Command.CommandText = "tblItemGroupDelete";

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
        
        private bool IsValid()
        {
            bool result = true; //true unless told it's wrong
            _BrokenRules.List.Clear();

            if (Name == null || _Name.Trim() == string.Empty)
            {
                result = false;
                BrokenRule br = new BrokenRule("Please name your collection.");
                _BrokenRules.List.Add(br);
            }
            if (_UserID == Guid.Empty || UserID == null)
            {
                result = false;
                BrokenRule br = new BrokenRule("Error Code: FUCK YOUUUUUUUUUUUUUU!!!!!!!!");
                _BrokenRules.List.Add(br);
            }
            //Regex regex = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]+?\.[a-zA-Z]{2,3}$");
            //Match match = regex.Match(_Email);
            //if (!match.Success)
            //{
            //    result = false;
            //    BrokenRule br = new BrokenRule("Email is in the wrong format.");
            //    _BrokenRules.List.Add(br);
            //}

            return result;
        }

        #endregion

        #region Public Methods
        public ItemGroup Save(Database database, Guid ParentID)
        {
            _UserID = ParentID; // How these get linked together. See UserFriendList.cs Comment: CONNECTAddress

            bool result = true;
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
            _UserID = (Guid)dr["UserID"];
            _Name = dr["Name"].ToString();

        }
        public ItemGroup GetById(Guid id)
        {
            Database database = new Database("ItemManager");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblItemGroupGetById";
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
        #endregion

        #region Construction
        public ItemGroup()
        {
            _UserID = Guid.Empty;
            _Name = string.Empty;
        }
        #endregion
    }
}
