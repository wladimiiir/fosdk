using System;
using System.Collections.Generic;

namespace FOnline.Worldmap.Entity
{
    public class Encounter : IEncounter
    {
        public Location Location { private set; }

        private readonly IList<IWorldmapGroup> wmGroups = new List<IWorldmapGroup> ();

        public Encounter (Location location)
        {
            this.Location = location;
        }

        Location GetLocation ()
        {
            return Location;
        }

        IList<IWorldmapGroup> GetGroups ()
        {
            return wmGroups;
        }

        void AddGroup (IWorldmapGroup wmGroup)
        {
            wmGroups.Add (wmGroup);
        }

        internal void RemoveGroup (WorldmapGroup wmGroup)
        {
            wmGroups.Remove (wmGroup);
        }
    }
}

