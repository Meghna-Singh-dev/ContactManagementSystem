using System.Xml.Linq;

namespace ContactManagementSystem
{
    interface iContactInterface
    {
        string saveContact(string fName, string lName, int contactNo, string emailID);
        bool deleteContact(int contactNo);
        bool updateContact(string keyword, string newRec);
        int searchContact(string searchKeyword, string searchValue);

    }
}
