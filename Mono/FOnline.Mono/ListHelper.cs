using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FOnline
{
	/// <summary>
	/// Helpers for engine to be able to call IList implementations without hassle
	/// </summary>
	static class ListHelper
	{
		public delegate bool CapacitySetter (IList list, int capacity);

		private static IList<CapacitySetter> capacitySetters = new List<CapacitySetter> ();

		public static void RegisterCapacitySetter (Type type, CapacitySetter capacitySetter)
		{
			capacitySetters.Add (capacitySetter);
		}
		// called by engine
		static void Add (IList list, object o)
		{
			list.Add (o);
		}
		// called by engine
		static int GetSize (IList list)
		{
			return list.Count;
		}
		// called by engine
		static object Get (IList list, int idx)
		{
			List<object> genericList = list as List<object>;
			return list [idx];
		}

		static void SetCapacity (IList list, int capacity)
		{
			foreach (var setter in capacitySetters) {
				if (setter (list, capacity)) {
					break;
				}
			}
		}
	}
}
