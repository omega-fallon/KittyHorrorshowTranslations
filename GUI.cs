using BepInEx;
using HarmonyLib;
using KittyHorrorshowTranslations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OmegaFallon.KittyHorrorshowTranslations
{
    public class Language
    {
        public int index { get; set; }
        public string name { get; set; }

        public string localName { get; set; }
        public string prompt { get; set; }
    }

    public class GUI : MonoBehaviour
    {
        public static GUI Instance;
        public void Awake()
        {
            Instance = this;
        }

        public int notNeededButtonFrames;

        public bool cursorErrorSkip;
        public bool subtitlesDecided;
        public bool doSubtitles;

        public bool readmeDecided;
        public bool subtitlesDecidedLetGo;

        public int titleCardStartTime;
        public bool guiDimensionsPrinted;

        public Font comicSans = UnityEngine.Font.CreateDynamicFontFromOSFont(["Comic Sans MS"], 60);
        public Font timesNewRoman = UnityEngine.Font.CreateDynamicFontFromOSFont(["Times New Roman"], 60);

        public Font japaneseSerif = UnityEngine.Font.CreateDynamicFontFromOSFont(["MS Mincho", "MS PMincho"], 60);
        public Font koreanSerif = UnityEngine.Font.CreateDynamicFontFromOSFont(["Batang", "BatangChe", "Gungsuh", "GungsuhChe"], 60);

        public void Start()
        {
            
        }

        public void HutongOutsource()
        {
            try
            {
                if (Plugin.Instance.runningGameFont == null || (Plugin.Instance.runningGameFont.name != PlayMakerGUI.GUISkin.font.name))
                {
                    Plugin.Instance.runningGameFont = PlayMakerGUI.GUISkin.font;
                    Plugin.Instance.PrintThisString("Game font name is: " + Plugin.Instance.runningGameFont.name);
                }
            }
            catch (Exception ex)
            {
                if (Plugin.Instance.runningGameFont == null || (Plugin.Instance.runningGameFont.name != GUISkin.current.font.name))
                {
                    Plugin.Instance.runningGameFont = UnityEngine.GUI.skin.font;
                    Plugin.Instance.PrintThisString("Game font could not be found: " + ex.ToString());
                }
            }
        }

        public bool noHutong;
        public void OnGUI()
        {
            try
            {
                switch (Plugin.Instance.runningGame)
                {
                    case "Grandmother":
                        
                        break;
                }

                if (noHutong)
                {
                    // do nothing
                }
                else if (Plugin.Instance.runningGameFont != null && Plugin.Instance.runningGameFont.name != "Arial")
                {
                    // do nothing
                }
                else if (Plugin.Instance.noHutong.Contains(Plugin.Instance.runningGame))
                {
                    Plugin.Instance.runningGameFont = GUISkin.current.font;
                    GUI.Instance.noHutong = true;
                    Plugin.Instance.PrintThisString("No Hutong so cannot get game font.");
                }
                else
                {
                    HutongOutsource();
                }
                

                // Creating standard button style
                GUIStyle standardButtonStyle = GUISkin.current.button;

                // For rainhouse specifically, introduce a pause before showing the menu
                switch (Plugin.Instance.runningGame)
                {
                    case "Rainhouse":
                    case "Rainhouse_64bit":
                    case "Actias":
                        if (Plugin.Instance.imagesRanThrough == 1 || Plugin.Instance.imagesRanThrough == 0)
                        {
                            return;
                        }
                        break;
                }

                // If the language has already been decided and subtitles have been decided (for games that need them), return
                if (!string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
                {
                    if (Plugin.Instance.runningGame != "Anatomy" && Plugin.Instance.runningGame != "CHYRZA")
                    {
                        subtitlesDecided = true;
                    }

                    if (subtitlesDecided && readmeDecided)
                    {
                        try
                        {
                            if (titleCardStartTime == 0)
                            {
                                titleCardStartTime = Plugin.Instance.updateCounter;
                            }

                            string translatedTitle = Plugin.Instance.runningGame;

                            translatedTitle = TranslatedTitles(translatedTitle);

                            if (new string[] { "Anatomy" }.Contains(Plugin.Instance.runningGame))
                            {
                                // Do nothing; game already has a built-in title card
                            }
                            else if (Plugin.Instance.updateCounter - titleCardStartTime < 5 * 60)
                            {
                                float width = (float)(Screen.width * 0.75);
                                float height = (float)(Screen.height * 0.5);
                                float x = (float)((Screen.width - width) / 2);
                                float y = (float)((Screen.height - height) / 2);

                                GUIStyle style = GUISkin.current.label;
                                style.fontSize = 60;
                                //style.fontStyle = UnityEngine.FontStyle.Italic;
                                style.alignment = TextAnchor.UpperCenter;
                                style.font = Plugin.Instance.runningGameFont;

                                string titleCardText;
                                switch (Plugin.Instance.gameLanguage)
                                {
                                    case "Chinese (Simplified)":
                                    case "Chinese (Traditional)":
                                        titleCardText = "基蒂·哈拉肖" + "的" + "\n《" + translatedTitle + "》";
                                        break;
                                    case "Dutch":
                                        titleCardText = "\"" + translatedTitle + "\"" + "\nvan Kitty Horrorshow";
                                        break;
                                    case "French":
                                        titleCardText = "« " + translatedTitle + " »" + "\nde Kitty Horrorshow";
                                        break;
                                    case "Japanese":
                                        titleCardText = "キティ・ハラショー" + "の" + "\n「" + translatedTitle + "」";
                                        break;
                                    case "Korean":
                                        titleCardText = "키티 하라쇼" + "\n'" + translatedTitle + "'";
                                        break;
                                    case "Polish":
                                        titleCardText = "„" + translatedTitle + "”" + "\nKitty Horrorshow";
                                        break;
                                    case "English":
                                        titleCardText = "";
                                        break;
                                    default:
                                        titleCardText = "\"" + translatedTitle + "\"" + "\nKitty Horrorshow";
                                        break;
                                }
                                if (!string.IsNullOrEmpty(titleCardText))
                                {
                                    UnityEngine.GUI.Label(new Rect(x, y, width, height), new GUIContent(titleCardText), style);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Plugin.Instance.PrintThisString("Exception when trying to print titlecard: " + ex.ToString());
                        }

                        return;
                    }

                    if (subtitlesDecided && !readmeDecided)
                    {
                        string[] pathParts = { Paths.PluginPath, "KittyHorrorshowTranslations", "readmes", Plugin.Instance.runningGame, Plugin.Instance.gameLanguage };
                        string[] pathParts2 = { Paths.PluginPath, "KittyHorrorshowTranslations", "net35", "readmes", Plugin.Instance.runningGame, Plugin.Instance.gameLanguage };

                        string[][] listsOfPathParts = { pathParts, pathParts2 };
                        string path = "";

                        foreach (string[] pathPartList in listsOfPathParts)
                        {
                            switch (Plugin.Instance.runningGame)
                            {
                                case "Grandmother":
                                case "Leechbowl":
                                case "Pente":
                                    pathPartList[Array.IndexOf(pathPartList, Plugin.Instance.runningGame)] = "Haunted Cities Vol. 1";
                                    break;
                                case "Gloompuke":
                                case "Monastery":
                                case "Roads":
                                case "Scarlet Bough":
                                case "Scarlet":
                                    pathPartList[Array.IndexOf(pathPartList, Plugin.Instance.runningGame)] = "Haunted Cities Vol. 2";
                                    break;
                                case "Basements":
                                case "Castle Wormclot":
                                case "Wormclot":
                                case "Ghost Lake":
                                case "GhostLake":
                                case "Seven Days":
                                case "Seven":
                                    pathPartList[Array.IndexOf(pathPartList, Plugin.Instance.runningGame)] = "Haunted Cities Vol. 3";
                                    break;
                                case "Exclusion Zone":
                                case "Exclusion":
                                case "Grandmother's Garden":
                                case "Lethargy Hill":
                                case "Tenement":
                                    pathPartList[Array.IndexOf(pathPartList, Plugin.Instance.runningGame)] = "Haunted Cities Vol. 4";
                                    break;
                            }

                            path = String.Join("\\", pathPartList.Where(x => !string.IsNullOrEmpty(x)).ToArray());

                            if (!Directory.Exists(path))
                            {
                                break;
                            }
                        }
                        
                        if (Directory.Exists(path))
                        {
                            Plugin.Instance.UnlockCursor();

                            string readmePrompt;

                            switch (Plugin.Instance.gameLanguage)
                            {
                                case "French": readmePrompt = "Lire les fichiers .txt\nqui accompagnent le jeu ?\n\n" + MiscGames.Instance.YesNo(); break;
                                case "Dutch": readmePrompt = "De bijbehorende .txt-bestanden\nvan de game lezen?\n\n" + MiscGames.Instance.YesNo(); break;
                                case "Japanese": readmePrompt = "ゲームに付属する.txt\nファイルを読みますか?\n\n" + MiscGames.Instance.YesNo(); break;
                                default: readmePrompt = "ERROR, THIS TEXT MUST BE FILLED IN"; break;
                            }

                            if (string.IsNullOrEmpty(readmePrompt))
                            {
                                // nothing
                            }
                            else
                            {
                                if (UnityEngine.GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 200, 100), readmePrompt, standardButtonStyle))
                                {
                                    readmeDecided = true;
                                    Process.Start(path);

                                    Plugin.Instance.LockCursor();
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

                                        Plugin.Instance.LockCursor();
                                    }
                                    else if (Input.GetKeyDown(KeyCode.N))
                                    {
                                        readmeDecided = true;

                                        Plugin.Instance.LockCursor();
                                    }
                                }
                            }
                        }
                        else
                        {
                            readmeDecided = true;
                            Plugin.Instance.LockCursor();
                        }
                    }
                    else if (!subtitlesDecided)
                    {
                        Plugin.Instance.UnlockCursor();

                        string subtitlePrompt;
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "English": subtitlePrompt = "Enable subtitles?\n\n" + MiscGames.Instance.YesNo(); break;
                            case "French": subtitlePrompt = "Activer les sous-titres ?\n\n" + MiscGames.Instance.YesNo(); break;
                            case "Dutch": subtitlePrompt = "Ondertiteling inschakelen?\n\n" + MiscGames.Instance.YesNo(); break;
                            case "Japanese": subtitlePrompt = "字幕を有効にしますか?\n\n" + MiscGames.Instance.YesNo(); break;
                            default: subtitlePrompt = "ERROR, THIS TEXT MUST BE FILLED IN"; break;
                        }

                        if (string.IsNullOrEmpty(subtitlePrompt))
                        {
                            // nothing
                        }
                        else
                        {
                            if (UnityEngine.GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 200, 100), subtitlePrompt, standardButtonStyle))
                            {
                                subtitlesDecided = true;
                                doSubtitles = true;

                                Plugin.Instance.LockCursor();
                            }
                            else
                            {
                                // Keycodes aren't translated because that's not how it works in the other games
                                if (Input.GetKeyDown(KeyCode.Y))
                                {
                                    subtitlesDecided = true;
                                    doSubtitles = true;

                                    Plugin.Instance.LockCursor();
                                }
                                else if (Input.GetKeyDown(KeyCode.N))
                                {
                                    subtitlesDecided = true;
                                    doSubtitles = false;

                                    Plugin.Instance.LockCursor();
                                }
                            }
                        }
                    }

                    return;
                }

                Plugin.Instance.UnlockCursor();

                // Establishing order and inclusion of languages - in final release, have this vary by game
                string[] availableLanguagesForThisGame = [];
                switch (Plugin.Instance.runningGame)
                {
                    case "Sigilvalley":
                    case "Sigilvalley_64bit":
                    case "Vaporcrane":
                    case "Vaporcrane_win":
                    case "Village":
                    case "Village_win":
                        availableLanguagesForThisGame = ["All"];
                        break;
                    default:
                        availableLanguagesForThisGame = ["English", "French", "Dutch", "Japanese", "Chinese (Simplified)", "Chinese (Traditional)"];
                        break;
                }

                // List of languages
                List<Language> languageList =
                [
                    new Language() { name = "English", localName = "English", prompt = "(Press NUMBER)" },

                    // Other langs
                    //new Language() { name = "Arabic", localName = "عربي", prompt = "(اضغط على NUMBER)" },
                    //new Language() { name = "Bengali", localName = "বাংলা", prompt = "(NUMBER টিপুন)" },
                    //new Language() { name = "Catalan", localName = "Català", prompt = "(Premeu NUMBER)" },
                    new Language() { name = "Chinese (Simplified)", localName = "简体中文", prompt = "（按下NUMBER）" },
                    new Language() { name = "Chinese (Traditional)", localName = "繁體中文", prompt = "（按下NUMBER）" },
                    new Language() { name = "Dutch", localName = "Nederlands", prompt = "(Druk op NUMBER)" },
                    new Language() { name = "French", localName = "Français", prompt = "(Appuyer sur NUMBER)" },
                    //new Language() { name = "German", localName = "Deutsch", prompt = "(Drücke NUMBER)" },
                    //new Language() { name = "Greek", localName = "Ελληνικά", prompt = "(XXX NUMBER)" },
                    //new Language() { name = "Hindi", localName = "हिन्दी", prompt = "(NUMBER दबाएँ)" },
                    //new Language() { name = "Italian", localName = "Italiano", prompt = "(Premi NUMBER)" },
                    new Language() { name = "Japanese", localName = "日本語", prompt = "(NUMBERを押す)" },
                    //new Language() { name = "Korean", localName = "한국인", prompt = "(NUMBER를 눌러)" },
                    //new Language() { name = "Polish", localName = "Polski", prompt = "(Naciśnij NUMBER)"},
                    //new Language() { name = "Portuguese", localName = "Português", prompt = "(Pressione NUMBER)"},
                    //new Language() { name = "Russian", localName = "Русский", prompt = "(Нажмите NUMBER)"},
                    //new Language() { name = "Spanish", localName = "Español", prompt = "(Presiona NUMBER)" },
                    //new Language() { name = "Turkish", localName = "Türkçe", prompt = "(NUMBER basın)" },
                    //new Language() { name = "Ukrainian", localName = "Українська", prompt = "(Натисніть NUMBER)"},
                ];

                // "All" shorthand
                if (Array.IndexOf(availableLanguagesForThisGame, "All") != -1)
                {
                    List<string> tempLangList = new List<string>();
                    foreach (Language lang in languageList)
                    {
                        tempLangList.Add(lang.name);
                    }
                    availableLanguagesForThisGame = tempLangList.ToArray();
                }

                // Math for button spacing
                int appWidth = Screen.width;
                int appHeight = Screen.height;

                int numLangs = availableLanguagesForThisGame.Length;

                int buttonWidth;
                int buttonHeight;
                if (Array.IndexOf(availableLanguagesForThisGame, "Unneeded") != -1)
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
                int widthSpacer2 = widthSpacer;
                int widthSpacer3 = widthSpacer;

                int maxLangsPerColumn = (int)Math.Floor((double)((appWidth*0.75) / buttonWidth));
                int numColumns = 1;
                for (int i = 1; i < 10; i++)
                {
                    if (numLangs > maxLangsPerColumn*i)
                    {
                        numColumns = i + 1;
                    }
                    else
                    {
                        break;
                    }
                }

                //Plugin.Instance.PrintThisString("maxLangsPerColumn & numColumns: " + maxLangsPerColumn + " " + numColumns);

                int heightSpacer = (appHeight - (numColumns * buttonHeight)) / (numColumns + 1);

                switch (numColumns)
                {
                    case 1:
                        break;
                    case 2:
                        widthSpacer = (appWidth - (maxLangsPerColumn * buttonWidth)) / (maxLangsPerColumn + 1);
                        widthSpacer2 = (appWidth - ((numLangs - maxLangsPerColumn) * buttonWidth)) / (numLangs - maxLangsPerColumn + 1);
                        break;
                    case 3:
                        widthSpacer = (appWidth - (maxLangsPerColumn * buttonWidth)) / (maxLangsPerColumn + 1);
                        widthSpacer2 = (appWidth - (maxLangsPerColumn * buttonWidth)) / (maxLangsPerColumn + 1);
                        widthSpacer3 = (appWidth - ((numLangs - (maxLangsPerColumn*2)) * buttonWidth)) / (numLangs - (maxLangsPerColumn*2) + 1);
                        break;
                }

                // No translation needed popup
                if (notNeededButtonFrames > 10 * 60)
                {
                    Plugin.Instance.gameLanguage = "English";
                    return;
                }
                if (Array.IndexOf(availableLanguagesForThisGame, "Unneeded") != -1)
                {
                    GUIStyle style = GUISkin.current.button;
                    style.fontSize = 30;

                    UnityEngine.GUI.Button(new Rect(widthSpacer, heightSpacer, buttonWidth, buttonHeight), "No translation needed." + "\nAucune traduction nécessaire." + "\nGeen vertaling nodig." + "\n翻訳は必要ありません。", style);

                    notNeededButtonFrames += 1;

                    return;
                }

                // Printing dimensions
                if (!guiDimensionsPrinted)
                {
                    guiDimensionsPrinted = true;
                    Plugin.Instance.PrintThisString("Window dimensions: " + appWidth.ToString() + " " + appHeight.ToString());
                    Plugin.Instance.PrintThisString("Button spacing values: " + widthSpacer.ToString() + " " + heightSpacer.ToString());
                }

                // Sort language list except for English and establish lang dictionary
                foreach (Language lang in languageList)
                {
                    for (int i = 0; i < availableLanguagesForThisGame.Length; i++)
                    {
                        availableLanguagesForThisGame[i] = availableLanguagesForThisGame[i].Replace(lang.name, lang.localName);
                    }
                }
                Array.Sort(availableLanguagesForThisGame, 1, availableLanguagesForThisGame.Length-1);
                foreach (Language lang in languageList)
                {
                    for (int i = 0; i < availableLanguagesForThisGame.Length; i++)
                    {
                        availableLanguagesForThisGame[i] = availableLanguagesForThisGame[i].Replace(lang.localName, lang.name);
                    }
                }

                // Standard buttons
                string[] promptButtons = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "Z", "X", "C", "V", "B", "N", "M", "L", "K"];
                KeyCode[] promptKeyCodes = [KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.L, KeyCode.K];

                foreach (Language lang in languageList)
                {
                    lang.index = Array.IndexOf(availableLanguagesForThisGame, lang.name);
                    
                    if (lang.index != -1)
                    {
                        lang.prompt = lang.prompt.Replace("NUMBER", promptButtons[lang.index]);
                        // First row
                        if (lang.index <= maxLangsPerColumn-1)
                        {
                            if (UnityEngine.GUI.Button(new Rect(widthSpacer + (lang.index * widthSpacer) + (lang.index * buttonWidth), heightSpacer, buttonWidth, buttonHeight), lang.localName + "\n\n" + lang.prompt, standardButtonStyle))
                            {
                                Plugin.Instance.gameLanguage = lang.name;
                                Plugin.Instance.AfterLanguageSelection();
                                return;
                            }
                        }
                        // Second row
                        else if (lang.index <= (maxLangsPerColumn*2)-1)
                        {
                            if (UnityEngine.GUI.Button(new Rect(widthSpacer2 + ((lang.index- maxLangsPerColumn) * widthSpacer2) + ((lang.index- maxLangsPerColumn) * buttonWidth), heightSpacer + buttonHeight + heightSpacer, buttonWidth, buttonHeight), lang.localName + "\n\n" + lang.prompt, standardButtonStyle))
                            {
                                Plugin.Instance.gameLanguage = lang.name;
                                Plugin.Instance.AfterLanguageSelection();
                                return;
                            }
                        }
                        // Third row
                        else
                        {
                            if (UnityEngine.GUI.Button(new Rect(widthSpacer3 + ((lang.index - (maxLangsPerColumn*2)) * widthSpacer3) + ((lang.index - (maxLangsPerColumn*2)) * buttonWidth), heightSpacer + buttonHeight + heightSpacer + buttonHeight + heightSpacer, buttonWidth, buttonHeight), lang.localName + "\n\n" + lang.prompt, standardButtonStyle))
                            {
                                Plugin.Instance.gameLanguage = lang.name;
                                Plugin.Instance.AfterLanguageSelection();
                                return;
                            }
                        }
                    }
                }

                // Allowing keypresses as alternative
                for (int i = 0; i < numLangs+1; i++)
                {
                    try
                    {
                        if (Input.GetKeyDown(promptKeyCodes[i]) && numLangs >= i + 1 && !string.IsNullOrEmpty(availableLanguagesForThisGame[i]))
                        {
                            Plugin.Instance.gameLanguage = availableLanguagesForThisGame[i];
                            Plugin.Instance.AfterLanguageSelection();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Plugin.Instance.PrintThisString("OnGUI keypresses exception: " + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Instance.PrintThisString("OnGUI exception: " + ex.ToString());
            }
        }

        public string TranslatedTitles(string str)
        {
            switch (str)
            {
                case "ANATOMY":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "ANATOMIE"; break;
                        case "Dutch": str = "ANATOMIE"; break;
                        case "Japanese": str = "解剖学"; break;
                    }
                    break;
                case "Ccccccc":
                case "000000FF0000":
                    str = "000000FF0000";
                    break;
                case "CHYRZA":
                    break;
                case "Sunset":
                case "Sunset, Spirit, Steel":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Crépuscule, Esprit, Acier"; break;
                        case "Dutch": str = "Zonsondergang, Geest, Staal"; break;
                        case "Japanese": str = "夕焼け、精神、鋼鉄"; break;
                    }
                    break;
                case "SUNSET":
                case "SUNSET SPIRIT STEEL":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "CRÉPUSCULE ESPRIT ACIER"; break;
                        case "Dutch": str = "ZONSONDERGANG GEEST STAAL"; break;
                        case "Japanese": str = "夕焼け、精神、鋼鉄"; break;
                    }
                    break;
                case "Sigil Valley":
                case "Sigilvalley":
                case "Sigilvalley_64bit":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "Arabic": str = "وادي سيجيل"; break;
                        case "Catalan": str = "Vall dels Sigils"; break;
                        case "Chinese (Simplified)": str = "印记谷"; break;
                        case "Chinese (Traditional)": str = "印記谷"; break;
                        case "Dutch": str = "Vallei van Sigils"; break;
                        case "French": str = "Vallée des Sceaux"; break;
                        case "German": str = "Tal der Siegel"; break;
                        case "Italian": str = "Valle dei Sigilli"; break;
                        case "Japanese": str = "印章の谷"; break;
                        case "Korean": str = "인장의 계곡"; break;
                        case "Portuguese": str = "Vale dos Sigilos"; break;
                        case "Spanish": str = "Valle de los Sellos"; break;
                        case "Polish": str = "Dolina Pieczęci"; break;
                    }
                    break;
                case "Archlake":
                case "Archlake_win":
                case "Arch Lake":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Lac d'Arc"; break;
                        case "Dutch": str = "Meer de Boog"; break;
                        case "Japanese": str = "アーチの湖"; break;
                    }
                    break;
                case "Rainhouse":
                case "Rainhouse_64bit":
                case "Rain, House, Eternity":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Pluie, Maison, Éternité"; break;
                        case "Dutch": str = "Regen, Huis, Eeuwigheid"; break;
                        case "Japanese": str = "雨、家、永遠"; break;
                    }
                    break;
                case "Vaporcrane":
                case "Vaporcrane_win":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Grue de Vapeur"; break;
                        case "Dutch": str = "Stoomkraan"; break;
                        case "Japanese": str = "蒸気の鶴"; break;
                    }
                    break;
                case "VAPORCRANE":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "GRUE DE VAPEUR"; break;
                        case "Dutch": str = "STOOMKRAAN"; break;
                        case "Japanese": str = "蒸気の鶴"; break;
                    }
                    break;
                case "Stormsea":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Mer des Tempêtes"; break;
                        case "Dutch": str = "Stormzee"; break;
                        case "Japanese": str = "嵐の海"; break;
                    }
                    break;
                case "Skin":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Peau"; break;
                        case "Dutch": str = "Huid"; break;
                        case "Japanese": str = "肌"; break;
                    }
                    break;
                case "BLOOD CITY":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "CITÉ DU SANG"; break;
                        case "Dutch": str = "BLOED STAD"; break;
                        case "Japanese": str = "血の街"; break;
                    }
                    break;
                case "Aurelia":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "Japanese": str = "アレリア"; break;
                    }
                    break;
                case "Wraithshead":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Tête de Wraith"; break;
                        case "Dutch": str = "Wraith-hoofd"; break;
                        case "Japanese": str = "レイスの頭"; break;
                    }
                    break;
                case "Wraithshead Gardens":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Les Jardins de la Tête de Wraith"; break;
                        case "Dutch": str = "Wraith-hoofd-tuinen"; break;
                        case "Japanese": str = "レイスの頭の庭園"; break;
                    }
                    break;
                case "Wraith":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Wraith"; break;
                        case "Dutch": str = "Wraith"; break;
                        case "Japanese": str = "レイス"; break;
                    }
                    break;
                case "Pente":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "Japanese": str = "ペンテイ"; break;
                    }
                    break;
                case "Leechbowl":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Bol de Sangsues"; break;
                        case "Dutch": str = "Kom met Bloedzuigers"; break;
                        case "Japanese": str = "ヒルのボウル"; break;
                    }
                    break;
                case "Grandmother":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Grand-mère"; break;
                        case "Dutch": str = "Grootmoeder"; break;
                        case "Japanese": str = "祖母"; break;
                    }
                    break;
                case "Cyberskull":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Crâne Cyber"; break;
                        case "Dutch": str = "Cyberschedel"; break;
                        case "Japanese": str = "サイバースカル"; break;
                    }
                    break;
                case "CYBERSKULL":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "CRÂNE CYBER"; break;
                        case "Dutch": str = "CYBERSCHEDEL"; break;
                        case "Japanese": str = "サイバースカル"; break;
                    }
                    break;
                case "Actias":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "Japanese": str = "アクティアス"; break;
                    }
                    break;
                case "Scarlet":
                case "Scarlet Bough":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Branche Écarlate"; break;
                        case "Dutch": str = "Scharlaken Tak"; break;
                        case "Japanese": str = "スカーレット枝"; break;
                    }
                    break;
                case "GES_Final":
                case "Garden, Eternity, Shape":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Jardin, Éternité, Forme"; break;
                        case "Dutch": str = "Tuin, Eeuwigheid, Vorm"; break;
                        case "Japanese": str = "庭、永遠、形"; break;
                    }
                    break;
                case "Gloompuke":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Morositévomir"; break;
                        case "Dutch": str = "Somberheidkots"; break;
                        case "Japanese": str = "憂鬱吐き気"; break;
                    }
                    break;
                case "Factory":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Usine"; break;
                        case "Dutch": str = "Fabriek"; break;
                        case "Japanese": str = "工場"; break;
                    }
                    break;
                case "Artery":
                case "Artery Heights":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Hauteurs d'Artère"; break;
                        case "Dutch": str = "Slagader Toppunten"; break;
                        case "Japanese": str = "ハイツの動脈"; break;
                    }
                    break;
                case "Amalia":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "Japanese": str = "アマリア"; break;
                    }
                    break;
                case "Charon":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Charon"; break;
                        case "Dutch": str = "Charon"; break;
                        case "Japanese": str = "カローン"; break;
                    }
                    break;
                case "Tin":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Étain"; break;
                        case "Dutch": str = "Tin"; break;
                        case "Japanese": str = "スズ"; break;
                    }
                    break;
                case "Spine":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Échine"; break;
                        case "Dutch": str = "Wervelkolom"; break;
                        case "Japanese": str = "脊椎"; break;
                    }
                    break;
                case "Sieve":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Tamis"; break;
                        case "Dutch": str = "Zeef"; break;
                        case "Japanese": str = "篩"; break;
                    }
                    break;
                case "Roads":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Routes"; break;
                        case "Dutch": str = "Wegen"; break;
                        case "Japanese": str = "道路"; break;
                    }
                    break;
                case "Needlerust":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Rouille des Aiguilles"; break;
                        case "Dutch": str = "Naaldroest"; break;
                        case "Japanese": str = "針の錆"; break;
                    }
                    break;
                case "Monastery":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Monastère"; break;
                        case "Dutch": str = "Klooster"; break;
                        case "Japanese": str = "修道院"; break;
                    }
                    break;
                case "Erosion":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Érosion"; break;
                        case "Dutch": str = "Erosie"; break;
                        case "Japanese": str = "侵食"; break;
                    }
                    break;
                case "Dust":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Poussière"; break;
                        case "Dutch": str = "Stof"; break;
                        case "Japanese": str = "埃"; break;
                    }
                    break;
                case "Basements":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Sous-sols"; break;
                        case "Dutch": str = "Kelders"; break;
                        case "Japanese": str = "地下3階"; break;
                    }
                    break;
                case "Wormclot":
                case "Castle Wormclot":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Château de Vercaillot"; break;
                        case "Dutch": str = "Kasteel Wormstolsel"; break;
                        case "Japanese": str = "虫血栓城"; break;
                    }
                    break;
                case "GhostLake":
                case "Ghost Lake":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Lac Fantôme"; break;
                        case "Dutch": str = "Spookmeer"; break;
                        case "Japanese": str = "幽霊の湖"; break;
                    }
                    break;
                case "Seven":
                case "Seven Days":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Sept Jours"; break;
                        case "Dutch": str = "Zeven Dagen"; break;
                        case "Japanese": str = "七日間"; break;
                    }
                    break;
                case "Exclusion":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Zone d'Exclusion"; break;
                        case "Dutch": str = "Sperrgebiet"; break;
                        case "Japanese": str = "立入禁止区域"; break;
                    }
                    break;
                case "Grandmother's Garden":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Le Jardin de Grand-mère"; break;
                        case "Dutch": str = "Grootmoeders Tuin"; break;
                        case "Japanese": str = "おばあちゃんの庭"; break;
                    }
                    break;
                case "Lethargy Hill":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Colline de la Léthargie"; break;
                        case "Dutch": str = "Lethargie Heuvel"; break;
                        case "Japanese": str = "無気力の丘"; break;
                    }
                    break;
                case "Tenement":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Immeuble"; break;
                        case "Dutch": str = "Huurkazerne"; break;
                        case "Japanese": str = "長屋"; break;
                    }
                    break;
                case "Broken Heart Key":
                case "Bhk":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Clé du Cœur Brisé"; break;
                        case "Dutch": str = "Gebroken Hart Sleutel"; break;
                        case "Japanese": str = "壊れた心の鍵"; break;
                    }
                    break;
                case "Complex":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Complexe"; break;
                        case "Dutch": str = "Complex"; break;
                        case "Japanese": str = "複合"; break;
                    }
                    break;
                case "Decommissioned City #65":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Ville Déclassée #65"; break;
                        case "Dutch": str = "Ontmantelde Stad #65"; break;
                        case "Japanese": str = "廃止された都市 #65"; break;
                    }
                    break;
                case "Living Room":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "Le Salon"; break;
                        case "Dutch": str = "Woonkamer"; break;
                        case "Japanese": str = "居間"; break;
                    }
                    break;
                case "Zerega":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "Japanese": str = "ゾレガ"; break;
                    }
                    break;
                case "Village":
                case "Village_win":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "Arabic": str = "قرية"; break;
                        case "Bulgarian": str = "Cело"; break;
                        case "Catalan": str = "Poble"; break;
                        case "Chinese (Simplified)": str = "村"; break;
                        case "Chinese (Traditional)": str = "村"; break;
                        case "French": str = "Village"; break;
                        case "German": str = "Dorf"; break;
                        case "Hebrew": str = "כפר"; break;
                        case "Hindi": str = "गाँव"; break;
                        case "Italian": str = "Villaggio"; break;
                        case "Japanese": str = "村落"; break;
                        case "Korean": str = "마을"; break;
                        case "Portuguese": str = "Aldeia"; break;
                        case "Russian": str = "Село"; break;
                        case "Spanish": str = "Pueblo"; break;
                    }
                    break;
            }
            return str;
        }
    }
}
