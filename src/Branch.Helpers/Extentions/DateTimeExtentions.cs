using System;

namespace Branch.Helpers.Extentions
{
	public static class DateTimeExtentions
	{
		/// <summary>
		/// Convert a long into a DateTime
		/// </summary>
		public static DateTime FromUnixTime(this Int64 self)
		{
			var ret = new DateTime(1970, 1, 1);
			return ret.AddSeconds(self);
		}
	}
}
