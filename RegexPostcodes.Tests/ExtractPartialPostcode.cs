using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexPostcodes.Tests
{
    [TestFixture]
    public class ExtractPartialPostcode
    {
        PostcodeChecker _postcodeChecker;

        [SetUp]
        public void Setup()
        {
            _postcodeChecker = new PostcodeChecker();
        }

        [Test]
        public void ReturnsTrueWhenFullPostcodeIsEntered()
        {
            // Postcode format examples taken from StackOverflow
            // http://stackoverflow.com/questions/1172097/c-sharp-uk-postcode-splitting
            Assert.That(_postcodeChecker.ExtractPartialPostcode("EC1A1BB"), Is.EqualTo("EC1A"));
            Assert.That(_postcodeChecker.ExtractPartialPostcode("DN551PT"), Is.EqualTo("DN55"));
            Assert.That(_postcodeChecker.ExtractPartialPostcode("W1A1HQ"), Is.EqualTo("W1A"));
            Assert.That(_postcodeChecker.ExtractPartialPostcode("M601NW"), Is.EqualTo("M60"));
            Assert.That(_postcodeChecker.ExtractPartialPostcode("CR26XH"), Is.EqualTo("CR2"));
            Assert.That(_postcodeChecker.ExtractPartialPostcode("M15AN"), Is.EqualTo("M1"));
        }
    }
}
