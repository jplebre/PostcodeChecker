using NUnit.Framework;

namespace RegexPostcodes.Tests
{
    [TestFixture]
    public class DetectPostcode
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
        //    The one exception that does not follow these general rules is the postcode "GIR 0AA", which is a special valid postcode.

        [Test]
        public void FullPostcodeReturnsPostcodeTypeFull()
        {
            Assert.That(_postcodeChecker.DetectPostcodeType("EC1A 1BB"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("DN55 1PT"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("W1A 1HQ"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("M1 5AN"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("M60 1NW"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("CR2 6XH"), Is.EqualTo(PostcodeType.Full));
        }

        [Test]
        public void FullPostcodeWithNoSpacesReturnsPostcodeTypeFull()
        {
            Assert.That(_postcodeChecker.DetectPostcodeType("EC1A1BB"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("DN551PT"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("W1A1HQ"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("M15AN"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("M601NW"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("CR26XH"), Is.EqualTo(PostcodeType.Full));
        }

        [Test]
        public void PartialPostcodeReturnsPostcodeTypePartial()
        {
            Assert.That(_postcodeChecker.DetectPostcodeType("EC1A"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(_postcodeChecker.DetectPostcodeType("DN55"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(_postcodeChecker.DetectPostcodeType("W1A"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(_postcodeChecker.DetectPostcodeType("M1"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(_postcodeChecker.DetectPostcodeType("M60"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(_postcodeChecker.DetectPostcodeType("CR2"), Is.EqualTo(PostcodeType.Partial));
        }

        [Test]
        public void ReturnsCorrectTypeOfPostcodeWhenOtherTextIsEntered()
        {
            Assert.That(_postcodeChecker.DetectPostcodeType("Pizza EC1A 1BB kebab"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("Pizza EC1A1BB kebab"), Is.EqualTo(PostcodeType.Full));
            Assert.That(_postcodeChecker.DetectPostcodeType("Pizza EC1A kebab"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(_postcodeChecker.DetectPostcodeType("Pizza 2GO kebab"), Is.EqualTo(PostcodeType.None));
        }

        [Test]
        public void NoPostcodeReturnsPostcodeTypeNone()
        {
            Assert.That(_postcodeChecker.DetectPostcodeType("Pizza"), Is.EqualTo(PostcodeType.None));
            Assert.That(_postcodeChecker.DetectPostcodeType("KFC"), Is.EqualTo(PostcodeType.None));
            Assert.That(_postcodeChecker.DetectPostcodeType("this is not a postcode 12"), Is.EqualTo(PostcodeType.None));
        }
    }
}
