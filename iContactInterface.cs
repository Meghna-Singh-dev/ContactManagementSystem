using System.Xml.Linq;

namespace ContactManagementSystem
{
    interface iContactInterface
    {
        string saveContact(string fName, string lName, string contactNo, string emailID);
        bool deleteContact(string contactNo);
        bool updateContact(string keyword, string newRec);
        int searchContact(string fName);

    }
}