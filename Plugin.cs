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

namespace KittyHorrorshowTranslations
{
    // Fully works under x86
    [BepInProcess("actias.exe")] // 5.2.0
    [BepInProcess("ccccccc.exe")] // 5.0.2
    [BepInProcess("Anatomy.exe")] // 5.2.0

    [BepInProcess("grandmother.exe")] // 5.2.0
    [BepInProcess("Leechbowl.exe")] // 5.2.0
    [BepInProcess("pente.exe")] // 5.2.0

    [BepInProcess("Gloompuke.exe")] // 5.3.5
    [BepInProcess("Scarlet.exe")] // 5.3.5

    // Fully works under x64
    [BepInProcess("Monastery.exe")] // 5.4.3
    [BepInProcess("Roads.exe")] // 5.4.3

    // Logs generated but no language menu under x86
    [BepInProcess("sigilvalley.exe")] // 4.6.3
    [BepInProcess("sunset.exe")] // 4.6.3
    [BepInProcess("rainhouse.exe")] // 4.6.3
    [BepInProcess("CHYRZA.exe")] // 4.3.3

    // Fully doesn't work under x86 and x64
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

            // Add .cs files and Harmony patches for individual games
            Harmony.CreateAndPatchAll(typeof(MainPatches));
            switch (runningGame)
            {
                case "Actias":
                    gameObject.AddComponent<Actias>();
                    break;
                case "Anatomy":
                    gameObject.AddComponent<Anatomy>();
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
            }
        }

        public void PrintThisString(string str)
        {
            Logger.LogInfo(str);
        }

        public string runningGame;
        public string gameLanguage = "";
        public bool guiDimensionsPrinted;
        public void OnGUI()
        {
            // If the language has already been decided, return.
            if (!string.IsNullOrEmpty(gameLanguage))
            {
                return;
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Establishing order and inclusion of languages - in final release, have this vary by game
            string[] languages = ["English", "French", "Dutch", "Japanese"];

            int englishDex = Array.IndexOf(languages, "English");
            int frenchDex = Array.IndexOf(languages, "French");
            int dutchDex = Array.IndexOf(languages, "Dutch");
            int japaneseDex = Array.IndexOf(languages, "Japanese");

            // Math for button spacing
            int appWidth = Screen.width;
            int appHeight = Screen.height;

            int numLangs = languages.Length;

            int buttonWidth = 150;
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

            // Placing the buttons
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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Plugin.Instance.Logger.LogInfo("Language set to "+gameLanguage);

            // Loading assets. Language-specific assets are loading into the _TRANS assets. This reduces switch statements later on. //
            switch (runningGame)
            {
                case "Anatomy":
                    Anatomy.Instance.AssetLoading();
                    break;
                case "Gloompuke":
                    Gloompuke.Instance.EditObjectNames();
                    break;
            }

            // Do texture replacements //
            TextureReplacement();
        }
            
        public string lastText;
        public bool texturereplaceOnLoad;
        public int scenesLoaded;
        public int currentLevelIndex;
        public GUIStyle guiStyle = new GUIStyle();

        [HarmonyPatch]
        public class MainPatches
        {
            // Level loading
            [HarmonyPostfix]
            [HarmonyPatch(typeof(LoadLevelNum), nameof(LoadLevelNum.OnEnter))]
            public static void SceneLoad(LoadLevelNum __instance)
            {
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
                    Plugin.Instance.Logger.LogInfo("Language has already been set. Running texture replacements.");
                    Plugin.Instance.TextureReplacement();
                }
            }

            // Text replacement
            [HarmonyPostfix]
            [HarmonyPatch(typeof(GUILabel), nameof(GUILabel.OnGUI))]
            public static void StyleReplacement(GUILabel __instance)
            {
                
            }

            [HarmonyPostfix]
            [HarmonyPatch(typeof(GUIContentAction), nameof(GUIContentAction.OnGUI))]
            public static void TextReplacement(GUIContentAction __instance)
            {
                if (__instance.text.Value != Plugin.Instance.lastText)
                {
                    if (!string.IsNullOrEmpty(__instance.text.Value))
                    {
                        Plugin.Instance.lastText = __instance.text.Value;
                    }
                    Plugin.Instance.Logger.LogInfo("Text was written to the screen: " + __instance.text.Value);
                    Plugin.Instance.Logger.LogInfo("Style was as follows: " + __instance.style.Value);
                }

                // Font replacement - WIP
                switch (Plugin.Instance.gameLanguage)
                {
                    case "Japanese":
                        //__instance.style.Value = "";
                        break;
                }

                // Call individual games' text replacement functions
                switch (Plugin.Instance.runningGame)
                {
                    case "Actias":
                        __instance.text.Value = Actias.Instance.TextReplacement(__instance.text.Value);
                        break;
                    case "Anatomy":
                        __instance.text.Value = Anatomy.Instance.TextReplacement(__instance.text.Value);
                        break;
                    case "Grandmother":
                        __instance.text.Value = Grandmother.Instance.TextReplacement(__instance.text.Value);
                        break;
                    case "Leechbowl":
                        __instance.text.Value = Leechbowl.Instance.TextReplacement(__instance.text.Value);
                        break;
                }
            }

            // Audio replacement
            [HarmonyPrefix]
            [HarmonyPatch(typeof(PlaySound), "DoPlaySound")]
            public static void AudioReplacement(PlaySound __instance)
            {
                Plugin.Instance.Logger.LogInfo("Sound played: "+ __instance.clip.Value.name);

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

        // Texture replacement
        public void TextureReplacement()
        {
            // Skipping games for which texture replacement is unnecessary
            string[] skipTextureReplacement = ["Grandmother", "Gloompuke"];
            if (Array.IndexOf(skipTextureReplacement, runningGame) != -1)
            {
                return;
            }

            // First, we run the sprite replacement foreach
            Logger.LogInfo("Beginning image runthroughs...");
            foreach (var image in Resources.FindObjectsOfTypeAll<SpriteRenderer>())
            {
                Logger.LogInfo("Image was run through: " + image.gameObject.name);

                // Don't do any actual replacements if the language is English or null/empty
                if (gameLanguage == "English" || string.IsNullOrEmpty(gameLanguage))
                {
                    return;
                }

                switch (Plugin.Instance.runningGame)
                {
                    case "Anatomy":
                        image.sprite = Anatomy.Instance.TextureReplacement(image);
                        break;
                }

            }
            Logger.LogInfo("End of image runthroughs.");

            // Secondly, the actual *texture* replacement loop. Yes, these two things are different, but I'm calling them both textures because that's what they are.
            Logger.LogInfo("Beginning texture runthroughs...");
            foreach (var renderer in Resources.FindObjectsOfTypeAll<Texture2D>())
            {
                Logger.LogInfo("Texture was run through: " + renderer.name);
            }
            Logger.LogInfo("End of texture runthroughs.");
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