using CCL.GTAIV;
using IVSDKDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using IVSDKDotNet;
using static IVSDKDotNet.Native.Natives;
using CCL;
using CCL.GTAIV;
using IVSDKDotNet.Enums;
using System.Runtime;

namespace DiversePD.ivsdk
{
    public class Main : Script
    {
        public static IVPed PlayerPed { get; set; }
        public static int PlayerIndex { get; set; }
        public static int PlayerHandle { get; set; }
        public static Vector3 PlayerPos { get; set; }
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

        private static bool canSpawnA;
        private static bool canSpawnB;
        private static bool canSpawnC;
        private static bool canSpawnD;
        private static int listNum;
        private static int vehCount;

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

        private static readonly List<string> vehBroker = new List<string>();
        private static readonly List<string> vehBohan = new List<string>();
        private static readonly List<string> vehAlgonquin = new List<string>();
        private static readonly List<string> vehAlderney = new List<string>();

        private static readonly List<string> PedModels = new List<string>();

        private static uint headComp;
        private static uint upprComp;
        private static uint lowrComp;
        private static uint suseComp;
        private static uint handComp;
        private static uint feetComp;
        private static uint jcktComp;
        private static uint hairComp;
        private static uint sus2Comp;
        private static uint teefComp;
        private static uint faceComp;

        public static DelayedCalling TheDelayedCaller;
        public Main()
        {
            Uninitialize += Main_Uninitialize;
            Initialized += Main_Initialized;
            Tick += Main_Tick;
            TheDelayedCaller = new DelayedCalling();
        }
        private void Main_Uninitialize(object sender, EventArgs e)
        {
            if (TheDelayedCaller != null)
            {
                TheDelayedCaller.ClearAll();
                TheDelayedCaller = null;
            }
        }

        private void Main_Initialized(object sender, EventArgs e)
        {
            LoadINI(Settings);
        }
        private void LoadComponents(SettingsFile settings)
        {
            string HeadString = settings.GetValue(driverModel, "Head Models", "");
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
            {
                //IVGame.ShowSubtitleMessage(vehToSpawn + " can spawn in " + island.ToString());
                return true;
            }

            else if (island == 1 && canSpawnB)
            {
                //IVGame.ShowSubtitleMessage(vehToSpawn + " can spawn in " + island.ToString());
                return true;
            }

            else if (island == 2 && canSpawnC)
            {
                //IVGame.ShowSubtitleMessage(vehToSpawn + " can spawn in " + island.ToString());
                return true;
            }

            else if (island == 3 && canSpawnD)
            {
                //IVGame.ShowSubtitleMessage(vehToSpawn + " can spawn in " + island.ToString());
                return true;
            }

            else if (!canSpawnA && !canSpawnB && !canSpawnC && !canSpawnD)
            {
                //IVGame.ShowSubtitleMessage(vehToSpawn + " can spawn in any island");
                return true;
            }
            else
            {
                if (vehType < (vehCount - 1))
                    vehType++;
                else
                    vehType = 0;
                //IVGame.ShowSubtitleMessage(vehToSpawn + " can't spawn in " + island.ToString());
                return false;
            }
        }

        private void CheckPedComponents(string pedModel, int pedHandl)
        {
            if (pedModel == "M_Y_COP")
                SET_CHAR_COMPONENT_VARIATION(pedHandl, 2, 0, 0);
        }
        private void Main_Tick(object sender, EventArgs e)
        {
            PlayerPed = IVPed.FromUIntPtr(IVPlayerInfo.FindThePlayerPed());
            PlayerIndex = (int)GET_PLAYER_ID();
            PlayerHandle = PlayerPed.GetHandle();
            PlayerPos = PlayerPed.Matrix.Pos;

            if (!isSpawning)
            {
                island = GET_MAP_AREA_FROM_COORDS(PlayerPos.X, PlayerPos.Y, PlayerPos.Z);

                if (!IS_WANTED_LEVEL_GREATER(PlayerIndex, 1) && OneStarOn)
                {
                    vehCount = vehModelsA.Count();
                    if (vehType > vehModelsA.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckVehicle(vehModelsA[listNum]))
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        return;
                    }

                    else
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        isSpawning = true;
                        carModel = vehModelsA[listNum];

                        driverModel = driverModelsA[listNum];
                        pass1Model = passengers1A[listNum];
                        pass2Model = passengers2A[listNum];
                        pass3Model = passengers3A[listNum];

                        dWeap = (int)driverWeapA[listNum];
                        p1Weap = (int)pass1WeapA[listNum];
                        p2Weap = (int)pass2WeapA[listNum];
                        p3Weap = (int)pass3WeapA[listNum];
                        SpawnPigs();
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 1) && !IS_WANTED_LEVEL_GREATER(PlayerIndex, 2) && TwoStarOn)
                {
                    vehCount = vehModelsB.Count();
                    if (vehType > vehModelsB.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckVehicle(vehModelsB[listNum]))
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        return;
                    }

                    else
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        isSpawning = true;
                        carModel = vehModelsB[listNum];

                        driverModel = driverModelsB[listNum];
                        pass1Model = passengers1B[listNum];
                        pass2Model = passengers2B[listNum];
                        pass3Model = passengers3B[listNum];

                        dWeap = (int)driverWeapB[listNum];
                        p1Weap = (int)pass1WeapB[listNum];
                        p2Weap = (int)pass2WeapB[listNum];
                        p3Weap = (int)pass3WeapB[listNum];
                        SpawnPigs();
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 2) && !IS_WANTED_LEVEL_GREATER(PlayerIndex, 3) && ThreeStarOn)
                {
                    vehCount = vehModelsC.Count();
                    if (vehType > vehModelsC.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckVehicle(vehModelsC[listNum]))
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        return;
                    }

                    else
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        isSpawning = true;
                        carModel = vehModelsC[listNum];

                        driverModel = driverModelsC[listNum];
                        pass1Model = passengers1C[listNum];
                        pass2Model = passengers2C[listNum];
                        pass3Model = passengers3C[listNum];

                        dWeap = (int)driverWeapC[listNum];
                        p1Weap = (int)pass1WeapC[listNum];
                        p2Weap = (int)pass2WeapC[listNum];
                        p3Weap = (int)pass3WeapC[listNum];
                        SpawnPigs();
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 3) && !IS_WANTED_LEVEL_GREATER(PlayerIndex, 4) && FourStarOn)
                {
                    vehCount = vehModelsD.Count();
                    if (vehType > vehModelsD.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckVehicle(vehModelsD[listNum]))
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        return;
                    }

                    else
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        isSpawning = true;
                        carModel = vehModelsD[listNum];

                        driverModel = driverModelsD[listNum];
                        pass1Model = passengers1D[listNum];
                        pass2Model = passengers2D[listNum];
                        pass3Model = passengers3D[listNum];

                        dWeap = (int)driverWeapD[listNum];
                        p1Weap = (int)pass1WeapD[listNum];
                        p2Weap = (int)pass2WeapD[listNum];
                        p3Weap = (int)pass3WeapD[listNum];
                        SpawnPigs();
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 4) && !IS_WANTED_LEVEL_GREATER(PlayerIndex, 5) && FiveStarOn)
                {
                    vehCount = vehModelsE.Count();
                    if (vehType > vehModelsE.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckVehicle(vehModelsE[listNum]))
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        return;
                    }

                    else
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        isSpawning = true;
                        carModel = vehModelsE[listNum];

                        driverModel = driverModelsE[listNum];
                        pass1Model = passengers1E[listNum];
                        pass2Model = passengers2E[listNum];
                        pass3Model = passengers3E[listNum];

                        dWeap = (int)driverWeapE[listNum];
                        p1Weap = (int)pass1WeapE[listNum];
                        p2Weap = (int)pass2WeapE[listNum];
                        p3Weap = (int)pass3WeapE[listNum];
                        SpawnPigs();
                    }
                }

                else if (IS_WANTED_LEVEL_GREATER(PlayerIndex, 5) && SixStarOn)
                {
                    vehCount = vehModelsF.Count();
                    if (vehType > vehModelsF.Count())
                        vehType = 0;

                    listNum = (vehCount - (vehCount - vehType));

                    if (!CheckVehicle(vehModelsF[listNum]))
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        return;
                    }

                    else
                    {
                        canSpawnA = false;
                        canSpawnB = false;
                        canSpawnC = false;
                        canSpawnD = false;
                        isSpawning = true;
                        carModel = vehModelsF[listNum];

                        driverModel = driverModelsF[listNum];
                        pass1Model = passengers1F[listNum];
                        pass2Model = passengers2F[listNum];
                        pass3Model = passengers3F[listNum];

                        dWeap = (int)driverWeapF[listNum];
                        p1Weap = (int)pass1WeapF[listNum];
                        p2Weap = (int)pass2WeapF[listNum];
                        p3Weap = (int)pass3WeapF[listNum];
                        SpawnPigs();
                    }
                }
            }
            TheDelayedCaller.Process();
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

            TheDelayedCaller.Add(TimeSpan.FromSeconds(timeToSpawn), "Main", () =>
            {
                if (HAS_MODEL_LOADED(GET_HASH_KEY(carModel)) && HAS_MODEL_LOADED(GET_HASH_KEY(driverModel)))
                {
                    CREATE_CAR(GET_HASH_KEY(carModel), PlayerPos.Around(SpawnDist), out v, true);

                    GET_CAR_COORDINATES(v, out vPos);
                    GET_CLOSEST_CAR_NODE_WITH_HEADING(vPos, out nodePos, out nodeHdng);
                    SET_CAR_COORDINATES(v, nodePos);
                    SET_CAR_HEADING(v, nodeHdng);
                    SET_CAR_FORWARD_SPEED(v, 10f);
                    veh = NativeWorld.GetVehicleInstanceFromHandle(v);
                    veh.PlaceOnGroundProperly();

                    CREATE_CHAR_INSIDE_CAR(v, 3, (uint)GET_HASH_KEY(driverModel), out p1);
                    if (HAS_MODEL_LOADED(GET_HASH_KEY(pass1Model)))
                        CREATE_CHAR_AS_PASSENGER(v, 3, (uint)GET_HASH_KEY(pass1Model), 0, out p2);

                    CheckPedComponents(driverModel, p1);
                    CheckPedComponents(pass1Model, p2);
                    if (debug)
                        IVGame.ShowSubtitleMessage("Spawned " + carModel + "  " + vehType.ToString() + "  " + vehCount.ToString());
                    if (dWeap > 0)
                        GIVE_WEAPON_TO_CHAR(p1, dWeap, -1, true);
                    if (p1Weap > 0)
                        GIVE_WEAPON_TO_CHAR(p2, p1Weap, -1, true);

                    SET_CHAR_WILL_DO_DRIVEBYS(p1, true);
                    SET_CHAR_WILL_DO_DRIVEBYS(p2, true);

                    SET_PED_PATH_MAY_DROP_FROM_HEIGHT(p1, true);
                    SET_PED_PATH_MAY_DROP_FROM_HEIGHT(p2, true);

                    SET_PED_PATH_MAY_USE_CLIMBOVERS(p1, true);
                    SET_PED_PATH_MAY_USE_CLIMBOVERS(p2, true);

                    SET_PED_PATH_MAY_USE_LADDERS(p1, true);
                    SET_PED_PATH_MAY_USE_LADDERS(p2, true);

                    MARK_CAR_AS_NO_LONGER_NEEDED(v);
                    MARK_CHAR_AS_NO_LONGER_NEEDED(p1);
                    MARK_CHAR_AS_NO_LONGER_NEEDED(p2);

                    if (veh.GetMaximumNumberOfPassengers() > 1)
                    {
                        if (HAS_MODEL_LOADED(GET_HASH_KEY(pass2Model)))
                            CREATE_CHAR_AS_PASSENGER(v, 3, (uint)GET_HASH_KEY(pass2Model), 1, out p3);
                        if (HAS_MODEL_LOADED(GET_HASH_KEY(pass3Model)))
                            CREATE_CHAR_AS_PASSENGER(v, 3, (uint)GET_HASH_KEY(pass3Model), 2, out p4);

                        CheckPedComponents(pass2Model, p3);
                        CheckPedComponents(pass3Model, p4);

                        if (p2Weap > 0)
                            GIVE_WEAPON_TO_CHAR(p3, p2Weap, -1, true);
                        if (p3Weap > 0)
                            GIVE_WEAPON_TO_CHAR(p4, p3Weap, -1, true);

                        SET_CHAR_WILL_DO_DRIVEBYS(p3, true);
                        SET_CHAR_WILL_DO_DRIVEBYS(p4, true);

                        SET_PED_PATH_MAY_DROP_FROM_HEIGHT(p3, true);
                        SET_PED_PATH_MAY_DROP_FROM_HEIGHT(p4, true);

                        SET_PED_PATH_MAY_USE_CLIMBOVERS(p3, true);
                        SET_PED_PATH_MAY_USE_CLIMBOVERS(p4, true);

                        SET_PED_PATH_MAY_USE_LADDERS(p3, true);
                        SET_PED_PATH_MAY_USE_LADDERS(p4, true);

                        MARK_CHAR_AS_NO_LONGER_NEEDED(p3);
                        MARK_CHAR_AS_NO_LONGER_NEEDED(p4);
                    }

                    if (vehType < (vehCount - 1))
                        vehType++;
                    else
                        vehType = 0;

                    isSpawning = false;
                }
            });
        }
    }
}
