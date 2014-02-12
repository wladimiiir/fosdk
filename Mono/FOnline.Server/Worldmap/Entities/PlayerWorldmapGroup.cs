using System;
using System.Collections.Generic;

namespace FOnline.Worldmap.Entity
{
    public class PlayerWorldmapGroup : WorldmapGroup, IPlayerWorldmapGroup
    {
        private readonly WorldmapLeader Leader;
        private readonly TravelDirection Direction;

        public PlayerWorldmapGroup (WorldmapLeader leader, TravelDirection travelDirection, Transport transport) : base (GenerateName (leader), transport)
        {
            Leader = leader;
            TravelDirection = travelDirection;
        }

        private String GenerateName (WorldmapLeader leader)
        {
            return leader.Critter.Name; //TODO: +followers
        }

        public TravelDirection GetTravelDirection ()
        {
            return Direction;
        }

        public WorldmapLeader GetLeader ()
        {
            return Leader;
        }

        public IList<WorldmapCritter> GetCritters ()
        {
            return GetCritters (true);
        }

        public IList<WorldmapCritter> GetFollowers ()
        {
            return GetCritters (false);
        }

        private IList<WorldmapCritter> GetCritters (bool includeLeader)
        {
            var wmGroup = new List<WorldmapCritter> ();
            foreach (var critter in Leader.Critter.GetGlobalGroup()) {
                if (!includeLeader && critter == Leader.Critter)
                    continue;
                wmGroup.Add (new WorldmapCritter (critter));
            }
            return wmGroup;
        }
    }
}

