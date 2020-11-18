using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestHomework
{
    [TestClass]
    public class StringTest
    {
        private const string numbers = "0123456789";
        private const string text = "AS As aS as";


        [TestMethod]
        public void SubstringStart()
        {
            Assert.AreEqual(numbers.Substring(0), "0123456789");
            Assert.AreEqual(numbers.Substring(5), "56789");
            Assert.AreEqual(numbers.Substring(9), "9");
            Assert.AreEqual(numbers.Substring(10), "");
        }

        [TestMethod]
        public void SubstringStartException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => numbers.Substring(-2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => numbers.Substring(11));
        }

        [TestMethod]
        public void SubstringStartLength()
        {
            Assert.AreEqual(numbers.Substring(0, 10), "0123456789");
            Assert.AreEqual(numbers.Substring(0, 5), "01234");
            Assert.AreEqual(numbers.Substring(5, 5), "56789");
            Assert.AreEqual(numbers.Substring(0, 0), "");
        }

        [TestMethod]
        public void SubstringStartLengthException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => numbers.Substring(5, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => numbers.Substring(-5, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => numbers.Substring(5, -5));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => numbers.Substring(-5, -5));
        }

        [TestMethod]
        public void ReplaceChar()
        {
            Assert.AreEqual(numbers.Replace('0', 'a'), "a123456789");
            Assert.AreEqual(text.Replace('a', 'Z'), "AS As ZS Zs");
        }

        [TestMethod]
        public void ReplaceString()
        {
            Assert.AreEqual(numbers.Replace("0", "a"), "a123456789");
            Assert.AreEqual(numbers.Replace("0123", "qwerty"), "qwerty456789");
            Assert.AreEqual(numbers.Replace("0123", ""), "456789");
            Assert.AreEqual(numbers.Replace("0123", null), "456789");
        }

        [TestMethod]
        public void ReplaceStringException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => numbers.Replace(null, "1"));
            Assert.ThrowsException<ArgumentException>(() => numbers.Replace("", null));
        }

        [TestMethod]
        public void ReplaceStringComparison()
        {
            Assert.AreEqual(text.Replace("as", "XZ", StringComparison.CurrentCulture), "AS As aS XZ");
            Assert.AreEqual(text.Replace("as", "XZ", StringComparison.CurrentCultureIgnoreCase), "XZ XZ XZ XZ");

            Assert.AreEqual(text.Replace("as", "XZ", StringComparison.InvariantCulture), "AS As aS XZ");
            Assert.AreEqual(text.Replace("as", "XZ", StringComparison.InvariantCultureIgnoreCase), "XZ XZ XZ XZ");

            Assert.AreEqual(text.Replace("as", "XZ", StringComparison.Ordinal), "AS As aS XZ");
            Assert.AreEqual(text.Replace("as", "XZ", StringComparison.OrdinalIgnoreCase), "XZ XZ XZ XZ");
        }

        [TestMethod]
        public void SplitChar()
        {
            CollectionAssert.AreEqual("".Split(' '), new[] {""});
            CollectionAssert.AreEqual(" ".Split(' '), new[] {"", ""});
            CollectionAssert.AreEqual(text.Split('z'), new[] {"AS As aS as"});
            CollectionAssert.AreEqual(text.Split(null), new[] {"AS", "As", "aS", "as"});
            CollectionAssert.AreEqual(text.Split(' '), new[] {"AS", "As", "aS", "as"});
            CollectionAssert.AreEqual(text.Split(' '), new[] {"AS", "As", "aS", "as"});
        }

        [TestMethod]
        public void SplitCharArray()
        {
            CollectionAssert.AreEqual(text.Split(' ', 's'), new[] {"AS", "A", "", "aS", "a", ""});
        }

        [TestMethod]
        public void SplitString()
        {
            CollectionAssert.AreEqual(text.Split(), new[] {"AS", "As", "aS", "as"});
            CollectionAssert.AreEqual(text.Split("zz"), new[] {"AS As aS as"});
            CollectionAssert.AreEqual(text.Split("s "), new[] {"AS A", "aS as"});
        }

        [TestMethod]
        public void SplitCount()
        {
            CollectionAssert.AreEqual(text.Split(' ', 3), new[] {"AS", "As", "aS as"});
            CollectionAssert.AreEqual(text.Split(new[] {' ', 's'}, 3), new[] {"AS", "A", " aS as"});
            CollectionAssert.AreEqual(text.Split(" a", 2), new[] {"AS As", "S as"});
        }

        [TestMethod]
        public void SplitOption()
        {
            CollectionAssert.AreEqual(text.Split('A', StringSplitOptions.RemoveEmptyEntries), new[] {"S ", "s aS as"});
            CollectionAssert.AreEqual(text.Split(new[] {' ', 's'}, StringSplitOptions.RemoveEmptyEntries),
                new[] {"AS", "A", "aS", "a"});
        }

        [TestMethod]
        public void SplitException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => text.Split('a', -1));
            Assert.ThrowsException<ArgumentException>(() => text.Split('a', (StringSplitOptions) 100));
        }
    }
}