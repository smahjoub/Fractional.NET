using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fractional
{
    public static class StringExtentions
    {
        private const string MIXED_FRACTIONAL_PATTERN = @"^(\-?\d+\s+\d+/\d+)?$";

        private const string SIMPLE_FRACTIONAL_PATTERN = @"^(\-?\d+/\d+|\-?\d+)?$";


        /// <summary>
        /// Return if the actual string reprensent a mixed fractional 
        /// </summary>
        /// <param name="fractional">Input fractional string</param>
        /// <returns>A boolean result</returns>
        public static bool IsMixedFractional(this string fractional)
        {
            if(fractional == null)
            {
                throw new ArgumentNullException("The fractional string could not be null");
            }
            return Regex.IsMatch(fractional, MIXED_FRACTIONAL_PATTERN);
        }


        /// <summary>
        /// Return if the actual string reprensent a simple fractional 
        /// </summary>
        /// <param name="fractional">Input fractional string</param>
        /// <returns>A boolean result</returns>
        public static bool IsSimpleFractional(this string fractional)
        {
            if (fractional == null)
            {
                throw new ArgumentNullException("The fractional string could not be null");
            }

            return Regex.IsMatch(fractional, SIMPLE_FRACTIONAL_PATTERN);
        }
    }
}
