using Rekenmachine.Components.Model;

namespace CalculatorTests
{
    public class UnitTestAddition
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
            _first.InputNumber = 12;
            _second.InputNumber = 7;
            decimal expectedResult = 19;

            // Act
            decimal result = _calculator.CalculateAddition(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndNoPlusMinus_SecondInput_NoDecimalsAndPlusMinus()
        {
            // Arange
            _first.InputNumber = 0.12M;
            _second.InputNumber = 7;
            decimal expectedResult = 7.12M;

            // Act
            decimal result = _calculator.CalculateAddition(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndPlusMinus_SecondInput_NoDecimalsAndPlusMinus()
        {
            // Arrange
            _first.InputNumber = -0.12M;
            _second.InputNumber = 7;
            decimal expectedResult = 6.88M;

            // Act
            decimal resul = _calculator.CalculateAddition(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(resul, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_NoDecimalsAndPlusMinus_SecondInput_Decimals_AndNoPlusMinus()
        {
            // Arange
            _first.InputNumber = 12;
            _second.InputNumber = 0.07M;
            decimal expectedResult = 12.07M;

            // Act
            decimal result = _calculator.CalculateAddition(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndPlusMinus_SecondInput_Decimals_AndPlusMinus()
        {
            // Arange
            _first.InputNumber = -0.12M;
            _second.InputNumber = -0.07m;
            decimal expectedResult = -0.19M;

            // Act
            decimal result = _calculator.CalculateAddition(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
