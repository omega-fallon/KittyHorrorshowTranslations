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

namespace AnatomyTranslations
{
    [BepInProcess("Anatomy.exe")]
    [BepInPlugin("OmegaFallon.AnatomyTranslations", "Anatomy Translations", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;
        private void Awake()
        {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
            Instance = this;

            // Plugin startup logic
            Logger.LogInfo($"Plugin {"OmegaFallon.AnatomyTranslations"} is loaded!");
        }

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
                return;
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Math for button spacing
            int appWidth = Screen.width;
            int appHeight = Screen.height;

            int numLangs = 4;
            int widthSpacer = (appWidth - (numLangs * 150)) / (numLangs + 1);
            int heightSpacer = (appHeight - 100) / 2;

            if (!guiDimensionsPrinted)
            {
                guiDimensionsPrinted = true;
                Plugin.Instance.Logger.LogInfo("Window dimensions: " + appWidth.ToString() + " " + appHeight.ToString());
                Plugin.Instance.Logger.LogInfo("Button spacing values: " + widthSpacer.ToString() + " " + heightSpacer.ToString());
            }

            if (GUI.Button(new Rect(widthSpacer, heightSpacer, 150, 100), "English"))
            {
                gameLanguage = "English";
                AfterLanguageSelection();
            }
            if (GUI.Button(new Rect(widthSpacer + (1 * widthSpacer) + (1 * 150), heightSpacer, 150, 100), "Français"))
            {
                gameLanguage = "French";
                AfterLanguageSelection();
            }
            if (GUI.Button(new Rect(widthSpacer + (2 * widthSpacer) + (2 * 150), heightSpacer, 150, 100), "Nederlands"))
            {
                gameLanguage = "Dutch";
                AfterLanguageSelection();
            }
            if (GUI.Button(new Rect(widthSpacer + (3 * widthSpacer) + (3 * 150), heightSpacer, 150, 100), "日本語"))
            {
                gameLanguage = "Japanese";
                AfterLanguageSelection();
            }
        }

        // OWML code
        public AudioClip GetAudio(string filename)
        {
            var path = Paths.PluginPath + "\\AnatomyTranslations\\" + filename;
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
            var path = Paths.PluginPath + "\\AnatomyTranslations\\" + filename;
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
        public AudioClip amen_TRANS;

        public Texture2D input_TRANS;
        public Texture2D title1_TRANS;
        public Texture2D title2_TRANS;
        public Texture2D title3_TRANS;
        public Texture2D title4_TRANS;
        public void AfterLanguageSelection()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Plugin.Instance.Logger.LogInfo("Language set to "+gameLanguage);

            // Loading assets. Language-specific assets are loading into the _TRANS assets. This reduces switch statements later on. //
            switch (gameLanguage)
            {
                case "French":
                    // Audio
                    amen_TRANS = GetAudio("audio\\Achy Breaky Song.mp3");

                    // Images
                    input_TRANS = GetTexture("images\\input_FR.png");
                    title1_TRANS = GetTexture("images\\title1_FR.png");
                    title2_TRANS = GetTexture("images\\title2_FR.png");
                    title3_TRANS = GetTexture("images\\title3_FR.png");
                    title4_TRANS = GetTexture("images\\title4_FR.png");

                    break;
            }

            // Do texture replacements //
            TextureReplacement();
        }

        private string lastText;
        private bool texturereplaceOnLoad;
        private int scenesLoaded = 0;
        
        [HarmonyPatch]
        public class MyPatchClass
        {
            // Level loading
            [HarmonyPostfix]
            [HarmonyPatch(typeof(LoadLevelNum), nameof(LoadLevelNum.OnEnter))]
            public static void SceneLoad()
            {
                Plugin.Instance.scenesLoaded += 1;
                Plugin.Instance.Logger.LogInfo("A level was loaded. Number loaded this session: "+ Plugin.Instance.scenesLoaded.ToString());

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
            [HarmonyPatch(typeof(GUIContentAction), nameof(GUIContentAction.OnGUI))]
            public static void TextReplacement(GUIContentAction __instance)
            {
                if (__instance.text.Value != Plugin.Instance.lastText)
                {
                    Plugin.Instance.lastText = __instance.text.Value;
                    Plugin.Instance.Logger.LogInfo("Text was written to the screen: " + __instance.text.Value);
                }

                switch (__instance.text.Value)
                {
                    // House 1
                    case "THERE IS A TAPE IN THE DINING ROOM":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE CASSETTE DANS LA SALLE À MANGER";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN CASSETTE IN DE EETKAMER";
                                break;
                            case "Japanese":
                                __instance.text.Value = "食堂にカセットがある";
                                break;
                        }
                        break;
                    case "THERE IS A TAPE IN THE DOWNSTAIRS BATHROOM":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE CASSETTE DANS LA SALLE DE BAINS EN BAS";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN CASSETTE IN DE BENEDEN BADKAMER";
                                break;
                            case "Japanese":
                                __instance.text.Value = "階下の風呂場にカセットがある";
                                break;
                        }
                        break;
                    case "THERE IS A TAPE IN THE GARAGE":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE CASSETTE DANS LE GARAGE";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN CASSETTE IN DE GARAGE";
                                break;
                            case "Japanese":
                                __instance.text.Value = "車庫にカセットがある";
                                break;
                        }
                        break;
                    case "THERE IS A TAPE IN THE LIVING ROOM":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE CASSETTE DANS LE SALON";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN CASSETTE IN DE WOONKAMER";
                                break;
                            case "Japanese":
                                __instance.text.Value = "居間にカセットがある";
                                break;
                        }
                        break;
                    case "THERE IS A TAPE ON THE STAIRS":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE CASSETTE SUR LES ESCALIERS";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN CASSETTE OP DE TRAP";
                                break;
                            case "Japanese":
                                __instance.text.Value = "階段にカセットがあります";
                                break;
                        }
                        break;
                    case "THERE IS A TAPE IN A BEDROOM":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE CASSETTE DANS UNE CHAMBRE";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN CASSETTE IN EEN SLAAPKAMER";
                                break;
                            case "Japanese":
                                __instance.text.Value = "ある寝室にカセットがあります";
                                break;
                        }
                        break;
                    case "THERE IS A TAPE IN THE BASEMENT":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE CASSETTE DANS LE SOUS-SOL";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN CASSETTE IN DE KELDER";
                                break;
                            case "Japanese":
                                __instance.text.Value = "地下室にカセットがある";
                                break;
                        }
                        break;
                    case "THERE IS A TAPE IN THE MASTER BEDROOM":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE CASSETTE DANS LA CHAMBRE PRINCIPALE";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN CASSETTE IN DE HOOFDSLAAPKAMER";
                                break;
                            case "Japanese":
                                __instance.text.Value = "主寝室にカセットがある";
                                break;
                        }
                        break;

                    // House 2+
                    case "THERRRRRRRRRRRR       RE IS A TAPE IN THE DINING ROOM":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "ILLLLLLLLLLLLLL       Ÿ A UNE CASSETTE DANS LA SALLE À MANGER";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ERRRRRRRRRRRRRR       IS EEN CASSETTE IN DE EETKAMER";
                                break;
                            case "Japanese":
                                __instance.text.Value = "食堂にiiiiiiiiiiiiii       カセットがある";
                                break;
                        }
                        break;
                    case "THERE IS A TA   A A  AAAA  A         DOOrRS ARE UnNLOCKED":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE CA   A A  AAAA  A         POrTES SONT DéVERROUILLÉES";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN CA   A A  AAAA  A         DEuREN ZIJN ONTGRENDELD";
                                break;
                            case "Japanese":
                                __instance.text.Value = "カ   カ カ  カカカカ  カ がある         すべてnoドアはロックされていない";
                                break;
                        }
                        break;
                    case "THERE IS A TTHERE IS A TTHERE IS A TTHERE IS A TTHERE IS A TTHERE IS A TTHERE IS A TTHERE IS A T":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "IL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE C";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ER IS EEN EER IS EEN EER IS EEN EER IS EEN EER IS EEN EER IS EEN EER IS EEN EER IS EEN C";
                                break;
                            case "Japanese":
                                __instance.text.Value = "がある gがある gがある gがある gがある gがある gがある gがある";
                                break;
                        }
                        break;
                    case "THHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "ILLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL";
                                break;
                            case "Dutch":
                                __instance.text.Value = "ERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";
                                break;
                            case "Japanese":
                                __instance.text.Value = "があrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";
                                break;
                        }
                        break;
                    case "                                                                          HHHHHHHHHHHHHHHHHHHHHHHURTS":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.text.Value = "                                                                          FFFFFFFFFFFFFFFFFFFFAIT MAL";
                                break;
                            case "Dutch":
                                __instance.text.Value = "                                                                          DDDDDDDDDDDDDDDDDDDOET PIJN";
                                break;
                            case "Japanese":
                                __instance.text.Value = "                                                                          iiiiiiiiiiiiiiiiiiiiii痛い";
                                break;
                        }
                        break;
                }
            }

            // Audio replacement
            [HarmonyPrefix]
            [HarmonyPatch(typeof(PlaySound), "DoPlaySound")]
            public static void AudioReplacement(PlaySound __instance)
            {
                Plugin.Instance.Logger.LogInfo("Sound played: "+ __instance.clip.Value.ToString());

                switch (__instance.clip.Value.ToString())
                {
                    case "amen (UnityEngine.AudioClip)":
                        __instance.clip.Value = Plugin.Instance.amen_TRANS;
                        break;
                }
            }
        }

        // Texture replacement
        public void TextureReplacement()
        {
            foreach (var image in Resources.FindObjectsOfTypeAll<SpriteRenderer>()) 
            {
                Logger.LogInfo("Image was run through: " + image.gameObject.name);

                if (gameLanguage == "English" || string.IsNullOrEmpty(gameLanguage))
                {
                    return;
                }

                switch (image.gameObject.name)
                {
                    case "input":
                        image.sprite = Sprite.Create(input_TRANS, new Rect(0.0f, 0.0f, 800, 600), new Vector2(0.5f, 0.5f), 100.0f);
                        break;
                    case "title1":
                        image.sprite = Sprite.Create(title1_TRANS, new Rect(0.0f, 0.0f, 800, 600), new Vector2(0.5f, 0.5f), 100.0f);
                        break;
                    case "title2":
                        image.sprite = Sprite.Create(title2_TRANS, new Rect(0.0f, 0.0f, 800, 600), new Vector2(0.5f, 0.5f), 100.0f);
                        break;
                    case "title3":
                        image.sprite = Sprite.Create(title3_TRANS, new Rect(0.0f, 0.0f, 800, 600), new Vector2(0.5f, 0.5f), 100.0f);
                        break;
                    case "title4":
                        image.sprite = Sprite.Create(title4_TRANS, new Rect(0.0f, 0.0f, 800, 600), new Vector2(0.5f, 0.5f), 100.0f);
                        break;
                }
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