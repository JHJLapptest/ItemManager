using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    class Events
    {
        public delegate void SecurityQuestionEventHandler(SecurityQuestionEventArgs e);

        public event SecurityQuestionEventHandler QuestionCheck;

        public void RaiseEvent (SecurityQuestionEventArgs e)
        {
            SecurityQuestionEventHandler evt = QuestionCheck;
            if(evt != null)
            {
                evt(e);
            }
        }
    }
}
