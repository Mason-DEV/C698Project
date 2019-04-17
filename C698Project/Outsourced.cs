using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C698Project
{
    class Outsourced
    {
        private string companyName;
        private int inHouse;
        private int outsourced;

        public void setCompanyName(string name)
        {
            companyName = name;
        }

        public string getCompanyName()
        {
            return companyName;
        }
        public void setInhouse(int inHouseID)
        {
            inHouse = inHouseID;
        }

        public int getInHouseID()
        {
            return inHouse;
        }

        public void setoutsourced(int outsourcedID)
        {
            outsourced = outsourcedID;
        }

        public int getoutsourcedID()
        {
            return outsourced;
        }
    }
}
