using System;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AuthorizeDepositBL
    {
        private AuthorizeDepositData _dataAccess;

        public AuthorizeDepositBL()
        {
            _dataAccess = new AuthorizeDepositData();
        }

        public bool DepositAmount(int accountNumber, decimal amount)
        {
            if (accountNumber <= 0 || amount <= 0)
            {
                return false;
            }

            return _dataAccess.DepositAmount(accountNumber, amount);
        }
    }
}
