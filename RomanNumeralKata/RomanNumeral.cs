using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        private static Dictionary<string, int> symbolValues = CreateNumeralsAndValues();
        public string TranslateIntToRomanNumeral(int number)
        {
            string numeralOutput = "";
            int modulusRemainder;
            
            var symbol = findRomanNumeralFromValue(5);
            
            // Set up symbol and values data structure. Then change IV and IX conditionals to be a resuable method. 
            
            if (number + 1 == 5)
            {
                numeralOutput = "IV";
                return numeralOutput;
            }
            
            if (number + 1 == 10)
            {
                numeralOutput = "IX";
                return numeralOutput;
            }
           
            
            if (number < 5)
            {
                modulusRemainder = number % 5;
                for (int i = 0; i < modulusRemainder; i++)
                {
                    numeralOutput += "I";
                }
                return numeralOutput;
            }
            
            if (number >= 5 && number < 10)
            {
                numeralOutput = "V";
                modulusRemainder = number % 5;
                for (int i = 0; i < modulusRemainder; i++)
                {
                    numeralOutput += "I";
                }

                return numeralOutput;
            }
            
            
            if (number == 10)
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

