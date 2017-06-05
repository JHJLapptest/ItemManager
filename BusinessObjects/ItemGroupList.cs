using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseHelper;
using System.Data;
using System.ComponentModel;

namespace BusinessObjects
{
    class ItemGroupList : Event
    {
        #region Private Members
        private BindingList<ItemGroup> _List;
        #endregion

        #region Public Properties
        public BindingList<ItemGroup> List
        {
            get
            {
                return _List;
            }
        }
        #endregion

        #region Public Methods
        public ItemGroupList GetByUserID(Guid userID)
        {
            Database database = new Database("ItemManager");
            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblItemGroupGetByUserID";
            database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = userID;
            DataTable dt = database.ExecuteQuery();
            //Create a user object from each datarow in the datatable
            foreach (DataRow dr in dt.Rows)
            {
                ItemGroup ig = new ItemGroup();
                ig.Initialize(dr);
                ig.InitializeBusinessData(dr);
                ig.IsNew = false;
                ig.IsDirty = false;
                ig.Savable += Ig_Savable;
                _List.Add(ig);
            }
            return this;
        }

        private void Ig_Savable(SavableEventArgs e)
        {
            RaiseEvent(e);
            //push
        }

        public bool Save(Database database, Guid parentID)
        {
            bool result = true;
            try
            {
                foreach (ItemGroup ig in _List)
                {
                    if (ig.IsSavable() == true)
                    {
                        ig.Save(database, parentID); //CONNECTFRIEND
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool IsSavable()
        {
            bool result = false;
            foreach (ItemGroup ig in _List)
            {
                if (ig.IsSavable() == true)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        #endregion

        #region Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new ItemGroup();
            ItemGroup ig = (ItemGroup)e.NewObject;
            
            //ig.Savable
            //todo: put more code here

        }
        
        #endregion

        #region Construction
        public ItemGroupList()
        {
            _List = new BindingList<ItemGroup>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}
