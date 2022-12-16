using Database.Validators;

namespace ExpenseTrackerTests
{
    [TestClass]
    public class ValidatorsTest
    {
        [TestMethod]
        public void TestPasswordValidateWithNullPassword()
        {
            bool isPasswordValid;
            isPasswordValid = PasswordValidator.IsValid(null);
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithEmptyPassword()
        {
            bool isPasswordValid;
            isPasswordValid = PasswordValidator.IsValid("");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithPasswordLengthLessThan6()
        {
            bool isPasswordValid;
            isPasswordValid = PasswordValidator.IsValid("abcde");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithPasswordLengthGreaterThan20()
        {
            bool isPasswordValid;
            isPasswordValid = PasswordValidator.IsValid("abcdefghijklmnopqrstuv");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithPasswordHavingNoUpperCase()
        {
            bool isPasswordValid;
            isPasswordValid = PasswordValidator.IsValid("abcdefghi");
            Assert.AreEqual(false, isPasswordValid);
        }


        [TestMethod]
        public void TestPasswordValidateWithPasswordWithNoLowerCase()
        {
            bool isPasswordValid;
            isPasswordValid = PasswordValidator.IsValid("ABCDEFGHIL");
            Assert.AreEqual(false, isPasswordValid);
        }


        [TestMethod]
        public void TestPasswordValidateWithPasswordWithNoSpecialCharacters()
        {
            bool isPasswordValid;
            isPasswordValid = PasswordValidator.IsValid("Abcdefghi");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithPasswordWithEmptyCharacters()
        {
            bool isPasswordValid;
            isPasswordValid = PasswordValidator.IsValid("Abc hihdjsbe@ge");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithValidPassword()
        {
            bool isPasswordValid;
            isPasswordValid = PasswordValidator.IsValid("Abc@hijkl");
            Assert.AreEqual(true, isPasswordValid);
        }
    }
}