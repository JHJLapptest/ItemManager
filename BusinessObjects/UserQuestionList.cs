using System;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;

namespace BusinessObjects
{
    public class UserQuestionList
    {
        #region Private Members
        private BindingList<UserQuestion> _List;
        #endregion

        #region Public Properties
        public BindingList<UserQuestion> List
        {
            get
            {
                return _List;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public UserQuestionList GetByUserID(Guid userID)
        {
            Database database = new Database("ItemManager");
            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblUserQuestionGetByUserID";
            database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = userID;
            DataTable dt = database.ExecuteQuery();
            //Create a user object from each datarow in the datatable
            foreach (DataRow dr in dt.Rows)
            {
                UserQuestion uq = new UserQuestion();
                uq.Initialize(dr);
                uq.InitializeBusinessData(dr);
                uq.IsNew = false;
                uq.IsDirty = false;
                _List.Add(uq);
            }
            return this;
        }

        public bool Save(Database database, Guid parentID)
        {
            bool result = true;
            try
            {
                foreach (UserQuestion uq in _List)
                {
                    if (uq.IsSavable() == true)
                    {
                        uq.Save(database, parentID); //CONNECTFRIEND
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
            foreach (UserQuestion ue in _List)
            {
                if (ue.IsSavable() == true)
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
            e.NewObject = new UserQuestion();
            UserQuestion uq = (UserQuestion)e.NewObject;
            //todo: put more code here
        }
        #endregion

        #region Construction
        public UserQuestionList()
        {
            _List = new BindingList<UserQuestion>();
            _List.AddingNew += _List_AddingNew;
        }

        #endregion
    }
}
