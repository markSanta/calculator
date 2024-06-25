using Rekenmachine.Components.Model;

namespace CalculatorTests
{
    public class UnitTestPercentage
    {
        private Calculator _calculator;
        private NumpadConfiguration _a; 

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
            _a = new NumpadConfiguration { InputNumber = 0 }; 
        }

        [Test]
        public void InputNumber_NoPlusMinus() 
        {
            // Arrange
            _a.InputNumber = 80;
            decimal expectedResult = 0.80M;

            // Act
            decimal result = _calculator.Percentage(_a.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [Test]
        public void InputNumber_WithPlusMinus() 
        {
            // Arrange
            _a.InputNumber = -80;
            decimal expectedResult = -0.80M;

            // Act
            decimal result = _calculator.Percentage(_a.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void InputNumber_Decimal_NoPlusMinus()
        {
            // Arrange
            _a.InputNumber = 0.80M;
            decimal expectedResult = 0.0080M;

            // Act
            decimal result = _calculator.Percentage(_a.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void InputNumber_Decimal_WithPlusMinus()
        {
            // Arrange
            _a.InputNumber = -0.80M;
            decimal expectedResult = -0.0080M;

            // Act
            decimal result = _calculator.Percentage(_a.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
