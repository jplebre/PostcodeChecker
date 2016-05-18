using NUnit.Framework;

namespace RegexPostcodes.Tests
{
    [TestFixture]
    public class ExtractPostcodeReturns
    {
        PostcodeChecker _postcodeChecker;

        [SetUp]
        public void Setup()
        {
            _postcodeChecker = new PostcodeChecker();
        }

        [Test]
        public void ExtractPostcode()
        {
            Assert.That(_postcodeChecker.ExtractPostcodeFromFreeText("EC1A 1BB"), Is.EqualTo("EC1A 1BB"));
        }

        [Test]
        public void ExtractPostcodeWhenOtherNonPostcodeWordsExist()
        {
            Assert.That(_postcodeChecker.ExtractPostcodeFromFreeText("pizza EC1A 1BB"), Is.EqualTo("EC1A 1BB"));
        }

        [Test]
        public void ExtractPostcodeWhenOtherNonPostcodeWordsExistWithNoSpaces()
        {
            Assert.That(_postcodeChecker.ExtractPostcodeFromFreeText("pizza EC1A1BB"), Is.EqualTo("EC1A1BB"));
        }

        [Test]
        public void ReturnsNullWhenNoPostcodeIsEntered()
        {
            Assert.That(_postcodeChecker.ExtractPostcodeFromFreeText("Indian Kebab Pizza"), Is.Null);
        }

        [Test]
        public void ExtractPartialPostcodeWhenOtherNonPostcodeWordsExist()
        {
            Assert.That(_postcodeChecker.ExtractPostcodeFromFreeText("pizza EC1A"), Is.EqualTo("EC1A"));
        }
    }
}
