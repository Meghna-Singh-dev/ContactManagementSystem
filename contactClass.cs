using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactManagementSystem
{
    public class contactClass: iContactInterface
    {
        string path = @"D:\\contactList.csv";
        int contactID = 0;
        public string saveContact(string fName, string lName, int contactNo, string emailID)
        {
            string result;
            if (!File.Exists(path))
            {
                using (StreamWriter stream = File.CreateText(path))
                {
                    stream.WriteLine("Contact ID, First Name,Last Name,Contact, Email ID");
                    contactID = 1;
                    string csvRow = string.Format("{0},{1},{2},{3}, {4}", contactID, fName, lName, contactNo, emailID);
                    stream.WriteLine(csvRow);
                    stream.Close();
                }
            }
            else
            {
                string[] lines = File.ReadAllLines(path);
               
                StreamWriter stream = File.AppendText(path);
                contactID = getContactID(lines);

                string csvRow = string.Format("{0},{1},{2},{3}, {4}", contactID, fName, lName, contactNo, emailID);
                stream.WriteLine(csvRow);
                stream.Close();
            }
            result = "Contact saved successfully!";
            return result;
        }

        public bool deleteContact(int contactId)
        {
            bool result = false;
            string[] lines = File.ReadAllLines(path);

            List<string> linesToWrite = new List<string>();
            List<string> newContentHeader = new List<string>();
            List<string> newContent = new List<string>();
            foreach (string s in lines)
            {
                String[] split = s.Split(' ');
                linesToWrite.Add(s);
            }
            foreach (string s in linesToWrite)
            {
                String[] str = s.Split(",");

                if (str[0] != "Contact ID" && (str[0] == contactId.ToString() || Convert.ToInt32(str[0]) == contactId))
                {
                    result = true;
                }
                if (str[0] != "Contact ID" && Convert.ToInt32(str[0]) != contactId)
                {
                    newContent.Add(s);
                }
            }
            newContentHeader.Add("Contact ID, First Name,Last Name,Contact, Email ID");
            foreach (string ss in newContent)
            {
                newContentHeader.Add(ss);
            }

            File.WriteAllLines(path, newContentHeader);

            return result;
        }

        public int searchContact(string searchKeyword, string searchValue)
        {
            List<string> resLines = new List<string>();
            var lines = File.ReadLines(path);
            int count = 0;
            if (searchValue != null)
            {
                foreach (var line in lines)
                {
                    var res = line.Split(new char[] { ',' });
                    if (res[1].ToString() == searchValue || res[2].ToString() == searchValue || res[3].ToString() == searchValue || res[4].ToString() == searchValue) // fName
                    {
                        resLines.Add(res[0]);
                        resLines.Add(res[1]);
                        resLines.Add(res[2]);
                        resLines.Add(res[3]);
                        resLines.Add(res[4]);
                    }
                }

                if (resLines.Count > 0)
                {
                    Console.WriteLine("We found the following contact details:\n");
                    Console.WriteLine("{0,5} {1,15} {2,20} {3,25} {4,30}", "CONTACT ID", "FIRST NAME", "LAST NAME", "CONTACT NUMBER", "EMAIL ID");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                    var ContactID = (resLines[0].ToString() ?? "").ToString();
                    var firstName = (resLines[1].ToString() ?? "").ToString();
                    var lastName = (resLines[2].ToString() ?? "").ToString();
                    var contactNo = (resLines[3].ToString() ?? "").ToString();
                    var emailId = (resLines[4].ToString() ?? "").ToString();
                    Console.WriteLine("{0,5} {1,15} {2,20} {3,25} {4,30}", ContactID, firstName, lastName, contactNo, emailId);
                    count++;
                }
                else
                {
                    Console.WriteLine("Sorry, no contact details found with that name!\n");
                }
            }
            else
            {
                lines = lines.Skip(1);
                Console.WriteLine("We found the following contact details:\n");
                Console.WriteLine("{0,5} {1,15} {2,20} {3,25} {4,30}", "CONTACT ID", "FIRST NAME", "LAST NAME", "CONTACT NUMBER", "EMAIL ID");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                foreach (var line in lines)
                {
                    var res = line.Split(new char[] { ',' });
                    var ContactID = (res[0].ToString() ?? "").ToString();
                    var firstName = (res[1].ToString() ?? "").ToString();
                    var lastName = (res[2].ToString() ?? "").ToString();
                    var contactNo = (res[3].ToString() ?? "").ToString();
                    var emailId = (res[4].ToString() ?? "").ToString();
                    Console.WriteLine("{0,5} {1,15} {2,20} {3,25} {4,30}", ContactID, firstName, lastName, contactNo, emailId);
                    count++;
                }
            }
            return count;
        }

        public bool updateContact(string keyword, string newRec)
        {
            bool result = false;
            string[] lines = File.ReadAllLines(path);

            List<string> linesToWrite = new List<string>();
            List<string> newContent = new List<string>();
            foreach (string s in lines)
            {
                String[] split = s.Split(' ');
                linesToWrite.Add(s);
            }
            foreach (string s in linesToWrite)
            {
                String[] str = s.Split(",");

                if (keyword == "1")
                {
                    str[1] = newRec;
                    result = true;
                }
                if (keyword == "2")
                {
                    str[2] = newRec;
                    result = true;
                }
                if (keyword == "3")
                {
                    str[3] = newRec;
                    result = true;
                }
                if (keyword == "4")
                {
                    str[4] = newRec;
                    result = true;
                }
                var data = string.Join(",", str);

                newContent.Add(data);
            }
            File.WriteAllLines(path, newContent);
            return result;  
        }

        private int getContactID(string[] lines)
        {
            int contactID = 0;
            string contacts = "";
            int val = lines.Count();
            if (val > 0)
            {
                contacts = lines[val - 1];
            }
            var res = contacts.Split(new char[] { ',' });

            contactID = Convert.ToInt32(res[0]);

            return contactID += 1;
        }

        public int IsValidContactNumber(string ContactNumber)
        {
            int contactNo = 0;
            try
            {
                contactNo = Convert.ToInt32(ContactNumber);
                int count = 0;
                while (contactNo > 0)
                {
                    contactNo = contactNo / 10;
                    count++;
                }
                if (count != 10)
                {
                    throw new Exception("contact number should only contains number and must be of 10 digits!");
                }
                return Convert.ToInt32(ContactNumber);
            }
            catch (Exception ex)
            {
                
                throw new Exception("contact number should only contains number and must be of 10 digits!");
            }
        }
        public string IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return null; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address;
            }
            catch
            {
                throw new Exception("Not a valid email ID format, valid format are - cog@wheel, cogwheel@example.com, 123@$.xyz");
            }
        }
    }
}
