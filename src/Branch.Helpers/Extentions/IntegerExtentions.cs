namespace Branch.Helpers.Extentions
{
	public static class IntegerExtentions
	{
		public static string ToHex(this int value)
		{
			return value.ToString("X");
		}
	}
}
