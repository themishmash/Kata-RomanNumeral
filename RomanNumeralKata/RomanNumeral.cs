using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        private static Dictionary<string, int> symbolValues = CreateNumeralsAndValues();
        
        public string TranslateIntToRomanNumeral(int inputNumber)
        {
            string numeralOutput = "";
            int modulusRemainder;
            
            
            //TODO Tricky thing to do: loop through conditionals and not to hardcode the numbers like 5, 10, etc
            if (inputNumber + 1 == 5) //symbolValues[5]
            {
                return setRomanNumeralForOneLessThanSymbol(inputNumber, numeralOutput);
            }
            
            if (inputNumber + 1 == 10)
            {
                return setRomanNumeralForOneLessThanSymbol(inputNumber, numeralOutput);
            }
           
            //TODO put the modulus remainder items etc into its own function
            if (inputNumber < 5)
            {
                modulusRemainder = inputNumber % 5;
                for (int i = 0; i < modulusRemainder; i++)
                {
                    numeralOutput += "I";
                }
                return numeralOutput;
            }
            
            if (inputNumber >= 5 && inputNumber < 10)
            {
                numeralOutput = "V";
                modulusRemainder = inputNumber % 5;
                for (int i = 0; i < modulusRemainder; i++)
                {
                    numeralOutput += "I";
                }

                return numeralOutput;
            }
            
            
            //TODO EASY FUNCTION TO CREATE. Need to reference the key and value again - see setRomanNumeral for guidance
            if (inputNumber == 10)
            {
                return "X";
            }

            return null;
        }

        private static Dictionary<string, int>CreateNumeralsAndValues()
        {
            Dictionary<string, int> numeralValues = new Dictionary<string, int>();
            numeralValues.Add("I", 1);
            numeralValues.Add("V", 5);
            numeralValues.Add("X", 10);
            numeralValues.Add("L", 50);
            numeralValues.Add("C", 100);
            numeralValues.Add("D", 500);
            numeralValues.Add("M", 1000);
            return numeralValues;
        }

        public string setRomanNumeralForOneLessThanSymbol(int inputNumber, string numeralOutput)
        {
            foreach (KeyValuePair<string, int> dictionaryEntry in symbolValues)
                
                if (inputNumber + 1 == dictionaryEntry.Value)
                {
                    numeralOutput = "I" + dictionaryEntry.Key; 
                    return numeralOutput;
                }

            return "";
        }
        public string findRomanNumeralFromValue(int value)
        {
            return symbolValues.FirstOrDefault(x => x.Value == value).Key;
        }
        // public string findValueFromRomanNumeral(string value)
        // {
        // }
    }
}

//If input is 7, this becomes 7 - 5 = 2. 
//Then 5 (V). Maybe variable for number of 'I's. Remainder will be the number of 'I's to add. 

//If input is 4. Then it becomes 4-5 = -1. If the answer is -1 --> add 'I' in front of V.

//If input is 9. Then it becomes 9 - 5 = 4. 

