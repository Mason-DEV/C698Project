using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C698Project
{
    class Products
    {

        private int productID;
        private string name;
        private double price;
        private int inStock;
        private int min;
        private int max;

        //productID getter & setter
        public void SetProductID(int productIDNum) {
            productID = productIDNum;
        }

        public int GetProductID() {
            return productID;
        }

        //name getter & setter
        public void SetName(string productName) {
            name = productName; 
        }

        public string GetName() {
            return name;
        }

        //price getter & setter
        public void SetPrice(double productPrice) {
            price = productPrice;
        }

        public double GetPrice() {
            return price;
        }

        //inStock getter & setter
        public void SetinStock(int productInStock)
        {
            inStock = productInStock;
        }

        public int GetInStock()
        {
            return inStock;
        }

        //min getter & setter
        public void SetMin(int productMin)
        {
            min = productMin;
        }

        public int GetProductMin()
        {
            return min;
        }

        //max getter & setter
        public void SetMax(int productMax)
        {
            max = productMax;
        }

        public int GetMax()
        {
            return max;
        }

    }
}
