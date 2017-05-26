using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseHelper;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EmailHelper;

namespace BusinessObjects
{
    public class User : HeaderData //Inherits HeaderData.cs
    {
        #region Private Members
        private string _FirstName;
        private string _LastName;
        private string _UserName;
        private string _Email;
        private string _Password;
        private UserQuestionList _Questions = null;
        Random rnd = new Random();
        //private BrokenRuleList _BrokenRules = new BrokenRuleList();
        #endregion

        #region Public Properties
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    base.IsDirty = true;
                }
            }
        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    base.IsDirty = true;
                }
            }
        }
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    base.IsDirty = true;
                }
            }
        }
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
        public UserQuestionList Questions
        {
            get
            {
                if (_Questions == null)
                {
                    _Questions = new UserQuestionList();
                    _Questions = _Questions.GetByUserID(base.ID);
                }
                return _Questions;
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
                database.Command.CommandText = "tblUserInsert";
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                database.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = _UserName;
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;


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
                database.Command.CommandText = "tblUserUpdate";
                database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                database.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = _UserName;
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;

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
                database.Command.CommandText = "tblUserDelete";

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
            if (_UserName == null || _UserName.Trim() == string.Empty)
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
        public User Save()
        {
            bool result = true;
            Database database = new Database("ItemManager");
            database.BeginTransaction();

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
            if (result == true && _Questions.IsSavable() == true)
            {
                result = _Questions.Save(database, base.ID);
            }
            if (result == true)
            {
                database.EndTransaction();
            }
            else
            {
                database.Rollback();
            }
            return this;
        }
        public bool IsSavable()
        {
            bool result = false;

            if ((base.IsDirty == true && IsValid() == true)/* || (_Friends != null && _Friends.IsSavable() == true)
                || (_Phones != null && _Phones.IsSavable()) || (_Emails != null && _Emails.IsSavable())
                || (_Addresses != null && _Addresses.IsSavable())*/)
            {
                result = true;
            }
            return result;
        }
        public void InitializeBusinessData(DataRow dr)
        {
            _FirstName = dr["FirstName"].ToString();
            _LastName = dr["LastName"].ToString();
            _UserName = dr["UserName"].ToString();
            _Email = dr["Email"].ToString();
            _Password = dr["Password"].ToString();
        }
        public User GetById(Guid id)
        {
            Database database = new Database("ItemManager");
            DataTable dt = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblUserGetById";
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
        public User Login(string login, string password)
        {
            //string username = string.Empty;
            //string email = string.Empty;
            Database database = new Database("ItemManager"); 
            DataTable dt = new DataTable();
            
            #region My Stuff
            /*
            if ((database.Command.CommandText = ("Select * FROM tblUser Where Username = " + login)) != null)
            {
                database.Command.CommandText = "tblUserLogin";
                database.Command.Parameters.Add("@Username", SqlDbType.VarChar).Value = login;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                dt = database.ExecuteQuery();
                DataRow dr = dt.Rows[0];
                base.Initialize(dr);
                InitializeBusinessData(dr);
            }
            else if ((database.Command.CommandText = ("Select * FROM tblUser Where Email = " + login)) != null)
            {
                database.Command.CommandText = "tblUserLogin";
                database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = login;
                database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                dt = database.ExecuteQuery();
                DataRow dr = dt.Rows[0];
                base.Initialize(dr);
                InitializeBusinessData(dr);
            }
            */
            #endregion

            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblUserLogin";
            database.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = login;
            database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = login;
            database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
            dt = database.ExecuteQuery();
            DataRow dr = dt.Rows[0];
            base.Initialize(dr);
            InitializeBusinessData(dr);
            if (login == UserName && dt != null && dt.Rows.Count == 1)
            {
                base.IsNew = false;
                base.IsDirty = false;

                return this;
            }
            else if (login == Email && dt != null && dt.Rows.Count == 1)
            {
                base.IsNew = false;
                base.IsDirty = false;

                return this;
            }
            else return null;


            /*if (dt != null && dt.Rows.Count == 1)
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
            }*/
        }
        public User Register(string email, string userName, string firstName, string lastName, string password, Guid questionID1, Guid questionID2, Guid questionID3, 
            string answer1, string answer2, string answer3)
        {
            bool result = false;
            try
            {
                //Password = PasswordGenerator.Password.Generate(8);
                Email = email;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
                Password = password;

                if (IsSavable() == true)
                {
                    Database database = new Database("ItemManager");
                    database.Command.Parameters.Clear();
                    database.BeginTransaction();
                    database.Command.CommandType = CommandType.StoredProcedure;
                    database.Command.CommandText = "tblUserInsert";
                    database.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = _UserName;
                    database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email;
                    database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName;
                    database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName;
                    database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password;
                    database.Command.Parameters.Add("@ReturnValueUserName", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    database.Command.Parameters.Add("@ReturnValueEmail", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    
                    base.Initialize(database, Guid.Empty);  //creates "buckets" for the data
                    database.ExecuteNonQueryJWithTransaction();  //fills the empty "buckets" with what we need
                    base.Initialize(database.Command);  //takes info in "buckets" and puts it into HeaderData

                    if (database.Command.Parameters["@ReturnValueEmail"].Value.ToString() == "False" && database.Command.Parameters["@ReturnValueUserName"].Value.ToString() == "False")
                    {
                        throw new Exception("Email and Username already exist.");
                    }
                    if (database.Command.Parameters["@ReturnValueEmail"].Value.ToString() == "False")
                    {
                        throw new Exception("Email already exist.");
                    }
                    if (database.Command.Parameters["@ReturnValueUserName"].Value.ToString() == "False")
                    {
                        throw new Exception("Username already exist.");
                    }
                    else
                    {
                        UserQuestion Q1 = new UserQuestion();
                        UserQuestion Q2 = new UserQuestion();
                        UserQuestion Q3 = new UserQuestion();

                        Q1.QuestionID = questionID1;
                        Q1.Answer = answer1;
                        Q2.QuestionID = questionID2;
                        Q2.Answer = answer2;
                        Q3.QuestionID = questionID3;
                        Q3.Answer = answer3;

                        _Questions = Questions;

                        _Questions.List.Add(Q1);
                        _Questions.List.Add(Q2);
                        _Questions.List.Add(Q3);

                        if (_Questions != null && _Questions.IsSavable() == true)
                        {
                            
                            result = _Questions.Save(database, base.ID);
                        }
                        if (result == true)
                        {
                            database.EndTransaction();
                        }
                        else
                        {
                            database.Rollback();
                        }

                        #region Send Email
                        //EmailConfig emailConfig = new EmailConfig();
                        //emailConfig = emailConfig.GetByName("gmail");

                        //SendEmail se = new SendEmail();
                        //se.Email = emailConfig.Email;
                        //se.Password = emailConfig.Password;
                        //se.Host = emailConfig.Host;
                        //se.Port = emailConfig.Port;
                        //string body = string.Format("Hello {0}, your Password is:\n {1}", _UserName, _Password);
                        //se.Send("jphamm360@gmail.com", _Email, "Collections Application Register", body);
                        #endregion
                        return this;
                    }
                }
                else
                {
                    return this;
                }
            }
            catch (SqlException exSQL)
            {
                throw;
                // TODO: Change this to database error
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public User ForgotPassword(string email, string username)
        {
            Database database = new Database("ItemManager");
            DataTable dt = new DataTable();
            //DataTable dt2 = new DataTable();
            database.Command.CommandType = CommandType.StoredProcedure;
            database.Command.CommandText = "tblUserGetByEmail";
            database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
            database.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
            dt = database.ExecuteQuery();
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                base.Initialize(dr);
                InitializeBusinessData(dr);
                base.IsNew = false;
                base.IsDirty = false;

                database.Command.Parameters.Clear();
                //SqlDataAdapter da2 = new SqlDataAdapter();
                database.Command.CommandType = CommandType.StoredProcedure;
                database.Command.CommandText = "tblUserQuestionGetByUserID";
                database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = base.ID;
                dt = database.ExecuteQuery();

                if (dt != null && dt.Rows.Count == 3)
                {
                    DataRow dr2 = dt.Rows[rnd.Next(0, dt.Rows.Count)];
                    //base.Initialize(dr);
                    //InitializeBusinessData(dr);
                    _Questions = new UserQuestionList();
                    
                    UserQuestion uq = new UserQuestion();
                    uq.Initialize(dr2);
                    uq.InitializeBusinessData(dr2);
                    _Questions.List.Add(uq);

                    //question.Question
                    //need getbyid for SecurityQuestions.


                }
                return this;
            }
            else
            {
                return null;
            }

        }
        public void SendEmailNow()
        {
            EmailConfig emailConfig = new EmailConfig();
            emailConfig = emailConfig.GetByName("gmail");
            SendEmail se = new SendEmail();
            se.Email = emailConfig.Email;
            se.Password = emailConfig.Password;
            se.Host = emailConfig.Host;
            se.Port = emailConfig.Port;
            string body = string.Format("Hello {0}, your Password is:\n {1}", _UserName, _Password);
            se.Send("JHJLapptest@gmail.com", _Email, "Here's Your Password", body);
        }
        #endregion

        #region Event Handlers
        #endregion

        #region Construction
        public User()
        {
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _UserName = string.Empty;
            _Email = string.Empty;
            _Password = string.Empty;
            
        }
        #endregion
    }
}
