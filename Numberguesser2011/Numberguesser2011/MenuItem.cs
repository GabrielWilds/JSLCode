using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Numberguesser2011
{
    class MenuItem<T>
    {
        protected T _content;
        protected String _description;
        protected bool _confirm = true;

        public T Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool NeedsConfirm
    {
        get { return _confirm; }
        set { _confirm = value; }
    }
    }
}
