using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_addressbook_test
{
    public class GroupData
    {
        public string name;
        private string header; // = "";

        public GroupData(string name)
        {
            this.name = name;
        }
        //для обратной совместимости вносим новый конструктор с тремя параметрами
        public GroupData (string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }
        public string footer = "";
        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

    }
}
