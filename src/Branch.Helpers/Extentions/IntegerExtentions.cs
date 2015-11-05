using System;

namespace Branch.Helpers.Extentions
{
	public static class IntegerExtentions
	{
		public static string ToHex(this int value)
		{
			return value.ToString("X");
		}

		public static string Ordinal(this int number)
		{
			var ones = number % 10;
			var tens = Math.Floor(number / 10f) % 10;
			if (Math.Abs(tens - 1) < 0.2)
				return number + "th";

			switch (ones)
			{
				case 1: return number + "st";
				case 2: return number + "nd";
				case 3: return number + "rd";
				default: return number + "th";
			}
		}

		#region [ Convert To Int64 ]

		public static Int64 ToInt64(this int value)
		{
			return Convert.ToInt64(value);
		}

		public static Int64 ToInt64(this uint value)
		{
			return Convert.ToInt64(value);
		}

		public static Int64 ToInt64(this short value)
		{
			return Convert.ToInt64(value);
		}

		public static Int64 ToInt64(this ushort value)
		{
			return Convert.ToInt64(value);
		}

		public static Int64 ToInt64(this ulong value)
		{
			return Convert.ToInt64(value);
		}

		#endregion
	}
}
