using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    class SecurityQuestionEventArgs : EventArgs
    {
        private UserQuestion _userQuestion;

        public UserQuestion UserQuestion
        {
            get
            {
                return _userQuestion;
            }
            set
            {
                _userQuestion = value;
            }
        }

        public SecurityQuestionEventArgs()
        {
            _userQuestion = new UserQuestion();
        }
    }
}
