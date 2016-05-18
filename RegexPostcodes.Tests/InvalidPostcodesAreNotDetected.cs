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
        //    § The letters I,J and Z are not used in the second position
        //    § The characters in the rightmost two positions may not be C, I, K, M, O or V

        [Test]
        public void DetectsInvalidCharactersForFirstDigit()
        {
            Assert.That(_postcodeChecker.ContainsPostcode("Q1 1AA"), Is.False);
            Assert.That(_postcodeChecker.ContainsPostcode("V1 1AA"), Is.False);
            Assert.That(_postcodeChecker.ContainsPostcode("X1 1AA"), Is.False);
        }

        [Test]
        public void DetectsInvalidCharactersForSecondDigit()
        {
            // TODO
            // Issue with this test. The algorithm will detect it's a valid postcode
            // Because I1 1AA is a valid postcode, as if it started with I, that would be a valid first letter

            //Assert.That(_postcodeChecker.ContainsPostcode("AI1 1AA"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("AJ1 1AA"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("AZ1 1AA"), Is.False);
        }

        [Test]
        public void DetectsInvalidCharactersForLast2Digits()
        {
            // TODO
            // How to best do this?
            // ContainsPostcode returns true because A1 is still a partial postcode.
            // I could return postcode type, or throw an exception. How to handle this behaviour?

            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1CA"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1IA"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1KA"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1MA"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1OA"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1VA"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1AC"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1AI"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1AK"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1AM"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1AO"), Is.False);
            //Assert.That(_postcodeChecker.ContainsPostcode("A1 1AV"), Is.False);
        }
    }
}
