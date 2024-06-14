using System;
using DataAccessLayer;
using static DataAccessLayer.AccountInfoData;

namespace BusinessLogicLayer
{
    public class AccountInfoBL
    {
        private readonly AccountInfoData _dataLayer = new AccountInfoData();

        public Account GetAccountInfo(int accountNo)
        {
            return _dataLayer.GetAccountInfo(accountNo);
        }

        public bool UpdatePhoneNumber(string newNumber, string accountNo)
        {
            return _dataLayer.UpdatePhoneNumber(newNumber, accountNo);
        }

        public int SendInfoUpdateRequest(string description, int accountNo)
        {
            return _dataLayer.SendInfoUpdateRequest(description, accountNo);
        }
    }
}
