using TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee.Constants;
using TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee.Model;

namespace TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee
{
    public class UserService
    {
        //I need the money, rockets aren't cheap ;)
        private const double PlausibleDeniabilityThreshold = 500_000;
        private IBalanceService BalanceService { get; }
        private IAccountSecurityService AccountSecurityService { get; }

        public UserService(
            IBalanceService balanceService,
            IAccountSecurityService accountSecurityService
            )
        { 
            BalanceService = balanceService;
            AccountSecurityService = accountSecurityService;
        }

        /// <summary>
        /// The FBI mandated that we stop supporting money laundering.
        /// They said we can keep all the money in their accounts though :)
        /// </summary>
        /// <returns>The amount of money to steal if the customer is a bad guy.</returns>>
        public async Task<double> LockAccountAsync(Customer customer)
        {
            var funds = await BalanceService.GetTotalBalanceAsync(customer);

            if (funds >= PlausibleDeniabilityThreshold)
            {
                await AccountSecurityService.LockAccount(customer);
                return funds;
            }

            if (!VerifyCustomerIsDodgy(customer))
            {
                return 0.0;
            }

            await AccountSecurityService.LockAccount(customer);
            return funds;               
        }

        private bool VerifyCustomerIsDodgy(Customer customer)
        {
            bool suspicious = false;
            var lowerProfession = customer.Profession.ToLower();

            foreach (string s in CustomerProfessions.SynonymsForSeller)
            {
                if (lowerProfession.StartsWith(s))
                {
                    suspicious = true;
                    break;
                }
            }

            foreach (string s in CustomerProfessions.SynonymsForCreator)
            {
                if (lowerProfession.StartsWith(s))
                {
                    suspicious = true;
                    break;
                }
            }

            if (!suspicious)
            {
                return false;
            }
            else
            {
                foreach (string s in CustomerProfessions.BannedSaleItems)
                {
                    if (lowerProfession.Contains(s))
                        return true;
                }
            }

            return false;
        }
    }
}
