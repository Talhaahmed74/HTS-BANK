using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SearchAccountInfoBL
    {
        private readonly SearchAccountInfoDAL _searchAccountInfoDAL;

        public SearchAccountInfoBL()
        {
            _searchAccountInfoDAL = new SearchAccountInfoDAL();
        }

        public AccountInfo GetAccountInfo(int accountNo, int adminId)
        {
            return _searchAccountInfoDAL.GetAccountInfo(accountNo, adminId);
        }
    }

   
}
