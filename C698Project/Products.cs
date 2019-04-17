using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void addAssociatedPart(Part part) {
            int associatedPartID;
            //first get assoicatedPartID
            SqlConnection con2 = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            con2.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT MAX(associatedPartID) FROM associatedParts;";

            try
            {
                associatedPartID = (int)cmd2.ExecuteScalar();
                associatedPartID = associatedPartID + 1;
            }
            catch
            {
                associatedPartID = 0;
            }
            con2.Close();

            
            
            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            SqlCommand command = con.CreateCommand();
            con.Open();
            SqlTransaction transaction;
            // Start a local transaction.
            transaction = con.BeginTransaction();

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            command.Connection = con;
            command.Transaction = transaction;
            command.CommandText =
               "INSERT INTO [dbo].[associatedParts] ([productID], [partID], [name], [price], [inStock], [associatedPartID]) VALUES (@productID, @partID, @name, @price, @inStock , @associatedPartID);";
            command.Parameters.AddWithValue("@productID", getProductID());
            Console.WriteLine("Inserting Part " + part.getParttID() + " " + "for productID " + getProductID());
            command.Parameters.AddWithValue("@partID", part.getParttID());
            command.Parameters.AddWithValue("@name", part.getName());
            command.Parameters.AddWithValue("@price", part.getPrice());
            command.Parameters.AddWithValue("@inStock", part.getInStock());
            command.Parameters.AddWithValue("@associatedPartID", associatedPartID);
            Console.WriteLine("associatePartID " + associatedPartID);
            command.ExecuteNonQuery();
            transaction.Commit();
            con.Close();



        }
        public bool removeAssociatedPart(int removeID) {

            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            SqlCommand command = con.CreateCommand();
            con.Open();
            SqlTransaction transaction;
            // Start a local transaction.
            transaction = con.BeginTransaction("SampleTransaction");

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            command.Connection = con;
            command.Transaction = transaction;
            command.CommandText =
              "DELETE FROM[dbo].[associatedParts] WHERE productID = @productID and partID = @partID";
            command.Parameters.AddWithValue("@productID", getProductID());
            command.Parameters.AddWithValue("@partID", removeID);
            command.ExecuteNonQuery();
            transaction.Commit();
            con.Close();

            return true;
        }
        public Part lookupAssociatedPart(int partID) {

            Console.WriteLine(productID);
            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            con.Open();
            var query = "SELECT productID, partID, name, price, inStock FROM dbo.associatedParts where partID = @partID and productID = @productID";
            var cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@partID", partID);
            Console.WriteLine("prodcutID" +getProductID());
            cmd.Parameters.AddWithValue("@productID", getProductID());

            String partsID;
            String name;
            String price;
            String inStock;
            String min;
            String max;
            Part lookedUpAssocPart = new Part();
            SqlDataReader rdr = cmd.ExecuteReader();
            // Fill the strings with the values retrieved, convert to types as needed
            while (rdr.Read())
            {
             

                partsID = rdr["partID"].ToString();
                lookedUpAssocPart.setPartID(Convert.ToInt32(partsID));

                name = rdr["name"].ToString();
                lookedUpAssocPart.setName(name);

                price = rdr["price"].ToString();
                lookedUpAssocPart.setPrice(Convert.ToDouble(price));

                inStock = rdr["inStock"].ToString();
                lookedUpAssocPart.setinStock(Convert.ToInt32(inStock));

              

            }
            con.Close();
            return lookedUpAssocPart;
        }

    }
}
