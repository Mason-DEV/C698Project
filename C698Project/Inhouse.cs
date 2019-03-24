using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C698Project
{
    class Inhouse
    {
        private int machineID;
        private int inHouse;
        private int outsourced;

        public void setMachineID(int machineIDSet) {
            machineID = machineIDSet;
        }

        public int getMachineID() {
            return machineID;
        }

        public void setInhouse(int inHouseID) {
            inHouse = inHouseID;
        }

        public int getInHouseID() {
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
