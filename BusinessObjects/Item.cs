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
    public class Item : HeaderData
    {
        #region Private Members
        private Guid _ItemGroupID;
        private string _Name;
        private string _Type;
        private bool _WishlistStatus;
        private int _Quantity;
        private decimal _Value;
        private BrokenRuleList _BrokenRules = new BrokenRuleList();
        #endregion

        #region Public Properties
        public Guid ItemGroupID
        {
            get
            {
                return _ItemGroupID;
            }
            set
            {
                if (_ItemGroupID != value)
                {
                    _ItemGroupID = value;
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
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (_Type != value)
                {
                    _Type = value;
                    base.IsDirty = true;
                }
            }
        }
        public bool WishListStatus
        {
            get
            {
                return _WishlistStatus;
            }
            set
            {
                if (_WishlistStatus != value)
                {
                    _WishlistStatus = value;
                    base.IsDirty = true;
                }
            }
        }
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                if (_Quantity != value)
                {
                    _Quantity = value;
                    base.IsDirty = true;
                }
            }
        }
        public decimal Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
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

        #region Private Methods
        private bool Insert(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblItemInsert";
                database.Command.Parameters.Add("@ItemGroupID", SqlDbType.UniqueIdentifier).Value = _ItemGroupID;
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;
                database.Command.Parameters.Add("@Type", SqlDbType.VarChar).Value = _Type;
                database.Command.Parameters.Add("@WishlistStatus", SqlDbType.Bit).Value = _WishlistStatus;
                database.Command.Parameters.Add("@Quantity", SqlDbType.Int).Value = _Quantity;
                database.Command.Parameters.Add("@Value", SqlDbType.Decimal).Value = _Value;


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
                database.Command.CommandText = "tblItemUpdate";
                database.Command.Parameters.Add("@ItemGroupID", SqlDbType.UniqueIdentifier).Value = _ItemGroupID;
                database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = _Name;
                database.Command.Parameters.Add("@Type", SqlDbType.VarChar).Value = _Type;
                database.Command.Parameters.Add("@WishlistStatus", SqlDbType.Bit).Value = _WishlistStatus;
                database.Command.Parameters.Add("@Quantity", SqlDbType.Int).Value = _Quantity;
                database.Command.Parameters.Add("@Value", SqlDbType.Decimal).Value = _Value;

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
                database.Command.CommandText = "tblItemDelete";

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
                BrokenRule br = new BrokenRule("Please name your item.");
                _BrokenRules.List.Add(br);
            }
            if (_Quantity < 0)
            {
                result = false;
                BrokenRule br = new BrokenRule("Quantity must be 0 or higher.");
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
        public Item GetByID(Guid ID)
        {
            Database database = new Database("ItemManager");
            DataTable dt = new DataTable();
            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblItemGetByID";
            database.Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;

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
            //base.Initialize(database, base.ID);
            //database.ExecuteNonQueryJWithTransaction();
            //base.Initialize(database.Command);
        }
        public Item GetByName(string Name)
        {
            Database database = new Database("ItemManager");
            DataTable dt = new DataTable();
            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblItemGetByName";
            database.Command.Parameters.Add("@ItemGroupID", SqlDbType.UniqueIdentifier).Value = _ItemGroupID;
            database.Command.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;

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
        //public Item GetByItemGroup(Guid IG)
        //{
        //    Database database = new Database("ItemManager");
        //    DataTable dt = new DataTable();
        //    database.Command.Parameters.Clear();
        //    database.Command.CommandType = CommandType.StoredProcedure;
        //    database.Command.CommandText = "tblItemGetByItemGroupID";
        //    database.Command.Parameters.Add("@ItemGroupID", SqlDbType.UniqueIdentifier).Value = _ItemGroupID;

        //    base.Initialize(database, base.ID);
        //    database.ExecuteNonQueryJWithTransaction();
        //    base.Initialize(database.Command);
        //    if (dt != null && dt.Rows.Count == 1)
        //    {
        //        DataRow dr = dt.Rows[0];
        //        base.Initialize(dr);
        //        InitializeBusinessData(dr);
        //        base.IsNew = false;
        //        base.IsDirty = false;
        //        return this;
        //    }
        //    else return null;
        //}
        public bool SwitchStatus(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblItemSwitchStatus";
                database.Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = base.ID;

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
        public Item Save(Database database, Guid ParentID)
        {
            _ItemGroupID = ParentID; // How these get linked together. See UserFriendList.cs Comment: CONNECTAddress

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
            _ItemGroupID = (Guid)dr["ItemGroupID"];
            _Name = dr["Name"].ToString();
            _Type = dr["Type"].ToString();
            _WishlistStatus = (bool)dr["WishListStatus"];
            _Quantity = (int)dr["Quantity"];
            _Value = (decimal)dr["Value"];
        }
        #endregion

        #region Event Handlers

        #endregion

        #region Construction
        public Item()
        {
            _ItemGroupID = Guid.Empty;
            _Name = string.Empty;
            _Type = string.Empty;
            _WishlistStatus = false;
            _Quantity = 0;
            _Value = 0;
        }
        #endregion
    }
}
