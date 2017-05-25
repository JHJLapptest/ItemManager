using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseHelper;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BusinessObjects
{
    public class SecurityQuestions : HeaderData //Inherits HeaderData.cs
    {
        #region Private Members
        private string _Question;
        //private UserPhoneTypeList _Types = null;
        //private BrokenRuleList _BrokenRules = new BrokenRuleList();
        #endregion

        #region Public Properties
        public string Question
        {
            get
            {
                return _Question;
            }
            set
            {
                if (_Question != value)
                {
                    _Question = value;
                    base.IsDirty = true;
                }
            }
        }

        //public UserPhoneTypeList Types
        //{
        //    get
        //    {
        //        if (_Types == null)
        //        {
        //            _Types = new UserPhoneTypeList();
        //            _Types = _Types.GetByUserID(base.Id);
        //        }
        //        return _Types;
        //    }
        //}


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
                database.Command.CommandText = "tblSecurityQuestionsInsert";
                database.Command.Parameters.Add("@Question", SqlDbType.VarChar).Value = _Question;

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
                database.Command.CommandText = "tblSecurityQuestionsUpdate";
                database.Command.Parameters.Add("@Question", SqlDbType.VarChar).Value = _Question;

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
                database.Command.CommandText = "tblSecurityQuestionsDelete";

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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            bool result = true; //true unless told it's wrong
            //_BrokenRules.List.Clear();

            if (_Question == null || _Question.Trim() == string.Empty)
            {
                result = false;
                //BrokenRule br = new BrokenRule("Email Type cannot be empty.");
                //_BrokenRules.List.Add(br);
            }
            //Regex regex = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
            //Match match = regex.Match(_Email);
            //if (!match.Success)
            //{
            //    result = false;
            //    BrokenRule br = new BrokenRule("Email is in the wrong format.");
            //    _BrokenRules.List.Add(br);
            //}
            //if (result == true && Friends.IsSavable() == true)
            //{
            //    result = _Friends.Save(database, base.Id);
            //}
            return result;
        }
        #endregion

        #region Public Methods
        public SecurityQuestions Save()
        {
            bool result = true;
            Database database = new Database("ItemManager");

            if (base.IsNew == true && base.IsDirty == true && IsValid() == true)
            {
                result = Insert(database);
            }
            else if (base.Deleted == true && base.IsDirty == true)
            {
                result = Delete(database);
            }
            else if (base.IsNew == false && base.IsDirty == true && IsValid() == true)
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

            if ((base.IsDirty == true && IsValid() == true)/* || (_Type != null && _Type.IsSavable() == true)*/)
            {
                result = true;
            }
            return result;
        }
        public void InitializeBusinessData(DataRow dr)
        {
            _Question = dr["Question"].ToString();
        }
        #endregion

        #region Event Handlers
        #endregion

        #region Construction
        public SecurityQuestions()
        {
            _Question = string.Empty;
        }
        #endregion
    }
}
