using TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee.Model;

namespace TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee
{
    public interface IAccountSecurityService
    {
        public Task LockAccount(Customer customer);
    }
}