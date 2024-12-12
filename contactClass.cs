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

        public bool deleteContact(string contactNo)
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
                if (str[2].ToString() == contactNo)
                {
                    result = true;
                }
                if (str[2].ToString() != contactNo)
                {
                    newContent.Add(s);
                }
            }
                File.WriteAllLines(path, newContent);

            return result;
        }

        public string saveContact(string fName, string lName, string contactNo, string emailID)
        {
            string result;
            if (!File.Exists(path))
            {
                using (StreamWriter stream = File.CreateText(path))
                {
                    string csvRow = string.Format("{0},{1},{2}, {3}", fName, lName, contactNo, emailID);
                    stream.WriteLine(csvRow);
                    stream.Close();
                }
            }
            else
            {
                StreamWriter stream = File.AppendText(path);
                string csvRow = string.Format("{0},{1},{2}, {3}", fName, lName, contactNo, emailID);
                stream.WriteLine(csvRow);
                stream.Close();
            }
            result = "Contact saved successfully!";            
            return result;
        }

        public int searchContact(string fName)
        {
            List<string> resLines = new List<string>();
            var lines = File.ReadLines(path);
            int count = 0;
            foreach (var line in lines)
            {
                var res = line.Split(new char[] { ',' });
                if (res[0].ToString() == fName)
                {
                    resLines.Add(res[0]);
                    resLines.Add(res[1]);
                    resLines.Add(res[2]);
                    resLines.Add(res[3]);
                }
            }

            if (resLines.Count > 0)
            {
                Console.WriteLine("We found the following contact details:\n");
                Console.WriteLine("{0,5} {1,15} {2,20} {3,25}", "FIRST NAME", "LAST NAME", "CONTACT NUMBER", "EMAIL ID");
                Console.WriteLine("---------------------------------------------------------------------------------------");

                var firstName = (resLines[0].ToString() ?? "").ToString();
                var lastName = (resLines[1].ToString() ?? "").ToString();
                var contactNo = (resLines[2].ToString() ?? "").ToString();
                var emailId = (resLines[3].ToString() ?? "").ToString();
                Console.WriteLine("{0,5} {1,15} {2,20} {3,25}", firstName, lastName, contactNo, emailId);
                count++;
            }
            else
            {
                Console.WriteLine("Sorry, no contact details found with that name!\n");
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
                    str[0] = newRec;
                    result = true;
                }
                if (keyword == "2")
                {
                    str[1] = newRec;
                    result = true;
                }
                if (keyword == "3")
                {
                    str[2] = newRec;
                    result = true;
                }
                if (keyword == "4")
                {
                    str[3] = newRec;
                    result = true;
                }
                var data = string.Join(",", str);

                newContent.Add(data);
            }
            File.WriteAllLines(path, newContent);
            return result;  
        }
    }
}
