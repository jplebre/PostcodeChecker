using System;
using System.Text.RegularExpressions;

namespace RegexPostcodes
{
    public class PostcodeChecker
    {
        // Slightly modified regex from Stack overflow
        // Takes into account legal characters and formats for postcodes
        // Does not anchor to the beginning of the string, therefore allowing for
        // postcode extraction:
        // http://stackoverflow.com/questions/23930574/pattern-match-a-partial-british-postcode
        const string postcodeRegex =
            @"([gG][iI][rR] {0,}0[aA]{2})|(?<full>([a-pr-uwyzA-PR-UWYZ][a-pr-uwyzA-PR-UWYZ]?[0-9][0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))|((?<first>([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?[abehmnprv-yABEHMNPRV-Y]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y])))(?<second> {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2})?)";

        public bool ContainsPostcode(string freeText)
        {
            Match match = PostcodeMatch(freeText);

            if (match.Success)
                return true;

            return false;
        }

        private static Match PostcodeMatch(string freeText)
        {
            var regex = new Regex(postcodeRegex);
            var match = regex.Match(freeText);
            return match;
        }


        public string ExtractPostcode(string freeText)
        {
            var match = PostcodeMatch(freeText);
            return match.Success ? match.Value : null;
        }


        public static void Main(string[] args)
        {
            // So the compiler doesn't complain
            Console.WriteLine("Stuff!");
        }

        public static PostcodeType DetectPostcode(string postcode)
        {
            var match = PostcodeMatch(postcode);
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
    }
}
