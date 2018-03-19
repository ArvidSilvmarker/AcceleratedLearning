using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTest_Modul4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidateText_ShortName()
        {
            List<string> listToTest = new List<string>();
            listToTest.Add("A");

            //exptected
            bool expectedValidation = false;

            //actual
            bool actualValidation = Modul_4.Program.ValidateText(listToTest, false);

            //check
            Assert.AreEqual(expectedValidation, actualValidation);
        }

        [TestMethod]
        public void TestValidateText_LongName()
        {
            List<string> listToTest = new List<string>();
            listToTest.Add("Aaaaaaaaaaaaaaaaa");

            //exptected
            bool expectedValidation = false;

            //actual
            bool actualValidation = Modul_4.Program.ValidateText(listToTest, false);

            //check
            Assert.AreEqual(expectedValidation, actualValidation);
        }

        [TestMethod]
        public void TestValidateText_EmptyName()
        {
            List<string> listToTest = new List<string>();
            listToTest.Add("");

            //exptected
            bool expectedValidation = false;

            //actual
            bool actualValidation = Modul_4.Program.ValidateText(listToTest, false);

            //check
            Assert.AreEqual(expectedValidation, actualValidation);
        }

        [TestMethod]
        public void TestValidateText_NullName()
        {
            List<string> listToTest = new List<string>();
            listToTest.Add(null);

            //exptected
            bool expectedValidation = false;

            //actual
            bool actualValidation = Modul_4.Program.ValidateText(listToTest, false);

            //check
            Assert.AreEqual(expectedValidation, actualValidation);
        }

        [TestMethod]
        public void TestValidateText_NullList()
        {

            //exptected
            bool expectedValidation = false;

            //actual
            bool actualValidation = Modul_4.Program.ValidateText(null, false);

            //check
            Assert.AreEqual(expectedValidation, actualValidation);
        }
    }
}
