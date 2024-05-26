using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee.Constants
{
    public class CustomerProfessions
    {
        public static List<string> SynonymsForSeller { get; } = new()
        {
            "seller",
            "brand consultant",
            "salesperson"
        };

        public static List<string> SynonymsForCreator { get; } = new()
        {
            "creator",
            "maker",
            "builder"
        };

        public static List<string> BannedSaleItems { get; } = new()
        {
            "bath water",
            "gun",
            "bomb",
            "mine",
            "knives",
            "sharp pointed stick"
        };
    }
}
