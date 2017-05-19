using System;
using System.Globalization;

namespace AnimalFeedingCalculator.Business.Extensions
{
    public static class DecimalExtension
    {
        public static decimal ToDecimal(this string stringToConvert)
        {
            return Convert.ToDecimal(stringToConvert, CultureInfo.InvariantCulture);
        }
    }
}