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
    public class UserQuestion : HeaderData
    {
        #region Private Members
        private Guid _UserID;
        private Guid _QuestionID;
        private string _Answer;
        private string _QuestionText;
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
        public Guid QuestionID
        {
            get
            {
                return _QuestionID;
            }
            set
            {
                if (_QuestionID != value)
                {
                    _QuestionID = value;
                    base.IsDirty = true;
                }
            }
        }
        public string QuestionText
        {
            get
            {
                SecurityQuestions sc = new SecurityQuestions();
                sc = sc.GetById(_QuestionID);
                return sc.Question;
            }
        }
        public string Answer
        {
            get
            {
                return _Answer;
            }
            set
            {
                if (Answer != value)
                {
                    _Answer = value;
                    base.IsDirty = true;
                }
            }
        }
        /*public BrokenRuleList BrokenRules
        {
            get
            {
                return _BrokenRules;
            }
        }*/
        #endregion

        #region Private Methods
        private bool Insert(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblUserQuestionInsert";

                database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID;
                database.Command.Parameters.Add("@QuestionID", SqlDbType.UniqueIdentifier).Value = _QuestionID;
                database.Command.Parameters.Add("@Answer", SqlDbType.VarChar).Value = _Answer;

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
                database.Command.CommandText = "tblUserQuestionUpdate";
                database.Command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = _UserID;
                database.Command.Parameters.Add("@QuestionID", SqlDbType.VarChar).Value = _QuestionID;
                database.Command.Parameters.Add("@Answer", SqlDbType.VarChar).Value = _Answer;

                base.Initialize(database, base.ID);
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
        private bool Delete(Database database)
        {
            bool result = true;
            try
            {
                database.Command.Parameters.Clear();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblUserQuestionDelete";

                base.Initialize(database, base.ID);
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
        private bool IsValid()
        {
            bool result = true; //true unless told it's wrong
            //_BrokenRules.List.Clear();

            if (QuestionID == null)
            {
                result = false;
                //BrokenRule br = new BrokenRule("Answer must contain an answer that is three letters or more.");
                //_BrokenRules.List.Add(br);
            }
            if (Answer == null || _Answer.Trim() == string.Empty || _Answer.Length < 3)
            {
                result = false;
                //BrokenRule br = new BrokenRule("Answer must contain an answer that is three letters or more.");
                //_BrokenRules.List.Add(br);
            }
            //Regex regex = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]+?\.[a-zA-Z]{2,3}$");
            //Match match = regex.Match(_Question);
            //if (!match.Success)
            //{
            //    result = false;
            //    BrokenRule br = new BrokenRule("Question is in the wrong format.");
            //    _BrokenRules.List.Add(br);
            //}

            return result;
        }
        #endregion

        #region Public Methods
        public UserQuestion Save(Database database, Guid ParentID)
        {
            _UserID = ParentID; // How these get linked together. See UserFriendList.cs Comment: CONNECTQuestion

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
            _QuestionID = (Guid)dr["QuestionID"];
            _Answer = dr["Answer"].ToString();
        }
        public UserQuestion GetById(Guid id)
        {
            Database database = new Database("ItemManager");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblUserQuestionGetById";
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

        #region Event Handlers
        #endregion

        #region Construction
        public UserQuestion()
        {
            _UserID = Guid.Empty;
            _QuestionID = Guid.Empty;
            _Answer = string.Empty;
        }
        #endregion
    }
}
