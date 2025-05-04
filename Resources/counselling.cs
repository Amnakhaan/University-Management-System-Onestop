using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onestop.Resources
{
    internal class counselling
    {
        public string type;
        public string counsellor;

        public counselling(string type, string counsellor)
        {
            this.type = type;
            this.counsellor = counsellor;
        }

        public void setType(string type)
        {
            this.type = type;
        }
        public string getType()
        {
            return this.type;
        }
        public void setCounsellor(string counsellor)
        {
            this.counsellor = counsellor;
        }
        public string getCounsellor()
        {
            return this.counsellor;
        }


    }
}
