using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CustomerLoginBL
    {
        CustomerLoginData cld = new CustomerLoginData();

        public bool verifyCustomerLogin(int accountNo, string password)
        {
            return cld.VerifyLogin(accountNo, password);
        }
    }
}
