using System;
using System.Collections.Generic;
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
            string romanOutput = "";
            int modulusRemainder;
            
            
            //TODO Tricky thing to do: loop through conditionals and not to hardcode the numbers like 5, 10, etc

           
            if (inputNumber + 1 == findMatchingRomanNumeral(inputNumber)) //symbolValues[5]
            {
                return setRomanNumeralForOneLessThanSymbol(inputNumber);
                
            }
            
            
            
            // if (inputNumber + 1 == 5) //symbolValues[5]
            // {
            //     return setRomanNumeralForOneLessThanSymbol(inputNumber);
            // }
            
            // if (inputNumber + 1 == 10)
            // {
            //     return setRomanNumeralForOneLessThanSymbol(inputNumber);
            // }
           
            //TODO put the modulus remainder items etc into its own function
            if (inputNumber < 5 && inputNumber + 1 != findMatchingRomanNumeral(inputNumber))
            {
                modulusRemainder = inputNumber % 5;
                for (int i = 0; i < modulusRemainder; i++)
                {
                    romanOutput += "I";
                }
                return romanOutput;
            }
            
            if (inputNumber >= 5 && inputNumber < 10)
            {
                romanOutput = "V";
                modulusRemainder = inputNumber % 5;
                for (int i = 0; i < modulusRemainder; i++)
                {
                    romanOutput += "I";
                }

                return romanOutput;
            }
            
            
            romanOutput = checkIfInputNumberMatchesRomanNumeral(inputNumber);

            return romanOutput;
        }

       

        public string setRomanNumeralForOneLessThanSymbol(int inputNumber)
        {
            foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
                
                if (inputNumber + 1 == dictionaryEntry.Value)
                {
                    
                    string romanOutput = "I" + dictionaryEntry.Key; 
                    return romanOutput;
                }

            return "";
        }

        // public string findMatchingInputNumberForOneLessThanSymbol()
        // {
        //     
        // }
        
        

        public string checkIfInputNumberMatchesRomanNumeral(int inputNumber)
        {
            foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
                
                if (inputNumber == dictionaryEntry.Value)
                {
                    return dictionaryEntry.Key;
                }
            return "";
        }

        public int findMatchingRomanNumeral(int inputNumber)
        {
            foreach (KeyValuePair<string, int> dictionaryEntry in RomanNumeralDictionary)
                
                if (inputNumber == dictionaryEntry.Value)
                {
                    return dictionaryEntry.Value;
                }
            return 0;
        }
        
        
      
       
        
        
        
        
        
        //Maybe can delete this later on
        public string findRomanNumeralFromValue(int value)
        {
            return RomanNumeralDictionary.FirstOrDefault(x => x.Value == value).Key;
        }
      
    }
}



