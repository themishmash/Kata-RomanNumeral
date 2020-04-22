using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks.Sources;

// SERIOUS REFACTOR NEEDED TO AVOID DRY. EDGE CASES FOR 40 > ARE NOT WORKING. CHECK LOGIC IN THE TENS TO SEE WHY THIS IS HAPPENING. 

namespace RomanNumeralKata
{
    public class RomanNumeral
    {
        private Dictionary<string, int>RomanNumeralDictionary 
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
            string romanOutput = "";

            if (InputMatchesNumeral(inputNumber))
            {
                romanOutput = FindRomanNumeralFromInput(inputNumber);
                return romanOutput;
            }

            var digits = ConvertInputToSeparateDigits(inputNumber);
            
            return romanOutput;
        }


        private string CreateUnits(List<int> digits)
        {
            string romanOutput = "";
            if (digits[digits.Count - 1] == GetDictionaryValueMinusOne(digits[digits.Count - 1]) - 1)
            {
                romanOutput = SetRomanNumeralForValueMinusOne(digits[digits.Count - 1]);
                return romanOutput;
            }
            if (digits[digits.Count - 1] < 5)
            {
                romanOutput = SetRomanNumeralForUnder5(digits[digits.Count - 1]);
                return romanOutput;
            }
            if (digits[digits.Count - 1] > 5 && digits[digits.Count - 1] < 10)
            {
                romanOutput = SetRomanNumeralBetween5And10(digits[digits.Count - 1]);
                return romanOutput;
            }

            return romanOutput;
        }
        
        
        private string CreateTens(List<int> digits)
        {
            string romanOutput = ""; //need to add *10 to below to equal 50
            if ((digits[digits.Count - 2]) == GetDictionaryValueMinusTen((digits[digits.Count - 2])-10)/10)
            {
                romanOutput = SetRomanNumeralForValueMinusTen(digits[digits.Count - 2]);
                return romanOutput;
            }
            if (digits[digits.Count - 2] < 5)
            {
                romanOutput = SetRomanNumeralForUnder50(digits[digits.Count - 2]);
                return romanOutput;
            }
            if (digits[digits.Count - 2] > 5 && digits[digits.Count - 2] < 10)
            {
                romanOutput = SetRomanNumeralBetween50And100(digits[digits.Count - 2]);
                return romanOutput;
            }

            return romanOutput;
        }
        
        private Dictionary<string, int> ConvertInputToSeparateDigits(int input)
        {
            Dictionary<string, int> digitPlaceValues = new Dictionary<string, int>
            {
                {"Ones", 0},
                {"Tens", 0},
                {"Hundreds", 0},
                {"Thousands", 0},
            };
            var lengthOfInput = input.ToString().Length;

            int units = (input / 1) % 10;
            int tens = (input / 10) % 10;
            int hundreds = (input / 100) % 10;
            int thousands = (input / 1000) % 10;
           
            digitPlaceValues["Ones"] = units;
            digitPlaceValues["Tens"] = tens;
            digitPlaceValues["Hundreds"] = hundreds;
            digitPlaceValues["Thousands"] = thousands;
            
            return digitPlaceValues;
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
        
        private static string SetRomanNumeralBetween50And100(int inputNumber)
        {
            string romanOutput = "L";
            int modulusRemainder = inputNumber % 50;
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += "X";
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
        
       

        private static string SetRomanNumeralForUnder50(int inputNumber)
        {
            var modulusRemainder = inputNumber % 50;
            string romanOutput = "";
            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += "X";
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
        
        private string SetRomanNumeralForValueMinusTen(int inputNumber)
        {
            int tens = inputNumber * 10;
            foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
                
                if (tens + 10 == dictionaryEntry.Value)
               
                {
                    string romanOutput = "X" + dictionaryEntry.Key; 
                    return romanOutput;
                }

            return "";
        }
        
        private int GetDictionaryValueMinusTen(int inputNumber)
        {
            int tens = inputNumber * 10;
            foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
                
                if (tens == dictionaryEntry.Value - 10)
                {
                    return dictionaryEntry.Value;
                }
            return 0;
        }


        private string FindRomanNumeralFromInput(int inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Key;
        }
        
        // FINDS MATCHING VALUE FROM THE LIST. IF NO MATCH RETURNS 0. TO BE USED FOR > 10. 
        public int FindDictionaryValueFromInput(int inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Value;
        }


        private bool InputMatchesNumeral(int inputNumber)
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



