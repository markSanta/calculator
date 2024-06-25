using Rekenmachine.Components.Model;

namespace CalculatorTests
{
    public class UnitTestDivision
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
            _first.InputNumber = 90;
            _second.InputNumber = 12;
            decimal expectedResult = 7.5M;

            // Act
            decimal result = _calculator.CalculateDivision(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult)); 
        }

        [Test]
        public void FirstInput_Decimals_AndNoPlusMinus_SecondInput_NoDecimalsAndPlusMinus()
        {
            // Arange
            _first.InputNumber = 0.90M;
            _second.InputNumber = 12;
            decimal expectedResult = 0.075M;

            // Act
            decimal result = _calculator.CalculateDivision(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndPlusMinus_SecondInput_NoDecimalsAndPlusMinus()
        {
            // Arrange
            _first.InputNumber = -0.90M;
            _second.InputNumber = 12;
            decimal expectedResult = -0.075M;

            // Act
            decimal resul = _calculator.CalculateDivision(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(resul, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_NoDecimalsAndPlusMinus_SecondInput_Decimals_AndNoPlusMinus()
        {
            // Arange
            _first.InputNumber = 90;
            _second.InputNumber = 0.12M;
            decimal expectedResult = 750;

            // Act
            decimal result = _calculator.CalculateDivision(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstInput_Decimals_AndPlusMinus_SecondInput_Decimals_AndPlusMinus()
        {
            // Arange
            _first.InputNumber = -0.90M;
            _second.InputNumber = -0.12m;
            decimal expectedResult = 7.5M;

            // Act
            decimal result = _calculator.CalculateDivision(_first.InputNumber, _second.InputNumber);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        } 
    }
}