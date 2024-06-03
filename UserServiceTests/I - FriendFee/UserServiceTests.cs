using Moq;
using TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee;
using TheBalladOfAllanMush.AggravatinglySuccessfulVentures.I___FriendFee.Model;

namespace UnitTests.I___FriendFee
{
    /// <summary>
    /// Internet genius and entrepeneur Allan Mush has hired you as an intern.
    /// He's busy trying to setup an electric car organisation right now, 
    /// so you've been tasked with fixing some *minor* bugs with his 
    /// multi-million dollar, internet finance product "FriendFee".
    /// 
    /// An experienced QA has written some tests to reproduce the user-reported bugs.
    /// 
    /// Using these tests as a guide-line, can you fix UserService.cs?
    /// Since this is just a warm-up, band-aid fixes are fine!
    /// You won't need to edit the code in this file.
    /// 
    /// You can move on once all the tests in this class pass.
    /// </summary>
    public class UserServiceTests
    {
        Mock<IBalanceService> BalanceServiceMock { get; } = new();
        Mock<IAccountSecurityService> AccountSecurityServiceMock { get; } = new();

        // CFBP now says we can only lock accounts if they're above the new limit
        // - Friendly QA guy
        private double newLimit = 1_000_000;

        [Fact]
        public async Task LockAccountAsync_CustomerFundsAboveNewThreshold_ShouldLockAndReturnFunds()
        {
            //arrange
            Customer testCustomer = new("Richie Rich", "Something suspicious");

            BalanceServiceMock.Setup(x => x.GetTotalBalanceAsync(testCustomer))
                .ReturnsAsync(newLimit + 1);

            AccountSecurityServiceMock.Setup(x => x.LockAccount(testCustomer))
                .Verifiable();

            var sut = CreateTestUserService();

            //act
            var result = await sut.LockAccountAsync(testCustomer);

            //assert
            AccountSecurityServiceMock.Verify(x => x.LockAccount(testCustomer), Times.Once);
            Assert.Equal(newLimit + 1, result);
        }

        /// <summary>
        /// Xunit theory is a neat way of testing similar test cases at the same time.
        /// 
        /// The inline data gets passed through to the test, 
        /// and you can see the results for each case in the test explorer.
        /// Neat, huh?
        /// 
        /// - Friendly QA Guy
        /// </summary>
        [Theory]
        [InlineData(1_000_000)]
        [InlineData(999_999)]
        [InlineData(0)]
        public async Task LockAccountAsync_CustomerFundsNotPastThreshold_ShouldReturnZero(double funds)
        {
            //arrange
            Customer testCustomer = new("Average Joe", "Professional Lottery Player");

            BalanceServiceMock.Setup(x => x.GetTotalBalanceAsync(testCustomer))
                .ReturnsAsync(funds);

            var sut = CreateTestUserService();

            //act
            var result = await sut.LockAccountAsync(testCustomer);

            //assert
            Assert.Equal(0.0, result);
            AccountSecurityServiceMock.Verify(x => x.LockAccount(testCustomer), Times.Never);
        }

        /// <summary>
        /// You can also use some cool structure like this one to
        /// neatly pass complex objects to test cases.
        /// 
        /// -Friendly QA guy.
        /// </summary>
        public static IEnumerable<object[]> GetDodgyCustomerTestCases()
        {
            string name = "John Cleese";
            string profession = "Seller of sharp pointed stick";

            yield return new object[] { name, profession };

            name = "Vash the Stampede";
            profession = "Creator of the trigun";

            yield return new object[] { name, profession };

            name = "Mr. War Criminal";
            profession = "Seller of mines";

            yield return new object[] { name, profession };
        }

        [Theory]
        [MemberData(nameof(GetDodgyCustomerTestCases))]
        public async Task LockAccountAsync_CustomerIsDodgy_ShouldLockAccountAndReturnFunds(string name, string profession)
        {
            //arrange
            double funds = 99;

            Customer testCustomer = new(name, profession);

            BalanceServiceMock.Setup(x => x.GetTotalBalanceAsync(testCustomer))
                .ReturnsAsync(funds);

            var sut = CreateTestUserService();

            //act
            var result = await sut.LockAccountAsync(testCustomer);

            //assert
            Assert.Equal(funds, result);
            AccountSecurityServiceMock.Verify(x => x.LockAccount(testCustomer), Times.Once);
        }

        [Fact]
        public async Task LockAccountAsync_CustomerIsTheCreatorOfMinecraft_ShouldNotLockAccount()
        {
            //arrange
            double funds = 600_000;

            Customer testCustomer = new("Markus Persson", "Creator of Minecraft");

            BalanceServiceMock.Setup(x => x.GetTotalBalanceAsync(testCustomer))
                .ReturnsAsync(funds);

            var sut = CreateTestUserService();

            //act
            var result = await sut.LockAccountAsync(testCustomer);

            //assert
            Assert.Equal(0.0, result);
            AccountSecurityServiceMock.Verify(x => x.LockAccount(testCustomer), Times.Never);
        }

        private UserService CreateTestUserService()
        {
            return new UserService(
                    BalanceServiceMock.Object,
                    AccountSecurityServiceMock.Object
                );
        }
    }
}