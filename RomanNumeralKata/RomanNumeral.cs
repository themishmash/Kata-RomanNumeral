using System;
using System.Collections.Generic;
using System.Linq;

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
        
        private Dictionary<string, int> digitPlaceValues = new Dictionary<string, int>
        {
            {"Ones", 0},
            {"Tens", 0}, 
            {"Hundreds", 0},
            {"Thousands", 0},
        };
        
        

        public string TranslateIntToRomanNumeral(int inputNumber)
        {
            List<string> romanOutput = new List<string>();
            
            SeparatingInputToPlaceValues(inputNumber);

            foreach (var digitPlaceValue in digitPlaceValues)
            {
                romanOutput.Add(SetRomanNumeralForRegularNumbers(digitPlaceValue));
            }

            romanOutput.Reverse();
            var symbolOutput = String.Join("", romanOutput);
            return symbolOutput;
        }
        
        private string SetRomanNumeralForRegularNumbers(KeyValuePair<string, int> numberEntry)
        {
            var midPointSymbol = 5;
            var romanDictionaryKey = "V";
            var unitSymbol = "I";

            if (numberEntry.Key == "Tens")
            {
                midPointSymbol = 50;
                romanDictionaryKey = "L";
                unitSymbol = "X";
            }
            else if (numberEntry.Key == "Hundreds")
            {
                midPointSymbol = 500;
                romanDictionaryKey = "D";
                unitSymbol = "C";
            }
            
            var romanOutput = GenerateRomanOutput(numberEntry, midPointSymbol, romanDictionaryKey, unitSymbol);
            return romanOutput;
        }

        private static string GenerateRomanOutput(KeyValuePair<string, int> numberEntry, int midPointSymbol, string romanDictionaryKey,
            string unitSymbol)
        {
            string romanOutput = "";
            var modulusRemainder = numberEntry.Value % midPointSymbol;
            if (numberEntry.Value > midPointSymbol)
            {
                romanOutput = romanDictionaryKey;
            }

            for (int i = 0; i < modulusRemainder; i++)
            {
                romanOutput += unitSymbol;
            }

            return romanOutput;
        }

        private void SeparatingInputToPlaceValues(int inputNumber)
        {
            int ones = (inputNumber / 1) % 10;
            int tens = (inputNumber / 10) % 10;
            int hundreds = (inputNumber / 100) % 10;
            int thousands = (inputNumber / 1000) % 10;
            digitPlaceValues["Ones"] = ones;
            digitPlaceValues["Tens"] = tens;
            digitPlaceValues["Hundreds"] = hundreds;
            digitPlaceValues["Thousands"] = thousands;
        }

        // public string TranslateIntToRomanNumeral(int inputNumber)
        // {
        //     string romanOutput = "";
        //
        //     if (InputMatchesNumeral(inputNumber))
        //     {
        //         romanOutput = FindRomanNumeralFromInput(inputNumber);
        //         return romanOutput;
        //     }
        //
        //     var digits = ConvertInputToSeparateDigits(inputNumber);
        //
        //     if (digits.Count == 1)
        //     {
        //         romanOutput = CreateUnits(digits);
        //     }
        //
        //     if (digits.Count == 2)
        //     {
        //         romanOutput = $"{CreateTens(digits)}{CreateUnits(digits)}";
        //     }
        //
        //     return romanOutput;
        // }
        //
        //
        // private string CreateUnits(List<int> digits)
        // {
        //     string romanOutput = "";
        //     if (digits[digits.Count - 1] == GetDictionaryValueMinusOne(digits[digits.Count - 1]) - 1)
        //     {
        //         romanOutput = SetRomanNumeralForValueMinusOne(digits[digits.Count - 1]);
        //         return romanOutput;
        //     }
        //     if (digits[digits.Count - 1] < 5)
        //     {
        //         romanOutput = SetRomanNumeralForUnder5(digits[digits.Count - 1]);
        //         return romanOutput;
        //     }
        //     if (digits[digits.Count - 1] > 5 && digits[digits.Count - 1] < 10)
        //     {
        //         romanOutput = SetRomanNumeralBetween5And10(digits[digits.Count - 1]);
        //         return romanOutput;
        //     }
        //
        //     return romanOutput;
        // }
        //
        //
        // private string CreateTens(List<int> digits)
        // {
        //     string romanOutput = ""; //need to add *10 to below to equal 50
        //     if ((digits[digits.Count - 2]) == GetDictionaryValueMinusTen((digits[digits.Count - 2])-10)/10)
        //     {
        //         romanOutput = SetRomanNumeralForValueMinusTen(digits[digits.Count - 2]);
        //         return romanOutput;
        //     }
        //     if (digits[digits.Count - 2] < 5)
        //     {
        //         romanOutput = SetRomanNumeralForUnder50(digits[digits.Count - 2]);
        //         return romanOutput;
        //     }
        //     if (digits[digits.Count - 2] > 5 && digits[digits.Count - 2] < 10)
        //     {
        //         romanOutput = SetRomanNumeralBetween50And100(digits[digits.Count - 2]);
        //         return romanOutput;
        //     }
        //
        //     return romanOutput;
        // }
        //
        // private List<int> ConvertInputToSeparateDigits(int input)
        // {
        //     var lengthOfInput = input.ToString().Length;
        //     List<int> digits = new List<int>();
        //     int units = 0;
        //     int tens = 0;
        //     int hundreds = 0;
        //     int thousands = 0;
        //
        //     if (lengthOfInput == 1)
        //     {
        //         units = input % 10;
        //         digits.Add(units);
        //     }
        //     else if (lengthOfInput == 2)
        //     {
        //         units = input % 10;
        //         tens = ((input - units) / 10) % 10;
        //         digits.Add(tens);
        //         digits.Add(units);
        //     }
        //     else if (lengthOfInput == 3)
        //     {
        //         units = input % 10;
        //         tens = ((input - units) / 10) % 10;
        //         hundreds = ((input - (units + (tens * 10))) / 100) % 10;
        //         digits.Add(hundreds);
        //         digits.Add(tens);
        //         digits.Add(units);
        //     }
        //     return digits;
        // }
        //
        // private static string SetRomanNumeralBetween5And10(int inputNumber)
        // {
        //     string romanOutput = "V";
        //     int modulusRemainder = inputNumber % 5;
        //     for (int i = 0; i < modulusRemainder; i++)
        //     {
        //         romanOutput += "I";
        //     }
        //     return romanOutput;
        // }
        //
        // private static string SetRomanNumeralBetween50And100(int inputNumber)
        // {
        //     string romanOutput = "L";
        //     int modulusRemainder = inputNumber % 50;
        //     for (int i = 0; i < modulusRemainder; i++)
        //     {
        //         romanOutput += "X";
        //     }
        //     return romanOutput;
        // }
        //
        //
        // private static string SetRomanNumeralForUnder5(int inputNumber)
        // {
        //     var modulusRemainder = inputNumber % 5;
        //     string romanOutput = "";
        //     for (int i = 0; i < modulusRemainder; i++)
        //     {
        //         romanOutput += "I";
        //     }
        //     return romanOutput;
        // }
        //
        //
        //
        // private static string SetRomanNumeralForUnder50(int inputNumber)
        // {
        //     var modulusRemainder = inputNumber % 50;
        //     string romanOutput = "";
        //     for (int i = 0; i < modulusRemainder; i++)
        //     {
        //         romanOutput += "X";
        //     }
        //     return romanOutput;
        // }
        //
        // private string SetRomanNumeralForValueMinusOne(int inputNumber)
        // {
        //     foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
        //         
        //         if (inputNumber + 1 == dictionaryEntry.Value)
        //         {
        //             
        //             string romanOutput = "I" + dictionaryEntry.Key; 
        //             return romanOutput;
        //         }
        //
        //     return "";
        // }
        //
        // private int GetDictionaryValueMinusOne(int inputNumber)
        // {
        //     foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
        //         
        //         if (inputNumber == dictionaryEntry.Value - 1)
        //         {
        //             return dictionaryEntry.Value;
        //         }
        //     return 0;
        // }
        //
        // private string SetRomanNumeralForValueMinusTen(int inputNumber)
        // {
        //     int tens = inputNumber * 10;
        //     foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
        //         
        //         if (tens + 10 == dictionaryEntry.Value)
        //        
        //         {
        //             string romanOutput = "X" + dictionaryEntry.Key; 
        //             return romanOutput;
        //         }
        //
        //     return "";
        // }
        //
        // private int GetDictionaryValueMinusTen(int inputNumber)
        // {
        //     int tens = inputNumber * 10;
        //     foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
        //         
        //         if (tens == dictionaryEntry.Value - 10)
        //         {
        //             return dictionaryEntry.Value;
        //         }
        //     return 0;
        // }
        //
        //
        private string FindRomanNumeralFromInput(int inputNumber)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Key;
        }
        //
        // // FINDS MATCHING VALUE FROM THE LIST. IF NO MATCH RETURNS 0. TO BE USED FOR > 10. 
        // public int FindDictionaryValueFromInput(int inputNumber)
        // {
        //     return RomanNumeralDictionary.FirstOrDefault(x => x.Value == inputNumber).Value;
        // }
        //
        //
        // private bool InputMatchesNumeral(int inputNumber)
        // {
        //     return FindRomanNumeralFromInput(inputNumber) != null;
        // }
      
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



