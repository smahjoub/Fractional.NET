using System;
using System.Collections.Generic;
using System.Text;

namespace Fractional.Extentions
{
    public static class DecimalExtentions
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
    }
}
