using System;

namespace Branch.Service.Halo4.Exceptions
{
	public class ContentNotFoundException
		: Exception
	{
		public ContentNotFoundException(string message)
			: base(message)
		{ }
	}
}
