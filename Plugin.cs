using BepInEx;
using HarmonyLib;
using HutongGames.PlayMaker.Actions;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using static HutongGames.PlayMaker.Actions.SendMessage;
using static System.Net.Mime.MediaTypeNames;
using HutongGames.Utility;
using System.Xml.Linq;
using System.Diagnostics;
using System.Drawing;
using OmegaFallon.KittyHorrorshowTranslations;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Logging;
using HutongGames.PlayMaker;

namespace KittyHorrorshowTranslations
{
    // To be tested
    [BepInProcess("village_win.exe")] // 

    // Fully works under x86
    [BepInProcess("actias.exe")] // 5.2.0
    [BepInProcess("ccccccc.exe")] // 5.0.2
    [BepInProcess("Anatomy.exe")] // 5.2.0

    [BepInProcess("grandmother.exe")] // 5.2.0
    [BepInProcess("Leechbowl.exe")] // 5.2.0
    [BepInProcess("pente.exe")] // 5.2.0

    [BepInProcess("Gloompuke.exe")] // 5.3.5
    [BepInProcess("Scarlet.exe")] // 5.3.5

    [BepInProcess("Acro.exe")] // 
    [BepInProcess("archlake_win.exe")] // 
    [BepInProcess("artery.exe")] // 
    [BepInProcess("BAST.exe")] // 
    [BepInProcess("Charon.exe")] // 
    [BepInProcess("cyberskull.exe")] // 
    [BepInProcess("factory.exe")] // 
    [BepInProcess("aurelia.exe")] // 
    [BepInProcess("skin.exe")] // 
    [BepInProcess("stormsea.exe")] // 5.1.1
    [BepInProcess("vaporcrane_win.exe")] // 5.1.1
    [BepInProcess("wraith.exe")] // 
    [BepInProcess("wraithshead.exe")] // 

    // Fully works under x86 with code that avoids the mouse lock crash
    [BepInProcess("sigilvalley.exe")] // 4.6.3
    [BepInProcess("sigilvalley_64bit.exe")] // 4.6.3
    [BepInProcess("sunset.exe")] // 4.6.3
    [BepInProcess("rainhouse.exe")] // 4.6.3
    [BepInProcess("CHYRZA.exe")] // 4.3.3

    // Fully works under x64
    [BepInProcess("Monastery.exe")] // 5.4.3
    [BepInProcess("Roads.exe")] // 5.4.3

    [BepInProcess("amalia.exe")] // 
    [BepInProcess("Dust.exe")] // 
    [BepInProcess("Erosion.exe")] // 
    [BepInProcess("GES_Final.exe")] // 
    [BepInProcess("GYR.exe")] // 
    [BepInProcess("Needlerust.exe")] // 
    [BepInProcess("Sieve.exe")] // 
    [BepInProcess("Spine.exe")] // 
    [BepInProcess("Tin.exe")] // 5.4.3

    // Must be in their own separate folder; has a UnityPlayer.dll
    [BepInProcess("basements.exe")] // 2017.4.2
    [BepInProcess("wormclot.exe")] // 2017.4.2
    [BepInProcess("GhostLake.exe")] // unknown
    [BepInProcess("seven.exe")] // 2017.4.2

    [BepInProcess("exclusion.exe")] // 2017.4.2
    [BepInProcess("Grandmother's Garden.exe")] // 2017.4.2
    [BepInProcess("Lethargy Hill.exe")] // 2019.2.0
    [BepInProcess("Tenement.exe")] // 2017.4.2

    [BepInProcess("Living Room.exe")] // 2019.4.0
    [BepInProcess("Decommissioned City #65.exe")] // 2021.2.14
    [BepInProcess("bhk.exe")] // 
    [BepInProcess("complex.exe")] // 
    [BepInProcess("zerega.exe")] // 

    // The plugin itself //
    [BepInPlugin("OmegaFallon.KittyHorrorshowTranslations", "Kitty Horrorshow Translations", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;
        
        public void Awake()
        {
            Instance = this;

            // Plugin startup logic
            Logger.LogInfo($"Plugin {"OmegaFallon.KittyHorrorshowTranslations"} is loaded!");

            // Load what game this is
            runningGame = Paths.ProcessName;
            runningGame = char.ToUpper(runningGame[0]) + runningGame.Substring(1);
            Logger.LogInfo("Current running game is " + runningGame);

            // Unity patches
            try
            {
                Harmony.CreateAndPatchAll(typeof(UnityPatches));
            }
            catch (Exception ex) 
            {
                Logger.LogInfo("Error in doing Unity patches: " + ex.ToString());
            }

            // Hutong patches
            switch (runningGame)
            {
                case "CHYRZA":
                case "Wraith":
                case "Village":
                case "Village_win":
                case "Bhk":
                    break;
                default:
                    try
                    {
                        Harmony.CreateAndPatchAll(typeof(HutongPatches));
                    }
                    catch (Exception ex)
                    {
                        Logger.LogInfo("Error in doing Hutong patches: " + ex.ToString());
                    }
                    break;
            }
            
            // Add .cs files and Harmony patches for individual games
            switch (runningGame)
            {
                case "Actias":
                    gameObject.AddComponent<Actias>();
                    break;
                case "Anatomy":
                    gameObject.AddComponent<Anatomy>();
                    gameObject.AddComponent<Anatomy_Subtitles>();
                    break;
                case "CHYRZA":
                    gameObject.AddComponent<CHYRZA>();
                    break;
                case "Exclusion":
                    gameObject.AddComponent<Exclusion>();
                    break;
                case "Gloompuke":
                    Harmony.CreateAndPatchAll(typeof(Gloompuke.GloompukePatches));
                    gameObject.AddComponent<Gloompuke>();
                    break;
                case "Grandmother":
                    gameObject.AddComponent<Grandmother>();
                    break;
                case "Leechbowl":
                    gameObject.AddComponent<Leechbowl>();
                    break;
                case "Sunset":
                    gameObject.AddComponent<Sunset>();
                    break;
            }

            gameObject.AddComponent<MiscGames>();
        }

        public void PrintThisString(string str)
        {
            Logger.LogInfo(str);
        }

        public string runningGame;
        public string gameLanguage = "";
        public bool guiDimensionsPrinted;

        public void UnlockCursor()
        {
            if (cursorErrorSkip != true)
            {
                try
                {
                    Meta_UnlockCursor();
                }
                catch
                {
                    cursorErrorSkip = true;
                    Logger.LogInfo("Inconsequential error: UnlockCursor failed likely due to this being a 4.x game.");
                }
            }
        }
        public void LockCursor()
        {
            if (cursorErrorSkip != true)
            {
                try
                {
                    Meta_LockCursor();
                }
                catch
                {
                    cursorErrorSkip = true;
                    Logger.LogInfo("Inconsequential error: LockCursor failed likely due to this being a 4.x game.");
                }
            }
        }
        public void Meta_UnlockCursor()
        {
            if (Cursor.lockState != CursorLockMode.None || Cursor.visible != true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Logger.LogInfo("Cursor unlocked.");
            }
        }

        public void Meta_LockCursor()
        {
            if (Cursor.lockState != CursorLockMode.Locked || Cursor.visible != false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Logger.LogInfo("Cursor locked.");
            }
        }

        public bool nineDown;
        public bool titleCardHackDone;
        public int updateCounterAtLastDebugLevelLoad;
        public void Update()
        {
            // Update counter
            updateCounter += 1;

            // DEBUG! Comment out in final release
            if (Input.GetKeyUp(KeyCode.Alpha9))
            {
                nineDown = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha9) && nineDown == false)
            {
                nineDown = true;

                Logger.LogInfo("Running debug replacements...");
                TextureAudioReplacement(true);
                FsmStringReplacement();
                Logger.LogInfo("Done with debug replacements.");
            }

            // Debug level loading
            if (Plugin.Instance.updateCounter - updateCounterAtLastDebugLevelLoad < 2)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Plugin.Instance.Logger.LogInfo("L is pressed.");
                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(0);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(1);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(2);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(3);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(4);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(5);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(6);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(7);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(8);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    updateCounterAtLastDebugLevelLoad = Plugin.Instance.updateCounter;
                    UnityEngine.Application.LoadLevel(9);
                }
            }

            // Hacky thing that makes texture replacements work on games with a little opening title card
            string[] titleCardGames = ["Rainhouse","Actias"];
            if (Array.IndexOf(titleCardGames, runningGame) != -1 && titleCardHackDone != true)
            {
                FsmStringReplacement();
                TextureAudioReplacement();

                if (imagesRanThrough > 1)
                {
                    titleCardHackDone = true;
                }
            }

            // Getting the game font?
            if (runningGameFont == null)
            {
                //Logger.LogInfo("Trying to find a game font...");
                //runningGameFont = (UnityEngine.Font)FindObjectOfType(typeof(UnityEngine.Font));
                //runningGameFont = Resources.FindObjectsOfTypeAll(typeof(UnityEngine.Font))[0].GetComponent<UnityEngine.Font>();

                if (runningGameFont == null)
                {
                    Logger.LogInfo("Found a game font, setting it as runningGameFont: " + runningGameFont.name);
                }
            }
        }

        public int notNeededButtonFrames;

        public bool cursorErrorSkip;
        public bool subtitlesDecided;
        public bool doSubtitles;

        public bool readmeDecided;
        public bool subtitlesDecidedLetGo;

        public int titleCardStartTime;

        public void OnGUI()
        {
            try
            {
                // Creating standard button style
                GUIStyle standardButtonStyle = GUISkin.current.button;
                if (runningGameFont != null)
                {
                    //standardButtonStyle.font = runningGameFont;
                }

                // If the language has already been decided and subtitles have been decided (for games that need them), return
                if (!string.IsNullOrEmpty(gameLanguage))
                {
                    if (runningGame != "Anatomy") 
                    {
                        subtitlesDecided = true;
                    }

                    if (subtitlesDecided && readmeDecided)
                    {
                        try
                        {
                            if (titleCardStartTime == 0)
                            {
                                titleCardStartTime = updateCounter;
                            }

                            string translatedTitle = runningGame;

                            switch (runningGame)
                            {
                                case "Anatomy":
                                case "Ccccccc":
                                    return;
                                case "CHYRZA":
                                    switch (gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "チいるザ"; break;
                                    }
                                    break;
                                case "Sunset":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Crépuscule, Esprit, Acier"; break;
                                        case "Dutch": translatedTitle = "Zonsondergang, Geest, Staal"; break;
                                        case "Japanese": translatedTitle = "夕焼け、精神、鋼鉄"; break;
                                    }
                                    break;
                                case "Sigilvalley":
                                case "Sigilvalley_64bit":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Vallée des Sceaux"; break;
                                        case "Dutch": translatedTitle = "Vallei van Sigils"; break;
                                        case "Japanese": translatedTitle = "印章の谷"; break;
                                    }
                                    break;
                                case "Archlake":
                                case "Archlake_win":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Lac d'Arc"; break;
                                        case "Dutch": translatedTitle = "Meer de Boog"; break;
                                        case "Japanese": translatedTitle = "アーチの湖"; break;
                                    }
                                    break;
                                case "Rainhouse":
                                case "Rainhouse_64bit":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Pluie, Maison, Éternité"; break;
                                        case "Dutch": translatedTitle = "Regen, Huis, Eeuwigheid"; break;
                                        case "Japanese": translatedTitle = "雨、家、永遠"; break;
                                    }
                                    break;
                                case "Vaporcrane":
                                case "Vaporcrane_64bit":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Grue de Vapeur"; break;
                                        case "Dutch": translatedTitle = "Stoomkraan"; break;
                                        case "Japanese": translatedTitle = "蒸気の鶴"; break;
                                    }
                                    break;
                                case "Stormsea":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Mer des Tempêtes"; break;
                                        case "Dutch": translatedTitle = "Stormzee"; break;
                                        case "Japanese": translatedTitle = "嵐の海"; break;
                                    }
                                    break;
                                case "Skin":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Peau"; break;
                                        case "Dutch": translatedTitle = "Huid"; break;
                                        case "Japanese": translatedTitle = "肌"; break;
                                    }
                                    break;
                                case "Aurelia":
                                    switch (gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "アレリア"; break;
                                    }
                                    break;
                                case "Wraithshead":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Tête de Wraith"; break;
                                        case "Dutch": translatedTitle = "Wraith-hoofd"; break;
                                        case "Japanese": translatedTitle = "レイスの頭"; break;
                                    }
                                    break;
                                case "Wraith":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Wraith"; break;
                                        case "Dutch": translatedTitle = "Wraith"; break;
                                        case "Japanese": translatedTitle = "レイス"; break;
                                    }
                                    break;
                                case "Pente":
                                    switch (gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "ペンテイ"; break;
                                    }
                                    break;
                                case "Leechbowl":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Bol de Sangsues"; break;
                                        case "Dutch": translatedTitle = "Kom met Bloedzuigers"; break;
                                        case "Japanese": translatedTitle = "ヒルのボウル"; break;
                                    }
                                    break;
                                case "Grandmother":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Grand-mère"; break;
                                        case "Dutch": translatedTitle = "Grootmoeder"; break;
                                        case "Japanese": translatedTitle = "祖母"; break;
                                    }
                                    break;
                                case "Cyberskull":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Crâne Cyber"; break;
                                        case "Dutch": translatedTitle = "Cyberschedel"; break;
                                        case "Japanese": translatedTitle = "サイバースカル"; break;
                                    }
                                    break;
                                case "Actias":
                                    switch (gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "アクティアス"; break;
                                    }
                                    break;
                                case "Scarlet":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Écarlate"; break;
                                        case "Dutch": translatedTitle = "Scharlaken"; break;
                                        case "Japanese": translatedTitle = "スカーレット"; break;
                                    }
                                    break;
                                case "Gloompuke":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Morositévomir"; break;
                                        case "Dutch": translatedTitle = "Somberheidkots"; break;
                                        case "Japanese": translatedTitle = "憂鬱吐き気"; break;
                                    }
                                    break;
                                case "Factory":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Usine"; break;
                                        case "Dutch": translatedTitle = "Fabriek"; break;
                                        case "Japanese": translatedTitle = "工場"; break;
                                    }
                                    break;
                                case "Artery":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Artère"; break;
                                        case "Dutch": translatedTitle = "Slagader"; break;
                                        case "Japanese": translatedTitle = "動脈"; break;
                                    }
                                    break;
                                case "Amalia":
                                    switch (gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "アマリア"; break;
                                    }
                                    break;
                                case "Charon":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Charon"; break;
                                        case "Dutch": translatedTitle = "Charon"; break;
                                        case "Japanese": translatedTitle = "カローン"; break;
                                    }
                                    break;
                                case "Tin":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Étain"; break;
                                        case "Dutch": translatedTitle = "Tin"; break;
                                        case "Japanese": translatedTitle = "スズ"; break;
                                    }
                                    break;
                                case "Spine":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Échine"; break;
                                        case "Dutch": translatedTitle = "Wervelkolom"; break;
                                        case "Japanese": translatedTitle = "脊椎"; break;
                                    }
                                    break;
                                case "Sieve":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Tamis"; break;
                                        case "Dutch": translatedTitle = "Zeef"; break;
                                        case "Japanese": translatedTitle = "篩"; break;
                                    }
                                    break;
                                case "Roads":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Routes"; break;
                                        case "Dutch": translatedTitle = "Wegen"; break;
                                        case "Japanese": translatedTitle = "道路"; break;
                                    }
                                    break;
                                case "Needlerust":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Rouille des Aiguilles"; break;
                                        case "Dutch": translatedTitle = "Naaldroest"; break;
                                        case "Japanese": translatedTitle = "針の錆"; break;
                                    }
                                    break;
                                case "Monastery":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Monastère"; break;
                                        case "Dutch": translatedTitle = "Klooster"; break;
                                        case "Japanese": translatedTitle = "修道院"; break;
                                    }
                                    break;
                                case "Erosion":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Érosion"; break;
                                        case "Dutch": translatedTitle = "Erosie"; break;
                                        case "Japanese": translatedTitle = "侵食"; break;
                                    }
                                    break;
                                case "Dust":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Poussière"; break;
                                        case "Dutch": translatedTitle = "Stof"; break;
                                        case "Japanese": translatedTitle = "埃"; break;
                                    }
                                    break;
                                case "Basements":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Sous-sols"; break;
                                        case "Dutch": translatedTitle = "Kelders"; break;
                                        case "Japanese": translatedTitle = "地下3階"; break;
                                    }
                                    break;
                                case "Wormclot":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Château de Vercaillot"; break;
                                        case "Dutch": translatedTitle = "Kasteel Wormstolsel"; break;
                                        case "Japanese": translatedTitle = "虫血栓城"; break;
                                    }
                                    break;
                                case "GhostLake":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Lac Fantôme"; break;
                                        case "Dutch": translatedTitle = "Spookmeer"; break;
                                        case "Japanese": translatedTitle = "幽霊の湖"; break;
                                    }
                                    break;
                                case "Seven":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Sept Jours"; break;
                                        case "Dutch": translatedTitle = "Zeven Dagen"; break;
                                        case "Japanese": translatedTitle = "七日間"; break;
                                    }
                                    break;
                                case "Exclusion":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Zone d'Exclusion"; break;
                                        case "Dutch": translatedTitle = "Sperrgebiet"; break;
                                        case "Japanese": translatedTitle = "立入禁止区域"; break;
                                    }
                                    break;
                                case "Grandmother's Garden":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Le Jardin de Grand-mère"; break;
                                        case "Dutch": translatedTitle = "Grootmoeders Tuin"; break;
                                        case "Japanese": translatedTitle = "おばあちゃんの庭"; break;
                                    }
                                    break;
                                case "Lethargy Hill":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Colline de la Léthargie"; break;
                                        case "Dutch": translatedTitle = "Lethargie Heuvel"; break;
                                        case "Japanese": translatedTitle = "無気力の丘"; break;
                                    }
                                    break;
                                case "Tenement":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Immeuble"; break;
                                        case "Dutch": translatedTitle = "Huurkazerne"; break;
                                        case "Japanese": translatedTitle = "長屋"; break;
                                    }
                                    break;
                                case "Bhk":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Clé du Cœur Brisé"; break;
                                        case "Dutch": translatedTitle = "Gebroken Hart Sleutel"; break;
                                        case "Japanese": translatedTitle = "壊れた心の鍵"; break;
                                    }
                                    break;
                                case "Complex":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Complexe"; break;
                                        case "Dutch": translatedTitle = "Complex"; break;
                                        case "Japanese": translatedTitle = "複合"; break;
                                    }
                                    break;
                                case "Decommissioned City #65":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Ville Déclassée #65"; break;
                                        case "Dutch": translatedTitle = "Ontmantelde Stad #65"; break;
                                        case "Japanese": translatedTitle = "廃止された都市 #65"; break;
                                    }
                                    break;
                                case "Living Room":
                                    switch (gameLanguage)
                                    {
                                        case "French": translatedTitle = "Le Salon"; break;
                                        case "Dutch": translatedTitle = "Woonkamer"; break;
                                        case "Japanese": translatedTitle = "居間"; break;
                                    }
                                    break;
                                case "Zerega":
                                    switch (gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "ゾレガ"; break;
                                    }
                                    break;
                            }

                            if (updateCounter - titleCardStartTime < 5 * 60)
                            {
                                float width = (float)(Screen.width * 0.75);
                                float height = (float)(Screen.height * 0.5);
                                float x = (float)((Screen.width - width) / 2);
                                float y = (float)((Screen.height - height) / 2);

                                GUIStyle style = GUISkin.current.label;
                                style.fontSize = 60;
                                //style.fontStyle = UnityEngine.FontStyle.Italic;
                                style.alignment = TextAnchor.UpperCenter;

                                if ((runningGame == "Rainhouse" || runningGame == "Rainhouse_64bit") && imagesRanThrough == 1) { style.m_Normal.textColor = UnityEngine.Color.red; }

                                switch (gameLanguage)
                                {
                                    case "French":
                                        GUI.Label(new Rect(x, y, width, height), new GUIContent("« " + translatedTitle + " »" + "\nde Kitty Horrorshow"), style);
                                        break;
                                    case "Dutch":
                                        GUI.Label(new Rect(x, y, width, height), new GUIContent("\"" + translatedTitle + "\"" + "\nvan Kitty Horrorshow"), style);
                                        break;
                                    case "Japanese":
                                        GUI.Label(new Rect(x, y, width, height), new GUIContent("キティ・ハラショ" + "の" + "\n「" + translatedTitle + "」"), style);
                                        break;
                                }
                            }
                        }
                        catch (Exception ex) 
                        {
                            Logger.LogInfo("Exception when trying to print titlecard: "+ex.ToString());
                        }

                        return;
                    }

                    if (subtitlesDecided && !readmeDecided)
                    {
                        string[] pathParts = { Paths.PluginPath, "KittyHorrorshowTranslations", "readmes", runningGame, gameLanguage};
                        pathParts = pathParts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        var path = String.Join("\\", pathParts);

                        if (!Directory.Exists(path))
                        {
                            string[] pathParts2 = { Paths.PluginPath, "KittyHorrorshowTranslations", "net35", "readmes", runningGame, gameLanguage };
                            pathParts2 = pathParts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            path = String.Join("\\", pathParts2);
                        }

                        if (Directory.Exists(path))
                        {
                            UnlockCursor();

                            string readmePrompt;

                            switch (gameLanguage)
                            {
                                case "French":
                                    readmePrompt = "Lire les fichiers .txt\nqui accompagnent le jeu ?\n\nY (OUI) / N (NON)";
                                    break;
                                case "Dutch":
                                    readmePrompt = "De bijbehorende .txt-bestanden\nvan de game lezen?\n\nY (JA) / N (NEE)";
                                    break;
                                case "Japanese":
                                    readmePrompt = "ゲームに付属する.txt\nファイルを読みますか?\n\nY (はい) / N (いいえ)";
                                    break;
                                default:
                                    readmePrompt = "";
                                    break;
                            }

                            if (string.IsNullOrEmpty(readmePrompt))
                            {
                                // nothing
                            }
                            else
                            {
                                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 200, 100), readmePrompt, standardButtonStyle))
                                {
                                    readmeDecided = true;
                                    Process.Start(path);

                                    LockCursor();
                                }
                                else
                                {
                                    // Preventing holding from subtitles to count forward to this
                                    if (!subtitlesDecidedLetGo)
                                    {
                                        if (!Input.GetKeyDown(KeyCode.Y) && !Input.GetKeyDown(KeyCode.N))
                                        {
                                            subtitlesDecidedLetGo = true;
                                        }
                                    }
                                    // Keycodes aren't translated because that's not how it works in the other games
                                    else if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        readmeDecided = true;
                                        Process.Start(path);

                                        LockCursor();
                                    }
                                    else if (Input.GetKeyDown(KeyCode.N))
                                    {
                                        readmeDecided = true;

                                        LockCursor();
                                    }
                                }
                            }
                        }
                        else
                        {
                            readmeDecided = true;
                            LockCursor();
                        }
                    }
                    else if (!subtitlesDecided)
                    {
                        UnlockCursor();

                        string subtitlePrompt;
                        switch (gameLanguage)
                        {
                            case "English":
                                subtitlePrompt = "Enable subtitles?\n\nY / N";
                                break;
                            case "French":
                                subtitlePrompt = "Activer les sous-titres ?\n\nY (OUI) / N (NON)";
                                break;
                            case "Dutch":
                                subtitlePrompt = "Ondertiteling inschakelen?\n\nY (JA) / N (NEE)";
                                break;
                            case "Japanese":
                                subtitlePrompt = "字幕を有効にしますか?\n\nY (はい) / N (いいえ)";
                                break;
                            default:
                                subtitlePrompt = "";
                                break;
                        }

                        if (string.IsNullOrEmpty(subtitlePrompt))
                        {
                            // nothing
                        }
                        else
                        {
                            if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 200, 100), subtitlePrompt, standardButtonStyle))
                            {
                                subtitlesDecided = true;
                                doSubtitles = true;

                                LockCursor();
                            }
                            else
                            {
                                // Keycodes aren't translated because that's not how it works in the other games
                                if (Input.GetKeyDown(KeyCode.Y))
                                {
                                    subtitlesDecided = true;
                                    doSubtitles = true;

                                    LockCursor();
                                }
                                else if (Input.GetKeyDown(KeyCode.N))
                                {
                                    subtitlesDecided = true;
                                    doSubtitles = false;

                                    LockCursor();
                                }
                            }
                        }
                    }

                    return;
                }

                UnlockCursor();

                // Establishing order and inclusion of languages - in final release, have this vary by game
                string[] languages = [];
                switch (runningGame)
                {
                    case "Sigilvalley":
                    case "Sigilvalley_64bit":
                    case "Vaporcrane":
                    case "Vaporcrane_win":
                        languages = ["Unneeded"];
                        break;
                    default:
                        languages = ["English", "French", "Dutch", "Japanese"];
                        break;
                }

                int englishDex = Array.IndexOf(languages, "English");
                int frenchDex = Array.IndexOf(languages, "French");
                int dutchDex = Array.IndexOf(languages, "Dutch");
                int japaneseDex = Array.IndexOf(languages, "Japanese");

                // Math for button spacing
                int appWidth = Screen.width;
                int appHeight = Screen.height;

                int numLangs = languages.Length;

                int buttonWidth;
                int buttonHeight;
                if (Array.IndexOf(languages, "Unneeded") != -1)
                {
                    buttonWidth = 500;
                    buttonHeight = 250;
                }
                else
                {
                    buttonWidth = 150;
                    buttonHeight = 100;
                }

                int widthSpacer = (appWidth - (numLangs * buttonWidth)) / (numLangs + 1);
                int heightSpacer = (appHeight - buttonHeight) / 2;

                // Write code here to catch buttons overlapping if we ever get enough languages for that to happen
                if (widthSpacer < 0)
                {

                }

                // Printing dimensions
                if (!guiDimensionsPrinted)
                {
                    guiDimensionsPrinted = true;
                    Plugin.Instance.Logger.LogInfo("Window dimensions: " + appWidth.ToString() + " " + appHeight.ToString());
                    Plugin.Instance.Logger.LogInfo("Button spacing values: " + widthSpacer.ToString() + " " + heightSpacer.ToString());
                }

                // No translation needed popup
                if (notNeededButtonFrames > 10*60)
                {
                    gameLanguage = "English";
                    return;
                }
                if (Array.IndexOf(languages, "Unneeded") != -1)
                {
                    GUIStyle style = GUISkin.current.button;
                    style.fontSize = 30;

                    GUI.Button(new Rect(widthSpacer, heightSpacer, buttonWidth, buttonHeight), "No translation needed." + "\nAucune traduction nécessaire." + "\nGeen vertaling nodig." + "\n翻訳は必要ありません。", style);

                    notNeededButtonFrames += 1;

                    return;
                }

                // Standard buttons
                if (englishDex != -1)
                {
                    if (GUI.Button(new Rect(widthSpacer + (englishDex * widthSpacer) + (englishDex * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "English" + "\n\n(Press " + (englishDex + 1) + ")", standardButtonStyle))
                    {
                        gameLanguage = "English";
                        AfterLanguageSelection();
                    }
                }
                if (frenchDex != -1)
                {
                    if (GUI.Button(new Rect(widthSpacer + (frenchDex * widthSpacer) + (frenchDex * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "Français" + "\n\n(Appuyez " + (frenchDex + 1) + ")", standardButtonStyle))
                    {
                        gameLanguage = "French";
                        AfterLanguageSelection();
                    }
                }
                if (dutchDex != -1)
                {
                    if (GUI.Button(new Rect(widthSpacer + (dutchDex * widthSpacer) + (dutchDex * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "Nederlands" + "\n\n(Druk " + (dutchDex + 1) + ")", standardButtonStyle))
                    {
                        gameLanguage = "Dutch";
                        AfterLanguageSelection();
                    }
                }
                if (japaneseDex != -1)
                {
                    if (GUI.Button(new Rect(widthSpacer + (japaneseDex * widthSpacer) + (japaneseDex * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "日本語" + "\n\n(" + (japaneseDex + 1) + "を押す)", standardButtonStyle))
                    {
                        gameLanguage = "Japanese";
                        AfterLanguageSelection();
                    }
                }

                // Allowing keypresses as alternative
                if ((Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) && numLangs >= 1 && !string.IsNullOrEmpty(languages[0]))
                {
                    gameLanguage = languages[0];
                    AfterLanguageSelection();
                }
                if ((Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) && numLangs >= 2 && !string.IsNullOrEmpty(languages[1]))
                {
                    gameLanguage = languages[1];
                    AfterLanguageSelection();
                }
                if ((Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) && numLangs >= 3 && !string.IsNullOrEmpty(languages[2]))
                {
                    gameLanguage = languages[2];
                    AfterLanguageSelection();
                }
                if ((Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)) && numLangs >= 4 && !string.IsNullOrEmpty(languages[3]))
                {
                    gameLanguage = languages[3];
                    AfterLanguageSelection();
                }
            }
            catch (Exception ex) 
            {
                Plugin.Instance.Logger.LogInfo("OnGUI exception: "+ex.ToString());
            }
        }

        // OWML code
        public AudioClip GetAudio(string mainFolder = "", string subFolder = "", string fileName = "")
        {
            try
            {
                string[] pathParts = { Paths.PluginPath, "KittyHorrorshowTranslations", "audio", mainFolder, subFolder, fileName };
                pathParts = pathParts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var path = String.Join("\\", pathParts);
                Logger.LogInfo("Loading audio from " + path);
                using var reader = new NAudio.Wave.AudioFileReader(path);
                var sampleCount = (int)(reader.Length * 8 / reader.WaveFormat.BitsPerSample);
                var outputSamples = new float[sampleCount];
                reader.Read(outputSamples, 0, sampleCount);
                var clip = AudioClip.Create(path, sampleCount / reader.WaveFormat.Channels, reader.WaveFormat.Channels, reader.WaveFormat.SampleRate, false);
                clip.SetData(outputSamples, 0);
                return clip;
            }
            catch
            {
                try
                {
                    string[] pathParts = { Paths.PluginPath, "KittyHorrorshowTranslations", "net35", "audio", mainFolder, subFolder, fileName };
                    pathParts = pathParts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    var path = String.Join("\\", pathParts);
                    Logger.LogInfo("Loading audio from " + path);
                    using var reader = new NAudio.Wave.AudioFileReader(path);
                    var sampleCount = (int)(reader.Length * 8 / reader.WaveFormat.BitsPerSample);
                    var outputSamples = new float[sampleCount];
                    reader.Read(outputSamples, 0, sampleCount);
                    var clip = AudioClip.Create(path, sampleCount / reader.WaveFormat.Channels, reader.WaveFormat.Channels, reader.WaveFormat.SampleRate, false);
                    clip.SetData(outputSamples, 0);
                    return clip;
                }
                catch (Exception ex)
                {
                    Logger.LogError("Error occured while attempting to load file " + fileName + ": " + ex.ToString());
                    return achyBreaky;
                }
            }
        }
        public Texture2D GetTexture(string mainFolder = "", string subFolder = "", string fileName = "")
        {
            try
            {
                string[] pathParts = { Paths.PluginPath, "KittyHorrorshowTranslations", "images", mainFolder, subFolder, fileName };
                pathParts = pathParts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var path = String.Join("\\", pathParts);
                Logger.LogInfo("Loading texture from " + path);
                var data = File.ReadAllBytes(path);
                var texture = new Texture2D(2, 2);
                texture.LoadImage(data);
                return texture;
            }
            catch
            {
                try
                {
                    string[] pathParts = { Paths.PluginPath, "KittyHorrorshowTranslations", "net35", "images", mainFolder, subFolder, fileName };
                    pathParts = pathParts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    var path = String.Join("\\", pathParts);
                    Logger.LogInfo("Loading texture from " + path);
                    var data = File.ReadAllBytes(path);
                    var texture = new Texture2D(2, 2);
                    texture.LoadImage(data);
                    return texture;
                }
                catch (Exception ex)
                {
                    Logger.LogError("Error occured while attempting to load file " + fileName + ": " + ex.ToString());
                    return bigRed;
                }
            }
        }
        // End OWML code
        
        public AudioClip achyBreaky;
        public Texture2D bigRed;
        public void Start()
        {
            achyBreaky = GetAudio("Achy Breaky Song.mp3");
            bigRed = GetTexture("bigRed.png");

            achyBreaky.name = "Achy Breaky Song";
            bigRed.name = "Big Red Error Texture";
        }

        // Loading textures and audio
        public void AfterLanguageSelection()
        {
            LockCursor();

            Logger.LogInfo("Language set to "+gameLanguage);

            // Fonts
            //foreach (string font in UnityEngine.Font.GetOSInstalledFontNames()) { Logger.LogInfo("System font found: "+font); }
            UnityEngine.Font[] fonts = FindObjectsOfType(typeof(UnityEngine.Font)) as UnityEngine.Font[];
            foreach (var font in fonts)
            {
                Plugin.Instance.Logger.LogInfo("Game font found: " + font.name);
            }

            // Find and print FsmStrings
            switch (runningGame)
            {
                case "CHYRZA":
                case "Wraith":
                case "Village":
                case "Village_win":
                case "Bhk":
                    break;
                default:
                    FsmStringReplacement();
                    break;
            }

            // Loading assets & other funcs. Language-specific assets are loaded into the _TRANS assets. This reduces switch statements later on. //
            switch (runningGame)
            {
                case "Anatomy":
                    Anatomy.Instance.AssetLoading();
                    break;
                case "Actias":
                    Actias.Instance.AssetLoading();
                    break;
                case "CHYRZA":
                    break;
                case "Gloompuke":
                    Gloompuke.Instance.EditObjectNames();
                    break;
                case "Sunset":
                    break;
            }

            // Do texture replacements //
            TextureAudioReplacement();
        }
            
        public string lastText;
        public bool texturereplaceOnLoad;
        public int scenesLoaded;
        public int currentLevelIndex;
        public GUIStyle guiStyle = new GUIStyle();

        public string lastSoundPlayed;
        public int updateCountAtLastSoundStart;
        public int updateCounter;

        public GUIStyle runningGameStyle;
        public UnityEngine.Font runningGameFont;

        public bool runningGameStyleGot;

        [HarmonyPatch]
        public class UnityPatches
        {
            // Audio replacement
            [HarmonyPrefix]
            [HarmonyPatch(typeof(AudioSource), nameof(AudioSource.PlayOneShot), new System.Type[] { typeof(AudioClip), typeof(float) })]
            public static void PlayOneShot_Patch(AudioClip clip)
            {
                Plugin.Instance.Logger.LogInfo("PlayOneShot, audio played: " + clip.name);
            }
            [HarmonyPrefix]
            [HarmonyPatch(typeof(AudioSource), nameof(AudioSource.PlayClipAtPoint), new System.Type[] { typeof(AudioClip), typeof(Vector3), typeof(float) })]
            public static void PlayClipAtPoint_Patch(AudioClip clip)
            {
                Plugin.Instance.Logger.LogInfo("PlayClipAtPoint, audio played: " + clip.name);
            }

            // Text replacement
            [HarmonyPrefix]
            [HarmonyPatch(typeof(GUI), nameof(GUI.Label), new System.Type[] { typeof(Rect), typeof(GUIContent), typeof(GUIStyle) })]
            public static void GUILabel_Prefix(GUI __instance, Rect position, GUIContent content, GUIStyle style)
            {
                if (content.m_Text != Plugin.Instance.lastText)
                {
                    Plugin.Instance.lastText = content.m_Text;
                    Plugin.Instance.Logger.LogInfo("GUI.Label rect: " + position);
                    Plugin.Instance.Logger.LogInfo("GUI.Label text: " + content.m_Text);

                    Plugin.Instance.Logger.LogInfo("GUI.Label style: " + style.name);
                    Plugin.Instance.Logger.LogInfo("GUI.Label font: " + style.font);
                    Plugin.Instance.Logger.LogInfo("GUI.Label font size: " + style.fontSize);
                    Plugin.Instance.Logger.LogInfo("GUI.Label IntPtr: " + style.m_Ptr);

                    if (Plugin.Instance.runningGameStyleGot != true && !string.IsNullOrEmpty(content.m_Text))
                    {
                        Plugin.Instance.runningGameStyleGot = true;
                        Plugin.Instance.runningGameStyle = style;
                        Plugin.Instance.runningGameFont = style.font;
                    }
                }

                // Font replacement - WIP
                if (false)
                {
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            switch (Plugin.Instance.runningGame)
                            {
                                case "Anatomy":
                                case "Actias":
                                    Plugin.Instance.Logger.LogInfo("Changing everything to Comic Sans because life sucks.");
                                    style.font = UnityEngine.Font.CreateDynamicFontFromOSFont("Comic Sans MS", 30);
                                    break;
                            }
                            break;
                        case "Japanese":
                            switch (Plugin.Instance.runningGame)
                            {
                                case "Anatomy":
                                case "Actias":
                                    style.font = UnityEngine.Font.CreateDynamicFontFromOSFont("Microsoft Himalaya", 30);
                                    break;
                            }
                            break;
                    }
                }

                // Call individual games' text replacement functions
                switch (Plugin.Instance.runningGame)
                {
                    case "Actias":
                        content.m_Text = Actias.Instance.TextReplacement(content.m_Text);
                        break;
                    case "Anatomy":
                        content.m_Text = Anatomy.Instance.TextReplacement(content.m_Text);
                        break;
                    case "Grandmother":
                        content.m_Text = Grandmother.Instance.TextReplacement(content.m_Text);
                        break;
                    case "Leechbowl":
                        content.m_Text = Leechbowl.Instance.TextReplacement(content.m_Text);
                        break;
                }

                // For games with too little text to justify getting their own .cs file or for phrases which appear in multiple games.
                content.m_Text = MiscGames.Instance.TextReplacement(content.m_Text);
            }
        }

        public void FsmStringReplacement()
        {
            try
            {
                Logger.LogInfo("Trying to find FsmStrings...");
                for (int i = 0; i <= Fsm.FsmList.Count - 1; i++)
                {
                    for (int i2 = 0; i2 <= Fsm.FsmList[i].Variables.StringVariables.Length - 1; i2++)
                    {
                        Plugin.Instance.PrintThisString(i+"-"+i2+" FsmString found: " + Fsm.FsmList[i].Variables.StringVariables[i2].Value);

                        switch (runningGame)
                        {
                            case "Actias":
                                Fsm.FsmList[i].Variables.StringVariables[i2].Value = Actias.Instance.TextReplacement(Fsm.FsmList[i].Variables.StringVariables[i2].Value);
                                break;
                            case "Anatomy":
                                Fsm.FsmList[i].Variables.StringVariables[i2].Value = Anatomy.Instance.TextReplacement(Fsm.FsmList[i].Variables.StringVariables[i2].Value);
                                break;
                            case "Leechbowl":
                                Fsm.FsmList[i].Variables.StringVariables[i2].Value = Leechbowl.Instance.TextReplacement(Fsm.FsmList[i].Variables.StringVariables[i2].Value);
                                break;
                            case "Grandmother":
                                Fsm.FsmList[i].Variables.StringVariables[i2].Value = Grandmother.Instance.TextReplacement(Fsm.FsmList[i].Variables.StringVariables[i2].Value);
                                break;
                            case "Sunset":
                                Fsm.FsmList[i].Variables.StringVariables[i2].Value = Sunset.Instance.TextReplacement(Fsm.FsmList[i].Variables.StringVariables[i2].Value);
                                break;
                        }

                        Fsm.FsmList[i].Variables.StringVariables[i2].Value = MiscGames.Instance.TextReplacement(Fsm.FsmList[i].Variables.StringVariables[i2].Value);
                    }
                }
                Logger.LogInfo("Done finding FsmStrings.");
            }
            catch (Exception ex)
            {
                Logger.LogInfo("Exception during printing FsmStrings: " + ex.ToString());
            }
        }

        [HarmonyPatch]
        public class HutongPatches
        {
            // Level loading
            [HarmonyPrefix]
            [HarmonyPatch(typeof(LoadLevelNum), nameof(LoadLevelNum.OnEnter))]
            public static void SceneLoad(LoadLevelNum __instance)
            {
                // DEBUG
                //__instance.levelIndex.Value = 2;

                // Setting variables //
                Plugin.Instance.scenesLoaded += 1;
                Plugin.Instance.currentLevelIndex = __instance.levelIndex.Value;

                Plugin.Instance.Logger.LogInfo("A level was loaded. Index: " + __instance.levelIndex.ToString() + ". Number of levels loaded this session: " + Plugin.Instance.scenesLoaded.ToString());

                // Check language //
                if (string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
                {
                    Plugin.Instance.Logger.LogInfo("Language is null or empty.");
                }
                else
                {
                    Plugin.Instance.Logger.LogInfo("Language has already been set. Running replacements...");
                    Plugin.Instance.TextureAudioReplacement();
                    Plugin.Instance.FsmStringReplacement();
                    Plugin.Instance.Logger.LogInfo("Replacements done.");
                }
            }

            // GameObject activation
            [HarmonyPostfix]
            [HarmonyPatch(typeof(ActivateGameObject), "DoActivateGameObject")]
            public static void ActivateGameObject_Patch(ActivateGameObject __instance)
            {
                if (__instance.activate.Value)
                {
                    Plugin.Instance.Logger.LogInfo("A GameObject was activated: " + __instance.gameObject.GameObject.ToString());
                }
                else
                {
                    Plugin.Instance.Logger.LogInfo("A GameObject was deactivated: " + __instance.gameObject.GameObject.ToString());
                }

                // Exclusion stuff
                if (Plugin.Instance.runningGame == "Exclusion" && __instance.activate.Value)
                {
                    switch (__instance.gameObject.GameObject.ToString())
                    {
                        case "Press Enter to continue":
                            Exclusion.Instance.pressEnter = __instance.gameObject.GameObject.Value;
                            break;
                        case "Escape":
                            Exclusion.Instance.escape = __instance.gameObject.GameObject.Value;
                            break;

                        case "Temple (Whole) Text":
                            Exclusion.Instance.templeWholeText = __instance.gameObject.GameObject.Value;
                            break;
                        case "Plaza Text":
                            Exclusion.Instance.plazaText = __instance.gameObject.GameObject.Value;
                            break;
                        case "Overlook Text":
                            Exclusion.Instance.overlookText = __instance.gameObject.GameObject.Value;
                            break;
                        case "Tower (Inner) Text":
                            Exclusion.Instance.towerInnerText = __instance.gameObject.GameObject.Value;
                            break;
                        case "Tower (Outer) Text":
                            Exclusion.Instance.towerOuterText = __instance.gameObject.GameObject.Value;
                            break;
                        case "Henge Text":
                            Exclusion.Instance.hengeText = __instance.gameObject.GameObject.Value;
                            break;
                        case "Inner Chamber Text":
                            Exclusion.Instance.innerChamberText = __instance.gameObject.GameObject.Value;
                            break;
                        case "Orchard Text":
                            Exclusion.Instance.orchardText = __instance.gameObject.GameObject.Value;
                            break;
                    }
                }
                // For some reason, these two tapes do not use Hutong's "PlaySound" so we're doing this hacky workaround. It works, and that's what matters.
                else if (Plugin.Instance.runningGame == "Anatomy" && __instance.activate.Value)
                {
                    switch (__instance.gameObject.GameObject.ToString())
                    {
                        case "FinalTape":
                            Plugin.Instance.updateCountAtLastSoundStart = Plugin.Instance.updateCounter;
                            Plugin.Instance.lastSoundPlayed = "tapeX_3";
                            break;
                        case "Audio Source":
                            if (Plugin.Instance.currentLevelIndex == 9)
                            {
                                Plugin.Instance.updateCountAtLastSoundStart = Plugin.Instance.updateCounter;
                                Plugin.Instance.lastSoundPlayed = "finalspeech";
                            }
                            break;
                        case "Sound Source":
                            if (Plugin.Instance.currentLevelIndex == 3)
                            {
                                Anatomy_Subtitles.Instance.screamingTape = __instance.gameObject.GameObject.Value;
                            }
                            break;
                        case "title4":
                            if (Plugin.Instance.currentLevelIndex == 3)
                            {
                                Anatomy_Subtitles.Instance.title4TV = __instance.gameObject.GameObject.Value;
                            }
                            break;
                    }
                }
            }

            // Text replacement for some other games
            [HarmonyPrefix]
            [HarmonyPatch(typeof(SetStringValue), nameof(SetStringValue.OnEnter))]
            public static void SetString_Patch(SetStringValue __instance)
            {
                Plugin.Instance.lastText = __instance.stringValue.Value;
                Plugin.Instance.Logger.LogInfo("A string was set by the name of " + __instance.stringVariable.Name + ": " + __instance.stringValue.Value);

                __instance.stringValue.Value = MiscGames.Instance.TextReplacement(__instance.stringValue.Value);
            }

            // Text replacement finding style
            //[HarmonyPostfix]
            //[HarmonyPatch(typeof(GUILabel), nameof(GUILabel.OnGUI))]
            //public static void Hutong_GUILabel_Patch(GUILabel __instance)
            //{
            //    Plugin.Instance.Logger.LogInfo("HutongGames.PlayMaker.Actions.GUILabel style: " + __instance.style.Value);
            //}

            //[HarmonyPostfix]
            //[HarmonyPatch(typeof(GUIContentAction), nameof(GUIContentAction.OnGUI))]
            //public static void Hutong_GUIContentAction_Patch(GUIContentAction __instance)
            //{
            //    Plugin.Instance.Logger.LogInfo("HutongGames.PlayMaker.Actions.GUIContentAction style: " + __instance.style.Value);
            //}

            // Audio replacement
            [HarmonyPrefix]
            [HarmonyPatch(typeof(PlaySound), "DoPlaySound")]
            public static void AudioReplacement(PlaySound __instance)
            {
                Plugin.Instance.Logger.LogInfo("Sound played: " + __instance.clip.Value.name);

                // Subtitle code
                if (Plugin.Instance.runningGame == "Anatomy") 
                {
                    switch (__instance.clip.Value.name)
                    {
                        case "tapeStart":
                        case "tapeStop":
                        case "tape1":
                        case "tape2":
                        case "tape3":
                        case "tape4":
                        case "tape5":
                        case "tape6":
                        case "tape7":
                        case "tape8":
                        case "tape9":
                        case "tape x":
                        case "tape1_2":
                        case "tape2_2":
                        case "tape3_2":
                        case "tape4_2":
                        case "tape5_2":
                        case "tape6_2":
                        case "finalspeech":
                        case "tape1_3":
                        case "tape2_3":
                        case "tape3_3":
                        case "tape4_3":
                        case "tape5_3":
                        case "tapeX_3":
                        case "amen":
                        case "screaming_tape":
                            Plugin.Instance.updateCountAtLastSoundStart = Plugin.Instance.updateCounter;
                            Plugin.Instance.lastSoundPlayed = __instance.clip.Value.name;
                            break;
                    }
                }

                // Don't do any actual replacements if the language is English or null/empty
                if (Plugin.Instance.gameLanguage == "English" || string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
                {
                    return;
                }

                // Do the replacements
                try
                {
                    switch (Plugin.Instance.runningGame)
                    {
                        case "Anatomy":
                            __instance.clip.Value = Anatomy.Instance.AudioReplacement(__instance.clip.Value);
                            break;
                    }
                }
                catch (Exception ex) 
                {
                    Plugin.Instance.Logger.LogError("Error occured while doing audio replacement: "+ex.ToString());
                }
            }
        }

        // Texture & audio replacement
        public int audioRanThrough;
        public int imagesRanThrough;
        public int texturesRanThrough;

        public void TextureAudioReplacement(bool runAll=false)
        {
            // Audio replacement
            string[] doAudioReplacement = [""];
            if (runAll || Array.IndexOf(doAudioReplacement, runningGame) != -1)
            {
                Logger.LogInfo("Beginning audio runthroughs...");
                audioRanThrough = 0;
                foreach (AudioClip clip in Resources.FindObjectsOfTypeAll<AudioClip>())
                {
                    Logger.LogInfo("AudioClip was run through: " + clip.name);
                    audioRanThrough += 1;

                    // Don't do any actual replacements if the language is English or null/empty
                    if (gameLanguage == "English" || string.IsNullOrEmpty(gameLanguage))
                    {
                        continue;
                    }

                    switch (Plugin.Instance.runningGame)
                    {
                        case "CHYRZA":
                            break;
                    }
                }
            }

            // Image replacement
            string[] doImageReplacement = ["Anatomy", "Actias", "Rainhouse", "Ccccccc", "Leechbowl", "Pente", "Acro", "Archlake_win", "Artery", "BAST", "Charon"];
            if (runAll || Array.IndexOf(doImageReplacement, runningGame) != -1)
            {
                Logger.LogInfo("Beginning image runthroughs...");
                imagesRanThrough = 0;
                foreach (var image in Resources.FindObjectsOfTypeAll<SpriteRenderer>())
                {
                    Logger.LogInfo("Image was run through: " + image.gameObject.name);
                    imagesRanThrough += 1;

                    // Don't do any actual replacements if the language is English or null/empty
                    if (gameLanguage == "English" || string.IsNullOrEmpty(gameLanguage))
                    {
                        continue;
                    }

                    switch (Plugin.Instance.runningGame)
                    {
                        case "Anatomy":
                            image.sprite = Anatomy.Instance.TextureReplacement(image);
                            break;
                        case "Actias":
                            image.sprite = Actias.Instance.TextureReplacement(image);
                            break;
                    }

                }
                Logger.LogInfo("End of image runthroughs.");
            }

            // The actual *texture* replacement loop. Yes, these two things are different, but I'm calling them both textures because that's what they are.
            string[] doTextureReplacement = ["Leechbowl"];
            if (runAll || Array.IndexOf(doTextureReplacement, runningGame) != -1)
            {
                Logger.LogInfo("Beginning texture runthroughs...");
                texturesRanThrough = 0;
                foreach (var texture in Resources.FindObjectsOfTypeAll<Texture2D>())
                {
                    Logger.LogInfo("Texture was run through: " + texture.name);
                    texturesRanThrough += 1;

                    // Don't do any actual replacements if the language is English or null/empty
                    if (gameLanguage == "English" || string.IsNullOrEmpty(gameLanguage))
                    {
                        continue;
                    }
                }
                Logger.LogInfo("End of texture runthroughs.");
            }
        }

        // Sprite replacement shorthand
        public UnityEngine.Sprite SpriteReplace(Texture2D texture, int width, int height)
        {
            try
            {
                var sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, width, height), new Vector2(0.5f, 0.5f), 100.0f);
                return sprite;
            }
            catch (Exception ex)
            {
                Logger.LogInfo("Exception occured when trying to create sprite named "+ texture.name + ": " + ex.ToString());
                return null;
            }
        }

        // Japanese shorthand
        public string IntToJapanese(string str)
        {
            switch (str)
            {
                case "1":
                    return "いっ";
                case "2":
                    return "に";
                case "3":
                    return "さん";
                case "4":
                    return "よん";
                case "5":
                    return "ご";
                case "6":
                    return "ろっ";
                case "7":
                    return "なな";
                case "8":
                    return "はっ";
                case "9":
                    return "きゅう";
                case "10":
                    return "じゅっ";
                default:
                    return "ERROR";
            }
        }
        public string IntToRoman(string str)
        {
            switch (str)
            {
                case "0":
                    return "０";
                case "1":
                    return "Ⅰ";
                case "2":
                    return "Ⅱ";
                case "3":
                    return "Ⅲ";
                case "4":
                    return "Ⅳ";
                case "5":
                    return "Ⅴ";
                case "6":
                    return "Ⅵ";
                case "7":
                    return "Ⅶ";
                case "8":
                    return "Ⅷ";
                case "9":
                    return "Ⅸ";
                case "10":
                    return "Ⅹ";
                default:
                    return "ERROR";
            }
        }

        // Call this function at Start if you wanna see something funny.
        public void Woodify()
        {
            var clearGlassMat = GameObject.Find("bookshelf").GetComponent<Renderer>().sharedMaterial;

            foreach (var renderer in Resources.FindObjectsOfTypeAll<Renderer>())
            {
                var materials = renderer.sharedMaterials;
                for (var i = 0; i < materials.Length; i++)
                {
                    if (!materials[i]) continue;

                    Logger.LogInfo("Material was run through: " + materials[i].name);

                    switch (materials[i].name)
                    {
                        default:
                            materials[i] = clearGlassMat;
                            break;
                    }
                }
                renderer.sharedMaterials = materials;
            }
        }
    }
}