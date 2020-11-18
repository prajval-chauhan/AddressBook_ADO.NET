using System;
using System.Data;
using System.Data.SqlClient;

namespace AddressBookADO.NET
{
    public class AddressBook
    {
        public static string connectionString = @"Server=DESKTOP-C457C73\SQLEXPRESS; Database=AddressBook_ADO.NET; User Id=prajval;Password=gonfreecs";
        SqlConnection connection = new SqlConnection(connectionString);
        ContactModel contacts = new ContactModel();
        /// <summary>
        /// UC1: Connecting to the already existing databse  
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void CheckConnection()
        {
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    this.connection.Close();
                    Console.WriteLine("connection O.K.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// Displays the contacts.
        /// </summary>
        public void DisplayContacts()
        {
            try
            {
                using (this.connection)
                {
                    string query = @"SELECT * FROM addressBook;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            contacts.firstName = dr.GetString(0);
                            contacts.lastName = dr.GetString(1);
                            contacts.address = dr.GetString(2);
                            contacts.city = dr.GetString(3);
                            contacts.state = dr.GetString(4);
                            contacts.zip = dr.GetInt32(5);
                            contacts.phoneNo = dr.GetInt64(6);
                            contacts.email = dr.GetString(7);
                            Console.WriteLine("***********************************************************");
                            Console.WriteLine("firstName: {0},\nlastName: {1},\naddress: {2},\ncity: {3},\nstate: {4},\nzip: {5},\nphoneNo: {6},\nemail: {7}",
                                contacts.firstName, contacts.lastName, contacts.address, contacts.city, contacts.state, contacts.zip, contacts.phoneNo, contacts.email);
                            Console.WriteLine("***********************************************************");
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// UC2: Creates the address book table.
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
                    if (result != 0)
                    {
                        Console.WriteLine("success");
                    }
                    else
                    {
                        Console.WriteLine(":(");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// UC3: Adds the contact into the address book table 
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <exception cref="Exception"></exception>
        public void AddContact(ContactModel contact)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spAddContacts", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstName", contact.firstName);
                    cmd.Parameters.AddWithValue("@lastName", contact.lastName);
                    cmd.Parameters.AddWithValue("@address", contact.address);
                    cmd.Parameters.AddWithValue("@city", contact.city);
                    cmd.Parameters.AddWithValue("@state", contact.state);
                    cmd.Parameters.AddWithValue("@zip", contact.zip);
                    cmd.Parameters.AddWithValue("@phoneNo", contact.phoneNo);
                    cmd.Parameters.AddWithValue("@email", contact.email);
                    this.connection.Open();
                    cmd.ExecuteNonQuery();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// UC4: Edits the contact usign the first name 
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <exception cref="Exception"></exception>
        public void EditContactUsingFirstName(ContactModel contact, string contactToBeEdited)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spEditContacts", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@contactToBeEdited", contactToBeEdited);
                    cmd.Parameters.AddWithValue("@firstName", contact.firstName);
                    cmd.Parameters.AddWithValue("@lastName", contact.lastName);
                    cmd.Parameters.AddWithValue("@address", contact.address);
                    cmd.Parameters.AddWithValue("@city", contact.city);
                    cmd.Parameters.AddWithValue("@state", contact.state);
                    cmd.Parameters.AddWithValue("@zip", contact.zip);
                    cmd.Parameters.AddWithValue("@phoneNo", contact.phoneNo);
                    cmd.Parameters.AddWithValue("@email", contact.email);
                    this.connection.Open();
                    cmd.ExecuteNonQuery();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// UC5: Deletes the contact using first name and last name 
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <exception cref="Exception"></exception>
        public void DeleteContact(string firstName, string lastName)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteContact", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstNameOfTheContactToBeDeleted", firstName);
                    cmd.Parameters.AddWithValue("@lastNameOfTheContactToBeDeleted", lastName);
                    this.connection.Open();
                    cmd.ExecuteNonQuery();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// Findings the contacts by city or by state
        /// </summary>
        /// <param name="cityOrStateName">Name of the city or state.</param>
        /// <exception cref="Exception"></exception>
        public void FindingContactsByCityOrByState(string cityOrStateName)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spFindByCityOrByState", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cityOrState", cityOrStateName);
                    this.connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            contacts.firstName = dr.GetString(0);
                            contacts.lastName = dr.GetString(1);
                            contacts.city = dr.GetString(2);
                            contacts.state = dr.GetString(3);
                            Console.WriteLine("***********************************************************");
                            Console.WriteLine("firstName: {0},\nlastName: {1},\ncity: {2},\nstate: {3}",
                                contacts.firstName, contacts.lastName, contacts.city, contacts.state);
                            Console.WriteLine("***********************************************************");
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                    dr.Close();
                    this.connection.Close();
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
