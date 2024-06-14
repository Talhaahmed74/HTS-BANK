using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BuisnessLogicLayer
{
    public class ModifyInfoBL
    {
        public object GetRequests(int accountNo)
        {
            return ModifyInfoData.GetRequests(accountNo);
        }
    }
}
