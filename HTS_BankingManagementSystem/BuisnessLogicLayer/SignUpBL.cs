using System;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SignUpBL
    {
        SignUpDAL dal = new SignUpDAL();

        public string SetupAccount(string firstName, string lastName, string fatherName, int age, string gender, string phoneNumber, string address, string cnic,string email, string accountType, string password, int branch, int admin)
        {
            return dal.SetupAccount(firstName, lastName, fatherName, age, gender, phoneNumber, address, cnic, email, password, accountType, branch, admin);
        }
    }
}
