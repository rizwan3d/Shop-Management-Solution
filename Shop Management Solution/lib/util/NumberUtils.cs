using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Shop_Management_Solution.lib.util
{
    class NumberUtils
    {
        public static float SafeParse(string input)
        {
            if (String.IsNullOrEmpty(input)) { throw new ArgumentNullException("input"); }

            float res;
            if (Single.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out res))
            {
                return res;
            }

            return 0.0f;
        }

    }
}
