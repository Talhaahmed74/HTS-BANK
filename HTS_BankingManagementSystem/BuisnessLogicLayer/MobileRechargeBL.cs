using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class MobileRechargeBL
    {
        private readonly MobileRechargeData _mobileRechargeData;

        public MobileRechargeBL()
        {
            _mobileRechargeData = new MobileRechargeData();
        }

        public string Recharge(int senderAccount, decimal amount, string network, string phoneNumber)
        {
            if (amount <= 0)
            {
                return "Error: Amount must be greater than zero.";
            }

            // Get the receiver account based on the phone number
            int receiverAccount = _mobileRechargeData.GetReceiverAccount(phoneNumber);
            if (receiverAccount == 0)
            {
                return "Error: Receiver account not found.";
            }

            // Check if the phone number matches the receiver account
            if (!_mobileRechargeData.ValidatePhoneNumber(receiverAccount, phoneNumber))
            {
                return "Error: The phone number does not match the receiver account.";
            }

            if (_mobileRechargeData.AddAmountToReceiver(receiverAccount, amount))
            {
                bool status = _mobileRechargeData.SubtractAmountFromSender(senderAccount, amount);
                if (status)
                {
                    return "Successfully recharged";
                }
                else
                {
                    return "Unsuccessful";
                }
            }
            else
            {
                return "Unsuccessful";
            }
        }
    }
}
