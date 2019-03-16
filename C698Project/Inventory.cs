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
        System.Data.SqlClient.SqlConnection con;
       
        public void addPart(Part part) {

            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mason\Documents\GitHub\C698Project\C698Project\DB.mdf;Integrated Security=True";
            con.Open();
            var query = "INSERT INTO [dbo].[partTable] ([partID], [name], [price], [inStock], [min], [max]) VALUES (@partID, @name, @price, @inStock, @min, @max); SELECT partID, name, price, inStock, min, max FROM partTable WHERE(partID = @partID)";
            var cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@partID", part.getParttID());
            cmd.Parameters.AddWithValue("@name", part.getName());
            cmd.Parameters.AddWithValue("@price", part.getPrice());
            cmd.Parameters.AddWithValue("@inStock", part.getInStock());
            cmd.Parameters.AddWithValue("@min", part.getMin());
            cmd.Parameters.AddWithValue("@max", part.getMax());
            cmd.ExecuteNonQuery();
         

            con.Close();

        }

        public bool deletePart(Part part) {
            //DELETE FROM[dbo].[partTable] WHERE(([partID] = @Original_partID) AND([price] = @Original_price) AND([inStock] = @Original_inStock) AND([min] = @Original_min) AND((@IsNull_max = 1 AND[max] IS NULL) OR([max] = @Original_max)))
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mason\Documents\GitHub\C698Project\C698Project\DB.mdf;Integrated Security=True";
            con.Open();
            var query = "DELETE FROM[dbo].[partTable] WHERE(([partID] = @partID) AND([price] = @price) AND ([inStock] = @inStock) AND([min] = @min) AND([max] = @max))";
            var cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@partID", part.getParttID());
            cmd.Parameters.AddWithValue("@price", part.getPrice());
            cmd.Parameters.AddWithValue("@inStock", part.getInStock());
            cmd.Parameters.AddWithValue("@min", part.getMin());
            cmd.Parameters.AddWithValue("@max", part.getMax());
            cmd.ExecuteNonQuery();


            return true;
        }

        public Part LookupPart(int partID) {
            Console.WriteLine(partID);
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mason\Documents\GitHub\C698Project\C698Project\DB.mdf;Integrated Security=True";
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
        
}

    }
}
