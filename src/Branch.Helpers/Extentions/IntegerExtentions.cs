using System;

namespace Branch.Helpers.Extentions
{
	public static class IntegerExtentions
	{
		public static string ToHex(this int value)
		{
			return value.ToString("X");
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
