using CCL.GTAIV;
using IVSDKDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static IVSDKDotNet.Native.Natives;
using CCL;
using IVSDKDotNet.Enums;
using System.Runtime;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace DiversePD.ivsdk
{
    public class Main : Script
    {
        public static IVPed PlayerPed { get; set; }
        public static int PlayerIndex { get; set; }
        public static int PlayerHandle { get; set; }
        public static Vector3 PlayerPos { get; set; }

        private static uint currEp;

        private static int v;
        private static int p1;
        private static int p2;
        private static int p3;
        private static int p4;
        private static int vehType = 0;
        private static Vector3 vPos;
        private static Vector3 nodePos;
        private static float nodeHdng;
        private static bool debug;
        IVVehicle veh;

        private static uint c1;
        private static uint c2;

        private static string carModel;
        private static string driverModel;
        private static string pass1Model;
        private static string pass2Model;
        private static string pass3Model;
        private static int dWeap;
        private static int p1Weap;
        private static int p2Weap;
        private static int p3Weap;

        private static bool isSpawning;
        private static int timeToSpawn;
        private static float SpawnDist;
        private static bool OneStarOn;
        private static bool TwoStarOn;
        private static bool ThreeStarOn;
        private static bool FourStarOn;
        private static bool FiveStarOn;
        private static bool SixStarOn;

        private static bool canSpawnIV;
        private static bool canSpawnTLAD;
        private static bool canSpawnTBOGT;

        private static bool canSpawnA;
        private static bool canSpawnB;
        private static bool canSpawnC;
        private static bool canSpawnD;
        private static int listNum;
        private static int vehCount;

        private static uint gTimer;
        private static uint fTimer;
        private static uint island;

        private static readonly List<string> vehModelsA = new List<string>();
        private static readonly List<string> driverModelsA = new List<string>();
        private static readonly List<string> passengers1A = new List<string>();
        private static readonly List<string> passengers2A = new List<string>();
        private static readonly List<string> passengers3A = new List<string>();
        private static readonly List<eWeaponType> driverWeapA = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass1WeapA = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass2WeapA = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass3WeapA = new List<eWeaponType>();

        private static readonly List<string> vehModelsB = new List<string>();
        private static readonly List<string> driverModelsB = new List<string>();
        private static readonly List<string> passengers1B = new List<string>();
        private static readonly List<string> passengers2B = new List<string>();
        private static readonly List<string> passengers3B = new List<string>();
        private static readonly List<eWeaponType> driverWeapB = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass1WeapB = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass2WeapB = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass3WeapB = new List<eWeaponType>();

        private static readonly List<string> vehModelsC = new List<string>();
        private static readonly List<string> driverModelsC = new List<string>();
        private static readonly List<string> passengers1C = new List<string>();
        private static readonly List<string> passengers2C = new List<string>();
        private static readonly List<string> passengers3C = new List<string>();
        private static readonly List<eWeaponType> driverWeapC = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass1WeapC = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass2WeapC = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass3WeapC = new List<eWeaponType>();

        private static readonly List<string> vehModelsD = new List<string>();
        private static readonly List<string> driverModelsD = new List<string>();
        private static readonly List<string> passengers1D = new List<string>();
        private static readonly List<string> passengers2D = new List<string>();
        private static readonly List<string> passengers3D = new List<string>();
        private static readonly List<eWeaponType> driverWeapD = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass1WeapD = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass2WeapD = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass3WeapD = new List<eWeaponType>();

        private static readonly List<string> vehModelsE = new List<string>();
        private static readonly List<string> driverModelsE = new List<string>();
        private static readonly List<string> passengers1E = new List<string>();
        private static readonly List<string> passengers2E = new List<string>();
        private static readonly List<string> passengers3E = new List<string>();
        private static readonly List<eWeaponType> driverWeapE = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass1WeapE = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass2WeapE = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass3WeapE = new List<eWeaponType>();

        private static readonly List<string> vehModelsF = new List<string>();
        private static readonly List<string> driverModelsF = new List<string>();
        private static readonly List<string> passengers1F = new List<string>();
        private static readonly List<string> passengers2F = new List<string>();
        private static readonly List<string> passengers3F = new List<string>();
        private static readonly List<eWeaponType> driverWeapF = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass1WeapF = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass2WeapF = new List<eWeaponType>();
        private static readonly List<eWeaponType> pass3WeapF = new List<eWeaponType>();

        private static readonly List<string> vehIV = new List<string>();
        private static readonly List<string> vehTLAD = new List<string>();
        private static readonly List<string> vehTBOGT = new List<string>();

        private static readonly List<string> pedIV = new List<string>();
        private static readonly List<string> pedTLAD = new List<string>();
        private static readonly List<string> pedTBOGT = new List<string>();

        private static readonly List<string> vehBroker = new List<string>();
        private static readonly List<string> vehBohan = new List<string>();
        private static readonly List<string> vehAlgonquin = new List<string>();
        private static readonly List<string> vehAlderney = new List<string>();

        private static readonly List<string> PedModels = new List<string>();

        private static bool sectionExists;
        private static int compSpawnType;
        private static int propSpawnType;

        private static List<int> HeadRainComps = new List<int>();
        private static List<int> UpperRainComps = new List<int>();
        private static List<int> LowerRainComps = new List<int>();
        private static List<int> SuseRainComps = new List<int>();
        private static List<int> HandRainComps = new List<int>();
        private static List<int> FeetRainComps = new List<int>();
        private static List<int> JacketRainComps = new List<int>();
        private static List<int> HairRainComps = new List<int>();
        private static List<int> Sus2RainComps = new List<int>();
        private static List<int> TeefRainComps = new List<int>();
        private static List<int> FaceRainComps = new List<int>();

        private static List<int> HeadRainProps = new List<int>();
        private static List<int> UpperRainProps = new List<int>();
        private static List<int> LowerRainProps = new List<int>();
        private static List<int> SuseRainProps = new List<int>();
        private static List<int> HandRainProps = new List<int>();
        private static List<int> FeetRainProps = new List<int>();
        private static List<int> JacketRainProps = new List<int>();
        private static List<int> HairRainProps = new List<int>();
        private static List<int> Sus2RainProps = new List<int>();
        private static List<int> TeefRainProps = new List<int>();
        private static List<int> FaceRainProps = new List<int>();

        private static eWeather Wthr;
        private static bool isRaining => (Wthr == eWeather.WEATHER_RAINING || Wthr == eWeather.WEATHER_LIGHTNING || Wthr == eWeather.WEATHER_DRIZZLE);
        public Main()
        {
            Initialized += Main_Initialized;
            Tick += Main_Tick;
        }
        private void Main_Initialized(object sender, EventArgs e)
        {
            LoadINI(Settings);
        }
        private void LoadINI(SettingsFile settings)
        {
            timeToSpawn = settings.GetInteger("MAIN", "Time to Spawn", 20);
            SpawnDist = settings.GetFloat("MAIN", "Spawn Distance", 120f);
            OneStarOn = settings.GetBoolean("1 STAR", "Enable", false);
            TwoStarOn = settings.GetBoolean("2 STAR", "Enable", false);
            ThreeStarOn = settings.GetBoolean("3 STAR", "Enable", false);
            FourStarOn = settings.GetBoolean("4 STAR", "Enable", false);
            FiveStarOn = settings.GetBoolean("5 STAR", "Enable", false);
            SixStarOn = settings.GetBoolean("6 STAR", "Enable", false);
            debug = settings.GetBoolean("MAIN", "Debug", false);

            /*PedModels.Clear();
            string PedString = settings.GetValue("MAIN", "Ped Models Used", "");
            foreach (var modelName in PedString.Split(','))
                PedModels.Add(modelName.ToString());*/

            vehModelsA.Clear();
            driverModelsA.Clear();
            passengers1A.Clear();
            passengers2A.Clear();
            passengers3A.Clear();
            driverWeapA.Clear();
            pass1WeapA.Clear();
            pass2WeapA.Clear();
            pass3WeapA.Clear();

            vehModelsB.Clear();
            driverModelsB.Clear();
            passengers1B.Clear();
            passengers2B.Clear();
            passengers3B.Clear();
            driverWeapB.Clear();
            pass1WeapB.Clear();
            pass2WeapB.Clear();
            pass3WeapB.Clear();

            vehModelsC.Clear();
            driverModelsC.Clear();
            passengers1C.Clear();
            passengers2C.Clear();
            passengers3C.Clear();
            driverWeapC.Clear();
            pass1WeapC.Clear();
            pass2WeapC.Clear();
            pass3WeapC.Clear();

            vehModelsD.Clear();
            driverModelsD.Clear();
            passengers1D.Clear();
            passengers2D.Clear();
            passengers3D.Clear();
            driverWeapD.Clear();
            pass1WeapD.Clear();
            pass2WeapD.Clear();
            pass3WeapD.Clear();

            vehModelsE.Clear();
            driverModelsE.Clear();
            passengers1E.Clear();
            passengers2E.Clear();
            passengers3E.Clear();
            driverWeapE.Clear();
            pass1WeapE.Clear();
            pass2WeapE.Clear();
            pass3WeapE.Clear();

            vehModelsF.Clear();
            driverModelsF.Clear();
            passengers1F.Clear();
            passengers2F.Clear();
            passengers3F.Clear();
            driverWeapF.Clear();
            pass1WeapF.Clear();
            pass2WeapF.Clear();
            pass3WeapF.Clear();


            if (OneStarOn)
            {
                string vehStringA = settings.GetValue("1 STAR", "Vehicle Models", "");
                string driverStringA = settings.GetValue("1 STAR", "Driver Models", "");
                string pass1StringA = settings.GetValue("1 STAR", "Front Passenger Models", "");
                string pass2StringA = settings.GetValue("1 STAR", "Back Left Passenger Models", "");
                string pass3StringA = settings.GetValue("1 STAR", "Back Right Passenger Models", "");
                string dWeapStringA = settings.GetValue("1 STAR", "Driver Weapon", "");
                string p1WeapStringA = settings.GetValue("1 STAR", "Front Passenger Weapon", "");
                string p2WeapStringA = settings.GetValue("1 STAR", "Back Left Passenger Weapon", "");
                string p3WeapStringA = settings.GetValue("1 STAR", "Back Right Passenger Weapon", "");

                foreach (var modelName in vehStringA.Split(','))
                    vehModelsA.Add(modelName.ToString());

                foreach (var modelName in driverStringA.Split(','))
                    driverModelsA.Add(modelName.ToString());

                foreach (var modelName in pass1StringA.Split(','))
                    passengers1A.Add(modelName.ToString());

                foreach (var modelName in pass2StringA.Split(','))
                    passengers2A.Add(modelName.ToString());

                foreach (var modelName in pass3StringA.Split(','))
                    passengers3A.Add(modelName.ToString());

                foreach (var modelName in dWeapStringA.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    driverWeapA.Add(weaponType);
                }
                foreach (var modelName in p1WeapStringA.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass1WeapA.Add(weaponType);
                }
                foreach (var modelName in p2WeapStringA.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass2WeapA.Add(weaponType);
                }
                foreach (var modelName in p3WeapStringA.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass3WeapA.Add(weaponType);
                }
            }

            if (TwoStarOn)
            {
                string vehStringB = settings.GetValue("2 STAR", "Vehicle Models", "");
                string driverStringB = settings.GetValue("2 STAR", "Driver Models", "");
                string pass1StringB = settings.GetValue("2 STAR", "Front Passenger Models", "");
                string pass2StringB = settings.GetValue("2 STAR", "Back Left Passenger Models", "");
                string pass3StringB = settings.GetValue("2 STAR", "Back Right Passenger Models", "");
                string dWeapStringB = settings.GetValue("2 STAR", "Driver Weapon", "");
                string p1WeapStringB = settings.GetValue("2 STAR", "Front Passenger Weapon", "");
                string p2WeapStringB = settings.GetValue("2 STAR", "Back Left Passenger Weapon", "");
                string p3WeapStringB = settings.GetValue("2 STAR", "Back Right Passenger Weapon", "");

                foreach (var modelName in vehStringB.Split(','))
                    vehModelsB.Add(modelName.ToString());

                foreach (var modelName in driverStringB.Split(','))
                    driverModelsB.Add(modelName.ToString());

                foreach (var modelName in pass1StringB.Split(','))
                    passengers1B.Add(modelName.ToString());

                foreach (var modelName in pass2StringB.Split(','))
                    passengers2B.Add(modelName.ToString());

                foreach (var modelName in pass3StringB.Split(','))
                    passengers3B.Add(modelName.ToString());

                foreach (var modelName in dWeapStringB.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    driverWeapB.Add(weaponType);
                }
                foreach (var modelName in p1WeapStringB.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass1WeapB.Add(weaponType);
                }
                foreach (var modelName in p2WeapStringB.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass2WeapB.Add(weaponType);
                }
                foreach (var modelName in p3WeapStringB.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass3WeapB.Add(weaponType);
                }
            }

            if (ThreeStarOn)
            {
                string vehStringC = settings.GetValue("3 STAR", "Vehicle Models", "");
                string driverStringC = settings.GetValue("3 STAR", "Driver Models", "");
                string pass1StringC = settings.GetValue("3 STAR", "Front Passenger Models", "");
                string pass2StringC = settings.GetValue("3 STAR", "Back Left Passenger Models", "");
                string pass3StringC = settings.GetValue("3 STAR", "Back Right Passenger Models", "");
                string dWeapStringC = settings.GetValue("3 STAR", "Driver Weapon", "");
                string p1WeapStringC = settings.GetValue("3 STAR", "Front Passenger Weapon", "");
                string p2WeapStringC = settings.GetValue("3 STAR", "Back Left Passenger Weapon", "");
                string p3WeapStringC = settings.GetValue("3 STAR", "Back Right Passenger Weapon", "");

                foreach (var modelName in vehStringC.Split(','))
                    vehModelsC.Add(modelName.ToString());

                foreach (var modelName in driverStringC.Split(','))
                    driverModelsC.Add(modelName.ToString());

                foreach (var modelName in pass1StringC.Split(','))
                    passengers1C.Add(modelName.ToString());

                foreach (var modelName in pass2StringC.Split(','))
                    passengers2C.Add(modelName.ToString());

                foreach (var modelName in pass3StringC.Split(','))
                    passengers3C.Add(modelName.ToString());

                foreach (var modelName in dWeapStringC.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    driverWeapC.Add(weaponType);
                }
                foreach (var modelName in p1WeapStringC.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass1WeapC.Add(weaponType);
                }
                foreach (var modelName in p2WeapStringC.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass2WeapC.Add(weaponType);
                }
                foreach (var modelName in p3WeapStringC.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass3WeapC.Add(weaponType);
                }
            }

            if (FourStarOn)
            {
                string vehStringD = settings.GetValue("4 STAR", "Vehicle Models", "");
                string driverStringD = settings.GetValue("4 STAR", "Driver Models", "");
                string pass1StringD = settings.GetValue("4 STAR", "Front Passenger Models", "");
                string pass2StringD = settings.GetValue("4 STAR", "Back Left Passenger Models", "");
                string pass3StringD = settings.GetValue("4 STAR", "Back Right Passenger Models", "");
                string dWeapStringD = settings.GetValue("4 STAR", "Driver Weapon", "");
                string p1WeapStringD = settings.GetValue("4 STAR", "Front Passenger Weapon", "");
                string p2WeapStringD = settings.GetValue("4 STAR", "Back Left Passenger Weapon", "");
                string p3WeapStringD = settings.GetValue("4 STAR", "Back Right Passenger Weapon", "");

                foreach (var modelName in vehStringD.Split(','))
                    vehModelsD.Add(modelName.ToString());

                foreach (var modelName in driverStringD.Split(','))
                    driverModelsD.Add(modelName.ToString());

                foreach (var modelName in pass1StringD.Split(','))
                    passengers1D.Add(modelName.ToString());

                foreach (var modelName in pass2StringD.Split(','))
                    passengers2D.Add(modelName.ToString());

                foreach (var modelName in pass3StringD.Split(','))
                    passengers3D.Add(modelName.ToString());

                foreach (var modelName in dWeapStringD.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    driverWeapD.Add(weaponType);
                }
                foreach (var modelName in p1WeapStringD.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass1WeapD.Add(weaponType);
                }
                foreach (var modelName in p2WeapStringD.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass2WeapD.Add(weaponType);
                }
                foreach (var modelName in p3WeapStringD.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass3WeapD.Add(weaponType);
                }
            }

            if (FiveStarOn)
            {
                string vehStringE = settings.GetValue("5 STAR", "Vehicle Models", "");
                string driverStringE = settings.GetValue("5 STAR", "Driver Models", "");
                string pass1StringE = settings.GetValue("5 STAR", "Front Passenger Models", "");
                string pass2StringE = settings.GetValue("5 STAR", "Back Left Passenger Models", "");
                string pass3StringE = settings.GetValue("5 STAR", "Back Right Passenger Models", "");
                string dWeapStringE = settings.GetValue("5 STAR", "Driver Weapon", "");
                string p1WeapStringE = settings.GetValue("5 STAR", "Front Passenger Weapon", "");
                string p2WeapStringE = settings.GetValue("5 STAR", "Back Left Passenger Weapon", "");
                string p3WeapStringE = settings.GetValue("5 STAR", "Back Right Passenger Weapon", "");

                foreach (var modelName in vehStringE.Split(','))
                    vehModelsE.Add(modelName.ToString());

                foreach (var modelName in driverStringE.Split(','))
                    driverModelsE.Add(modelName.ToString());

                foreach (var modelName in pass1StringE.Split(','))
                    passengers1E.Add(modelName.ToString());

                foreach (var modelName in pass2StringE.Split(','))
                    passengers2E.Add(modelName.ToString());

                foreach (var modelName in pass3StringE.Split(','))
                    passengers3E.Add(modelName.ToString());

                foreach (var modelName in dWeapStringE.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    driverWeapE.Add(weaponType);
                }
                foreach (var modelName in p1WeapStringE.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass1WeapE.Add(weaponType);
                }
                foreach (var modelName in p2WeapStringE.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass2WeapE.Add(weaponType);
                }
                foreach (var modelName in p3WeapStringE.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass3WeapE.Add(weaponType);
                }
            }

            if (SixStarOn)
            {
                string vehStringF = settings.GetValue("6 STAR", "Vehicle Models", "");
                string driverStringF = settings.GetValue("6 STAR", "Driver Models", "");
                string pass1StringF = settings.GetValue("6 STAR", "Front Passenger Models", "");
                string pass2StringF = settings.GetValue("6 STAR", "Back Left Passenger Models", "");
                string pass3StringF = settings.GetValue("6 STAR", "Back Right Passenger Models", "");
                string dWeapStringF = settings.GetValue("6 STAR", "Driver Weapon", "");
                string p1WeapStringF = settings.GetValue("6 STAR", "Front Passenger Weapon", "");
                string p2WeapStringF = settings.GetValue("6 STAR", "Back Left Passenger Weapon", "");
                string p3WeapStringF = settings.GetValue("6 STAR", "Back Right Passenger Weapon", "");

                foreach (var modelName in vehStringF.Split(','))
                    vehModelsF.Add(modelName.ToString());

                foreach (var modelName in driverStringF.Split(','))
                    driverModelsF.Add(modelName.ToString());

                foreach (var modelName in pass1StringF.Split(','))
                    passengers1F.Add(modelName.ToString());

                foreach (var modelName in pass2StringF.Split(','))
                    passengers2F.Add(modelName.ToString());

                foreach (var modelName in pass3StringF.Split(','))
                    passengers3F.Add(modelName.ToString());

                foreach (var modelName in dWeapStringF.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    driverWeapF.Add(weaponType);
                }
                foreach (var modelName in p1WeapStringF.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass1WeapF.Add(weaponType);
                }
                foreach (var modelName in p2WeapStringF.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass2WeapF.Add(weaponType);
                }
                foreach (var modelName in p3WeapStringF.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    pass3WeapF.Add(weaponType);
                }
            }

            vehIV.Clear();
            vehTLAD.Clear();
            vehTBOGT.Clear();

            string vehIVString = settings.GetValue("MAIN", "IVVehModels", "");
            string vehTLADString = settings.GetValue("MAIN", "TLADVehModels", "");
            string vehTBOGTString = settings.GetValue("MAIN", "TBOGTVehModels", "");

            foreach (var modelName in vehIVString.Split(','))
                vehIV.Add(modelName.ToString());
            foreach (var modelName in vehTLADString.Split(','))
                vehTLAD.Add(modelName.ToString());
            foreach (var modelName in vehTBOGTString.Split(','))
                vehTBOGT.Add(modelName.ToString());

            pedIV.Clear();
            pedTLAD.Clear();
            pedTBOGT.Clear();

            string pedIVString = settings.GetValue("MAIN", "IVPedModels", "");
            string pedTLADString = settings.GetValue("MAIN", "TLADPedModels", "");
            string pedTBOGTString = settings.GetValue("MAIN", "TBOGTPedModels", "");

            foreach (var modelName in pedIVString.Split(','))
                pedIV.Add(modelName.ToString());
            foreach (var modelName in pedTLADString.Split(','))
                pedTLAD.Add(modelName.ToString());
            foreach (var modelName in pedTBOGTString.Split(','))
                pedTBOGT.Add(modelName.ToString());

            vehBroker.Clear();
            vehBohan.Clear();
            vehAlgonquin.Clear();
            vehAlderney.Clear();

            string brokrString = settings.GetValue("MAIN", "BrokerDukesVehicles", "");
            string bohanString = settings.GetValue("MAIN", "BohanVehicles", "");
            string AlgoString = settings.GetValue("MAIN", "AlgonquinVehicles", "");
            string AlderString = settings.GetValue("MAIN", "AlderneyVehicles", "");

            foreach (var modelName in brokrString.Split(','))
                vehBroker.Add(modelName.ToString());
            foreach (var modelName in bohanString.Split(','))
                vehBohan.Add(modelName.ToString());
            foreach (var modelName in AlgoString.Split(','))
                vehAlgonquin.Add(modelName.ToString());
            foreach (var modelName in AlderString.Split(','))
                vehAlderney.Add(modelName.ToString());
        }
        private void ClearSpawnConditions()
        {
            canSpawnIV = false;
            canSpawnTLAD = false;
            canSpawnTBOGT = false;

            canSpawnA = false;
            canSpawnB = false;
            canSpawnC = false;
            canSpawnD = false;
        }
        private bool CheckEpisodeVehicle(string vehToSpawn)
        {
            foreach (string vehString in vehIV)
            {
                if (vehToSpawn == vehString)
                    canSpawnIV = true;
            }
            foreach (string vehString in vehTLAD)
            {
                if (vehToSpawn == vehString)
                    canSpawnTLAD = true;
            }
            foreach (string vehString in vehTBOGT)
            {
                if (vehToSpawn == vehString)
                    canSpawnTBOGT = true;
            }
            if (canSpawnIV && currEp == 0)
                return true;
            else if (canSpawnTLAD && currEp == 1)
                return true;
            else if (canSpawnTBOGT && currEp == 2)
                return true;
            else if (!canSpawnIV && !canSpawnTLAD && !canSpawnTBOGT)
                return true;
            else
            {
                if (vehType < (vehCount - 1))
                    vehType++;
                else
                    vehType = 0;
                return false;
            }
        }
        private bool CheckEpisodePed(string pedToSpawn)
        {
            foreach (string pedString in pedIV)
            {
                if (pedToSpawn == pedString)
                    canSpawnIV = true;
            }
            foreach (string pedString in pedTLAD)
            {
                if (pedToSpawn == pedString)
                    canSpawnTLAD = true;
            }
            foreach (string pedString in pedTBOGT)
            {
                if (pedToSpawn == pedString)
                    canSpawnTBOGT = true;
            }
            if (canSpawnIV && currEp == 0)
                return true;
            else if (canSpawnTLAD && currEp == 1)
                return true;
            else if (canSpawnTBOGT && currEp == 2)
                return true;
            else if (!canSpawnIV && !canSpawnTLAD && !canSpawnTBOGT)
                return true;
            else
            {
                if (vehType < (vehCount - 1))
                    vehType++;
                else
                    vehType = 0;
                return false;
            }
        }
        private bool CheckVehicle(string vehToSpawn)
        {
            foreach (string vehString in vehBroker)
            {
                if (vehToSpawn == vehString)
                    canSpawnA = true;
            }
            foreach (string vehString in vehBohan)
            {
                if (vehToSpawn == vehString)
                    canSpawnB = true;
            }
            foreach (string vehString in vehAlgonquin)
            {
                if (vehToSpawn == vehString)
                    canSpawnC = true;
            }
            foreach (string vehString in vehAlderney)
            {
                if (vehToSpawn == vehString)
                    canSpawnD = true;
            }

            if (island == 0 && canSpawnA)
                return true;

            else if (island == 1 && canSpawnB)
                return true;

            else if (island == 2 && canSpawnC)
                return true;

            else if (island == 3 && canSpawnD)
                return true;

            else if (!canSpawnA && !canSpawnB && !canSpawnC && !canSpawnD)
                return true;

            else
            {
                if (vehType < (vehCount - 1))
                    vehType++;
                else
                    vehType = 0;
                return false;
            }
        }
        private void LoadComponents(SettingsFile settings, string pedModel)
        {
            HeadRainComps.Clear();
            UpperRainComps.Clear();
            LowerRainComps.Clear();
            SuseRainComps.Clear();
            HandRainComps.Clear();
            FeetRainComps.Clear();
            JacketRainComps.Clear();
            HairRainComps.Clear();
            Sus2RainComps.Clear();
            TeefRainComps.Clear();
            FaceRainComps.Clear();

            HeadRainProps.Clear();
            UpperRainProps.Clear();
            LowerRainProps.Clear();
            SuseRainProps.Clear();
            HandRainProps.Clear();
            FeetRainProps.Clear();
            JacketRainProps.Clear();
            HairRainProps.Clear();
            Sus2RainProps.Clear();
            TeefRainProps.Clear();
            FaceRainProps.Clear();

            if (settings.DoesSectionExists(pedModel))
            {
                sectionExists = true;

                int RainComponentSpawnType = settings.GetInteger(pedModel, "RainComponentSpawnType", 0);
                int RainPropSpawnType = settings.GetInteger(pedModel, "RainPropSpawnType", 0);

                string HeadRainCompString = settings.GetValue(pedModel, "HeadRainComps", "");
                string UpperRainCompString = settings.GetValue(pedModel, "UpperRainComps", "");
                string LowerRainCompString = settings.GetValue(pedModel, "LowerRainComps", "");
                string SuseRainCompString = settings.GetValue(pedModel, "SuseRainComps", "");
                string HandRainCompString = settings.GetValue(pedModel, "HandRainComps", "");
                string FeetRainCompString = settings.GetValue(pedModel, "FeetRainComps", "");
                string JacketRainCompString = settings.GetValue(pedModel, "JacketRainComps", "");
                string HairRainCompString = settings.GetValue(pedModel, "HairRainComps", "");
                string Sus2RainCompString = settings.GetValue(pedModel, "Sus2RainComps", "");
                string TeefRainCompString = settings.GetValue(pedModel, "TeefRainComps", "");
                string FaceRainCompString = settings.GetValue(pedModel, "FaceRainComps", "");

                string HeadRainPropString = settings.GetValue(pedModel, "HeadRainComps", "");
                string UpperRainPropString = settings.GetValue(pedModel, "UpperRainComps", "");
                string LowerRainPropString = settings.GetValue(pedModel, "LowerRainComps", "");
                string SuseRainPropString = settings.GetValue(pedModel, "SuseRainComps", "");
                string HandRainPropString = settings.GetValue(pedModel, "HandRainComps", "");
                string FeetRainPropString = settings.GetValue(pedModel, "FeetRainComps", "");
                string JacketRainPropString = settings.GetValue(pedModel, "JacketRainComps", "");
                string HairRainPropString = settings.GetValue(pedModel, "HairRainComps", "");
                string Sus2RainPropString = settings.GetValue(pedModel, "Sus2RainComps", "");
                string TeefRainPropString = settings.GetValue(pedModel, "TeefRainComps", "");
                string FaceRainPropString = settings.GetValue(pedModel, "FaceRainComps", "");

                HeadRainComps = HeadRainCompString.Split(',').Select(int.Parse).ToList();
                UpperRainComps = UpperRainCompString.Split(',').Select(int.Parse).ToList();
                LowerRainComps = LowerRainCompString.Split(',').Select(int.Parse).ToList();
                SuseRainComps = SuseRainCompString.Split(',').Select(int.Parse).ToList();
                HandRainComps = HandRainCompString.Split(',').Select(int.Parse).ToList();
                FeetRainComps = FeetRainCompString.Split(',').Select(int.Parse).ToList();
                JacketRainComps = JacketRainCompString.Split(',').Select(int.Parse).ToList();
                HairRainComps = HairRainCompString.Split(',').Select(int.Parse).ToList();
                Sus2RainComps = Sus2RainCompString.Split(',').Select(int.Parse).ToList();
                TeefRainComps = TeefRainCompString.Split(',').Select(int.Parse).ToList();
                FaceRainComps = FaceRainCompString.Split(',').Select(int.Parse).ToList();

                HeadRainProps = HeadRainPropString.Split(',').Select(int.Parse).ToList();
                UpperRainProps = UpperRainPropString.Split(',').Select(int.Parse).ToList();
                LowerRainProps = LowerRainPropString.Split(',').Select(int.Parse).ToList();
                SuseRainProps = SuseRainPropString.Split(',').Select(int.Parse).ToList();
                HandRainProps = HandRainPropString.Split(',').Select(int.Parse).ToList();
                FeetRainProps = FeetRainPropString.Split(',').Select(int.Parse).ToList();
                JacketRainProps = JacketRainPropString.Split(',').Select(int.Parse).ToList();
                HairRainProps = HairRainPropString.Split(',').Select(int.Parse).ToList();
                Sus2RainProps = Sus2RainPropString.Split(',').Select(int.Parse).ToList();
                TeefRainProps = TeefRainPropString.Split(',').Select(int.Parse).ToList();
                FaceRainProps = FaceRainPropString.Split(',').Select(int.Parse).ToList();

                compSpawnType = RainComponentSpawnType;
                propSpawnType = RainPropSpawnType;
            }
            else
                sectionExists = false;
        }
        private void CheckPedComponents(string pedModel, int pedHandl)
        {
            /*if (pedModel == "M_Y_COP")
                SET_CHAR_COMPONENT_VARIATION(pedHandl, 2, 0, 0);*/
            LoadComponents(Settings, pedModel);

            if (sectionExists)
            {
                Wthr = NativeWorld.CurrentWeather;
                int i = 0;
                List<int> compList = null;
                List<int> propList = null;

                for (i = 0; i < 11; i++)
                {
                    switch (i)
                    {
                        case 0:
                            compList = HeadRainComps;
                            propList = HeadRainProps;
                            break;
                        case 1:
                            compList = UpperRainComps;
                            propList = UpperRainProps;
                            break;
                        case 2:
                            compList = LowerRainComps;
                            propList = LowerRainProps;
                            break;
                        case 3:
                            compList = SuseRainComps;
                            propList = SuseRainProps;
                            break;
                        case 4:
                            compList = HandRainComps;
                            propList = HandRainProps;
                            break;
                        case 5:
                            compList = FeetRainComps;
                            propList = FeetRainProps;
                            break;
                        case 6:
                            compList = JacketRainComps;
                            propList = JacketRainProps;
                            break;
                        case 7:
                            compList = HairRainComps;
                            propList = HairRainProps;
                            break;
                        case 8:
                            compList = Sus2RainComps;
                            propList = Sus2RainProps;
                            break;
                        case 9:
                            compList = TeefRainComps;
                            propList = TeefRainProps;
                            break;
                        case 10:
                            compList = FaceRainComps;
                            propList = FaceRainProps;
                            break;
                    }

                    int spawnChance = GENERATE_RANDOM_INT_IN_RANGE(0, 2);
                    int compIndex = GENERATE_RANDOM_INT_IN_RANGE(0, compList.Count());
                    uint compVar = GET_CHAR_DRAWABLE_VARIATION(pedHandl, i);
                    GET_CHAR_PROP_INDEX(pedHandl, i, out int pedProp);

                    int propIndex = GENERATE_RANDOM_INT_IN_RANGE(0, propList.Count());

                    if (compSpawnType == 0)
                        spawnChance = 0;
                    else if (compSpawnType == 2)
                        spawnChance = 1;

                    if (compList[compIndex] != -1 && spawnChance != 0 && isRaining)
                    {
                        uint texCount = GET_NUMBER_OF_CHAR_TEXTURE_VARIATIONS(pedHandl, (uint)i, (uint)compList[compIndex]);
                        int texVar = GENERATE_RANDOM_INT_IN_RANGE(0, (int)texCount);

                        SET_CHAR_COMPONENT_VARIATION(pedHandl, (uint)i, (uint)compList[compIndex], (uint)texVar);
                        //SET_CHAR_PROP_INDEX();
                    }

                    else
                    {
                        if (compVar == compList[compIndex])
                            SET_CHAR_DEFAULT_COMPONENT_VARIATION(pedHandl);
                    }

                    if (propSpawnType == 0)
                        spawnChance = 0;
                    else if (propSpawnType == 2)
                        spawnChance = 1;

                    if (propList[propIndex] != -1 && spawnChance != 0 && isRaining)
                        SET_CHAR_PROP_INDEX(pedHandl, (uint)i, (uint)propList[propIndex]);
                    else
                    {
                        if (pedProp == propList[propIndex])
                            CLEAR_CHAR_PROP(pedHandl, i);
                    }
                }
            }
        }
        private void SpawnPedInVeh(string pModel, int pedHandle, int pWeap)
        {
            CheckPedComponents(pModel, pedHandle);
            if (pWeap > 0)
                GIVE_WEAPON_TO_CHAR(pedHandle, pWeap, -1, true);

            SET_CHAR_WILL_DO_DRIVEBYS(pedHandle, true);
            SET_PED_PATH_MAY_DROP_FROM_HEIGHT(pedHandle, true);
            SET_PED_PATH_MAY_USE_CLIMBOVERS(pedHandle, true);
            SET_PED_PATH_MAY_USE_LADDERS(pedHandle, true);

            MARK_MODEL_AS_NO_LONGER_NEEDED(GET_HASH_KEY(pModel));
            MARK_CHAR_AS_NO_LONGER_NEEDED(pedHandle);
        }
        private void Main_Tick(object sender, EventArgs e)
        {
            PlayerPed = IVPed.FromUIntPtr(IVPlayerInfo.FindThePlayerPed());
            PlayerIndex = (int)GET_PLAYER_ID();
            PlayerHandle = PlayerPed.GetHandle();
            PlayerPos = PlayerPed.Matrix.Pos;

            currEp = GET_CURRENT_EPISODE();
            GET_GAME_TIMER(out gTimer);

            if (!isSpawning)
            {
                island = GET_MAP_AREA_FROM_COORDS(PlayerPos.X, PlayerPos.Y, PlayerPos.Z);

                if (!IS_WANTED_LEVEL_GREATER(PlayerIndex, 1) && OneStarOn)
                {
                    vehCount = vehModelsA.Count();
                    if (vehType >= vehModelsA.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckEpisodeVehicle(vehModelsA[listNum]))
                    {
                        ClearSpawnConditions();
                        if (debug)
                            IVGame.ShowSubtitleMessage(vehModelsA[listNum] + " cannot spawn in this episode.");
                        return;
                    }
                    if (!CheckVehicle(vehModelsA[listNum]))
                    {
                        ClearSpawnConditions();
                        if (debug)
                            IVGame.ShowSubtitleMessage(vehModelsA[listNum] + " cannot spawn in this island.");
                        return;
                    }

                    else
                    {
                        ClearSpawnConditions();
                        carModel = vehModelsA[listNum];

                        driverModel = driverModelsA[listNum];
                        pass1Model = passengers1A[listNum];
                        pass2Model = passengers2A[listNum];
                        pass3Model = passengers3A[listNum];

                        dWeap = (int)driverWeapA[listNum];
                        p1Weap = (int)pass1WeapA[listNum];
                        p2Weap = (int)pass2WeapA[listNum];
                        p3Weap = (int)pass3WeapA[listNum];

                        GET_GAME_TIMER(out fTimer);
                        isSpawning = true;
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 1) && !IS_WANTED_LEVEL_GREATER(PlayerIndex, 2) && TwoStarOn)
                {
                    vehCount = vehModelsB.Count();
                    if (vehType >= vehModelsB.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckEpisodeVehicle(vehModelsB[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }
                    if (!CheckVehicle(vehModelsB[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }

                    else
                    {
                        ClearSpawnConditions();
                        carModel = vehModelsB[listNum];

                        driverModel = driverModelsB[listNum];
                        pass1Model = passengers1B[listNum];
                        pass2Model = passengers2B[listNum];
                        pass3Model = passengers3B[listNum];

                        dWeap = (int)driverWeapB[listNum];
                        p1Weap = (int)pass1WeapB[listNum];
                        p2Weap = (int)pass2WeapB[listNum];
                        p3Weap = (int)pass3WeapB[listNum];

                        GET_GAME_TIMER(out fTimer);
                        isSpawning = true;
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 2) && !IS_WANTED_LEVEL_GREATER(PlayerIndex, 3) && ThreeStarOn)
                {
                    vehCount = vehModelsC.Count();
                    if (vehType >= vehModelsC.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckEpisodeVehicle(vehModelsC[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }
                    if (!CheckVehicle(vehModelsC[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }

                    else
                    {
                        ClearSpawnConditions();
                        carModel = vehModelsC[listNum];

                        driverModel = driverModelsC[listNum];
                        pass1Model = passengers1C[listNum];
                        pass2Model = passengers2C[listNum];
                        pass3Model = passengers3C[listNum];

                        dWeap = (int)driverWeapC[listNum];
                        p1Weap = (int)pass1WeapC[listNum];
                        p2Weap = (int)pass2WeapC[listNum];
                        p3Weap = (int)pass3WeapC[listNum];

                        GET_GAME_TIMER(out fTimer);
                        isSpawning = true;
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 3) && !IS_WANTED_LEVEL_GREATER(PlayerIndex, 4) && FourStarOn)
                {
                    vehCount = vehModelsD.Count();
                    if (vehType >= vehModelsD.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckEpisodeVehicle(vehModelsD[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }
                    if (!CheckVehicle(vehModelsD[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }

                    else
                    {
                        ClearSpawnConditions();
                        carModel = vehModelsD[listNum];

                        driverModel = driverModelsD[listNum];
                        pass1Model = passengers1D[listNum];
                        pass2Model = passengers2D[listNum];
                        pass3Model = passengers3D[listNum];

                        dWeap = (int)driverWeapD[listNum];
                        p1Weap = (int)pass1WeapD[listNum];
                        p2Weap = (int)pass2WeapD[listNum];
                        p3Weap = (int)pass3WeapD[listNum];

                        GET_GAME_TIMER(out fTimer);
                        isSpawning = true;
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 4) && !IS_WANTED_LEVEL_GREATER(PlayerIndex, 5) && FiveStarOn)
                {
                    vehCount = vehModelsE.Count();
                    if (vehType >= vehModelsE.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckEpisodeVehicle(vehModelsE[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }
                    if (!CheckVehicle(vehModelsE[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }

                    else
                    {
                        ClearSpawnConditions();
                        carModel = vehModelsE[listNum];

                        driverModel = driverModelsE[listNum];
                        pass1Model = passengers1E[listNum];
                        pass2Model = passengers2E[listNum];
                        pass3Model = passengers3E[listNum];

                        dWeap = (int)driverWeapE[listNum];
                        p1Weap = (int)pass1WeapE[listNum];
                        p2Weap = (int)pass2WeapE[listNum];
                        p3Weap = (int)pass3WeapE[listNum];

                        GET_GAME_TIMER(out fTimer);
                        isSpawning = true;
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 5) && SixStarOn)
                {
                    vehCount = vehModelsF.Count();
                    if (vehType >= vehModelsF.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckEpisodeVehicle(vehModelsF[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }
                    if (!CheckVehicle(vehModelsF[listNum]))
                    {
                        ClearSpawnConditions();
                        return;
                    }

                    else
                    {
                        ClearSpawnConditions();
                        carModel = vehModelsF[listNum];

                        driverModel = driverModelsF[listNum];
                        pass1Model = passengers1F[listNum];
                        pass2Model = passengers2F[listNum];
                        pass3Model = passengers3F[listNum];

                        dWeap = (int)driverWeapF[listNum];
                        p1Weap = (int)pass1WeapF[listNum];
                        p2Weap = (int)pass2WeapF[listNum];
                        p3Weap = (int)pass3WeapF[listNum];

                        GET_GAME_TIMER(out fTimer);
                        isSpawning = true;
                    }
                }
            }
            else
                SpawnPigs();
        }
        private void SpawnPigs()
        {
            if (!HAS_MODEL_LOADED(GET_HASH_KEY(carModel)))
                REQUEST_MODEL(GET_HASH_KEY(carModel));

            if (!HAS_MODEL_LOADED(GET_HASH_KEY(driverModel)))
                REQUEST_MODEL(GET_HASH_KEY(driverModel));

            if (!HAS_MODEL_LOADED(GET_HASH_KEY(pass1Model)))
                REQUEST_MODEL(GET_HASH_KEY(pass1Model));

            if (!HAS_MODEL_LOADED(GET_HASH_KEY(pass2Model)))
                REQUEST_MODEL(GET_HASH_KEY(pass2Model));

            if (!HAS_MODEL_LOADED(GET_HASH_KEY(pass3Model)))
                REQUEST_MODEL(GET_HASH_KEY(pass3Model));

            if (gTimer >= (fTimer + (timeToSpawn * 1000)))
            {
                if (HAS_MODEL_LOADED(GET_HASH_KEY(carModel)) && HAS_MODEL_LOADED(GET_HASH_KEY(driverModel)))
                {

                    //if (GET_CLOSEST_ROAD(PlayerPos.Around(SpawnDist).X, PlayerPos.Around(SpawnDist).Y, PlayerPos.Around(SpawnDist).Z, 10.0f, 2, out Vector3 sNode, out Vector3 nNode, out float sRoad, out float nRoad, out float cWidth))
                    if (GET_RANDOM_CAR_NODE(PlayerPos.Around(SpawnDist).X, PlayerPos.Around(SpawnDist).Y, PlayerPos.Around(SpawnDist).Z, 10.0f, true, true, false, out nodePos.X, out nodePos.Y, out nodePos.Z, out nodeHdng))
                    {
                        //GET_CLOSEST_MAJOR_CAR_NODE(PlayerPos.Around(SpawnDist), out nodePos);
                        /*GET_CLOSEST_CAR_NODE_WITH_HEADING(sNode, out nodePos, out nodeHdng);
                        if ((nodePos - PlayerPos).Length() < SpawnDist)
                            GET_CLOSEST_CAR_NODE_WITH_HEADING(nNode, out nodePos, out nodeHdng);*/

                        if ((nodePos - PlayerPos).Length() >= SpawnDist)
                        {
                            CREATE_CAR(GET_HASH_KEY(carModel), nodePos, out v, true);
                            MARK_MODEL_AS_NO_LONGER_NEEDED(GET_HASH_KEY(carModel));

                            SET_CAR_COORDINATES(v, nodePos);
                            SET_CAR_HEADING(v, nodeHdng);
                            SET_CAR_FORWARD_SPEED(v, 5f);
                            veh = NativeWorld.GetVehicleInstanceFromHandle(v);
                            veh.PlaceOnGroundProperly();

                            CREATE_CHAR_INSIDE_CAR(v, 3, (uint)GET_HASH_KEY(driverModel), out p1);

                            SpawnPedInVeh(driverModel, p1, dWeap);

                            if (veh.GetMaximumNumberOfPassengers() > 0)
                            {
                                if (HAS_MODEL_LOADED(GET_HASH_KEY(pass1Model)))
                                    CREATE_CHAR_AS_PASSENGER(v, 3, (uint)GET_HASH_KEY(pass1Model), 0, out p2);

                                SpawnPedInVeh(pass1Model, p2, p1Weap);

                                if (veh.GetMaximumNumberOfPassengers() > 1)
                                {
                                    if (HAS_MODEL_LOADED(GET_HASH_KEY(pass2Model)))
                                        CREATE_CHAR_AS_PASSENGER(v, 3, (uint)GET_HASH_KEY(pass2Model), 1, out p3);

                                    SpawnPedInVeh(pass2Model, p3, p2Weap);
                                }
                                if (veh.GetMaximumNumberOfPassengers() > 2)
                                {
                                    if (HAS_MODEL_LOADED(GET_HASH_KEY(pass3Model)))
                                        CREATE_CHAR_AS_PASSENGER(v, 3, (uint)GET_HASH_KEY(pass3Model), 2, out p4);

                                    SpawnPedInVeh(pass3Model, p4, p3Weap);
                                }
                            }

                            MARK_CAR_AS_NO_LONGER_NEEDED(v);
                            if (debug)
                                IVGame.ShowSubtitleMessage("Spawned " + carModel + " " + (nodePos - PlayerPos).Length() + " meters from player. Vehicle " + (vehType + 1).ToString() + " out of " + vehCount.ToString() + ".");
                        }
                        else
                            return;
                    }
                    else
                    {
                        if (debug)
                            IVGame.ShowSubtitleMessage("No acceptable paths detected, recalculating...");
                        return;
                    }

                    if (vehType < (vehCount - 1))
                        vehType++;
                    else
                        vehType = 0;

                    isSpawning = false;
                }
                else
                    return;
            }
        }
    }
}
