using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO.NET
{
    public class AddressBook
    {
        public static string connectionString = @"Server=DESKTOP-C457C73\SQLEXPRESS; Database=AddressBook_ADO.NET; User Id=prajval;Password=gonfreecs";
        SqlConnection connection = new SqlConnection(connectionString);
        /// <summary>
        /// UC1: Connecting to the already existing databse  
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void CheckConnection()
        {
            try
            {
                using(this.connection)
                {
                    this.connection.Open();
                    this.connection.Close();
                    Console.WriteLine("connection O.K.");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// Creates the address book table.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void CreateAddressBookTable()
        {
            try
            {
                using (this.connection)
                {
                    string query = @"CREATE TABLE addressBook(firstName varchar(50) not null, lastName varchar(50) not null, address varchar(50) not null
                                     ,city varchar(50) not null, state varchar(50) not null, zip int not null, phoneNo bigint not null, email varchar(50) not null);";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if(result != 0)
                    {
                        Console.WriteLine("success");
                    }
                    else
                    {
                        Console.WriteLine(":(");
                    }
                }
            }
        catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
