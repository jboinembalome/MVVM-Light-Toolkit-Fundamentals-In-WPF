using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WhyMvvm.Helpers
{
    /// <summary>
    /// Creating an extension to convert a URI into an IDictionnary.
    /// </summary>
    public static class UriExtensions
    {
        private static readonly Regex Regex = new Regex(@"[?|&]([\w\.]+)=([^?|^&]+)");

        /// <summary>
        /// Parse URI to IDictionary<string, string>.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static IDictionary<string, string> ParseQueryString(this Uri uri)
        {
            var match = Regex.Match(uri.OriginalString);
            var paramaters = new Dictionary<string, string>();
            while (match.Success)
            {
                paramaters.Add(match.Groups[1].Value, match.Groups[2].Value);
                match = match.NextMatch();
            }
            return paramaters;
        }
    }
}
