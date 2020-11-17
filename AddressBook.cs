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
    }
}
