using System.Globalization;

namespace Rekenmachine.Components.Model
{
    public class NumpadConfiguration
    {
        public decimal InputNumber { get; set; }
        public string InputDecimal { get; set; }
        public string DisplayNumber { get; set; }
        public List<int> DisplayInputNumbers {  get; set; } 
 
        private string plusMinus { get; set; }

        private string concatInputNumber { get; set; }

        public NumpadConfiguration()
        {
            this.InputNumber = 0;
            this.InputDecimal = string.Empty;
            this.DisplayNumber = string.Empty;
            this.DisplayInputNumbers = new List<int>();
            this.plusMinus = string.Empty; 
            this.concatInputNumber = string.Empty;  
        }

        /* Will combine the first and second input numbers into string */
        public void ConcatenateNumbers(int fillDigit, string fillDigitInString, bool isCommaOn)
        {     
            int totalDigitPlaceholderFirst = DisplayInputNumbers.Count; 

            if (isCommaOn && totalDigitPlaceholderFirst < 9)
            {
                // set comma when comma is clicked multiple times
                string firstInputWithComma = this.concatInputNumber.Contains(',') ? "" : ",";

                // concatenate first input number with decimals
                this.InputDecimal += firstInputWithComma + fillDigitInString;
                this.concatInputNumber = $"{this.InputDecimal}";

                // update placeholder of first input number
                this.DisplayNumber = PlaceholderNumber(this.concatInputNumber);
            } 
            else
            {
                // check for first input number if the digits has enough space to store in placeholder
                if (totalDigitPlaceholderFirst < 9 && DisplayInputNumbers.Count < 9)
                {
                    // place the digit of fist input numbers to the placeholder
                    DisplayInputNumbers.Add(fillDigit);
                     
                    // update first input number
                    this.DisplayNumber = PlaceholderNumber(fillDigitInString); 
                } 
            }

            ConvertInputNumberToDecimal(this.DisplayNumber);
        }

        /* The minus sign will be toggled on and off based on for first input number and second input number */
        public string TogglePlusAndMinus(bool isPlusMinusOn, string plusMinusFirstInput)
        {  
            plusMinusFirstInput = isPlusMinusOn ? plusMinusFirstInput += "-" : plusMinusFirstInput += "";

            // overwrite display value
            this.concatInputNumber = isPlusMinusOn ? $"{plusMinusFirstInput}{this.DisplayNumber}" : $"{this.DisplayNumber}";
             
            ConvertInputNumberToDecimal(this.concatInputNumber);

            return this.concatInputNumber;
        }

        private void ConvertInputNumberToDecimal(string firstNumber)
        {
            if (!string.IsNullOrEmpty(firstNumber))
                InputNumber = decimal.Parse(firstNumber);
        }
         
        /* Placeholders of numbers with plus and minus 9 digits and decimals */
        private string PlaceholderNumber(string firstInput)
        {
            string resultFirstInput;

            // Comma is first pressed after the operation (division, multiply, minus and adding)
            if (DisplayInputNumbers.Count == 0)
            {
                resultFirstInput = $"{plusMinus}{firstInput}";
            }
            else // Numpad is first pressed before the operation (division, multiply, minus and adding)
            {
                switch (DisplayInputNumbers.Count - 1)
                {
                    case 0:
                        resultFirstInput = $"{plusMinus}{DisplayInputNumbers[0]}{InputDecimal}";
                        break;
                    case 1:
                        resultFirstInput = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}{InputDecimal}";
                        break;
                    case 2:
                        resultFirstInput = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}{InputDecimal}";
                        break;
                    case 3:
                        resultFirstInput = $"{plusMinus}{DisplayInputNumbers[0]}.{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}{DisplayInputNumbers[3]}{InputDecimal}";
                        break;
                    case 4:
                        resultFirstInput = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}.{DisplayInputNumbers[2]}{DisplayInputNumbers[3]}{DisplayInputNumbers[4]}{InputDecimal}";
                        break;
                    case 5:
                        resultFirstInput = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}.{DisplayInputNumbers[3]}{DisplayInputNumbers[4]}{DisplayInputNumbers[5]}{InputDecimal}";
                        break;
                    case 6:
                        resultFirstInput = $"{plusMinus}{DisplayInputNumbers[0]}.{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}{DisplayInputNumbers[3]}.{DisplayInputNumbers[4]}{DisplayInputNumbers[5]}{DisplayInputNumbers[6]}{InputDecimal}";
                        break;
                    case 7:
                        resultFirstInput = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}.{DisplayInputNumbers[2]}{DisplayInputNumbers[3]}{DisplayInputNumbers[4]}.{DisplayInputNumbers[5]}{DisplayInputNumbers[6]}{DisplayInputNumbers[7]}{InputDecimal}";
                        break;
                    default:
                        resultFirstInput = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}.{DisplayInputNumbers[3]}{DisplayInputNumbers[4]}{DisplayInputNumbers[5]}.{DisplayInputNumbers[6]}{DisplayInputNumbers[7]}{DisplayInputNumbers[8]}{InputDecimal}";
                        break;
                }
            } 
            return resultFirstInput; 
        }


    }
}
