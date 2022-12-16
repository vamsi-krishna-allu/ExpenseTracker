using Database.Validators;

namespace ExpenseTrackerTests
{
    [TestClass]
    public class EmailValidatorTest
    {
        [TestMethod]
        public void TestWithNullEmail()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsValid(null);
            Assert.AreEqual(false, isEmailValid);
        }

        [TestMethod]
        public void TestWithEmptyEmail()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsValid("");
            Assert.AreEqual(false, isEmailValid);
        }

        [TestMethod]
        public void TestWithAtTheRateAtEnd()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsValid("abcde@");
            Assert.AreEqual(false, isEmailValid);
        }

        [TestMethod]
        public void TestWithoutAtTheRate()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsValid("abcdefghijklmnopqrstuv");
            Assert.AreEqual(false, isEmailValid);
        }


        [TestMethod]
        public void TestWithValidEmail()
        {
            bool isEmailValid;
            isEmailValid = EmailValidator.IsValid("Abc@gmail.com");
            Assert.AreEqual(true, isEmailValid);
        }
    }
}