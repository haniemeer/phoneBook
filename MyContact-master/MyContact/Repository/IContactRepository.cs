using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyContact
{
    interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int Contact_ID);
        DataTable Search(String Parameter);
        bool Insert(String Name, String Family, String Email, String Mobile, int Age, string Address);
        bool Update(int Contact_ID, String Name, String Family, String Email, String Mobile, int Age, string Address);
        bool Delete(int Contact_ID);
    }

}
