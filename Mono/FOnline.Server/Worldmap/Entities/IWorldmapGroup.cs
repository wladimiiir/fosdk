using System;
using System.Collections.Generic;

namespace FOnline.Worldmap.Entity
{
    public interface IWorldmapGroup
    {
        String GetName ();

        TravelDirection GetTravelDirection ();

        Transport GetTransport ();

        IList<WorldmapCritter> GetCritters ();

        IEncounter GetCurrentEncounter ();

        IEncounter GoToEncounter (IEncounter encounter);
    }
}

