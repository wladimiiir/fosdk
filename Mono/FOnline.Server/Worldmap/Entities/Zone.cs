using System;
using System.Collections.Generic;

namespace FOnline
{
	public class Zone
	{
		private readonly IList<WorldmapGroup> groups = new List<WorldmapGroup>();
		private readonly IList<Encounter> encounters = new List<Encounter>();

		public Zone()
		{
		}

		void AddGroup(WorldmapGroup group)
		{
			groups.Add(group);
		}

		void RemoveGroup(WorldmapGroup group)
		{
			groups.Remove(group);
		}
	}
}

