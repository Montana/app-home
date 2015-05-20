using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Branch.Helpers.Extentions
{
	public static class StringExtentions
	{
		public static string InterruptWithCommas(this string s)
		{
			var val = int.Parse(s);
			return val.ToString("N0");
		}

		public static int ToDecimal(this string s)
		{
			return int.Parse(s, NumberStyles.HexNumber);
		}

		public static IEnumerable<string> SplitEvery(this string s, int partLength)
		{
			for (var i = 0; i < s.Length; i += partLength)
				yield return s.Substring(i, Math.Min(partLength, s.Length - i));
		}

		public static string ToCssRgb(this string hexColour)
		{
			return hexColour.ToCssRgb(1.0);
		}

		public static string ToCssRgb(this string hexColour, double opacity)
		{
			var rgbParts = hexColour.Replace("#", "").SplitEvery(2).ToArray();
			return $"rgba({rgbParts[0].ToDecimal()},{rgbParts[1].ToDecimal()},{rgbParts[2].ToDecimal()},{opacity})";
		}
	}
}
