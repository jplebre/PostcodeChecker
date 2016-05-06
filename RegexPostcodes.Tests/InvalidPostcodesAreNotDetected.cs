using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexPostcodes.Tests
{
    [TestFixture]
    public class InvalidPostcodesAreNotDetected
    {
        PostcodeChecker _postcodeChecker;

        [SetUp]
        public void Setup()
        {
            _postcodeChecker = new PostcodeChecker();
        }

        //    UK postcodes must be in one of the following forms(with one exception, see below): 
        //    § A9 9AA 
        //    § A99 9AA
        //    § AA9 9AA
        //    § AA99 9AA
        //    § A9A 9AA
        //    § AA9A 9AA
        //
        //    where A represents an alphabetic character and 9 represents a numeric character.

        //    Additional rules apply to alphabetic characters, as follows:
        //    § The character in position 1 may not be Q, V or X
        //    § The character in position 2 may not be I, J or Z
        //    § The character in position 3 may not be I, L, M, N, O, P, Q, R, V, X, Y or Z
        //    § The character in position 4 may not be C, D, F, G, I, J, K, L, O, Q, S, T, U or Z
        //    § The characters in the rightmost two positions may not be C, I, K, M, O or V
        //    The one exception that does not follow these general rules is the postcode "GIR 0AA", which is a special valid postcode.

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }
    }
}
