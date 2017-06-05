using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BrokenRule
    {
        #region Private Members
        private string _Rule = string.Empty;
        #endregion

        #region Public Properties
        public string Rule
        {
            get
            {
                return _Rule;
            }
            set
            {
                _Rule = value;
            }
        }
        #endregion

        #region Construction
        public BrokenRule(string rule)
        {
            _Rule = rule;
        }
        #endregion
    }
}
