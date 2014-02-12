using System;
using System.Collections.Generic;

namespace FOnline.Worldmap.Entity
{
    public interface IEncounter
    {
        Location GetLocation ();

        IList<IWorldmapGroup> GetGroups ();

        void AddGroup (IWorldmapGroup group);
    }
}

