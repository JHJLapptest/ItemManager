using System;
using System.ComponentModel;
using DatabaseHelper;
using System.Data;


namespace BusinessObjects
{
    public class SecurityQuestionsList
    {
        #region Private Members
        private BindingList<SecurityQuestions> _List;
        #endregion

        #region Public Properties
        public BindingList<SecurityQuestions> List
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
        public SecurityQuestionsList GetAll()
        {
            Database database = new Database("ItemManager");
            database.Command.Parameters.Clear();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblSecurityQuestionsGetAll";
            DataTable dt = database.ExecuteQuery();
            //Create a user object from each datarow in the datatable
            foreach (DataRow dr in dt.Rows)
            {
                SecurityQuestions sc = new SecurityQuestions();
                sc.Initialize(dr);
                sc.InitializeBusinessData(dr);
                sc.IsNew = false;
                sc.IsDirty = false;
                _List.Add(sc);
            }
            return this;
        }

        public SecurityQuestionsList Save()
        {
            foreach (SecurityQuestions upt in _List)
            {
                if (upt.IsSavable() == true)
                {
                    upt.Save();
                }
            }
            return this;
        }
        #endregion

        #region Event Handlers
        private void _List_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new SecurityQuestions();
        }
        #endregion

        #region Construction
        public SecurityQuestionsList()
        {
            _List = new BindingList<SecurityQuestions>();
            _List.AddingNew += _List_AddingNew;
        }


        #endregion
    }
}
