using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BrokenRuleList
    {
        #region Private Members
        private List<BrokenRule> _BrokenRules = new List<BrokenRule>();
        #endregion

        #region Public Properties
        public List<BrokenRule> List
        {
            get
            {
                return _BrokenRules;
            }
        }
        #endregion
    }
}
