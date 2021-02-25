using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyEats.Business.Helper
{
    public class PostcodeHelper
    {
        public static string ExtractOutcode(string postcode)
        {
            var input = postcode.Replace(" ", "").ToUpper();
            var pattern = @"^(((([A-Z][A-Z]{0,1})[0-9][A-Z0-9]{0,1}) {0,}[0-9])[A-Z]{2})$";
            var match = Regex.Match(input, pattern);
            var result = match.Groups[3].Value;

            return result;
        }
    }
}
