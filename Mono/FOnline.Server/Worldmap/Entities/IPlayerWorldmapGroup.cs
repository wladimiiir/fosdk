using System;
using System.Collections.Generic;

namespace FOnline.Worldmap.Entity
{
    public interface IPlayerWorldmapGroup : IWorldmapGroup
    {
        WorldmapLeader GetLeader ();

        IList<WorldmapCritter> GetFollowers ();
    }
}

