using System;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AdminLoginBL
    {
        private AdminLoginData adminLoginData = new AdminLoginData();

        public bool VerifyAdminLogin(int accountNo, string password)
        {
            return adminLoginData.VerifyLogin(accountNo, password);
        }
    }
}
