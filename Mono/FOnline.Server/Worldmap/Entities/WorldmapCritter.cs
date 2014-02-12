using System;

namespace FOnline.Worldmap.Entity
{
    public class WorldmapCritter
    {
        private readonly Critter critter;

        public WorldmapCritter (Critter critter)
        {
            this.critter = critter;
        }

        public IWorldmapGroup createGroup (Transport transport)
        {

        }
    }
}

