using System;
using System.Collections.Generic;
using System.Text;

namespace Fractional.Extentions
{
    internal static class DecimalExtentions
    {
        /// <summary>
        /// Return if the actual decimal is an integer
        /// </summary>
        /// <param name="dec">The decimal value</param>
        /// <returns>A boolean result</returns>
        public static bool IsAnInteger(this decimal dec)
        {
           return Math.Ceiling(dec) == Math.Floor(dec);
        }

        /// <summary>
        /// Pull out the number of decimal places in a decimal value
        /// </summary>
        /// <param name="dec">The decimal valu</param>
        /// <returns>The number of dicimal places</returns>
        public static int GetDecimalPlaces(this decimal dec)
        {
            dec = Math.Abs(dec);
            dec -= Math.Truncate(dec);
            var decimalPlaces = 0;
            while (dec > 0)
            {
                decimalPlaces++;
                dec *= 10;
                dec -= Math.Truncate(dec);
            }

            return decimalPlaces;
        }
    }
}
