using System;
using System.Collections.Generic;

namespace FOnline.Worldmap.Entity
{
    public abstract class WorldmapGroup : IWorldmapGroup
    {
        private readonly String Name;
        private readonly Transport Transport;
        private IEncounter CurrentEncounter;

        public WorldmapGroup (String name, Transport transport)
        {
            Name = name;
            Transport = transport;
        }

        public String GetName ()
        {
            return Name;
        }

        public Transport GetTransport ()
        {
            return Transport;
        }

        public IEncounter GetCurrentEncounter ()
        {
            return CurrentEncounter;
        }

        public IEncounter GoToEncounter (IEncounter encounter)
        {
            CurrentEncounter = encounter;
            encounter.AddGroup (this);
        }
    }
}

