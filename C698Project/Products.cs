using System;
using System.Collections;
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
        public void setProductID(int productIDNum) {
            productID = productIDNum;
        }

        public int getProductID() {
            return productID;
        }

        //name getter & setter
        public void setName(string productName) {
            name = productName; 
        }

        public string getName() {
            return name;
        }

        //price getter & setter
        public void setPrice(double productPrice) {
            price = productPrice;
        }

        public double getPrice() {
            return price;
        }

        //inStock getter & setter
        public void setinStock(int productInStock)
        {
            inStock = productInStock;
        }

        public int getInStock()
        {
            return inStock;
        }

        //min getter & setter
        public void setMin(int productMin)
        {
            min = productMin;
        }

        public int getProductMin()
        {
            return min;
        }

        //max getter & setter
        public void setMax(int productMax)
        {
            max = productMax;
        }

        public int getMax()
        {
            return max;
        }

    }
}
