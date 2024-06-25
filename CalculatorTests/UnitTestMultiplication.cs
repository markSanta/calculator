using Rekenmachine.Components.Model;

namespace CalculatorTests
{
    public class UnitTestMultiplication
    {
        private Calculator _calculator;
        private NumpadConfiguration _first;
        private NumpadConfiguration _second;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
            _first = new NumpadConfiguration { InputNumber = 0 };
            _second = new NumpadConfiguration { InputNumber = 0 };
        }

        [Test]
        public void FirstInput_SecondInput_Without_Decimals_And_PlusMinus()
        {
            // Arange
            _first.InputNumber = 5;
            _second.InputNumber = 5;
            decimal expectedResult = 25;

            // Act
            decimal result = _calculator.CalculateMultiplication(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndNoPlusMinus_SecondInput_NoDecimalsAndPlusMinus()
        {
            // Arange
            _first.InputNumber = 0.50M;
            _second.InputNumber = 5;
            decimal expectedResult = 2.5M;

            // Act
            decimal result = _calculator.CalculateMultiplication(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndPlusMinus_SecondInput_NoDecimalsAndPlusMinus()
        {
            // Arrange
            _first.InputNumber = -0.50M;
            _second.InputNumber = 5;
            decimal expectedResult = -2.5M;

            // Act
            decimal resul = _calculator.CalculateMultiplication(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(resul, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_NoDecimalsAndPlusMinus_SecondInput_Decimals_AndNoPlusMinus()
        {
            // Arange
            _first.InputNumber = 50;
            _second.InputNumber = 0.05M;
            decimal expectedResult = 2.5M;

            // Act
            decimal result = _calculator.CalculateMultiplication(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndPlusMinus_SecondInput_Decimals_AndPlusMinus()
        {
            // Arange
            _first.InputNumber = -0.50M;
            _second.InputNumber = -0.05m;
            decimal expectedResult = 0.025M;

            // Act
            decimal result = _calculator.CalculateMultiplication(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
