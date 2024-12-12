using System;
using System.Buffers;
using System.IO;
using System.Numerics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactManagementSystem
{
    static class Program
    {
        static void Main(string[] args)
        {
            contactClass _contactClass = new contactClass();

            Console.Write("Hello! What you want to do today?\n");
            Console.Write("1: Save a contact \n");
            Console.Write("2: Delete a contact\n");
            Console.Write("3: Update a contact\n");
            Console.Write("4: Search a contact\n");
            Console.Write("\nPlease enter you selection as number:\n");

            string? commandType = Console.ReadLine();
            if (commandType == "1")
            {
                Console.WriteLine("Please enter First Name : \n");
                string? fName = Console.ReadLine();
                Console.WriteLine("Please enter Last Name : \n");
                string? lName = Console.ReadLine();
                int contactNo;
                Console.WriteLine("Please enter Contact Number : \n");
                contactNo = _contactClass.IsValidContactNumber(Console.ReadLine().ToString());

                Console.WriteLine("Please enter Email ID : \n");
                string? emailID =_contactClass.IsValidEmail(Console.ReadLine().ToString());

                var result = _contactClass.saveContact(fName, lName, contactNo, emailID);
                Console.WriteLine(result);
            }
            if (commandType == "2")
            {
                string searchValue = null;
                string? searchKeyword = null;
                _contactClass.searchContact(searchKeyword, searchValue);

                Console.WriteLine("\n Please select contact id to be deleted: \n");
                int deleteContact =Convert.ToInt32(Console.ReadLine());
                bool res = _contactClass.deleteContact(deleteContact);
                if (res)
                {
                    Console.WriteLine("\n selected contact has been deleted successfully");
                }

                //Console.WriteLine("Please enter First Name to search: \n");
                //string? fName = Console.ReadLine();
                //int count = 0;// _contactClass.searchContact(fName);
                //if (count > 0)
                //{
                //    Console.WriteLine("\nPlease enter contact number from above search result to be deleted: \n");
                //    int contactNumber = Convert.ToInt32(Console.ReadLine());
                //    bool res = _contactClass.deleteContact(contactNumber);
                //    if (res)
                //    {
                //        Console.WriteLine("\n above Contact deleted successfully");
                //    }
                //}
            }
            if (commandType == "3")
            {
                Console.WriteLine("Please enter First Name for which contact needs to be updated: \n");
                string? fName = Console.ReadLine();
                int count = 0; // _contactClass.searchContact(fName);
                if (count > 0)
                {
                    Console.WriteLine("\nPlease enter which value you want to update: 1 - First Name, 2 - Last Name, 3 - Contact Number, 4 - Email ID \n");
                    string? keyword = Console.ReadLine();
                    Console.WriteLine("\nPlease enter the new data \n");
                    string? newRec = Console.ReadLine();
                    bool res = _contactClass.updateContact(keyword, newRec);
                    if (res)
                    {
                        Console.WriteLine("\n above Contact details update successfully");
                    }
                }

            }
            if (commandType == "4")
            {
                string searchValue = null;
                Console.WriteLine("\nPlease enter search criteria: 1 - First Name, 2 - Last Name, 3 - Contact Number, 4 - Email ID, 5 - All \n");
                string? searchKeyword = Console.ReadLine();
                if (searchKeyword != "5")
                {
                    Console.WriteLine("\nPlease enter the search criteria value \n");
                    searchValue = Console.ReadLine();
                }
                _contactClass.searchContact(searchKeyword, searchValue);
            }
        }
    }
}







