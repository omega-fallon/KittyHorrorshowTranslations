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

    // DOES NOT WORK under x86 or x64 - has a UnityPlayer.dll
    [BepInProcess("basements.exe")] // 2017.4.2
    [BepInProcess("wormclot.exe")] // 2017.4.2
    [BepInProcess("GhostLake.exe")] // unknown
    [BepInProcess("seven.exe")] // 2017.4.2

    [BepInProcess("exclusion.exe")] // 2017.4.2
    [BepInProcess("Grandmother's Garden.exe")] // 2017.4.2
    [BepInProcess("Lethargy Hill.exe")] // 2019.2.0
    [BepInProcess("Tenement.exe")] // 2017.4.2

    [BepInProcess("LivingRoom.exe")] // 2019.4.0
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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public bool nineDown;
        public bool rainHouseImageRunDone;
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

                Logger.LogInfo("Running debug texture and audio replacement...");
                TextureAudioReplacement(true);
                Logger.LogInfo("Done with debug texture and audio replacement.");
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
            if (Array.IndexOf(titleCardGames, runningGame) != -1 && rainHouseImageRunDone != true)
            {
                TextureAudioReplacement();

                if (imagesRanThrough > 1)
                {
                    rainHouseImageRunDone = true;
                }
            }
        }

        public int notNeededButtonFrames;
        public bool cursorErrorSkip;
        public bool subtitlesDecided;
        public bool doSubtitles;

        public void OnGUI()
        {
            try
            {
                // If the language has already been decided and subtitles have been decided (for games that need them), return
                if (!string.IsNullOrEmpty(gameLanguage))
                {
                    if (subtitlesDecided)
                    {
                        return;
                    }
                    else if (runningGame == "Anatomy")
                    {
                        switch (gameLanguage)
                        {
                            case "English":
                                if (GUI.Button(new Rect((Screen.width - 150) / 2, (Screen.height - 100) / 2, 150, 100), "Enable subtitles?\n\nY / N"))
                                {
                                    // nothing
                                }
                                break;
                            case "French":
                                if (GUI.Button(new Rect((Screen.width - 150) / 2, (Screen.height - 100) / 2, 150, 100), "Activer les sous-titres ?\n\nY (OUI) / N (NON)"))
                                {
                                    // nothing
                                }
                                break;
                            case "Dutch":
                                if (GUI.Button(new Rect((Screen.width - 150) / 2, (Screen.height - 100) / 2, 150, 100), "Ondertiteling inschakelen?\n\nY (JA) / N (NEE)"))
                                {
                                    // nothing
                                }
                                break;
                            case "Japanese":
                                if (GUI.Button(new Rect((Screen.width - 150) / 2, (Screen.height - 100) / 2, 150, 100), "字幕を有効にしますか?\n\nY (はい) / N (いいえ)"))
                                {
                                    // nothing
                                }
                                break;
                        }
                        
                        // Keycodes aren't translated because that's not how it works in the other games
                        if (Input.GetKeyDown(KeyCode.Y))
                        {
                            subtitlesDecided = true;
                            doSubtitles = true;
                        }
                        else if (Input.GetKeyDown(KeyCode.N))
                        {
                            subtitlesDecided = true;
                            doSubtitles = false;
                        }
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                // Error dodging for 4.0 games
                if (cursorErrorSkip != true)
                {
                    try
                    {
                        UnlockCursor();
                    }
                    catch
                    {
                        cursorErrorSkip = true;
                        Plugin.Instance.Logger.LogInfo("Inconsequential error: UnlockCursor failed likely due to this being a 4.x game.");
                    }
                }

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
                if (Array.IndexOf(languages, "Unneeded") != -1)
                {
                    buttonWidth = 200;
                }
                else
                {
                    buttonWidth = 150;
                }

                int buttonHeight = 100;

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
                    GUI.Button(new Rect(widthSpacer, heightSpacer, buttonWidth, buttonHeight), "No translation needed." + "\nAucune traduction nécessaire." + "\nGeen vertaling nodig." + "\n翻訳は必要ありません。");

                    notNeededButtonFrames += 1;

                    return;
                }

                // Standard buttons
                if (englishDex != -1)
                {
                    if (GUI.Button(new Rect(widthSpacer + (englishDex * widthSpacer) + (englishDex * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "English" + "\n\n(Press " + (englishDex + 1) + ")"))
                    {
                        gameLanguage = "English";
                        AfterLanguageSelection();
                    }
                }
                if (frenchDex != -1)
                {
                    if (GUI.Button(new Rect(widthSpacer + (frenchDex * widthSpacer) + (frenchDex * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "Français" + "\n\n(Appuyez " + (frenchDex + 1) + ")"))
                    {
                        gameLanguage = "French";
                        AfterLanguageSelection();
                    }
                }
                if (dutchDex != -1)
                {
                    if (GUI.Button(new Rect(widthSpacer + (dutchDex * widthSpacer) + (dutchDex * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "Nederlands" + "\n\n(Druk " + (dutchDex + 1) + ")"))
                    {
                        gameLanguage = "Dutch";
                        AfterLanguageSelection();
                    }
                }
                if (japaneseDex != -1)
                {
                    if (GUI.Button(new Rect(widthSpacer + (japaneseDex * widthSpacer) + (japaneseDex * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "日本語" + "\n\n(" + (japaneseDex + 1) + "を押す)"))
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
        public AudioClip GetAudio(string filename)
        {
            var path = Paths.PluginPath + "\\KittyHorrorshowTranslations\\audio\\" + filename;
            Logger.LogInfo("Loading audio from "+path);
            using var reader = new NAudio.Wave.AudioFileReader(path);
            var sampleCount = (int)(reader.Length * 8 / reader.WaveFormat.BitsPerSample);
            var outputSamples = new float[sampleCount];
            reader.Read(outputSamples, 0, sampleCount);
            var clip = AudioClip.Create(path, sampleCount / reader.WaveFormat.Channels, reader.WaveFormat.Channels, reader.WaveFormat.SampleRate, false);
            clip.SetData(outputSamples, 0);
            return clip;
        }
        public Texture2D GetTexture(string filename)
        {
            var path = Paths.PluginPath + "\\KittyHorrorshowTranslations\\images\\" + filename;
            Logger.LogInfo("Loading texture from " + path);
            var data = File.ReadAllBytes(path);
            var texture = new Texture2D(2, 2);
            texture.LoadImage(data);
            return texture;
        }
        // End OWML code

        public void Start()
        {
            
        }

        // Loading textures and audio
        public void AfterLanguageSelection()
        {
            // Error dodging for 4.0 games
            if (cursorErrorSkip != true)
            {
                try
                {
                    LockCursor();
                }
                catch
                {
                    cursorErrorSkip = true;
                    Logger.LogInfo("Inconsequential error: LockCursor failed likely due to this being a 4.x game.");
                }
            }

            Logger.LogInfo("Language set to "+gameLanguage);
            foreach (string font in UnityEngine.Font.GetOSInstalledFontNames())
            {
                Logger.LogInfo("System font found: "+font);
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

        [HarmonyPatch]
        public class HutongPatches
        {
            // Level loading
            [HarmonyPrefix]
            [HarmonyPatch(typeof(LoadLevelNum), nameof(LoadLevelNum.OnEnter))]
            public static void SceneLoad(LoadLevelNum __instance)
            {
                // Setting variables //
                Plugin.Instance.scenesLoaded += 1;
                Plugin.Instance.currentLevelIndex = __instance.levelIndex.Value;

                // DEBUG
                //__instance.levelIndex.Value = 7;

                Plugin.Instance.Logger.LogInfo("A level was loaded. Index: " + __instance.levelIndex.ToString() + ". Number of levels loaded this session: " + Plugin.Instance.scenesLoaded.ToString());

                // Check language //
                if (string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
                {
                    Plugin.Instance.Logger.LogInfo("Language is null or empty.");
                }
                else
                {
                    Plugin.Instance.Logger.LogInfo("Language has already been set. Running texture replacements.");
                    Plugin.Instance.TextureAudioReplacement();
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

                switch (Plugin.Instance.runningGame)
                {
                    case "Anatomy":
                        __instance.clip.Value = Anatomy.Instance.AudioReplacement(__instance.clip.Value);
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
            string[] doAudioReplacement = ["CHYRZA"];
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