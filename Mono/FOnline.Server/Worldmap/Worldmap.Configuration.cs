using System;

namespace FOnline.Worldmap
{
    public class Configuration
    {
        public static uint WorldmapProcessInterval = Time.RealSecond (10);
        public static float WorldmapBaseMapSpeed = 5f;

        public static void ReadConfigFile (string configFile)
        {
            //TODO: read from config file
        }
    }
}

