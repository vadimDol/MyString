using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyString.Test
{
    [TestClass]
    public class TestsConstructor
    {
        [TestMethod]
        public void СreateString()
        {
            Str str1 = new Str();
            Assert.IsNotNull(str1);
        }

        [TestMethod]
        public void CanInitializeStrWithString()
        {
            Str str1 = new Str("string1 string2");
            Assert.IsTrue(str1.ToString() == "string1 string2");
        }

        [TestMethod]
        public void CanInitializeStrWithCharArray()
        {
            char[] charArray = "string".ToCharArray();
            Str str2 = new Str(charArray);
            Assert.IsTrue(str2.ToString() == "string");
        }

        [TestMethod]
        public void TestCopyConstructor()
        {
            Str str1 = new Str("str1");
            Str str2 = new Str(str1);
            Assert.IsTrue(str1 == str2);
        }

        [TestMethod]
        public void CanSetTheSizeOfAString()
        {
            int initSize = 10;
            Str str1 = new Str(initSize);
            Assert.IsTrue(str1.Lenght() == initSize);
        }

    }

    [TestClass]
    public class TestsClassMethods
    {
        [TestClass]
        public class FindSymbol
        {
            [TestMethod]
            public void CanFindTheSymbol()
            {
                Str str1 = new Str("testing");
                Assert.IsTrue(str1.FindSymbol('e') == 1);
            }

            [TestMethod]
            public void IfNotFindTheSymbolReturnMinusOne()
            {
                Str str1 = new Str("testing");
                Assert.IsTrue(str1.FindSymbol('v') == -1);
            }
        }

        [TestClass]
        public class Swap
        {
            [TestMethod]
            public void CanSwapValueVariable()
            {
                Str str1 = new Str("word1");
                Str str2 = new Str("word2");
                str2.swap(ref str1);
                Assert.IsTrue(str1.ToString() == "word2");
                Assert.IsTrue(str2.ToString() == "word1");
            }
        }

        [TestClass]
        public class Substr
        {
            [TestMethod]
            public void WithAnIncorrectIndexAnExceptionIsThrown()
            {
                Str str1 = new Str("word1");

                Assert.ThrowsException<System.Exception>(() =>
                {
                    Str newStr = str1.Substr(5, 3);
                });

                Assert.ThrowsException<System.Exception>(() =>
                {
                    Str newStr = str1.Substr(7, 2);
                });

                Assert.ThrowsException<System.Exception>(() =>
                {
                    Str newStr = str1.Substr(-1, 2);
                });

                Assert.ThrowsException<System.Exception>(() =>
                {
                    Str newStr = str1.Substr(-5, 2);
                });

                Assert.ThrowsException<System.Exception>(() =>
                {
                    Str newStr = str1.Substr(7, 8);
                });
            }

            [TestMethod]
            public void WithCorrectDataReturnString ()
            {
                Str str1 = new Str("abcdef");
                Str newStr = str1.Substr(2, 3);
                Assert.IsTrue(newStr.ToString() == "cd");
            }
        }


        [TestClass]
        public class FindWord
        {
            [TestMethod]
            public void IfWordIsFoundReturnPositionOfTheWord()
            {
                Str str1 = new Str("testing");
                Assert.IsTrue(str1.Find("sti") == 2);
            }

            [TestMethod]
            public void IfNotFindTheWordReturnMinusOne()
            {
                Str str1 = new Str("testing");
                Assert.IsTrue(str1.Find("stingf") == -1);
                Assert.IsTrue(str1.Find("testinh") == -1);
            }

            [TestMethod]
            public void LengthOfTheSearchStringIsGreater()
            {
                Str str1 = new Str("testing");
                Assert.IsTrue(str1.Find("testinggg") == -1);
            }
        }
    }

    [TestClass]
    public class TestsOverloadedOperators
    {
        [TestClass]
        public class OpreratorPlus
        {
            [TestMethod]
            public void CanConcatenateStrings()
            {
                Str str1 = new Str("testing");
                Str str2 = new Str(" string");
                Str str3 = str1 + str2;
                Assert.IsTrue(str3.ToString() == "testing string");
            }
        }

        [TestClass]
        public class OpreratorEquality
        {
            [TestMethod]
            public void LengthOfLinesIsDifferent()
            {
                Str str1 = new Str("test");
                Str str2 = new Str("testing");

                Assert.IsTrue(!(str1 == str2));
            }

            [TestMethod]
            public void SameWords()
            {
                Str str1 = new Str("test");
                Str str2 = new Str("test");

                Assert.IsTrue(str1 == str2);
            }

            [TestMethod]
            public void DifferentWords()
            {
                Str str1 = new Str("test");
                Str str2 = new Str("text");

                Assert.IsTrue(!(str1 == str2));
            }
        }

        [TestClass]
        public class OpreratorNotEqual
        {
            [TestMethod]
            public void CanComparedWithTheOperatorNotEqual()
            {
                Str str1 = new Str("test");
                Str str2 = new Str("text");

                Assert.IsTrue(str1 != str2);
            }
        }
    }
}
