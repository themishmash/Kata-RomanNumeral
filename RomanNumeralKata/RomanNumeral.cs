using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks.Sources;

namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        private Dictionary<string, decimal>RomanNumeralDictionary 
        = new Dictionary<string, decimal>
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };
        
        public string TranslateIntToRomanNumeral(decimal inputNumber)
        {
            string romanOutput;
            int digit = 1;
            int tens = 10;

            if (InputMatchesNumeral(inputNumber))
            {
                romanOutput = FindRomanNumeralFromInput(inputNumber);
                return romanOutput;
            }
           
            
            if (inputNumber.ToString().Length == 2)
            {
                
                decimal divideNumber = inputNumber / 10;
                var numberArray = divideNumber.ToString().Split(".").ToArray();

                int inputTens = (Convert.ToInt32(numberArray[0])) * 10;
                int inputOnes = Convert.ToInt32(numberArray[1]);
                

                romanOutput = $"{FindRomanNumeralFromInput(inputTens)}{FindRomanNumeralFromInput(inputOnes)}";
                return romanOutput;
            }
             else
             {
                 if (inputNumber == GetDictionaryValueMinusOne(inputNumber) - 1)
                 {
                     romanOutput = SetRomanNumeralForValueMinusOne(inputNumber);
                     return romanOutput;
                 }
                 if (inputNumber < 5)
                 {
                     romanOutput = SetRomanNumeralForUnder5(inputNumber);
                     return romanOutput;
                 }
                 if (inputNumber > 5 && inputNumber < 10)
                 {
                     romanOutput = SetRomanNumeralBetween5And10(inputNumber);
                     return romanOutput;
                 }
             }
            
             romanOutput = FindRomanNumeralFromInput(inputNumber);
            return romanOutput;
        }

        private static string SetRomanNumeralBetween5And10(decimal inputNumber)
        {
            string romanOutput = "V";
            decimal modulusRemainder = inputNumber % 5;
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += "I";
            }
            return romanOutput;
        }

        private static string SetRomanNumeralForUnder5(decimal inputNumber)
        {
            var modulusRemainder = inputNumber % 5;
            string romanOutput = "";
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += "I";
            }
            return romanOutput;
        }

        private string SetRomanNumeralForValueMinusOne(decimal inputNumber)
        {
            foreach (KeyValuePair<string, decimal> dictionaryEntry in RomanNumeralDictionary)
                
                if (inputNumber + 1 == dictionaryEntry.Value)
                {
                    
                    string romanOutput = "I" + dictionaryEntry.Key; 
                    return romanOutput;
                }

            return "";
        }
        
        private decimal GetDictionaryValueMinusOne(decimal inputNumber)
        {
            foreach (KeyValuePair<string, decimal> dictionaryEntry in RomanNumeralDictionary)
                
                if (inputNumber == dictionaryEntry.Value - 1)
                {
                    return dictionaryEntry.Value;
                }
            return 0;
        }


        private string FindRomanNumeralFromInput(decimal inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Key;
        }
        
        // FINDS MATCHING VALUE FROM THE LIST. IF NO MATCH RETURNS 0. TO BE USED FOR > 10. 
        public decimal FindDictionaryValueFromInput(decimal inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Value;
        }


        private bool InputMatchesNumeral(decimal inputNumber)
        {
            return FindRomanNumeralFromInput(inputNumber) != null;
        }
      
        // IMPERATIVE WAY?? DOING THE SAME AS FindRomanNumeralFromValue(). 
        // private string GetRomanNumeralForMatchingInput(int inputNumber)
        // {
        //     foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
        //         
        //         if (inputNumber == dictionaryEntry.Value)
        //         {
        //             return dictionaryEntry.Key;
        //         }
        //     return "";
        // }
    }
}



