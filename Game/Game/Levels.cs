using System;
using System.Collections.Generic;
using System.Drawing;

namespace Game
{
    class Levels
    {
        List<Image> BackGroundsDirectory = new List<Image> {
            (Image)Properties.Resources.ResourceManager.GetObject("StartLock.jpg"),
            (Image)Properties.Resources.ResourceManager.GetObject("SecondLocation.jpg"),
            (Image)Properties.Resources.ResourceManager.GetObject("StartLock.jpg")
        };

        List<Units> LevelObjects = new List<Units> {
            new Units(600, (Image)Properties.Resources.ResourceManager.GetObject("Barrel.png"), "Barrel")
        };

        int CurrentIndexLocations = 0;
        int CurrentIndexObjects = 0;

        public Image NextLocation()
        {
            CurrentIndexLocations++;
            return (BackGroundsDirectory[CurrentIndexLocations - 1]);
        }

        public Units NextoObjects()
        {
            CurrentIndexObjects++;
            return LevelObjects[CurrentIndexObjects - 1];
        }
    }
}
