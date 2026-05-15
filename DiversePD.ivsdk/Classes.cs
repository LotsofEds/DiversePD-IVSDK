using IVSDKDotNet.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiversePD.ivsdk
{

    public class WantedLevelData
    {
        public int timeToSpawn;
        public List<string> vehModels = new List<string>();
        public List<string> driverModels = new List<string>();
        public List<string> passengers1 = new List<string>();
        public List<string> passengers2 = new List<string>();
        public List<string> passengers3 = new List<string>();
        public List<eWeaponType> driverWeap = new List<eWeaponType>();
        public List<eWeaponType> pass1Weap = new List<eWeaponType>();
        public List<eWeaponType> pass2Weap = new List<eWeaponType>();
        public List<eWeaponType> pass3Weap = new List<eWeaponType>();

        public WantedLevelData()
        {
        }
    }

    public class PedData
    {
        public readonly string ModelName;

        public List<int> CompSpawnType = new List<int>();
        public List<int> PropSpawnType = new List<int>();

        public List<int> CompIDs = new List<int>();
        public List<int> CompMdls = new List<int>();
        public List<int> CompTxds = new List<int>();

        public List<int> PropIDs = new List<int>();
        public List<int> PropMdls = new List<int>();

        public List<int> RainCompSpawnType = new List<int>();
        public List<int> RainPropSpawnType = new List<int>();

        public List<int> RainCompIDs = new List<int>();
        public List<int> RainCompMdls = new List<int>();
        public List<int> RainCompTxds = new List<int>();

        public List<int> RainPropIDs = new List<int>();
        public List<int> RainPropMdls = new List<int>();

        public bool GiveHelmet;

        public PedData(string modelName)
        {
            ModelName = modelName;
        }
    }
}
