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

        [TestMethod]
        public void TestSoustraction()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.Soustraction("20", "10"), "10");
        }

        [TestMethod]
        public void TestSoustractionFailed()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreNotEqual(calculate.Soustraction("20", "10"), "-100");
        }

        [TestMethod]
        public void TestSoustractionNegatif()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.Soustraction("-1", "-10"), "9");
        }

        [TestMethod]
        public void TestMultiplication()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.Multiplication("10", "10"), "100");
        }

        [TestMethod]
        public void TestMultiplicationNegatif()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.Multiplication("-10", "10"), "-100");
        }

        [TestMethod]
        public void TestMultiplicationDoubleNegatif()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.Multiplication("-10", "-10"), "100");
        }

        [TestMethod]
        public void TestMultiplicationDecimal()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.Multiplication("0,5", "2"), "1");
        }

        [TestMethod]
        public void TestDivision()
        {
            Calculette_Agile.Calculate calculate = new Calculate();
            Assert.AreEqual(calculate.Division("10", "2"), "5");
        }
    }
}
