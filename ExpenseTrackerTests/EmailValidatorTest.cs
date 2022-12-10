using CoreLibrary;

namespace ExpenseTrackerTests
{
    [TestClass]
    public class EmailValidatorTest
    {
        [TestMethod]
        public void TestWithNullEmail()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsEmailValid(null);
            Assert.AreEqual(false, isEmailValid);
        }

        [TestMethod]
        public void TestWithEmptyEmail()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsEmailValid("");
            Assert.AreEqual(false, isEmailValid);
        }

        [TestMethod]
        public void TestWithAtTheRateAtEnd()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsEmailValid("abcde@");
            Assert.AreEqual(false, isEmailValid);
        }

        [TestMethod]
        public void TestWithoutAtTheRate()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsEmailValid("abcdefghijklmnopqrstuv");
            Assert.AreEqual(false, isEmailValid);
        }


        [TestMethod]
        public void TestWithValidEmail()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsEmailValid("Abc@gmail.com");
            Assert.AreEqual(true, isEmailValid);
        }
    }
}