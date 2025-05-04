using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onestop.Resources
{
    internal class lostandfound
    {
        public int itemid;
        public string itemname;
        public string location;
        public string time;

        public lostandfound(int itemid, string itemname, string location, string time)
        {
            this.itemid = itemid;
            this.itemname = itemname;
            this.location = location;
            this.time = time;
        }

        public void setItemId(int itemid)
        {
            this.itemid =itemid;
        }
        public int getItemId()
        {
            return this.itemid;
        }
        public void setItemName(string itemname)
        {
            this.itemname = itemname;
        }
        public string getItemName()
        {
            return this.itemname;
        }
        public void setLcation(string location)
        {
            this.location = location;
        }
        public string getLocation()
        {
            return this.location;
        }
        public void setTime(string time)
        {
            this.time = time;
        }
        public string getTime()
        {
            return this.time;
        }



         






    }
}
