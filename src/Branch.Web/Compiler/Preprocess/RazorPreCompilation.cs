using System;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Compiler.Preprocess
{
	public class RazorPreCompilation : RazorPreCompileModule
	{
		public RazorPreCompilation(IServiceProvider provider) : base(provider)
		{
			GenerateSymbols = true;
		}
	}
}
