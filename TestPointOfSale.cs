using NUnit.Framework;
using System.IO;

namespace PointOfSale
{
    [TestFixture]
    public class TestPointOfSale
    {
        PointOfSaleTerminal terminal;

        [SetUp]
        public void SetUp()
        {
            terminal = new PointOfSaleTerminal();
            terminal.SetPricing(File.ReadAllText("PricingData.json"));
        }

        [Test]
        public void ScanProduct_ABCDABA()
        {
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("A");
            Assert.That(terminal.CalculateTotal(), Is.EqualTo(13.25m));
        }

        [Test]
        public void ScanProduct_CCCCCCC()
        {
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            Assert.That(terminal.CalculateTotal(), Is.EqualTo(6m));
        }

        [Test]
        public void ScanProduct_ABCD()
        {
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            Assert.That(terminal.CalculateTotal(), Is.EqualTo(7.25m));
        }

        [Test]
        public void ScanProduct_None()
        {
            Assert.That(terminal.CalculateTotal(), Is.EqualTo(0m));
        }

        [Test]
        public void ScanProduct_D()
        {
            terminal.ScanProduct("D");
            Assert.That(terminal.CalculateTotal(), Is.EqualTo(0.75m));
        }

        [Test]
        public void ScanProduct_ACCCBCCACCCAA()
        {
            terminal.ScanProduct("A");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("A");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");
            Assert.That(terminal.CalculateTotal(), Is.EqualTo(15.5m));
        }
    }
}
