using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class SavableEventArgs : EventArgs
    {
        #region Private Members
        private bool _Savable = false;
        #endregion

        #region Public Properties
        public bool Savable
        {
            get
            {
                return _Savable;
            }
            set
            {
                _Savable = value;
            }
        }
        #endregion

        #region Construction
        public SavableEventArgs(Boolean savable)
        {
            _Savable = savable;
        }
        #endregion
    }
}
