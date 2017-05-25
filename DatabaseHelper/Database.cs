using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ConfigurationHelper;

namespace DatabaseHelper
{
    public class Database
    {
        #region Private Members

        SqlConnection _cn;
        SqlCommand _cmd;
        SqlDataAdapter _da;
        DataTable _dt;
        string _connectionName;

        #endregion

        #region Public Properties

        public SqlCommand Command
        {
            get
            {
                return _cmd;
            }
        }

        #endregion

        #region Public Methods
        public void BeginTransaction()
        {
            _cn.ConnectionString = Configuration.GetConnectionString(_connectionName);
            _cn.Open();
            _cmd.Connection = _cn;
            _cmd.Transaction = _cn.BeginTransaction();
        }
        public void EndTransaction()
        {
            _cmd.Transaction.Commit();
            _cn.Close();
        }
        public void Rollback()
        {
            _cmd.Transaction.Rollback();
            _cn.Close();
        }
        public SqlCommand ExecuteNonQueryJWithTransaction()
        {
            _cmd.ExecuteNonQuery();
            return _cmd;
        }
        public SqlCommand ExecuteNonQueryJ()
        {
            _cn.ConnectionString = Configuration.GetConnectionString(_connectionName);
            _cn.Open();

            _cmd.Connection = _cn;
            _cmd.ExecuteNonQuery();

            _cn.Close();
            return _cmd;
        }

        public DataTable ExecuteQuery()
        {
            _da = new SqlDataAdapter();
            _dt = new DataTable();

            _cn.ConnectionString = Configuration.GetConnectionString(_connectionName);
            _cn.Open();

            _cmd.Connection = _cn;
            _da.SelectCommand = _cmd;

            _da.Fill(_dt);
            _cn.Close();

            return _dt;
        }
        #endregion

        #region Construction
        public Database(string connectionName)
        {
            _connectionName = connectionName;
            _cn = new SqlConnection();
            _cmd = new SqlCommand();
        }
        #endregion
    }
}
