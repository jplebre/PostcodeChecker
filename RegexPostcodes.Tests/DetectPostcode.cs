﻿using NUnit.Framework;

namespace RegexPostcodes.Tests
{
    [TestFixture]
    public class DetectPostcode
    {
        [Test]
        public void FullPostcodeReturnsPostcodeTypeFull()
        {
            Assert.That(PostcodeChecker.DetectPostcode("EC1A 1BB"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("DN55 1PT"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("W1A 1HQ"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("M1 5AN"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("M60 1NW"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("CR2 6XH"), Is.EqualTo(PostcodeType.Full));
        }

        [Test]
        public void FullPostcodeWithNoSpacesReturnsPostcodeTypeFull()
        {
            Assert.That(PostcodeChecker.DetectPostcode("EC1A1BB"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("DN551PT"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("W1A1HQ"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("M15AN"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("M601NW"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("CR26XH"), Is.EqualTo(PostcodeType.Full));
        }

        [Test]
        public void PartialPostcodeReturnsPostcodeTypePartial()
        {
            Assert.That(PostcodeChecker.DetectPostcode("EC1A"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(PostcodeChecker.DetectPostcode("DN55"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(PostcodeChecker.DetectPostcode("W1A"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(PostcodeChecker.DetectPostcode("M1"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(PostcodeChecker.DetectPostcode("M60"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(PostcodeChecker.DetectPostcode("CR2"), Is.EqualTo(PostcodeType.Partial));
        }

        [Test]
        public void ReturnsCorrectTypeOfPostcodeWhenOtherTextIsEntered()
        {
            Assert.That(PostcodeChecker.DetectPostcode("Pizza EC1A 1BB kebab"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("Pizza EC1A1BB kebab"), Is.EqualTo(PostcodeType.Full));
            Assert.That(PostcodeChecker.DetectPostcode("Pizza EC1A kebab"), Is.EqualTo(PostcodeType.Partial));
            Assert.That(PostcodeChecker.DetectPostcode("Pizza 2GO kebab"), Is.EqualTo(PostcodeType.None));
        }

        [Test]
        public void NoPostcodeReturnsPostcodeTypeNone()
        {
            Assert.That(PostcodeChecker.DetectPostcode("Pizza"), Is.EqualTo(PostcodeType.None));
            Assert.That(PostcodeChecker.DetectPostcode("KFC"), Is.EqualTo(PostcodeType.None));
            Assert.That(PostcodeChecker.DetectPostcode("this is not a postcode 12"), Is.EqualTo(PostcodeType.None));
        }
    }
}
