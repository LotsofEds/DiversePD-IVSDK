using CCL;
using CCL.GTAIV;
using IVSDKDotNet;
using IVSDKDotNet.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static IVSDKDotNet.Native.Natives;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        private static Vector3 nodePos;
        private static float nodeHdng;
        private static bool debug;
        IVVehicle veh;

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
        private static int timeToSpawn = 20;
        private static float SpawnDist;

        private static int wantedIndex;
        private static int listNum;
        private static int vehCount;

        private static uint gTimer;
        private static uint fTimer;
        private static uint island;

        private static WantedLevelData[] wantedLevelDatas;

        private static List<PedData> pedDatas = new List<PedData>();

        private static readonly List<string> vehBroker = new List<string>();
        private static readonly List<string> vehBohan = new List<string>();
        private static readonly List<string> vehAlgonquin = new List<string>();
        private static readonly List<string> vehAlderney = new List<string>();

        private static eWeather Wthr;
        private static bool isRaining => (Wthr == eWeather.WEATHER_RAINING || Wthr == eWeather.WEATHER_LIGHTNING || Wthr == eWeather.WEATHER_DRIZZLE);
        public Main()
        {
            Initialized += Main_Initialized;
            Uninitialize += Main_Uninitialize;
            Tick += Main_Tick;
        }

        private void Main_Uninitialize(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                wantedLevelDatas[i].vehModels.Clear();
                wantedLevelDatas[i].driverModels.Clear();
                wantedLevelDatas[i].passengers1.Clear();
                wantedLevelDatas[i].passengers2.Clear();
                wantedLevelDatas[i].passengers3.Clear();
                wantedLevelDatas[i].driverWeap.Clear();
                wantedLevelDatas[i].pass1Weap.Clear();
                wantedLevelDatas[i].pass2Weap.Clear();
                wantedLevelDatas[i].pass3Weap.Clear();
            }

            pedDatas.Clear();
        }
        private void Main_Initialized(object sender, EventArgs e)
        {
            wantedLevelDatas = new WantedLevelData[7];
            LoadINI(Settings);
        }
        private void AddPedData(SettingsFile settings, string pedModel)
        {
            bool alreadyAdded = false;
            foreach (PedData pedDat in pedDatas)
            {
                if (pedDat.ModelName == pedModel)
                {
                    alreadyAdded = true;
                    break;
                }
            }

            if (!alreadyAdded)
            {
                pedDatas.Add(new PedData(pedModel));

                foreach (PedData pedDat in pedDatas)
                {
                    if (pedDat.ModelName == pedModel)
                    {
                        string CompSpawnType = settings.GetValue(pedModel, "CompSpawnType", "");
                        string PropSpawnType = settings.GetValue(pedModel, "PropSpawnType", "");

                        string CompIDString = settings.GetValue(pedModel, "CompIndex", "");
                        string CompMdlString = settings.GetValue(pedModel, "CompModels", "");
                        string CompTxdString = settings.GetValue(pedModel, "CompTxds", "");

                        string PropIDString = settings.GetValue(pedModel, "PropIndex", "");
                        string PropMdlString = settings.GetValue(pedModel, "PropModels", "");

                        string RainCompSpawnType = settings.GetValue(pedModel, "RainCompSpawnType", "");
                        string RainPropSpawnType = settings.GetValue(pedModel, "RainPropSpawnType", "");

                        string RainCompIDString = settings.GetValue(pedModel, "RainCompIndex", "");
                        string RainCompMdlString = settings.GetValue(pedModel, "RainCompModels", "");
                        string RainCompTxdString = settings.GetValue(pedModel, "RainCompTxds", "");

                        string RainPropIDString = settings.GetValue(pedModel, "RainPropIndex", "");
                        string RainPropMdlString = settings.GetValue(pedModel, "RainPropModels", "");

                        pedDat.CompSpawnType = CompSpawnType.Split(',').Select(int.Parse).ToList();
                        pedDat.PropSpawnType = PropSpawnType.Split(',').Select(int.Parse).ToList();

                        pedDat.CompIDs = CompIDString.Split(',').Select(int.Parse).ToList();
                        pedDat.CompMdls = CompMdlString.Split(',').Select(int.Parse).ToList();
                        pedDat.CompTxds = CompTxdString.Split(',').Select(int.Parse).ToList();

                        pedDat.PropIDs = PropIDString.Split(',').Select(int.Parse).ToList();
                        pedDat.PropMdls = PropMdlString.Split(',').Select(int.Parse).ToList();

                        pedDat.RainCompSpawnType = RainCompSpawnType.Split(',').Select(int.Parse).ToList();
                        pedDat.RainPropSpawnType = RainPropSpawnType.Split(',').Select(int.Parse).ToList();

                        pedDat.RainCompIDs = RainCompIDString.Split(',').Select(int.Parse).ToList();
                        pedDat.RainCompMdls = RainCompMdlString.Split(',').Select(int.Parse).ToList();
                        pedDat.RainCompTxds = RainCompTxdString.Split(',').Select(int.Parse).ToList();

                        pedDat.RainPropIDs = RainPropIDString.Split(',').Select(int.Parse).ToList();
                        pedDat.RainPropMdls = RainPropMdlString.Split(',').Select(int.Parse).ToList();

                        pedDat.GiveHelmet = settings.GetBoolean(pedModel, "GiveHelmetIfOnBike", false);
                    }
                }
            }
        }
        private void LoadINI(SettingsFile settings)
        {
            SpawnDist = settings.GetFloat("MAIN", "Spawn Distance", 120f);
            debug = settings.GetBoolean("MAIN", "Debug", false);

            for (int i = 0; i < 7; i++)
            {
                wantedLevelDatas[i] = new WantedLevelData();

                wantedLevelDatas[i].timeToSpawn = settings.GetInteger(i.ToString() + " STAR", "Time to Spawn", 30);

                string vehString = settings.GetValue(i.ToString() + " STAR", "Vehicle Models", "");
                string driverString = settings.GetValue(i.ToString() + " STAR", "Driver Models", "");
                string pass1String = settings.GetValue(i.ToString() + " STAR", "Front Passenger Models", "");
                string pass2String = settings.GetValue(i.ToString() + " STAR", "Back Left Passenger Models", "");
                string pass3String = settings.GetValue(i.ToString() + " STAR", "Back Right Passenger Models", "");
                string dWeapString = settings.GetValue(i.ToString() + " STAR", "Driver Weapon", "");
                string p1WeapString = settings.GetValue(i.ToString() + " STAR", "Front Passenger Weapon", "");
                string p2WeapString = settings.GetValue(i.ToString() + " STAR", "Back Left Passenger Weapon", "");
                string p3WeapString = settings.GetValue(i.ToString() + " STAR", "Back Right Passenger Weapon", "");

                foreach (var modelName in vehString.Split(','))
                    wantedLevelDatas[i].vehModels.Add(modelName.ToString());

                foreach (var modelName in driverString.Split(','))
                {
                    wantedLevelDatas[i].driverModels.Add(modelName.ToString());

                    if (settings.DoesSectionExists(modelName))
                        AddPedData(Settings, modelName);
                }

                foreach (var modelName in pass1String.Split(','))
                {
                    wantedLevelDatas[i].passengers1.Add(modelName.ToString());

                    if (settings.DoesSectionExists(modelName))
                        AddPedData(Settings, modelName);
                }

                foreach (var modelName in pass2String.Split(','))
                {
                    wantedLevelDatas[i].passengers2.Add(modelName.ToString());

                    if (settings.DoesSectionExists(modelName))
                        AddPedData(Settings, modelName);
                }

                foreach (var modelName in pass3String.Split(','))
                {
                    wantedLevelDatas[i].passengers3.Add(modelName.ToString());

                    if (settings.DoesSectionExists(modelName))
                        AddPedData(Settings, modelName);
                }

                foreach (var modelName in dWeapString.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    wantedLevelDatas[i].driverWeap.Add(weaponType);
                }
                foreach (var modelName in p1WeapString.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    wantedLevelDatas[i].pass1Weap.Add(weaponType);
                }
                foreach (var modelName in p2WeapString.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    wantedLevelDatas[i].pass2Weap.Add(weaponType);
                }
                foreach (var modelName in p3WeapString.Split(','))
                {
                    eWeaponType weaponType = (eWeaponType)Enum.Parse(typeof(eWeaponType), modelName.Trim(), true);
                    wantedLevelDatas[i].pass3Weap.Add(weaponType);
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
            bool brokerSpawn = false;
            bool bohanSpawn = false;
            bool algonquinSpawn = false;
            bool alderneySpawn = false;

            foreach (string vehString in vehBroker)
            {
                if (vehToSpawn == vehString)
                {
                    brokerSpawn = true;
                    break;
                }
            }
            foreach (string vehString in vehBohan)
            {
                if (vehToSpawn == vehString)
                    bohanSpawn = true;
            }
            foreach (string vehString in vehAlgonquin)
            {
                if (vehToSpawn == vehString)
                    algonquinSpawn = true;
            }
            foreach (string vehString in vehAlderney)
            {
                if (vehToSpawn == vehString)
                    alderneySpawn = true;
            }

            if (island == 0 && brokerSpawn)
                return true;

            else if (island == 1 && bohanSpawn)
                return true;

            else if (island == 2 && algonquinSpawn)
                return true;

            else if (island == 3 && alderneySpawn)
                return true;

            else if (!brokerSpawn && !bohanSpawn && !algonquinSpawn && !alderneySpawn)
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
        private bool CheckVehModel(string model)
        {
            if (IS_MODEL_IN_CDIMAGE(GET_HASH_KEY(model)) && IS_THIS_MODEL_A_VEHICLE((uint)GET_HASH_KEY(model)))
            {
                if (!HAS_MODEL_LOADED(GET_HASH_KEY(model)))
                    REQUEST_MODEL(GET_HASH_KEY(model));
                return true;
            }
            else
            {
                IVGame.Console.PrintError(model + " is not a valid vehicle model.");
                return false;
            }
        }
        private bool CheckPedModel(string model)
        {
            if (IS_MODEL_IN_CDIMAGE(GET_HASH_KEY(model)) && IS_THIS_MODEL_A_PED((uint)GET_HASH_KEY(model)))
            {
                if (!HAS_MODEL_LOADED(GET_HASH_KEY(model)))
                    REQUEST_MODEL(GET_HASH_KEY(model));
                return true;
            }
            else
            {
                IVGame.Console.PrintError(model + " is not a valid ped model.");
                return false;
            }
        }
        private void CheckPedComponents(string pedModel, int pedHandl)
        {
            foreach (PedData pedDat in pedDatas)
            {
                if (pedDat.ModelName == pedModel)
                {
                    Wthr = NativeWorld.CurrentWeather;

                    SET_CHAR_RANDOM_COMPONENT_VARIATION(pedHandl);

                    // Ped Comps
                    for (int i = 0; i < pedDat.CompSpawnType.Count; i++)
                    {
                        int spawnChance = GENERATE_RANDOM_INT_IN_RANGE(0, 2);
                        uint compVar = GET_CHAR_DRAWABLE_VARIATION(pedHandl, pedDat.CompIDs[i]);

                        if (pedDat.CompSpawnType[i] == 0)
                            spawnChance = 0;
                        else if (pedDat.CompSpawnType[i] == 2)
                            spawnChance = 1;

                        if (pedDat.CompMdls[i] != -1 && spawnChance != 0)
                        {
                            if (pedDat.CompTxds[i] == -1)
                            {
                                uint texCount = GET_NUMBER_OF_CHAR_TEXTURE_VARIATIONS(pedHandl, (uint)pedDat.CompIDs[i], (uint)pedDat.CompMdls[i]);
                                int texVar = GENERATE_RANDOM_INT_IN_RANGE(0, (int)texCount);

                                SET_CHAR_COMPONENT_VARIATION(pedHandl, (uint)pedDat.CompIDs[i], (uint)pedDat.CompMdls[i], (uint)texVar);
                            }
                            else
                                SET_CHAR_COMPONENT_VARIATION(pedHandl, (uint)pedDat.CompIDs[i], (uint)pedDat.CompMdls[i], (uint)pedDat.CompTxds[i]);
                        }

                        else if (pedDat.CompMdls[i] != -1 && compVar == pedDat.CompMdls[i])
                            SET_CHAR_DEFAULT_COMPONENT_VARIATION(pedHandl);
                    }

                    // Rain Comps
                    for (int i = 0; i < pedDat.RainCompSpawnType.Count; i++)
                    {
                        int spawnChance = GENERATE_RANDOM_INT_IN_RANGE(0, 2);
                        uint compVar = GET_CHAR_DRAWABLE_VARIATION(pedHandl, pedDat.RainCompIDs[i]);

                        if (pedDat.RainCompSpawnType[i] == 0)
                            spawnChance = 0;
                        else if (pedDat.RainCompSpawnType[i] == 2)
                            spawnChance = 1;

                        if (isRaining && pedDat.RainCompMdls[i] != -1 && spawnChance != 0)
                        {
                            if (pedDat.RainCompTxds[i] == -1)
                            {
                                uint texCount = GET_NUMBER_OF_CHAR_TEXTURE_VARIATIONS(pedHandl, (uint)pedDat.RainCompIDs[i], (uint)pedDat.RainCompMdls[i]);
                                int texVar = GENERATE_RANDOM_INT_IN_RANGE(0, (int)texCount);

                                SET_CHAR_COMPONENT_VARIATION(pedHandl, (uint)pedDat.RainCompIDs[i], (uint)pedDat.RainCompMdls[i], (uint)texVar);
                            }
                            else
                                SET_CHAR_COMPONENT_VARIATION(pedHandl, (uint)pedDat.RainCompIDs[i], (uint)pedDat.RainCompMdls[i], (uint)pedDat.RainCompTxds[i]);
                        }

                        else if (!isRaining && pedDat.RainCompMdls[i] != -1 && compVar == pedDat.RainCompMdls[i])
                            SET_CHAR_DEFAULT_COMPONENT_VARIATION(pedHandl);
                    }

                    // Ped Props
                    for (int i = 0; i < pedDat.PropSpawnType.Count; i++)
                    {
                        int spawnChance = GENERATE_RANDOM_INT_IN_RANGE(0, 2);
                        GET_CHAR_PROP_INDEX(pedHandl, pedDat.RainPropIDs[i], out int pedProp);

                        if (pedDat.PropSpawnType[i] == 0)
                            spawnChance = 0;
                        else if (pedDat.PropSpawnType[i] == 2)
                            spawnChance = 1;

                        if (pedDat.PropMdls[i] != -1 && spawnChance != 0)
                            SET_CHAR_PROP_INDEX(pedHandl, (uint)i, (uint)pedDat.PropMdls[i]);
                        else if (pedDat.PropMdls[i] != -1 && pedProp == pedDat.PropMdls[i])
                            CLEAR_CHAR_PROP(pedHandl, i);
                    }

                    // Rain Props
                    for (int i = 0; i < pedDat.RainPropSpawnType.Count; i++)
                    {
                        int spawnChance = GENERATE_RANDOM_INT_IN_RANGE(0, 2);
                        GET_CHAR_PROP_INDEX(pedHandl, pedDat.RainPropIDs[i], out int pedProp);

                        if (pedDat.RainPropSpawnType[i] == 0)
                            spawnChance = 0;
                        else if (pedDat.RainPropSpawnType[i] == 2)
                            spawnChance = 1;

                        if (isRaining && pedDat.RainPropMdls[i] != -1 && spawnChance != 0)
                            SET_CHAR_PROP_INDEX(pedHandl, (uint)i, (uint)pedDat.RainPropMdls[i]);

                        else if (!isRaining && pedDat.RainPropMdls[i] != -1 && pedProp == pedDat.RainPropMdls[i])
                            CLEAR_CHAR_PROP(pedHandl, i);
                    }
                }

                if (pedDat.GiveHelmet && IS_CHAR_ON_ANY_BIKE(pedHandl))
                    GIVE_PED_HELMET(pedHandl);
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
        private void CheckListCount(int index)
        {
            vehCount = wantedLevelDatas[index].vehModels.Count();
            if (vehType >= wantedLevelDatas[index].vehModels.Count())
                vehType = 0;

            listNum = (vehCount - (vehCount - vehType));
        }
        private void SpawnPigs()
        {
            if (!CheckVehModel(carModel))
            {
                isSpawning = false;
                if (vehType < (vehCount - 1))
                    vehType++;
                else
                    vehType = 0;
            }
            if (!CheckPedModel(driverModel))
                driverModel = "M_Y_COP";

            if (pass1Model != "none")
                if (!CheckPedModel(pass1Model))
                    pass1Model = "M_Y_COP";

            if (pass2Model != "none")
                if (!CheckPedModel(pass2Model))
                    pass2Model = "M_Y_COP";

            if (pass3Model != "none")
                if (!CheckPedModel(pass3Model))
                    pass3Model = "M_Y_COP";

            if (gTimer >= (fTimer + (timeToSpawn * 1000)))
            {
                if (HAS_MODEL_LOADED(GET_HASH_KEY(carModel)) && HAS_MODEL_LOADED(GET_HASH_KEY(driverModel)))
                {
                    bool isBoat = false;
                    bool isFlying = false;
                    if (IS_THIS_MODEL_A_BOAT((uint)GET_HASH_KEY(carModel)))
                        isBoat = true;
                    if (IS_THIS_MODEL_A_HELI((uint)GET_HASH_KEY(carModel)) || IS_THIS_MODEL_A_PLANE((uint)GET_HASH_KEY(carModel)))
                        isFlying = true;

                    if (isFlying || (isBoat && GET_RANDOM_WATER_NODE(PlayerPos.X, PlayerPos.Y, PlayerPos.Z, SpawnDist + 10.0f, true, true, false, false, out nodePos.X, out nodePos.Y, out nodePos.Z, out nodeHdng)) || (!isBoat && GET_RANDOM_CAR_NODE(PlayerPos.X, PlayerPos.Y, PlayerPos.Z, SpawnDist + 10.0f, true, true, false, out nodePos.X, out nodePos.Y, out nodePos.Z, out nodeHdng)))
                    {
                        if (isFlying)
                        {
                            nodePos = PlayerPos.Around(SpawnDist);
                            nodePos.Z = PlayerPos.Z;
                        }

                        if ((nodePos - PlayerPos).Length() >= SpawnDist)
                        {
                            if (isFlying)
                            {
                                GET_GROUND_Z_FOR_3D_COORD(nodePos, out float groundZ);
                                if (groundZ >= 50)
                                    nodePos.Z = 30 + groundZ;
                                else
                                    nodePos.Z = 80;
                            }

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
                                if (pass1Model != "none")
                                {
                                    if (HAS_MODEL_LOADED(GET_HASH_KEY(pass1Model)))
                                        CREATE_CHAR_AS_PASSENGER(v, 3, (uint)GET_HASH_KEY(pass1Model), 0, out p2);

                                    SpawnPedInVeh(pass1Model, p2, p1Weap);
                                }

                                if (veh.GetMaximumNumberOfPassengers() > 1 && pass2Model != "none")
                                {
                                    if (HAS_MODEL_LOADED(GET_HASH_KEY(pass2Model)))
                                        CREATE_CHAR_AS_PASSENGER(v, 3, (uint)GET_HASH_KEY(pass2Model), 1, out p3);

                                    SpawnPedInVeh(pass2Model, p3, p2Weap);
                                }
                                if (veh.GetMaximumNumberOfPassengers() > 2 && pass3Model != "none")
                                {
                                    if (HAS_MODEL_LOADED(GET_HASH_KEY(pass3Model)))
                                        CREATE_CHAR_AS_PASSENGER(v, 3, (uint)GET_HASH_KEY(pass3Model), 2, out p4);

                                    SpawnPedInVeh(pass3Model, p4, p3Weap);
                                }
                            }

                            MARK_CAR_AS_NO_LONGER_NEEDED(v);

                            isSpawning = false;

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
                    }

                    if (vehType < (vehCount - 1))
                        vehType++;
                    else
                        vehType = 0;
                }
                else
                    return;
            }
        }
        private void Main_Tick(object sender, EventArgs e)
        {
            PlayerPed = IVPed.FromUIntPtr(IVPlayerInfo.FindThePlayerPed());
            PlayerIndex = (int)GET_PLAYER_ID();
            PlayerHandle = PlayerPed.GetHandle();
            PlayerPos = PlayerPed.Matrix.Pos;

            GET_GAME_TIMER(out gTimer);

            if (!isSpawning)
            {
                island = GET_MAP_AREA_FROM_COORDS(PlayerPos.X, PlayerPos.Y, PlayerPos.Z);

                for (int i = 0; i < 7; i++)
                {
                    if ((i == 0 && !IS_WANTED_LEVEL_GREATER(PlayerIndex, (uint)i)) || (i > 0 && IS_WANTED_LEVEL_GREATER(PlayerIndex, (uint)(i - 1)) && !IS_WANTED_LEVEL_GREATER(PlayerIndex, (uint)i)))
                    {
                        timeToSpawn = wantedLevelDatas[i].timeToSpawn;
                        CheckListCount(i);

                        if (!CheckVehicle(wantedLevelDatas[i].vehModels[listNum]))
                        {
                            if (debug)
                                IVGame.ShowSubtitleMessage(wantedLevelDatas[i].vehModels[listNum] + " cannot spawn in this island.");
                            return;
                        }

                        else
                        {
                            wantedIndex = i;
                            GET_GAME_TIMER(out fTimer);
                            isSpawning = true;
                        }
                    }
                }
            }
            else
            {
                CheckListCount(wantedIndex);

                if (!CheckVehicle(wantedLevelDatas[wantedIndex].vehModels[listNum]))
                {
                    if (debug)
                        IVGame.ShowSubtitleMessage(wantedLevelDatas[wantedIndex].vehModels[listNum] + " cannot spawn in this island.");

                    isSpawning = false;
                    return;
                }

                carModel = wantedLevelDatas[wantedIndex].vehModels[listNum];

                driverModel = wantedLevelDatas[wantedIndex].driverModels[listNum];
                pass1Model = wantedLevelDatas[wantedIndex].passengers1[listNum];
                pass2Model = wantedLevelDatas[wantedIndex].passengers2[listNum];
                pass3Model = wantedLevelDatas[wantedIndex].passengers3[listNum];

                dWeap = (int)wantedLevelDatas[wantedIndex].driverWeap[listNum];
                p1Weap = (int)wantedLevelDatas[wantedIndex].pass1Weap[listNum];
                p2Weap = (int)wantedLevelDatas[wantedIndex].pass2Weap[listNum];
                p3Weap = (int)wantedLevelDatas[wantedIndex].pass3Weap[listNum];

                SpawnPigs();
            }
        }
    }
}
