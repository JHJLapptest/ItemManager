using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseHelper;
using System.Data.SqlClient;
using System.Data;

namespace BusinessObjects
{
    public class HeaderData : Event
    {
        #region Private Members
        private Guid _ID;
        private int _Version;
        private DateTime _LastUpdated;
        private bool _Deleted;

        private bool _IsNew;
        private bool _IsDirty;
        #endregion

        #region Public Properties
        public Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public int Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }
        public DateTime LastUpdate
        {
            get
            {
                return _LastUpdated;
            }
            set
            {
                _LastUpdated = value;
            }
        }
        public bool Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                _Deleted = value;
                _IsDirty = true;
            }
        }
        public bool IsDirty
        {
            get
            {
                return _IsDirty;
            }
            set
            {
                _IsDirty = value;
            }
        }
        public bool IsNew
        {
            get
            {
                return _IsNew;
            }
            set
            {
                _IsNew = value;
            }
        }
        #endregion

        #region Public Methods
        public void Initialize(Database database, Guid id)
        {
            SqlParameter parm = new SqlParameter();
            parm.ParameterName = "@ID";
            parm.Direction = ParameterDirection.InputOutput;
            parm.SqlDbType = SqlDbType.UniqueIdentifier;
            parm.Value = id;
            database.Command.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@Version";
            parm.Direction = ParameterDirection.InputOutput;
            parm.SqlDbType = SqlDbType.Int;
            parm.Value = 0;
            database.Command.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@LastUpdated";
            parm.Direction = ParameterDirection.InputOutput;
            parm.SqlDbType = SqlDbType.DateTime;
            parm.Value = DateTime.MaxValue;
            database.Command.Parameters.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@Deleted";
            parm.Direction = ParameterDirection.InputOutput;
            parm.SqlDbType = SqlDbType.Bit;
            parm.Value = 0;
            database.Command.Parameters.Add(parm);
        }

        public void Initialize(SqlCommand cmd)
        {
            _ID = (Guid)cmd.Parameters["@ID"].Value;
            _Version = (int)cmd.Parameters["@Version"].Value;
            _LastUpdated = (DateTime)cmd.Parameters["@LastUpdated"].Value;
            Deleted = (bool)cmd.Parameters["@Deleted"].Value;
        }

        public void Initialize(DataRow dr)
        {
            _ID = (Guid)dr["ID"];
            _Version = (int)dr["Version"];
            _LastUpdated = (DateTime)dr["LastUpdated"];
            _Deleted = (bool)dr["Deleted"];
        }
        #endregion

        #region Event Handlers
        #endregion

        #region Construction
        public HeaderData()
        {
            _ID = Guid.Empty;
            _Version = 0;
            _LastUpdated = DateTime.MaxValue;
            _Deleted = false;
            _IsNew = true;
            _IsDirty = false;
        }

        #endregion
    }
}
