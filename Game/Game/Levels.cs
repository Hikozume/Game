using System;
using System.Collections.Generic;
using System.Drawing;

namespace Game
{
    class Levels
    {
        List<string> BackGroundsDirectory = new List<string> {
            "C:\\Users\\Admin\\Source\\Repos\\Hikozume\\Game\\Game\\Game\\Resources\\StartLock.jpg",
            "C:\\Users\\Admin\\Source\\Repos\\Hikozume\\Game\\Game\\Game\\Resources\\SecondLocation.jpg",
            "C:\\Users\\Admin\\Source\\Repos\\Hikozume\\Game\\Game\\Game\\Resources\\StartLock.jpg"
        };

        List<Units> LevelObjects = new List<Units> {
            new Units(600, Image.FromFile("C:\\Users\\Admin\\Source\\Repos\\Hikozume\\Game\\Game\\Game\\Resources\\Barrel.png"), "Barrel")
        };

        int CurrentIndexLocations = 0;
        int CurrentIndexObjects = 0;

        public Image NextLocation()
        {
            CurrentIndexLocations++;
            return Image.FromFile(BackGroundsDirectory[CurrentIndexLocations - 1]);
        }

        public Units NextoObjects()
        {
            CurrentIndexObjects++;
            return LevelObjects[CurrentIndexObjects - 1];
        }
    }
}
