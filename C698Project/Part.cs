using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C698Project
{
    class Part
    {
        private int partID;
        private string name;
        private double price;
        private int inStock;
        private int min;
        private int max;

        
        public void setPartID(int partIDNum)
        {
            partID = partIDNum;
        }

        public int getParttID()
        {
            return partID;
        }

        //name getter & setter
        public void setName(string partName)
        {
            name = partName;
        }

        public string getName()
        {
            return name;
        }

        //price getter & setter
        public void setPrice(double partPrice)
        {
            price = partPrice;
        }

        public double getPrice()
        {
            return price;
        }

        //inStock getter & setter
        public void setinStock(int partInStock)
        {
            inStock = partInStock;
        }

        public int getInStock()
        {
            return inStock;
        }

        //min getter & setter
        public void setMin(int partMin)
        {
            min = partMin;
        }

        public int getMin()
        {
            return min;
        }

        //max getter & setter
        public void setMax(int partMax)
        {
            max = partMax;
        }

        public int getMax()
        {
            return max;
        }

        public void addThePart() {
            Inventory part= new Inventory();
            part.addPart(this); 
        }
    }

}
