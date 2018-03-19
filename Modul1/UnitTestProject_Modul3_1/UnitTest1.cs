using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject_Modul3_1
{


    [TestClass]
    public class UnitTestZelda
    {
        [TestMethod]
        public void TestZeldaLogic()
        {

            //Actual

            var nameList = new List<string>();
            nameList.Add("Adam");
            nameList.Add("Zelda");
            List<Modul3.ZeldaPerson> actualZeldaList = Modul3.Program.ZeldaLogic(nameList);



            //Expected

            List<Modul3.ZeldaPerson> expectedZeldaList = new List<Modul3.ZeldaPerson>();

            var person = new Modul3.ZeldaPerson();
            person.color = ConsoleColor.Green;
            person.name = "Adam";

            expectedZeldaList.Add(person);


            //Check
            Assert.AreEqual(expectedZeldaList[0].name, actualZeldaList[0].name);
            Assert.AreEqual(expectedZeldaList[0].color, actualZeldaList[0].color);
            Assert.AreEqual(expectedZeldaList.Count, actualZeldaList.Count);
        }

        [TestMethod]
        public void TestAllowZeldaLogic()
        {
            //Actual

            var nameList = new List<string>();
            nameList.Add("Zelda");
            nameList.Add("AllowZelda");
            List<Modul3.ZeldaPerson> actualZeldaList = Modul3.Program.ZeldaLogic(nameList);



            //Expected

            List<Modul3.ZeldaPerson> expectedZeldaList = new List<Modul3.ZeldaPerson>();

            var person = new Modul3.ZeldaPerson();
            person.color = ConsoleColor.Green;
            person.name = "Zelda";

            expectedZeldaList.Add(person);


            //Check
            Assert.AreEqual(expectedZeldaList[0].name, actualZeldaList[0].name);
            Assert.AreEqual(expectedZeldaList[0].color, actualZeldaList[0].color);
            Assert.AreEqual(expectedZeldaList.Count, actualZeldaList.Count);
        }

        [TestMethod]
        public void TestLinkLogic()
        {
            //Actual

            var nameList = new List<string>();
            nameList.Add("Link");
            List<Modul3.ZeldaPerson> actualZeldaList = Modul3.Program.ZeldaLogic(nameList);



            //Expected

            List<Modul3.ZeldaPerson> expectedZeldaList = new List<Modul3.ZeldaPerson>();

            var person = new Modul3.ZeldaPerson();
            person.color = ConsoleColor.DarkGreen;
            person.name = "Link, Savior of Hyrule";

            expectedZeldaList.Add(person);


            //Check
            Assert.AreEqual(expectedZeldaList[0].name, actualZeldaList[0].name);
            Assert.AreEqual(expectedZeldaList[0].color, actualZeldaList[0].color);
            Assert.AreEqual(expectedZeldaList.Count, actualZeldaList.Count);
        }

        [TestMethod]
        public void TestOneLineCompareLesserThan()
        {
            //Actual
            string actualString = Modul3.Program.OneLineCompare(17);

            //Expected
            string expectedString = "Mindre än 20";

            //Check
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void TestOneLineCompareGreaterThan()
        {
            //Actual
            string actualString = Modul3.Program.OneLineCompare(23);

            //Expected
            string expectedString = "Större än 20";

            //Check
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void TestOneLineCompareEqualTo()
        {
            //Actual
            string actualString = Modul3.Program.OneLineCompare(20);

            //Expected
            string expectedString = "Lika med 20";

            //Check
            Assert.AreEqual(expectedString, actualString);
        }

    }


}
