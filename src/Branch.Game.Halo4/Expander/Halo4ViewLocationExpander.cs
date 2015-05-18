using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Razor;

namespace Branch.Game.Halo4.Expander
{
	public class Halo4ViewLocationExpander : IViewLocationExpander
	{
		private const string ValueKey = "language";
		private readonly Func<ActionContext, string> _valueFactory;

		/// <summary>
		/// Initializes a new instance of <see cref="LanguageViewLocationExpander"/>.
		/// </summary>
		/// <param name="valueFactory">A factory that provides tbe language to use for expansion.</param>
		public Halo4ViewLocationExpander(Func<ActionContext, string> valueFactory)
		{
			_valueFactory = valueFactory;
		}
		
		public void PopulateValues(ViewLocationExpanderContext context)
		{
			var value = _valueFactory(context.ActionContext);
			if (!string.IsNullOrEmpty(value))
			{
				context.Values[ValueKey] = value;
			}
		}

		public virtual IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
															   IEnumerable<string> viewLocations)
		{
			string value;
			if (context.Values.TryGetValue(ValueKey, out value))
			{
				return ExpandViewLocationsCore(viewLocations, value);
			}
			return viewLocations;
		}

		private IEnumerable<string> ExpandViewLocationsCore(IEnumerable<string> viewLocations,
															string value)
		{
			foreach (var location in viewLocations)
			{
				yield return location.Replace("{0}", value + "/{0}");
				yield return location;
			}
		}
	}
}