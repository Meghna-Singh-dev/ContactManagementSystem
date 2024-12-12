using System;
using System.IO;

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
                Console.WriteLine("Please enter Contact Number : \n");
                string? contactNo = Console.ReadLine();
                Console.WriteLine("Please enter Email ID : \n");
                string? emailID = Console.ReadLine();

                var result = _contactClass.saveContact(fName, lName, contactNo, emailID);
                Console.WriteLine(result);
            }
            if (commandType == "2")
            {
                Console.WriteLine("Please enter First Name to search: \n");
                string? fName = Console.ReadLine();
                int count = _contactClass.searchContact(fName);
                if (count > 0)
                {
                    Console.WriteLine("\nPlease enter contact number from above search result to be deleted: \n");
                    string? contactNumber = Console.ReadLine();
                    bool res = _contactClass.deleteContact(contactNumber);
                    if (res)
                    {
                        Console.WriteLine("\n above Contact deleted successfully");
                    }
                }
            }
            if (commandType == "3")
            {
                Console.WriteLine("Please enter First Name for which contact needs to be updated: \n");
                string? fName = Console.ReadLine();
                int count = _contactClass.searchContact(fName);
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
                Console.WriteLine("Please enter First Name : \n");
                string? fName = Console.ReadLine();
                _contactClass.searchContact(fName);
            }
        }
    }
}







