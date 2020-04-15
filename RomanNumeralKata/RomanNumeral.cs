using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Channels;

namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        public Dictionary<string, int>RomanNumeralDictionary 
        = new Dictionary<string, int>
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };
        
        public string TranslateIntToRomanNumeral(int inputNumber)
        {
            string romanOutput;
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
            romanOutput = FindRomanNumeralFromInput(inputNumber);
            return romanOutput;
        }

        private static string SetRomanNumeralBetween5And10(int inputNumber)
        {
            string romanOutput = "V";
            int modulusRemainder = inputNumber % 5;
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += "I";
            }
            return romanOutput;
        }

        private static string SetRomanNumeralForUnder5(int inputNumber)
        {
            var modulusRemainder = inputNumber % 5;
            string romanOutput = "";
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += "I";
            }
            return romanOutput;
        }

        private string SetRomanNumeralForValueMinusOne(int inputNumber)
        {
            foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
                
                if (inputNumber + 1 == dictionaryEntry.Value)
                {
                    
                    string romanOutput = "I" + dictionaryEntry.Key; 
                    return romanOutput;
                }

            return "";
        }
        
        private int GetDictionaryValueMinusOne(int inputNumber)
        {
            foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
                
                if (inputNumber == dictionaryEntry.Value - 1)
                {
                    return dictionaryEntry.Value;
                }
            return 0;
        }
        
        
        public string FindRomanNumeralFromInput(int inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Key;
        }
        
        // FINDS MATCHING VALUE FROM THE LIST. IF NO MATCH RETURNS 0. TO BE USED FOR > 10. 
        public int FindDictionaryValueFromInput(int inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Value;
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



