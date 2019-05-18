using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook2
{
    class Figure
    {
        private bool colored = false;

        public bool Colored //Property (свойства)
        {
            get
            {
                return colored;
            }
            set
            {
                colored = value;
            }
        }
    }
}
