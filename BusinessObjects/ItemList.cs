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
    public class ItemList : Event
    {
        #region Private Members
        private BindingList<Item> _List;
        #endregion

        #region Public Properties
        public BindingList<Item> List
        {
            get
            {
                return _List;
            }
        }
        #endregion

        #region Public Methods
        public ItemList GetByItemGroup(Guid itemGroupID)
        {
            Database database = new Database("ItemManager");
            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblItemGetByItemGroupId";
            database.Command.Parameters.Add("@ItemGroupID", SqlDbType.UniqueIdentifier).Value = itemGroupID;
            DataTable dt = database.ExecuteQuery();
            //Create a user object from each datarow in the datatable
            foreach (DataRow dr in dt.Rows)
            {
                Item il = new Item();
                il.Initialize(dr);
                il.InitializeBusinessData(dr);
                il.IsNew = false;
                il.IsDirty = false;
                il.Savable += Il_Savable;
                _List.Add(il);
            }
            return this;
        }
        public bool GetByWishlistStatus (bool wishliststatus)
        {
            bool result = false;
            foreach (Item il in List)
            {
                if (il.WishListStatus == true)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }


            return result;
        }

        public bool Save(Database database, Guid parentID)
        {
            bool result = true;
            try
            {
                foreach (Item il in _List)
                {
                    if (il.IsSavable() == true)
                    {
                        il.Save(database, parentID); //CONNECTFRIEND
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
            foreach (Item il in _List)
            {
                if (il.IsSavable() == true)
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
            e.NewObject = new Item();
            Item il = (Item)e.NewObject;

            il.Savable += Il_Savable;
            //todo: put more code here

        }
        private void Il_Savable(SavableEventArgs e)
        {
            
        }
        #endregion

        #region Construction
        public ItemList()
        {
            _List = new BindingList<Item>();
            _List.AddingNew += _List_AddingNew;
        }
        #endregion
    }
}
