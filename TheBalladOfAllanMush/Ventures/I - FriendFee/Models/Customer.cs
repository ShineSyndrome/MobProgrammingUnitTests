namespace TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee.Model
{
    public class Customer
    {
        public Customer(string name, string profession)
        {
            Name = name;
            Profession = profession;
        }

        public string Name { get; }
        public string Profession { get; }
    }
}
