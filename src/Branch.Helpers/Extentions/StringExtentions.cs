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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phrase"></param>
		/// <param name="convertFromUpperCamelCase"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		public static string ToSlug(this string phrase, bool convertFromUpperCamelCase = false, int maxLength = 50)
		{
			var str = phrase;

			if (convertFromUpperCamelCase)
			{
				// convert to upper-camel-case to hypenated-case
				str = Regex.Replace(str, @"(\B[A-Z])", "-$1");
			}

			// make string lowercase
			str = str.ToLowerInvariant();

			// invalid chars, make into spaces
			str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

			// convert multiple spaces/hyphens into one space
			str = Regex.Replace(str, @"[\s-]+", " ").Trim();

			// cut and trim it
			str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();

			// hyphens
			str = Regex.Replace(str, @"\s", "-");

			return str;
		}

		public static bool TryParseToEnum<T>(this string value, bool ignoreCase, out T output)
			where T : struct
		{
			// strip and sanitise non-legal enum name chars
			value = Regex.Replace(value, @"[^a-z]+[^a-zA-Z0-9]*", "");

			// conventional TryParse
			return Enum.TryParse<T>(value, ignoreCase, out output);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string MakeCamelCaseFriendly(this string value)
		{
			return Regex.Replace(value, @"(\B[A-Z]+?(?=[A-Z][^A-Z])|\B[A-Z]+?(?=[^A-Z]))", " $1");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <remarks>This is only valid in Halo: Reach.</remarks>
		public static bool MadeByBungie(this string value)
		{
			return (value == "??" || value == "¦");
		}

		/// <summary>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToTitleCase(this string value)
		{
			return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);
		}
	}
}
