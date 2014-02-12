using System;

namespace FOnline.Worldmap.Entity
{
    public class WorldmapLeader : GameType
    {
        internal Critter Critter { get; private set; }

        public WorldmapLeader (Critter critter)
        {
            this.Critter = critter;
        }
    }
}

