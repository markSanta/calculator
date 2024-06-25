using Rekenmachine.Components.Model;

namespace CalculatorTests
{
    public class UnitTestSubtraction
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
            _first.InputNumber = 9;
            _second.InputNumber = 23;
            decimal expectedResult = -14;

            // Act
            decimal result = _calculator.CalculateSubtraction(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndNoPlusMinus_SecondInput_NoDecimalsAndPlusMinus()
        {
            // Arange
            _first.InputNumber = 0.09M;
            _second.InputNumber = 23;
            decimal expectedResult = -22.91M;

            // Act
            decimal result = _calculator.CalculateSubtraction(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndPlusMinus_SecondInput_NoDecimalsAndPlusMinus()
        {
            // Arrange
            _first.InputNumber = -0.09M;
            _second.InputNumber = 23;
            decimal expectedResult = -23.09M;

            // Act
            decimal resul = _calculator.CalculateSubtraction(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(resul, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_NoDecimalsAndPlusMinus_SecondInput_Decimals_AndNoPlusMinus()
        {
            // Arange
            _first.InputNumber = 9;
            _second.InputNumber = 0.23M;
            decimal expectedResult = 8.77M;

            // Act
            decimal result = _calculator.CalculateSubtraction(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndPlusMinus_SecondInput_Decimals_AndPlusMinus()
        {
            // Arange
            _first.InputNumber = -0.09M;
            _second.InputNumber = -0.23m;
            decimal expectedResult = 0.14M;

            // Act
            decimal result = _calculator.CalculateSubtraction(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
