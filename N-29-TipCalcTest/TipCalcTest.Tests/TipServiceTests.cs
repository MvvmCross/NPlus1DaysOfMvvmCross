using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TipCalcTest.Core.Services;

namespace TipCalcTest.Tests
{
    [TestFixture]
    public class TipServiceTests
    {
        [Test]
        public void TestThatZeroGenerosityReturnsZeroTip()
        {
            // Arrange
            var tip = new TipService();

            // Act
            var result = tip.Calc(42.35, 0);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestThatTenGenerosityReturnsTenPercentTip()
        {
            // Arrange
            var tip = new TipService();

            // Act
            var result = tip.Calc(42.35, 10);

            // Assert
            Assert.AreEqual(4.235, result);
        }
    }
}
