using BepInEx;
using KittyHorrorshowTranslations;
using System;
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

        public void OnGUI()
        {
            try
            {
                // Creating standard button style
                GUIStyle standardButtonStyle = GUISkin.current.button;
                if (Plugin.Instance.runningGameFont != null)
                {
                    //standardButtonStyle.font = runningGameFont;
                }

                // If the language has already been decided and subtitles have been decided (for games that need them), return
                if (!string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
                {
                    if (Plugin.Instance.runningGame != "Anatomy")
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

                            switch (Plugin.Instance.runningGame)
                            {
                                case "Anatomy":
                                case "Ccccccc":
                                    return;
                                case "CHYRZA":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "チいるザ"; break;
                                    }
                                    break;
                                case "Sunset":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Crépuscule, Esprit, Acier"; break;
                                        case "Dutch": translatedTitle = "Zonsondergang, Geest, Staal"; break;
                                        case "Japanese": translatedTitle = "夕焼け、精神、鋼鉄"; break;
                                    }
                                    break;
                                case "Sigilvalley":
                                case "Sigilvalley_64bit":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Vallée des Sceaux"; break;
                                        case "Dutch": translatedTitle = "Vallei van Sigils"; break;
                                        case "Japanese": translatedTitle = "印章の谷"; break;
                                    }
                                    break;
                                case "Archlake":
                                case "Archlake_win":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Lac d'Arc"; break;
                                        case "Dutch": translatedTitle = "Meer de Boog"; break;
                                        case "Japanese": translatedTitle = "アーチの湖"; break;
                                    }
                                    break;
                                case "Rainhouse":
                                case "Rainhouse_64bit":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Pluie, Maison, Éternité"; break;
                                        case "Dutch": translatedTitle = "Regen, Huis, Eeuwigheid"; break;
                                        case "Japanese": translatedTitle = "雨、家、永遠"; break;
                                    }
                                    break;
                                case "Vaporcrane":
                                case "Vaporcrane_64bit":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Grue de Vapeur"; break;
                                        case "Dutch": translatedTitle = "Stoomkraan"; break;
                                        case "Japanese": translatedTitle = "蒸気の鶴"; break;
                                    }
                                    break;
                                case "Stormsea":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Mer des Tempêtes"; break;
                                        case "Dutch": translatedTitle = "Stormzee"; break;
                                        case "Japanese": translatedTitle = "嵐の海"; break;
                                    }
                                    break;
                                case "Skin":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Peau"; break;
                                        case "Dutch": translatedTitle = "Huid"; break;
                                        case "Japanese": translatedTitle = "肌"; break;
                                    }
                                    break;
                                case "Aurelia":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "アレリア"; break;
                                    }
                                    break;
                                case "Wraithshead":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Tête de Wraith"; break;
                                        case "Dutch": translatedTitle = "Wraith-hoofd"; break;
                                        case "Japanese": translatedTitle = "レイスの頭"; break;
                                    }
                                    break;
                                case "Wraith":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Wraith"; break;
                                        case "Dutch": translatedTitle = "Wraith"; break;
                                        case "Japanese": translatedTitle = "レイス"; break;
                                    }
                                    break;
                                case "Pente":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "ペンテイ"; break;
                                    }
                                    break;
                                case "Leechbowl":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Bol de Sangsues"; break;
                                        case "Dutch": translatedTitle = "Kom met Bloedzuigers"; break;
                                        case "Japanese": translatedTitle = "ヒルのボウル"; break;
                                    }
                                    break;
                                case "Grandmother":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Grand-mère"; break;
                                        case "Dutch": translatedTitle = "Grootmoeder"; break;
                                        case "Japanese": translatedTitle = "祖母"; break;
                                    }
                                    break;
                                case "Cyberskull":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Crâne Cyber"; break;
                                        case "Dutch": translatedTitle = "Cyberschedel"; break;
                                        case "Japanese": translatedTitle = "サイバースカル"; break;
                                    }
                                    break;
                                case "Actias":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "アクティアス"; break;
                                    }
                                    break;
                                case "Scarlet":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Écarlate"; break;
                                        case "Dutch": translatedTitle = "Scharlaken"; break;
                                        case "Japanese": translatedTitle = "スカーレット"; break;
                                    }
                                    break;
                                case "Gloompuke":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Morositévomir"; break;
                                        case "Dutch": translatedTitle = "Somberheidkots"; break;
                                        case "Japanese": translatedTitle = "憂鬱吐き気"; break;
                                    }
                                    break;
                                case "Factory":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Usine"; break;
                                        case "Dutch": translatedTitle = "Fabriek"; break;
                                        case "Japanese": translatedTitle = "工場"; break;
                                    }
                                    break;
                                case "Artery":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Artère"; break;
                                        case "Dutch": translatedTitle = "Slagader"; break;
                                        case "Japanese": translatedTitle = "動脈"; break;
                                    }
                                    break;
                                case "Amalia":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "アマリア"; break;
                                    }
                                    break;
                                case "Charon":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Charon"; break;
                                        case "Dutch": translatedTitle = "Charon"; break;
                                        case "Japanese": translatedTitle = "カローン"; break;
                                    }
                                    break;
                                case "Tin":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Étain"; break;
                                        case "Dutch": translatedTitle = "Tin"; break;
                                        case "Japanese": translatedTitle = "スズ"; break;
                                    }
                                    break;
                                case "Spine":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Échine"; break;
                                        case "Dutch": translatedTitle = "Wervelkolom"; break;
                                        case "Japanese": translatedTitle = "脊椎"; break;
                                    }
                                    break;
                                case "Sieve":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Tamis"; break;
                                        case "Dutch": translatedTitle = "Zeef"; break;
                                        case "Japanese": translatedTitle = "篩"; break;
                                    }
                                    break;
                                case "Roads":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Routes"; break;
                                        case "Dutch": translatedTitle = "Wegen"; break;
                                        case "Japanese": translatedTitle = "道路"; break;
                                    }
                                    break;
                                case "Needlerust":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Rouille des Aiguilles"; break;
                                        case "Dutch": translatedTitle = "Naaldroest"; break;
                                        case "Japanese": translatedTitle = "針の錆"; break;
                                    }
                                    break;
                                case "Monastery":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Monastère"; break;
                                        case "Dutch": translatedTitle = "Klooster"; break;
                                        case "Japanese": translatedTitle = "修道院"; break;
                                    }
                                    break;
                                case "Erosion":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Érosion"; break;
                                        case "Dutch": translatedTitle = "Erosie"; break;
                                        case "Japanese": translatedTitle = "侵食"; break;
                                    }
                                    break;
                                case "Dust":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Poussière"; break;
                                        case "Dutch": translatedTitle = "Stof"; break;
                                        case "Japanese": translatedTitle = "埃"; break;
                                    }
                                    break;
                                case "Basements":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Sous-sols"; break;
                                        case "Dutch": translatedTitle = "Kelders"; break;
                                        case "Japanese": translatedTitle = "地下3階"; break;
                                    }
                                    break;
                                case "Wormclot":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Château de Vercaillot"; break;
                                        case "Dutch": translatedTitle = "Kasteel Wormstolsel"; break;
                                        case "Japanese": translatedTitle = "虫血栓城"; break;
                                    }
                                    break;
                                case "GhostLake":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Lac Fantôme"; break;
                                        case "Dutch": translatedTitle = "Spookmeer"; break;
                                        case "Japanese": translatedTitle = "幽霊の湖"; break;
                                    }
                                    break;
                                case "Seven":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Sept Jours"; break;
                                        case "Dutch": translatedTitle = "Zeven Dagen"; break;
                                        case "Japanese": translatedTitle = "七日間"; break;
                                    }
                                    break;
                                case "Exclusion":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Zone d'Exclusion"; break;
                                        case "Dutch": translatedTitle = "Sperrgebiet"; break;
                                        case "Japanese": translatedTitle = "立入禁止区域"; break;
                                    }
                                    break;
                                case "Grandmother's Garden":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Le Jardin de Grand-mère"; break;
                                        case "Dutch": translatedTitle = "Grootmoeders Tuin"; break;
                                        case "Japanese": translatedTitle = "おばあちゃんの庭"; break;
                                    }
                                    break;
                                case "Lethargy Hill":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Colline de la Léthargie"; break;
                                        case "Dutch": translatedTitle = "Lethargie Heuvel"; break;
                                        case "Japanese": translatedTitle = "無気力の丘"; break;
                                    }
                                    break;
                                case "Tenement":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Immeuble"; break;
                                        case "Dutch": translatedTitle = "Huurkazerne"; break;
                                        case "Japanese": translatedTitle = "長屋"; break;
                                    }
                                    break;
                                case "Bhk":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Clé du Cœur Brisé"; break;
                                        case "Dutch": translatedTitle = "Gebroken Hart Sleutel"; break;
                                        case "Japanese": translatedTitle = "壊れた心の鍵"; break;
                                    }
                                    break;
                                case "Complex":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Complexe"; break;
                                        case "Dutch": translatedTitle = "Complex"; break;
                                        case "Japanese": translatedTitle = "複合"; break;
                                    }
                                    break;
                                case "Decommissioned City #65":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Ville Déclassée #65"; break;
                                        case "Dutch": translatedTitle = "Ontmantelde Stad #65"; break;
                                        case "Japanese": translatedTitle = "廃止された都市 #65"; break;
                                    }
                                    break;
                                case "Living Room":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "French": translatedTitle = "Le Salon"; break;
                                        case "Dutch": translatedTitle = "Woonkamer"; break;
                                        case "Japanese": translatedTitle = "居間"; break;
                                    }
                                    break;
                                case "Zerega":
                                    switch (Plugin.Instance.gameLanguage)
                                    {
                                        case "Japanese": translatedTitle = "ゾレガ"; break;
                                    }
                                    break;
                            }

                            if (Plugin.Instance.updateCounter - titleCardStartTime < 5 * 60)
                            {
                                float width = (float)(Screen.width * 0.75);
                                float height = (float)(Screen.height * 0.5);
                                float x = (float)((Screen.width - width) / 2);
                                float y = (float)((Screen.height - height) / 2);

                                GUIStyle style = GUISkin.current.label;
                                style.fontSize = 60;
                                //style.fontStyle = UnityEngine.FontStyle.Italic;
                                style.alignment = TextAnchor.UpperCenter;

                                // Rainhouse legibility
                                if ((Plugin.Instance.runningGame == "Rainhouse" || Plugin.Instance.runningGame == "Rainhouse_64bit") && Plugin.Instance.imagesRanThrough == 1) 
                                { 
                                    style.m_Normal.textColor = UnityEngine.Color.red;
                                }

                                switch (Plugin.Instance.gameLanguage)
                                {
                                    case "French":
                                        UnityEngine.GUI.Label(new Rect(x, y, width, height), new GUIContent("« " + translatedTitle + " »" + "\nde Kitty Horrorshow"), style);
                                        break;
                                    case "Dutch":
                                        UnityEngine.GUI.Label(new Rect(x, y, width, height), new GUIContent("\"" + translatedTitle + "\"" + "\nvan Kitty Horrorshow"), style);
                                        break;
                                    case "Japanese":
                                        UnityEngine.GUI.Label(new Rect(x, y, width, height), new GUIContent("キティ・ハラショ" + "の" + "\n「" + translatedTitle + "」"), style);
                                        break;
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
                        pathParts = pathParts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        var path = String.Join("\\", pathParts);

                        if (!Directory.Exists(path))
                        {
                            string[] pathParts2 = { Paths.PluginPath, "KittyHorrorshowTranslations", "net35", "readmes", Plugin.Instance.runningGame, Plugin.Instance.gameLanguage };
                            pathParts2 = pathParts.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            path = String.Join("\\", pathParts2);
                        }

                        if (Directory.Exists(path))
                        {
                            Plugin.Instance.UnlockCursor();

                            string readmePrompt;

                            switch (Plugin.Instance.gameLanguage)
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
                        availableLanguagesForThisGame = ["Unneeded"];
                        break;
                    default:
                        availableLanguagesForThisGame = ["English", "French", "Dutch", "Japanese"];
                        break;
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
                int heightSpacer = (appHeight - buttonHeight) / 2;

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

                // Write code here to catch buttons overlapping if we ever get enough languages for that to happen
                if (widthSpacer < 0)
                {

                }

                // Printing dimensions
                if (!guiDimensionsPrinted)
                {
                    guiDimensionsPrinted = true;
                    Plugin.Instance.PrintThisString("Window dimensions: " + appWidth.ToString() + " " + appHeight.ToString());
                    Plugin.Instance.PrintThisString("Button spacing values: " + widthSpacer.ToString() + " " + heightSpacer.ToString());
                }

                // Sort language list except for English and establish lang dictionary
                Array.Sort(availableLanguagesForThisGame, 1, availableLanguagesForThisGame.Length-1);
                List<Language> languageList =
                [
                    new Language() { name = "English", localName = "English", prompt = "(Press NUMBER)" },

                    // Other langs
                    new Language() { name = "Dutch", localName = "Nederlands", prompt = "(Druk NUMBER)" },
                    new Language() { name = "French", localName = "Français", prompt = "(Appuyez NUMBER)" },
                    new Language() { name = "German", localName = "Deutsch", prompt = "(Drücken NUMBER)" },
                    new Language() { name = "Italian", localName = "Italiano", prompt = "(Premere NUMBER)" },
                    new Language() { name = "Japanese", localName = "日本語", prompt = "(NUMBERを押す)" },
                    new Language() { name = "Spanish", localName = "Español", prompt = "(Presione NUMBER)" },
                ];

                // Standard buttons
                foreach (Language lang in languageList)
                {
                    lang.index = Array.IndexOf(availableLanguagesForThisGame, lang.name);
                    lang.prompt = lang.prompt.Replace("NUMBER",(lang.index+1).ToString());

                    if (lang.index != -1)
                    {
                        if (UnityEngine.GUI.Button(new Rect(widthSpacer + (lang.index * widthSpacer) + (lang.index * buttonWidth), heightSpacer, buttonWidth, buttonHeight), lang.localName+"\n\n"+lang.prompt, standardButtonStyle))
                        {
                            Plugin.Instance.gameLanguage = lang.name;
                            Plugin.Instance.AfterLanguageSelection();
                            return;
                        }
                    }
                }

                // Allowing keypresses as alternative
                for (int i = 0; i < 9; i++)
                {
                    if ((Input.GetKeyDown(KeyCode.Keypad1+i) || Input.GetKeyDown(KeyCode.Alpha1+i)) && numLangs >= i+1 && !string.IsNullOrEmpty(availableLanguagesForThisGame[i]))
                    {
                        Plugin.Instance.gameLanguage = availableLanguagesForThisGame[i];
                        Plugin.Instance.AfterLanguageSelection();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Instance.PrintThisString("OnGUI exception: " + ex.ToString());
            }
        }

    }
}
