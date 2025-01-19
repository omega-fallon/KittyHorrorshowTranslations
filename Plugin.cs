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
using static PixelCrushers.DialogueSystem.Articy.ArticyData;
using System.Runtime.InteropServices;
using System.Security.Policy;

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
    [BepInProcess("DUSTCITY.exe")] // 4.3.3

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

        public string runningGame_windowTitle;

        public string[] noHutong = ["CHYRZA", "Wraith", "Village", "Village_win", "Bhk", "DUSTCITY"];

        public void Awake()
        {
            Instance = this;

            // Plugin startup logic
            Logger.LogInfo($"Plugin {"OmegaFallon.KittyHorrorshowTranslations"} is loaded!");

            // Load what game this is
            runningGame = Paths.ProcessName;
            runningGame = char.ToUpper(runningGame[0]) + runningGame.Substring(1);
            Logger.LogInfo("Current running game is " + runningGame);

            runningGame_windowTitle = runningGame;
            switch (runningGame_windowTitle)
            {
                case "Sigilvalley":
                case "Sigilvalley_64bit":
                    runningGame_windowTitle = "Sigil Valley";
                    break;
                case "Bhk":
                    runningGame_windowTitle = "Broken Heart Key";
                    break;
                case "Seven":
                    runningGame_windowTitle = "Seven Days";
                    break;
                case "GhostLake":
                    runningGame_windowTitle = "Ghost Lake";
                    break;
                case "Wormclot":
                    runningGame_windowTitle = "Castle Wormclot";
                    break;
                case "Rainhouse":
                case "Rainhouse_64bit":
                    runningGame_windowTitle = "Rain, House, Eternity";
                    break;
                case "Sunset":
                    runningGame_windowTitle = "SUNSET SPIRIT STEEL";
                    break;
                case "Archlake":
                case "Archlake_win":
                case "ArchLake":
                    runningGame_windowTitle = "Arch Lake";
                    break;
                case "Vaporcrane":
                case "Vaporcrane_win":
                    runningGame_windowTitle = "VAPORCRANE";
                    break;
                case "Skin":
                    runningGame_windowTitle = "BLOOD CITY";
                    break;
                case "Wraithshead":
                    runningGame_windowTitle = "Wraithshead Gardens";
                    break;
                case "Cyberskull":
                    runningGame_windowTitle = "CYBERSKULL";
                    break;
                case "Scarlet":
                    runningGame_windowTitle = "Scarlet Bough";
                    break;
                case "GES_Final":
                    runningGame_windowTitle = "Garden, Eternity, Shape";
                    break;
                case "Anatomy":
                    runningGame_windowTitle = "ANATOMY";
                    break;
                case "Village":
                case "Village_win":
                    runningGame_windowTitle = "Village";
                    break;
                case "Artery":
                    runningGame_windowTitle = "Artery Heights";
                    break;
                case "DUSTCITY":
                case "DUST CITY":
                    runningGame_windowTitle = "Dust City";
                    break;
            }

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
            if (Array.IndexOf(noHutong, runningGame) != -1)
            {
                //nothing
            }
            else
            {
                try
                {
                    Harmony.CreateAndPatchAll(typeof(HutongPatches));
                }
                catch (Exception ex)
                {
                    Logger.LogInfo("Error in doing Hutong patches: " + ex.ToString());
                }
            }

            // Add .cs files and Harmony patches for individual games
            gameObject.AddComponent<OmegaFallon.KittyHorrorshowTranslations.GUI>();
            switch (runningGame)
            {
                case "Actias":
                    gameObject.AddComponent<Actias>();
                    break;
                case "Anatomy":
                    gameObject.AddComponent<Anatomy>();
                    gameObject.AddComponent<Subtitles>();
                    gameObject.AddComponent<Subtitles_Anatomy>();
                    break;
                case "Basements":
                    gameObject.AddComponent<Basements>();
                    break;
                case "Ccccccc":
                    gameObject.AddComponent<Ccccccc>();
                    break;
                case "CHYRZA":
                    gameObject.AddComponent<CHYRZA>();
                    gameObject.AddComponent<Subtitles>();
                    gameObject.AddComponent<Subtitles_CHYRZA>();
                    break;
                case "DUSTCITY":
                    gameObject.AddComponent<DUSTCITY>();
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
                case "Living Room":
                    gameObject.AddComponent<Living_Room>();
                    break;
                case "Pente":
                    gameObject.AddComponent<Pente>();
                    break;
                case "Rainhouse":
                    gameObject.AddComponent<RainHouseEternity>();
                    break;
                case "Sunset":
                    gameObject.AddComponent<Sunset>();
                    break;
                case "Tenement":
                    gameObject.AddComponent<Tenement>();
                    break;
                case "Wormclot":
                    gameObject.AddComponent<Wormclot>();
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

        public void UnlockCursor()
        {
            if (OmegaFallon.KittyHorrorshowTranslations.GUI.Instance.cursorErrorSkip != true)
            {
                try
                {
                    Meta_UnlockCursor();
                }
                catch
                {
                    OmegaFallon.KittyHorrorshowTranslations.GUI.Instance.cursorErrorSkip = true;
                    Logger.LogInfo("Inconsequential error: UnlockCursor failed likely due to this being a 4.x game.");
                }
            }
        }
        public void LockCursor()
        {
            if (OmegaFallon.KittyHorrorshowTranslations.GUI.Instance.cursorErrorSkip != true)
            {
                try
                {
                    Meta_LockCursor();
                }
                catch
                {
                    OmegaFallon.KittyHorrorshowTranslations.GUI.Instance.cursorErrorSkip = true;
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
        }

        // OWML code
        public AudioClip GetAudio(string mainFolder = "", string subFolder = "", string fileName = "")
        {
            try
            {
                string[] pathParts = [Paths.PluginPath, "KittyHorrorshowTranslations", "audio", mainFolder, subFolder, fileName];
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
                    string[] pathParts = [Paths.PluginPath, "KittyHorrorshowTranslations", "net35", "audio", mainFolder, subFolder, fileName];
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
                string[] pathParts = [Paths.PluginPath, "KittyHorrorshowTranslations", "images", mainFolder, subFolder, fileName];
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
                    string[] pathParts = [Paths.PluginPath, "KittyHorrorshowTranslations", "net35", "images", mainFolder, subFolder, fileName];
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

        [DllImport("user32.dll", EntryPoint = "SetWindowText", CharSet = CharSet.Unicode)]
        public static extern bool SetWindowText(System.IntPtr hwnd, System.String lpString);
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Unicode)]
        public static extern System.IntPtr FindWindow(System.String className, System.String windowName);

        // Loading textures and audio
        public void AfterLanguageSelection()
        {
            LockCursor();

            Logger.LogInfo("Language set to "+gameLanguage);

            // Window name
            Logger.LogInfo(runningGame_windowTitle);
            var windowPtr = FindWindow(null, runningGame_windowTitle);
            SetWindowText(windowPtr, OmegaFallon.KittyHorrorshowTranslations.GUI.Instance.TranslatedTitles(runningGame_windowTitle));

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
                case "Ccccccc":
                    Ccccccc.Instance.AssetLoading();
                    break;
                case "CHYRZA":
                    break;
                case "Gloompuke":
                    Gloompuke.Instance.TextSearch();
                    break;
                case "Pente":
                    Pente.Instance.AssetLoading();
                    break;
                case "Rainhouse":
                    RainHouseEternity.Instance.AssetLoading();
                    break;
            }

            // Do texture replacements //
            TextureAudioReplacement();
        }
            
        public string lastText;
        public bool texturereplaceOnLoad;
        public int scenesLoaded;
        public int currentLevelIndex;
        public GUIStyle guiStyle = new();

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
            [HarmonyPatch(typeof(AudioSource), nameof(AudioSource.PlayOneShot), [typeof(AudioClip), typeof(float)])]
            public static void PlayOneShot_Patch(AudioClip clip)
            {
                Plugin.Instance.Logger.LogInfo("PlayOneShot, audio played: " + clip.name);

                if (Plugin.Instance.runningGame == "CHYRZA")
                {
                    switch (clip.name)
                    {
                        case "message1":
                        case "message2":
                        case "message3":
                        case "message4":
                        case "message5":
                        case "message6":
                        case "message7":
                        case "message8":
                        case "message9":
                            Plugin.Instance.updateCountAtLastSoundStart = Plugin.Instance.updateCounter;
                            Plugin.Instance.lastSoundPlayed = clip.name;
                            break;
                    }
                }
            }
            [HarmonyPrefix]
            [HarmonyPatch(typeof(AudioSource), nameof(AudioSource.PlayClipAtPoint), [typeof(AudioClip), typeof(Vector3), typeof(float)])]
            public static void PlayClipAtPoint_Patch(AudioClip clip)
            {
                Plugin.Instance.Logger.LogInfo("PlayClipAtPoint, audio played: " + clip.name);
            }

            // Text replacement
            [HarmonyPrefix]
            [HarmonyPatch(typeof(UnityEngine.GUI), nameof(UnityEngine.GUI.Label), [typeof(Rect), typeof(GUIContent), typeof(GUIStyle)])]
            public static void GUILabel_Prefix(UnityEngine.GUI __instance, Rect position, GUIContent content, GUIStyle style)
            {
                if (content.m_Text != Plugin.Instance.lastText && Plugin.Instance.runningGame != "Gloompuke")
                {
                    Plugin.Instance.lastText = content.m_Text;
                    Plugin.Instance.Logger.LogInfo("GUI.Label rect: " + position);
                    Plugin.Instance.Logger.LogInfo("GUI.Label text: " + content.m_Text);

                    Plugin.Instance.Logger.LogInfo("GUI.Label style: " + style.name);
                    Plugin.Instance.Logger.LogInfo("GUI.Label font: " + style.font);
                    Plugin.Instance.Logger.LogInfo("GUI.Label font size: " + style.fontSize);
                    Plugin.Instance.Logger.LogInfo("GUI.Label IntPtr: " + style.m_Ptr);

                    if ((Plugin.Instance.runningGameStyleGot != true && !string.IsNullOrEmpty(content.m_Text)) || style.font.name != Plugin.Instance.runningGameFont.name)
                    {
                        Plugin.Instance.runningGameStyleGot = true;
                        Plugin.Instance.runningGameStyle = style;
                        Plugin.Instance.runningGameFont = style.font;
                        Plugin.Instance.PrintThisString("GUILabel patch font name: " + style.font.name);
                    }
                }

                // Font replacement - WIP
                switch (Plugin.Instance.runningGame)
                {
                    case "Sunset":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                //style.font = UnityEngine.Font.CreateDynamicFontFromOSFont("Times New Roman", 30);

                                foreach (UnityEngine.Font font in FindObjectsOfType<UnityEngine.Font>())
                                {
                                    Plugin.Instance.Logger.LogInfo("Found font with name: "+font.name);
                                }

                                break;
                        }
                        break;
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
                    case "Gloompuke":
                        //content.m_Text = Gloompuke.Instance.NameTranslation(content.m_Text);
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
                            case "Rainhouse":
                                Fsm.FsmList[i].Variables.StringVariables[i2].Value = RainHouseEternity.Instance.TextReplacement(Fsm.FsmList[i].Variables.StringVariables[i2].Value);
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

        public string lastDrawTextureName;
        [HarmonyPatch]
        public class HutongPatches
        {
            // Level loading
            [HarmonyPrefix]
            [HarmonyPatch(typeof(LoadLevelNum), nameof(LoadLevelNum.OnEnter))]
            public static void SceneLoad(LoadLevelNum __instance)
            {
                // DEBUG
                //__instance.levelIndex.Value = 1;

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

            // SetGUISkin
            [HarmonyPostfix]
            [HarmonyPatch(typeof(SetGUISkin), nameof(SetGUISkin.OnGUI))]
            public static void SetGUISkin_Patch(SetGUISkin __instance)
            {
                Plugin.Instance.runningGameFont = __instance.skin.font;
                Plugin.Instance.PrintThisString("SetGUISkin patch: " + Plugin.Instance.runningGameFont.name);
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


                // For some reason, these two tapes do not use Hutong's "PlaySound" so we're doing this hacky workaround. It works, and that's what matters.
                if (Plugin.Instance.runningGame == "Anatomy" && __instance.activate.Value)
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
                                Subtitles.Instance.screamingTape = __instance.gameObject.GameObject.Value;
                            }
                            break;
                        case "title4":
                            if (Plugin.Instance.currentLevelIndex == 3)
                            {
                                Subtitles.Instance.title4TV = __instance.gameObject.GameObject.Value;
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
                if (Plugin.Instance.gameLanguage == "English" || Plugin.Instance.gameLanguage == "English (UK)" || string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
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
                    Plugin.Instance.Logger.LogError("Error occured while doing audio replacement: " + ex.ToString());
                }
            }

            [HarmonyPrefix]
            [HarmonyPatch(typeof(HutongGames.PlayMaker.Actions.DrawTexture), nameof(HutongGames.PlayMaker.Actions.DrawTexture.OnGUI))]
            public static void DrawTexture_Patch(HutongGames.PlayMaker.Actions.DrawTexture __instance)
            {
                if (__instance.texture.Value.name != Plugin.Instance.lastDrawTextureName) 
                {
                    Plugin.Instance.lastDrawTextureName = __instance.texture.Value.name;
                    Plugin.Instance.PrintThisString("Drawing a new texture to the screen named \"" + __instance.texture.Value.name + "\"");
                }

                switch (Plugin.Instance.runningGame)
                {
                    case "Ccccccc":
                        switch (__instance.texture.Value.name)
                        {
                            case "msg1":
                            case "msg2":
                            case "scr2":
                            case "scr3":
                            case "scr4":
                            case "scr5":
                                __instance.texture.Value = Ccccccc.Instance.CccccccImages[__instance.texture.Value.name];

                                break;
                        }
                        break;
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
                    if (gameLanguage == "English" || gameLanguage == "English (UK)" || string.IsNullOrEmpty(gameLanguage))
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
                        case "Ccccccc":
                            image.sprite = Ccccccc.Instance.TextureReplacement(image);
                            break;
                        case "Pente":
                            image.sprite = Pente.Instance.TextureReplacement(image);
                            break;
                        case "Rainhouse":
                            image.sprite = RainHouseEternity.Instance.TextureReplacement(image);
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

        // US to UK English
        public string Britishize(string str)
        {
            // -or to -our
            str = str.Replace("color", "colour");
            str = str.Replace("behavior", "behaviour");
            str = str.Replace("favor", "favour");
            str = str.Replace("flavor", "flavour");
            str = str.Replace("harbor", "harbour");
            str = str.Replace("honor", "honour");
            str = str.Replace("humor", "humour");
            str = str.Replace("labor", "labour");
            str = str.Replace("neighbor", "neighbour");
            str = str.Replace("rumor", "rumour");
            str = str.Replace("splendor", "splendour");
            str = str.Replace("armor", "armour");
            str = str.Replace("tumor", "tumour");

            str = str.Replace("honourary", "honorary");
            str = str.Replace("honourific", "honorific");
            str = str.Replace("humourous", "humorous");
            str = str.Replace("labourious", "laborious");
            str = str.Replace("vigourous", "vigorous");

            // -er to -re
            str = str.Replace("center", "centre");
            str = str.Replace("caliber", "calibre");
            str = str.Replace("fiber", "fibre");
            str = str.Replace("somber", "sombre");
            str = str.Replace("specter", "spectre");
            str = str.Replace("theater", "theatre");

            // -se to -ce
            str = str.Replace("defense", "defence");
            str = str.Replace("offense", "offence");
            str = str.Replace("pretense", "pretence");

            // ae to oe
            str = str.Replace("eon", "aeon");
            str = str.Replace("anemia", "anaemia");
            str = str.Replace("anesthesia", "anaesthesia");
            str = str.Replace("diarrhea", "diarrhoea");
            str = str.Replace("encyclopedia", "encyclopaedia");
            str = str.Replace("feces", "faeces");
            str = str.Replace("fetal", "foetal");
            str = str.Replace("hemoglobin", "haemoglobin");
            str = str.Replace("esophagus", "oesophagus");
            str = str.Replace("estrogen", "oestrogen");
            str = str.Replace("archeology", "archaeology");

            // -ize to -ise
            str = str.Replace("civilized", "civilised");
            str = str.Replace("civilization", "civilisation");
            str = str.Replace("organize", "organise");
            str = str.Replace("realize", "realise");
            str = str.Replace("recognize", "recognise");
            str = str.Replace("socializing", "socialising");
            str = str.Replace("hybridization", "hybridisation");
            str = str.Replace("realization", "realisation");
            str = str.Replace("patronizing", "patronising");
            // note to self: practice/practise and advice/advise are contextual

            // -yze to -yse
            str = str.Replace("analyze", "analyse");
            str = str.Replace("catalyze", "catalyse");
            str = str.Replace("paralyze", "paralyse");

            // -og to -ogue
            str = str.Replace("analog", "analogue");
            str = str.Replace("catalog", "catalogue");
            str = str.Replace("dialog", "dialogue");

            // double consonants
            str = str.Replace("canceled", "cancelled");
            str = str.Replace("chanelled", "channelled");
            str = str.Replace("channeled", "channelled");
            str = str.Replace("Channeling", "Channelling");
            str = str.Replace("channeling", "channelling");
            str = str.Replace("counselor", "counsellor");
            str = str.Replace("cruelest", "cruellest");
            str = str.Replace("jewelery", "jewellery");
            str = str.Replace("labeled", "labelled");
            str = str.Replace("modeling", "modelling");
            str = str.Replace("quarreled", "quarrelled");
            str = str.Replace("shriveled", "shrivelled");
            str = str.Replace("signaling", "signalling");
            str = str.Replace("traveler", "traveller");
            str = str.Replace("traveling", "travelling");
            str = str.Replace("traveled", "travelled");
            str = str.Replace("tunneling ", "tunnelling");
            str = str.Replace("worshiper", "worshipper");
            str = str.Replace("leveled ", "levelled");

            // misc.
            str = str.Replace("gray", "grey");
            str = str.Replace("cozy", "cosy");
            str = str.Replace("Cozy", "Cosy");
            str = str.Replace("asshole", "arsehole");
            str = str.Replace("Asshole", "Arsehole");
            str = str.Replace("acknowlegement", "acknowledgement");
            str = str.Replace("dreamed", "dreamt");
            str = str.Replace("learned", "learnt");
            str = str.Replace("naught", "nought");
            str = str.Replace("my ass", "my arse");
            str = str.Replace("some kind of draft", "some kind of draught");

            return str;
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