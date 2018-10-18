using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_day3;

namespace UnitTestProject.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(-255.255, ExpectedResult = "1100002222220001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "010000011110111111111111111111111111111111102220000000000000")]

        public string Insert_AllParamsAreCorrect_ResultingNumberFound(double number)
        {
            var t = new Tasks();
            return t.DoubleToBinaryString(number);
        }

        public void Insert_IncorrectNumber_ExceptionThrown(double number)
        {
            var t = new Tasks();
            Assert.Throws<ArgumentException>(() => t.DoubleToBinaryString(number));
        }

    }
}
