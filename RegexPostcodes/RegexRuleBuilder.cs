using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexPostcodes
{
    public class RegexRuleBuilder
    {
        // Slightly modified regex from Stack overflow
        // Takes into account legal characters and formats for postcodes
        // Does not anchor to the beginning of the string, therefore allowing for
        // postcode extraction:
        // http://stackoverflow.com/questions/23930574/pattern-match-a-partial-british-postcode

        private const string PostBoxException = "([gG][iI][rR] {0,}0[aA]{2})";

        private const string AN_NAATypePostcodeWithNoSpaces =
            "(?<full>([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9][^cikmovCIKMOV]{2}))";

        private const string FirstGroupLabel = "((?<first>";
        private const string FirstGroupAANN = "([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?[abehmnprv-yABEHMNPRV-Y]?)";
        private const string FirstGroupANA = "(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])";
        private const string FirstGroupAANA = "([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y])))";

        private const string SecondGroup = "(?<second> {0,}[0-9][^cikmovCIKMOV]{2})?)";

        public static string PostCodeRegex { get { return BuildPostcode(); } }

        public static string BuildPostcode()
        {
            return @"" + PostBoxException + 
                        "|" + AN_NAATypePostcodeWithNoSpaces +
                        "|" + FirstGroupLabel +
                            FirstGroupAANN +
                            "|" + FirstGroupANA +
                            "|" + FirstGroupAANA
                        + SecondGroup;
        }
    }
}
