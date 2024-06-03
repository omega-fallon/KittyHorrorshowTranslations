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

namespace KittyHorrorshowTranslations
{
    [BepInProcess("Anatomy.exe")]
    [BepInProcess("exclusion.exe")]
    [BepInProcess("sunset.exe")]
    [BepInProcess("Leechbowl.exe")]
    [BepInProcess("pente.exe")]
    [BepInProcess("rainhouse.exe")]
    [BepInProcess("Monastery.exe")]
    [BepInProcess("actias.exe")]
    [BepInProcess("grandmother.exe")]
    [BepInProcess("Roads.exe")]
    [BepInPlugin("OmegaFallon.KittyHorrorshowTranslations", "Kitty Horrorshow Translations", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;
        public void Awake()
        {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
            Instance = this;

            // Plugin startup logic
            Logger.LogInfo($"Plugin {"OmegaFallon.KittyHorrorshowTranslations"} is loaded!");

            // Load what game this is
            runningGame = Paths.ProcessName;
            runningGame = char.ToUpper(runningGame[0]) + runningGame.Substring(1);
            Logger.LogInfo("Current running game is " + runningGame);

            // Add .cs files for individual games
            gameObject.AddComponent<Actias>();
            gameObject.AddComponent<Anatomy>();
            gameObject.AddComponent<Grandmother>();
        }

        public string runningGame;
        public string gameLanguage = "";
        public bool guiDimensionsPrinted;
        public void OnGUI()
        {
            // If we've loaded into gameplay and the language is still null, default to English.
            if (scenesLoaded > 0 && string.IsNullOrEmpty(gameLanguage))
            {
                Plugin.Instance.Logger.LogInfo("No input on language selection screen. Defaulting to English.");
                gameLanguage = "English";
            }
            
            // If the language has already been decided, return.
            if (!string.IsNullOrEmpty(gameLanguage))
            {
                // nothing
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // Math for button spacing
                int appWidth = Screen.width;
                int appHeight = Screen.height;

                int numLangs = 4;

                int buttonWidth = 150;
                int buttonHeight = 100;

                int widthSpacer = (appWidth - (numLangs * buttonWidth)) / (numLangs + 1);
                int heightSpacer = (appHeight - buttonHeight) / 2;

                // Write code here to catch buttons overlapping if we ever get enough languages for that to happen
                if (widthSpacer < 0)
                {

                }

                if (!guiDimensionsPrinted)
                {
                    guiDimensionsPrinted = true;
                    Plugin.Instance.Logger.LogInfo("Window dimensions: " + appWidth.ToString() + " " + appHeight.ToString());
                    Plugin.Instance.Logger.LogInfo("Button spacing values: " + widthSpacer.ToString() + " " + heightSpacer.ToString());
                }

                if (GUI.Button(new Rect(widthSpacer, heightSpacer, buttonWidth, buttonHeight), "English"))
                {
                    gameLanguage = "English";
                    AfterLanguageSelection();
                }
                if (GUI.Button(new Rect(widthSpacer + (1 * widthSpacer) + (1 * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "Français"))
                {
                    gameLanguage = "French";
                    AfterLanguageSelection();
                }
                if (GUI.Button(new Rect(widthSpacer + (2 * widthSpacer) + (2 * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "Nederlands"))
                {
                    gameLanguage = "Dutch";
                    AfterLanguageSelection();
                }
                if (GUI.Button(new Rect(widthSpacer + (3 * widthSpacer) + (3 * buttonWidth), heightSpacer, buttonWidth, buttonHeight), "日本語"))
                {
                    gameLanguage = "Japanese";
                    AfterLanguageSelection();
                }
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
        public class MyPatchClass
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
                        try
                        {
                            __instance.text.Value = Grandmother.Instance.TextReplacement(__instance.text.Value);
                        }
                        catch (Exception ex)
                        {
                            Plugin.Instance.Logger.LogInfo("Text replacement error occured: " + ex.ToString());
                        }
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
            string[] skipTextureReplacement = ["Grandmother"];
            if (Array.IndexOf(skipTextureReplacement, runningGame) != -1)
            {
                return;
            }

            // First, we run the sprite replacement foreach
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

            // Secondly, the actual *texture* replacement loop. Yes, these two things are different, but I'm calling them both textures because that's what they are.
            foreach (var renderer in Resources.FindObjectsOfTypeAll<Texture2D>())
            {
                Logger.LogInfo("Texture was run through: " + renderer.name);
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