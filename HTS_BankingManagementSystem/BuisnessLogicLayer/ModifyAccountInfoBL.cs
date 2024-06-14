using System;
using DataAccessLayer;

namespace BuisnessLogicLayer
{
    public class ModifyAccountInfoBL
    {
        public int UpdateAddress(int accountNo, string address)
        {
            ModifyAccountInfoData data = new ModifyAccountInfoData();
            return data.UpdateAddress(accountNo, address);
        }
    }
}
