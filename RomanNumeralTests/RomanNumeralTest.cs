using NUnit.Framework;
using RomanNumeralKata;

namespace RomanNumeralTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        // [Test]
        // public void RomanNumeral_input1_returnsRomanNumeral_I()
        // {
        //     //Given (class we need to create)
        //     RomanNumeral romanNumeral = new RomanNumeral();
        //
        //     //When
        //     string result = romanNumeral.TranslateIntToRomanNumeral(1);
        //
        //     //Then
        //     Assert.AreEqual("I", result);
        // }
        //
        // [Test]
        // public void RomanNumeral_input1_returnsRomanNumeral_II()
        // {
        //     //Given (class we need to create)
        //     RomanNumeral romanNumeral = new RomanNumeral();
        //
        //     //When
        //     string result = romanNumeral.TranslateIntToRomanNumeral(2);
        //
        //     //Then
        //     Assert.AreEqual("II", result);
        // }
        
        [Test]
        public void RomanNumeral_input_1_2_3_returnsRomanNumeral_I_II_III()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();
            

            //Then
            Assert.AreEqual("I", romanNumeral.TranslateIntToRomanNumeral(1));
            Assert.AreEqual("II", romanNumeral.TranslateIntToRomanNumeral(2));
            Assert.AreEqual("III", romanNumeral.TranslateIntToRomanNumeral(3));
        }
        
        [Test]
        public void RomanNumeral_input_4_returnsRomanNumeral_IV()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();

            //When
            //string result = romanNumeral.TranslateIntToRomanNumeral(1);

            //Then
            Assert.AreEqual("IV", romanNumeral.TranslateIntToRomanNumeral(4));
           
        }
        
        [Test]
        public void RomanNumeral_Input_5_returns_V()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            // When
            string result = romanNumeral.TranslateIntToRomanNumeral(5);
            // Then
            Assert.AreEqual("V", result);
        }
        
        [Test]
        public void RomanNumeral_input_6_7_8_returnsRomanNumeral_VI_VII_VIII()
        {
            //Given (class we need to create)
            RomanNumeral romanNumeral = new RomanNumeral();
            

            //Then
            Assert.AreEqual("VI", romanNumeral.TranslateIntToRomanNumeral(6));
            Assert.AreEqual("VII", romanNumeral.TranslateIntToRomanNumeral(7));
            Assert.AreEqual("VIII", romanNumeral.TranslateIntToRomanNumeral(8));
        }
        
        [Test]
        public void RomanNumeral_Input_10_returns_X()
        {
            // Given
            RomanNumeral romanNumeral = new RomanNumeral();
            // When
            string result = romanNumeral.TranslateIntToRomanNumeral(10);
            // Then
            Assert.AreEqual("X", result);
        }
    }
}