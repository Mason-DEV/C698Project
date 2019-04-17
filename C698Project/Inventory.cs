using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C698Project
{
    class Inventory
    {


        int inHouseID;
        int outSourcedID;
        int machineID;
        string companyName;

        public void addPart(Part part) {
            //Need to get correct inHouse or Outsourced information

            Console.WriteLine(inHouseID);
            Console.WriteLine(outSourcedID);
            Console.WriteLine(machineID);
            Console.WriteLine(companyName);

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
               "INSERT INTO [dbo].[partTable] ([partID], [name], [price], [inStock], [min], [max], [inHouse], [outsourced] ,[companyName],[machineID]) VALUES (@partID, @name, @price, @inStock, @min, @max, @inHouseID,@outSourcedID,@companyName,@machineID); SELECT partID, name, price, inStock, min, max, inHouse, outsourced ,companyName,machineID FROM partTable WHERE(partID = @partID)";
            command.Parameters.AddWithValue("@partID", part.getParttID());
            command.Parameters.AddWithValue("@name", part.getName());
            command.Parameters.AddWithValue("@price", part.getPrice());
            command.Parameters.AddWithValue("@inStock", part.getInStock());
            command.Parameters.AddWithValue("@min", part.getMin());
            command.Parameters.AddWithValue("@max", part.getMax());
            command.Parameters.AddWithValue("@inHouseID", inHouseID);
            command.Parameters.AddWithValue("@outSourcedID", outSourcedID);
            command.Parameters.AddWithValue("@companyName", companyName);
            command.Parameters.AddWithValue("@machineID", machineID);
            command.ExecuteNonQuery();
            transaction.Commit();
            con.Close();


        }

        public void houseInfo(Inhouse info) {
           inHouseID = info.getInHouseID();
           outSourcedID = info.getoutsourcedID();
            if (inHouseID == 1)
            {
                machineID = info.getMachineID();
                companyName = "";
            }
          
        }

        public void outSourceInfo(Outsourced info)
        {
            outSourcedID = info.getoutsourcedID();
            inHouseID = info.getInHouseID();

            if (outSourcedID == 1)
            {
                companyName = info.getCompanyName();
                machineID = 0;
            }
        }

        public bool deletePart(Part part) {
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
              "DELETE FROM[dbo].[partTable] WHERE(([partID] = @partID) AND([price] = @price) AND ([inStock] = @inStock) AND([min] = @min) AND([max] = @max))";
            command.Parameters.AddWithValue("@partID", part.getParttID());
            command.Parameters.AddWithValue("@price", part.getPrice());
            command.Parameters.AddWithValue("@inStock", part.getInStock());
            command.Parameters.AddWithValue("@min", part.getMin());
            command.Parameters.AddWithValue("@max", part.getMax());
            command.ExecuteNonQuery();
            transaction.Commit();
            con.Close();

            return true;
        }

        public Part LookupPart(int partID) {
            Console.WriteLine(partID);
            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            con.Open();
            var query = "SELECT partID, name, price, inStock, min, max FROM dbo.partTable where partID = @partID";
            var cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@partID", partID);
            
            String ID;
            String name;
            String price;
            String inStock;
            String min;
            String max;
            Part lookedupPart = new Part();
            SqlDataReader rdr = cmd.ExecuteReader();
            // Fill the strings with the values retrieved, convert to types as needed
            while (rdr.Read())
            {
                
                ID = rdr["partID"].ToString();
                lookedupPart.setPartID(Convert.ToInt32(ID));

                name = rdr["name"].ToString();
                lookedupPart.setName(name);

                price = rdr["price"].ToString();
                lookedupPart.setPrice(Convert.ToDouble(price));

                inStock = rdr["inStock"].ToString();
                lookedupPart.setinStock(Convert.ToInt32(inStock));

                min = rdr["min"].ToString();
                lookedupPart.setMin(Convert.ToInt32(min));

                max = rdr["max"].ToString();
                lookedupPart.setMax(Convert.ToInt32(max));
                


            }
            con.Close();
            return lookedupPart;
            



        }

        public void updatePart(int partID, Part part) {
            Console.WriteLine("Updating Part");

            Console.WriteLine("Setting machineID to " + machineID);

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
                "UPDATE partTable SET name = @name, price = @price, inStock = @inStock, min = @min, max = @max,  inHouse = @inHouseID, outsourced = @outSourcedID ,companyName = @companyName, machineID = @machineID WHERE  partID = @partID;";
            command.Parameters.AddWithValue("@partID", partID);
            command.Parameters.AddWithValue("@name", part.getName());
            command.Parameters.AddWithValue("@price", part.getPrice());
            command.Parameters.AddWithValue("@inStock", part.getInStock());
            command.Parameters.AddWithValue("@min", part.getMin());
            command.Parameters.AddWithValue("@max", part.getMax());
            command.Parameters.AddWithValue("@inHouseID", inHouseID);
            command.Parameters.AddWithValue("@outSourcedID", outSourcedID);
            command.Parameters.AddWithValue("@companyName", companyName);
            command.Parameters.AddWithValue("@machineID", machineID);
            var affected  = command.ExecuteNonQuery();
            transaction.Commit();
            con.Close();
            Console.WriteLine("Updated Part "+affected);

        }

        public void addProduct(Products product) {
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
               "INSERT INTO [dbo].[productTable] ([productID], [name], [price], [inStock], [min], [max]) VALUES (@productID, @name, @price, @inStock, @min, @max); SELECT productID, name, price, inStock, min, max FROM productTable WHERE(productID = @productID)";
            command.Parameters.AddWithValue("@productID", product.getProductID());
            command.Parameters.AddWithValue("@name", product.getName());
            command.Parameters.AddWithValue("@price", product.getPrice());
            command.Parameters.AddWithValue("@inStock", product.getInStock());
            command.Parameters.AddWithValue("@min", product.getProductMin());
            command.Parameters.AddWithValue("@max", product.getMax());
            command.ExecuteNonQuery();
            transaction.Commit();
            con.Close();

        }

        public bool removeProduct(int productID) {
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
              "DELETE FROM[dbo].[productTable] WHERE(([productID] = @productID))";
            command.Parameters.AddWithValue("@productID", productID);
            command.ExecuteNonQuery();
            transaction.Commit();
            con.Close();

            return true;
        }

        public Products lookupProduct(int productID) {

            Console.WriteLine(productID);
            SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Application.StartupPath + "\\DB.mdf; Integrated Security=True");
            con.Open();
            var query = "SELECT productID, name, price, inStock, min, max FROM dbo.productTable where productID = @productID";
            var cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@productID", productID);

            String ID;
            String name;
            String price;
            String inStock;
            String min;
            String max;
            Products lookedupProduct = new Products();
            SqlDataReader rdr = cmd.ExecuteReader();
            // Fill the strings with the values retrieved, convert to types as needed
            while (rdr.Read())
            {

                ID = rdr["productID"].ToString();
                lookedupProduct.setProductID(Convert.ToInt32(ID));

                name = rdr["name"].ToString();
                lookedupProduct.setName(name);

                price = rdr["price"].ToString();
                lookedupProduct.setPrice(Convert.ToDouble(price));

                inStock = rdr["inStock"].ToString();
                lookedupProduct.setinStock(Convert.ToInt32(inStock));

                min = rdr["min"].ToString();
                lookedupProduct.setMin(Convert.ToInt32(min));

                max = rdr["max"].ToString();
                lookedupProduct.setMax(Convert.ToInt32(max));



            }
            con.Close();
            return lookedupProduct;

        }

        public void updateProduct(int productID, Products product) {

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
                "UPDATE productTable SET name = @name, price = @price, inStock = @inStock, min = @min, max = @max WHERE  productID = @productID;";
            command.Parameters.AddWithValue("@productID", productID);
            command.Parameters.AddWithValue("@name", product.getName());
            command.Parameters.AddWithValue("@price", product.getPrice());
            command.Parameters.AddWithValue("@inStock", product.getInStock());
            command.Parameters.AddWithValue("@min", product.getProductMin());
            command.Parameters.AddWithValue("@max", product.getMax());
            var affected = command.ExecuteNonQuery();
            transaction.Commit();
            con.Close();

        }
       
    }
}
