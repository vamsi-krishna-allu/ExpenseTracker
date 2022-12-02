using CoreLibrary;

namespace ExpenseTrackerTests
{
    [TestClass]
    public class ValidatorsTest
    {
        [TestMethod]
        public void TestPasswordValidateWithNullPassword()
        {
            bool isPasswordValid;
            isPasswordValid = Validators.IsPasswordValid(null);
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithEmptyPassword()
        {
            bool isPasswordValid;
            isPasswordValid = Validators.IsPasswordValid("");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithPasswordLengthLessThan6()
        {
            bool isPasswordValid;
            isPasswordValid = Validators.IsPasswordValid("abcde");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithPasswordLengthGreaterThan20()
        {
            bool isPasswordValid;
            isPasswordValid = Validators.IsPasswordValid("abcdefghijklmnopqrstuv");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithPasswordHavingNoUpperCase()
        {
            bool isPasswordValid;
            isPasswordValid = Validators.IsPasswordValid("abcdefghi");
            Assert.AreEqual(false, isPasswordValid);
        }


        [TestMethod]
        public void TestPasswordValidateWithPasswordWithNoLowerCase()
        {
            bool isPasswordValid;
            isPasswordValid = Validators.IsPasswordValid("ABCDEFGHIL");
            Assert.AreEqual(false, isPasswordValid);
        }


        [TestMethod]
        public void TestPasswordValidateWithPasswordWithNoSpecialCharacters()
        {
            bool isPasswordValid;
            isPasswordValid = Validators.IsPasswordValid("Abcdefghi");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithPasswordWithEmptyCharacters()
        {
            bool isPasswordValid;
            isPasswordValid = Validators.IsPasswordValid("Abc hihdjsbe@ge");
            Assert.AreEqual(false, isPasswordValid);
        }

        [TestMethod]
        public void TestPasswordValidateWithValidPassword()
        {
            bool isPasswordValid;
            isPasswordValid = Validators.IsPasswordValid("Abc@hijkl");
            Assert.AreEqual(true, isPasswordValid);
        }
    }
}