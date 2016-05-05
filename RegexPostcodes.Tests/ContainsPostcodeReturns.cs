using NUnit.Framework;

namespace RegexPostcodes.Tests
{
    [TestFixture]
    public class ContainsPostcodeReturns
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
            Assert.That(_postcodeChecker.ContainsPostcode("EC1A 1BB"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("DN55 1PT"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("W1A 1HQ"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("M1 1AA"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("M60 1NW"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("CR2 6XH"), Is.True);
        }

        [Test]
        public void ReturnsTrueWhenFullPostcodeIsEnteredAndOtherWords()
        {
            Assert.That(_postcodeChecker.ContainsPostcode("Pizza EC4M 7RF"), Is.True);
        }

        [Test]
        public void ReturnsFalseWhenNonPostcodeSequencesAreEntered()
        {
            Assert.That(_postcodeChecker.ContainsPostcode("Pizza Kebab Indian"), Is.False);
        }

        [Test]
        public void ReturnsTrueWhenPartialPostcodeIsEntered()
        {
            Assert.That(_postcodeChecker.ContainsPostcode("EC1A"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("DN55"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("W1A"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("M1"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("M60"), Is.True);
            Assert.That(_postcodeChecker.ContainsPostcode("CR2"), Is.True);
        }

        [Test]
        public void ReturnsTrueWhenFullPostcodeWithoutSpacesIsEnteredAndOtherWords()
        {
            Assert.That(_postcodeChecker.ContainsPostcode("Pizza EC1A1BB"), Is.True);
        }

        [Test]
        public void ReturnsTrueWhenFullPostcodeIsEnteredWithoutSpaces()
        {
            Assert.That(_postcodeChecker.ContainsPostcode("EC1A1BB"), Is.True);
        }
    }
}
