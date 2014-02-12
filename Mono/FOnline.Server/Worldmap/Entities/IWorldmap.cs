using System;

namespace FOnline.Worldmap.Entity
{
    public interface IWorldmap
    {
        float GetTravelSpeed (IWorldmapGroup group, uint worldX, uint worldY);

        IWorldmapGroup FindWorldmapGroup (IWorldmapGroup group, uint worldX, uint worldY);

        IEncounter FindEncounter (IWorldmapGroup group, uint worldX, uint worldY);
    }
}

