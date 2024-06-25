using Rekenmachine.Components.Model;

namespace NumpadConfigurationTests
{
    public class UnitTestTogglePlusAndMinus 
    {
        private NumpadConfiguration numpad;

        [SetUp]
        public void Setup()
        {
            numpad = new NumpadConfiguration { InputNumber = 0 };
        }

        [Test]
        public void Number_WithDecimals_AndHasNotPlusMinus_Expect_NumberWithDecimals_AndHasPlusMinus()
        {
            // Arrange
            numpad.InputNumber = 0.0078M;
            numpad.DisplayNumber = "0,0078";
            decimal expectedResult = -0.0078M;
            bool flagPlusMinusTrue = true;

            // Act
            string displayNumber = numpad.TogglePlusAndMinus(flagPlusMinusTrue);

            // Assert
            Assert.That(displayNumber, Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public void Number_WithDecimals_AndHasPlusMinus_Excpect_NumberWithDecimals_AndHasNotPlusMinus()
        {
            // Arrange
            numpad.InputNumber = -0.0078M;
            numpad.DisplayNumber = "-0,0078";
            decimal expectedResult = 0.0078M;
            bool flagPlusMinusFalse = false;

            // Act
            string displayNumber = numpad.TogglePlusAndMinus(flagPlusMinusFalse);

            // Assert
            Assert.That(displayNumber, Is.EqualTo(expectedResult.ToString()));
        }
    }
}