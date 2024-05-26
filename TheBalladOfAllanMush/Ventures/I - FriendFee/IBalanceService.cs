using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee.Model;

namespace TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee
{
    public interface IBalanceService
    {
        public Task<double> GetTotalBalanceAsync(Customer customer);
    }
}
