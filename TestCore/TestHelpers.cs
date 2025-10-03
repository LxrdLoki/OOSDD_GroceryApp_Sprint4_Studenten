using Grocery.Core.Helpers;

namespace TestCore
{
    public class TestHelpers
    {
        [SetUp]
        public void Setup()
        {
        }

        //Happy flow
        [Test]
        public void TestPasswordHelperReturnsTrue()
        {
            string password = "user3";
            string passwordHash = "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=";
            Assert.IsTrue(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        [TestCase("user1", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08=")]
        [TestCase("user3", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=")]
        public void TestPasswordHelperReturnsTrue(string password, string passwordHash)
        {
            Assert.IsTrue(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        //Unhappy flow
        [Test]
        public void TestPasswordHelperReturnsFalse()
        {
            string password = "user3";
            string wrongHash = "invalidHash";
            Assert.IsFalse(PasswordHelper.VerifyPassword(password, wrongHash));
        }

        // Unhappy flow - valid Base64, but wrong password instead
        [TestCase("user1_wrong", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08=")]
        [TestCase("user3_wrong", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=")]
        public void TestPasswordHelperReturnsFalse(string password, string passwordHash)
        {
            Assert.That(PasswordHelper.VerifyPassword(password, passwordHash), Is.False);
        }
    }
}