namespace Rekenmachine.Components.Model
{
    public class Calculator
    {
        public Calculator()
        {
                
        }

        /* Calculate the percentage of the number */
        public decimal Percentage(decimal a)
        {
            return a / 100;
        }

        public decimal CalculateDivision(decimal a, decimal b)
        {
            return a / b;
        }

        public decimal CalculateMultiplication(decimal a, decimal b)
        {
            return a * b;
        }

        public decimal CalculateSubtraction(decimal a, decimal b)
        {
            return a - b;
        }

        public decimal CalculateAddition(decimal a, decimal b)
        {
            return a + b;
        }
    }
}
