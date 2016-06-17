using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculette_Agile;

namespace CalculetteTest
{
    [TestClass]
    public class TestClear
    {
        [TestMethod]
        public void TestBack()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.ClearLastDigit("0123456789"), "012345678");
        }

        [TestMethod]
        public void TestBackEmpty()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.ClearLastDigit(""), "0");
        }

        [TestMethod]
        public void TestBackOneChar()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.ClearLastDigit("1"), "0");
        }
    }
}
