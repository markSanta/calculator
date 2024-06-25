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

        private string collectInputNumber { get; set; }

        public NumpadConfiguration()
        {
            this.InputNumber = 0;
            this.InputDecimal = string.Empty;
            this.DisplayNumber = string.Empty;
            this.DisplayInputNumbers = new List<int>();
            this.plusMinus = string.Empty; 
            this.collectInputNumber = string.Empty;  
        }

        /* Collect the numbers and store it in a string and then convert that string to decimal */
        public void CollectNumber(int fillDigit, string fillDigitInString, bool isCommaOn)
        {     
            int totalDigitPlaceholder = DisplayInputNumbers.Count; 

            // collecting part for decimal
            if (isCommaOn && totalDigitPlaceholder < 9)
            {
                // set 1 comma when comma is clicked multiple times
                string inputWithComma = this.collectInputNumber.Contains(',') ? "" : ",";

                // concatenate input number with decimal
                this.InputDecimal += inputWithComma + fillDigitInString;
                this.collectInputNumber = $"{this.InputDecimal}";

                // update placeholder of input number
                this.DisplayNumber = PlaceholderNumber(this.collectInputNumber);
            }
            else // collecting part for integers
            { 
                if (totalDigitPlaceholder < 9)
                {
                    // storing the integer
                    DisplayInputNumbers.Add(fillDigit);
                     
                    // update display number
                    this.DisplayNumber = PlaceholderNumber(fillDigitInString); 
                } 
            }

            // colleting the numbers complete and stored in a string and convert it to decimal
            ConvertInputNumberToDecimal(this.DisplayNumber);
        }

        /* The plus- & minus-sign will be toggled on and off */
        public string TogglePlusAndMinus(bool isPlusMinusOn)
        {
            // toggle plus- & minus-sign
            plusMinus = isPlusMinusOn ? plusMinus += "-" : plusMinus += "";

            if (this.DisplayNumber.Contains('-'))
            {
                // get the index of plus- and minus-sign
                int indexPlusMinus = this.DisplayNumber.IndexOf('-');
                // remove it from display number
                this.DisplayNumber = this.DisplayNumber.Remove(indexPlusMinus, 1);

                // update the collection of numbers
                this.collectInputNumber = this.DisplayNumber;
            }
            else
            {
                // update the collection of numbers
                this.collectInputNumber = $"{plusMinus}{this.DisplayNumber}";
                // also update display number
                this.DisplayNumber = this.collectInputNumber;
            }
              
            ConvertInputNumberToDecimal(this.collectInputNumber);

            return this.collectInputNumber;
        }

        /* Convert string to decimal */
        private void ConvertInputNumberToDecimal(string inputNumber)
        {
            if (!string.IsNullOrEmpty(inputNumber))
                InputNumber = decimal.Parse(inputNumber);
        }
         
        /* To organize plus- & minus-sign, 9 digits and decimal and to display it */
        private string PlaceholderNumber(string inputNumber)
        {
            string displayResult;

            // comma is first pressed 
            if (DisplayInputNumbers.Count == 0)
            {
                displayResult = $"0{plusMinus}{inputNumber}";
            }
            else // numpad is first pressed 
            {
                switch (DisplayInputNumbers.Count - 1)
                {
                    case 0:
                        displayResult = $"{plusMinus}{DisplayInputNumbers[0]}{InputDecimal}";
                        break;
                    case 1:
                        displayResult = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}{InputDecimal}";
                        break;
                    case 2:
                        displayResult = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}{InputDecimal}";
                        break;
                    case 3:
                        displayResult = $"{plusMinus}{DisplayInputNumbers[0]}.{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}{DisplayInputNumbers[3]}{InputDecimal}";
                        break;
                    case 4:
                        displayResult = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}.{DisplayInputNumbers[2]}{DisplayInputNumbers[3]}{DisplayInputNumbers[4]}{InputDecimal}";
                        break;
                    case 5:
                        displayResult = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}.{DisplayInputNumbers[3]}{DisplayInputNumbers[4]}{DisplayInputNumbers[5]}{InputDecimal}";
                        break;
                    case 6:
                        displayResult = $"{plusMinus}{DisplayInputNumbers[0]}.{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}{DisplayInputNumbers[3]}.{DisplayInputNumbers[4]}{DisplayInputNumbers[5]}{DisplayInputNumbers[6]}{InputDecimal}";
                        break;
                    case 7:
                        displayResult = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}.{DisplayInputNumbers[2]}{DisplayInputNumbers[3]}{DisplayInputNumbers[4]}.{DisplayInputNumbers[5]}{DisplayInputNumbers[6]}{DisplayInputNumbers[7]}{InputDecimal}";
                        break;
                    default:
                        displayResult = $"{plusMinus}{DisplayInputNumbers[0]}{DisplayInputNumbers[1]}{DisplayInputNumbers[2]}.{DisplayInputNumbers[3]}{DisplayInputNumbers[4]}{DisplayInputNumbers[5]}.{DisplayInputNumbers[6]}{DisplayInputNumbers[7]}{DisplayInputNumbers[8]}{InputDecimal}";
                        break;
                }
            } 
            return displayResult; 
        } 
    }
}
