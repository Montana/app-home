using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

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
			return hexColour.ToCssRgba(1.0);
		}

		public static string ToCssRgba(this string hexColour, double opacity)
		{
			var rgbParts = hexColour.Replace("#", "").SplitEvery(2).ToArray();
			return $"rgba({rgbParts[0].ToDecimal()},{rgbParts[1].ToDecimal()},{rgbParts[2].ToDecimal()},{opacity})";
		}

		public static bool TryParseToEnum<T>(this string value, bool ignoreCase, out T output)
			where T : struct
		{
			// strip and sanitise non-legal enum name chars
			value = Regex.Replace(value, @"[^a-z]+[^a-zA-Z0-9]*", "");

			// conventional TryParse
			return Enum.TryParse<T>(value, ignoreCase, out output);
		}
	}
}
