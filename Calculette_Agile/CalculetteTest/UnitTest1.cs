using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculette_Agile;

// ============ Ctrl + R + A pour lancer les tests unitaires ==============

namespace CalculetteTest
{
    [TestClass]
    public class CalculateUnit
    {

        [TestMethod]
        public void TestAddition()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.Addition("10", "20"), "30");
        }

        [TestMethod]
        public void TestAdditionFailed()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreNotEqual(calculate.Addition("999999999999999999999999999", "1"), "1000000000000000000000000000");
            Assert.AreEqual(calculate.Addition("999999999999999999999999999", "1"), "1E+27");
        }

        [TestMethod]
        public void TestAdditionNegatif()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.Addition("-1", "-1"), "-2");
        }
    }
}
