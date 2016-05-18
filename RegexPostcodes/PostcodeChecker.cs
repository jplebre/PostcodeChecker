using System;
using System.Text.RegularExpressions;

namespace RegexPostcodes
{
    public class PostcodeChecker
    {
        string _postcodeRegex = RegexRuleBuilder.PostCodeRegex;

        internal string PostcodeRegex
        {
            get
            {
                return _postcodeRegex;
            }
        }

        public bool ContainsPostcode(string freeText)
        {
            Match match = PostcodeMatch(freeText);
            return match.Success ? true : false;
        }

        public string ExtractPostcodeFromFreeText(string freeText)
        {
            Match match = PostcodeMatch(freeText);
            return match.Success ? match.Value : null;
        }

        public string ExtractPartialPostcode(string postcode)
        {
            if (DetectPostcodeType(postcode) == PostcodeType.Full)
                return postcode.Substring(0, postcode.Length - 3).TrimEnd();
            else return "";
        }

        public PostcodeType DetectPostcodeType(string postcode)
        {
            Match match = PostcodeMatch(postcode);

            if (!match.Success)
            {
                return PostcodeType.None;
            }

            if (!string.IsNullOrEmpty(match.Groups["full"].Value))
            {
                return PostcodeType.Full;
            }

            if (string.IsNullOrEmpty(match.Groups["second"].Value))
            {
                return PostcodeType.Partial;
            }

            return PostcodeType.Full;
        }

        private Match PostcodeMatch(string freeText)
        {
            var regex = new Regex(PostcodeRegex);
            Match match = regex.Match(freeText);

            return match;
        }
    }
}
