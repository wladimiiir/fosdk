using System;
using System.Collections.Generic;

namespace FOnline.Worldmap.Entity
{
    public class Worldmap : IWorldmap
    {
        private readonly IList<Zone> zones = new List<Zone> ();

        public Worldmap ()
        {
        }

        public void AddZone (Zone zone)
        {
            zones.Add (zone);
        }

        float GetTravelSpeed (IWorldmapGroup group, uint worldX, uint worldY)
        {
            return Configuration.WorldmapBaseMapSpeed;
        }

        public IWorldmapGroup FindWorldmapGroup (IWorldmapGroup group, uint worldX, uint worldY)
        {
            return null;
        }

        public IEncounter FindEncounter (IWorldmapGroup group, uint worldX, uint worldY)
        {
            return null;
        }
    }
}

