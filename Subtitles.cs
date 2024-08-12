using KittyHorrorshowTranslations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OmegaFallon.KittyHorrorshowTranslations
{
    public class Subtitles : MonoBehaviour
    {
        public static Subtitles Instance;
        public void Awake()
        {
            Instance = this;
        }

        public void Start()
        {
            
        }

        public string lastSubtitle;
        public string currentSubtitle;

        public GameObject screamingTape;
        public GameObject title4TV;

        public void OnGUI()
        {
            try
            {
                if (GUI.Instance.doSubtitles == false)
                {
                    return;
                }

                // Setting current subtitle //
                float audioTimeInSeconds = (float)(Plugin.Instance.updateCounter - Plugin.Instance.updateCountAtLastSoundStart) / 60;
                Dictionary<double, string> subtitleTimestampsGlobal = [];

                switch (Plugin.Instance.runningGame)
                {
                    case "Anatomy":
                        subtitleTimestampsGlobal = Subtitles_Anatomy.Instance.ReturnSubtitles(Plugin.Instance.lastSoundPlayed);
                        break;
                    case "CHYRZA":
                        subtitleTimestampsGlobal = Subtitles_CHYRZA.Instance.ReturnSubtitles(Plugin.Instance.lastSoundPlayed);
                        break;
                    default:
                        Plugin.Instance.PrintThisString("ERROR! Subtitles enabled but not playing a game with subtitles!");
                        break;
                }

                // Iterate through dictionary to join comma-ending strings for testing
                if (Plugin.Instance.runningGame != "Anatomy")
                {
                    for (int i = 0; i < subtitleTimestampsGlobal.Count - 1; i++)
                    {
                        KeyValuePair<double, string> one = subtitleTimestampsGlobal.ElementAt(i);

                        // Critera for line joining
                        if (one.Value.EndsWith(",") || one.Value.EndsWith(",\"") || one.Value.EndsWith(";") || one.Value.EndsWith("..."))
                        {
                            // Find the first line after this one which DOESN'T meet the critera.
                            int stoppingIndex = subtitleTimestampsGlobal.Count - 1;
                            for (int i2 = 0; i + i2 < subtitleTimestampsGlobal.Count; i2++)
                            {
                                KeyValuePair<double, string> next = subtitleTimestampsGlobal.ElementAt(i + i2);
                                if (next.Value.EndsWith(",") || next.Value.EndsWith(",\"") || next.Value.EndsWith(";") || next.Value.EndsWith("..."))
                                {
                                    continue;
                                }
                                else
                                {
                                    stoppingIndex = i + i2;
                                    break;
                                }
                            }

                            // Loop through every line from i+1 to stoppingIndex, forming the string.
                            string combinedLine = one.Value;
                            for (int i3 = i + 1; i3 <= stoppingIndex; i3++)
                            {
                                combinedLine += " " + subtitleTimestampsGlobal.ElementAt(i3).Value;
                            }

                            // Finally, write the new value to each
                            for (int i4 = i; i4 <= stoppingIndex; i4++)
                            {
                                subtitleTimestampsGlobal[subtitleTimestampsGlobal.ElementAt(i4).Key] = combinedLine;
                            }
                        }
                    }
                }

                // Iterate through the dictionary, fetching the appropriate subtitle based on time passed
                for (int i = 0; i < subtitleTimestampsGlobal.Count; i++)
                {
                    KeyValuePair<double, string> subtitle = subtitleTimestampsGlobal.Reverse().ElementAt(i);

                    if (audioTimeInSeconds >= subtitle.Key)
                    {
                        currentSubtitle = subtitle.Value;
                        break;
                    }
                }

                // Sound description code
                if (Plugin.Instance.currentLevelIndex == 3 && screamingTape != null && Vector3.Distance(screamingTape.transform.position, GameObject.Find("PLAYER").transform.position) <= 5.5)
                {
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "English": case "English-UK": currentSubtitle = "[distorted screaming]"; break;
                        case "French": currentSubtitle = "[cris déformés]"; break;
                        case "Dutch": currentSubtitle = "[verwrongen schreeuwen]"; break;
                        case "Japanese": currentSubtitle = "[歪んだ叫び声]"; break;
                        case "Chinese (Simplified)": currentSubtitle = "[扭曲的尖叫声]"; break;
                        case "Chinese (Traditional)": currentSubtitle = "[扭曲的尖叫聲]"; break;
                    }
                }
                else if (Plugin.Instance.lastSoundPlayed == "tape4_2" || (Plugin.Instance.currentLevelIndex == 3 && title4TV != null && Vector3.Distance(title4TV.transform.position, GameObject.Find("PLAYER").transform.position) <= 5.5))
                {
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "English": case "English-UK": currentSubtitle = "[static]"; break;
                        case "French": currentSubtitle = "[friture]"; break;
                        case "Dutch": currentSubtitle = "[statisch]"; break;
                        case "Japanese": currentSubtitle = "[砂嵐]"; break;
                        case "Chinese (Simplified)": currentSubtitle = "[噪声]"; break;
                        case "Chinese (Traditional)": currentSubtitle = "[噪聲]"; break;
                    }
                }

                // Display the subtitle
                if (!string.IsNullOrEmpty(currentSubtitle))
                {
                    if (Plugin.Instance.gameLanguage == "English-UK")
                    {
                        currentSubtitle = Plugin.Instance.Britishize(currentSubtitle);
                    }
                    
                    // Styling
                    var style = GUISkin.current.label;
                    style.fontSize = 30;
                    style.fontStyle = UnityEngine.FontStyle.Italic;
                    style.font = Plugin.Instance.runningGameFont;

                    float x;
                    float y;
                    float width;
                    float height;

                    // Blow your ears out code
                    if (Plugin.Instance.lastSoundPlayed == "tape3_2" || (Plugin.Instance.lastSoundPlayed == "tape5_2" && audioTimeInSeconds >= 38.846))
                    {
                        style.fontSize = 60;
                        currentSubtitle = currentSubtitle.ToUpper();

                        width = (float)(Screen.width * 0.75);
                        height = (float)(Screen.height * 0.75);
                        x = (float)((Screen.width - width) / 2);
                        y = (float)((Screen.height - height) / 2);
                    }
                    // Dream code
                    else if (Plugin.Instance.lastSoundPlayed == "tape6_2" && audioTimeInSeconds >= 20.8 && !(audioTimeInSeconds >= 115.3))
                    {
                        style.m_Normal.textColor = Color.red;

                        width = (float)(Screen.width * 0.5);
                        height = (float)(Screen.height);
                        x = (float)(Screen.width * 0.25);
                        y = (float)(Screen.height * 0.6);
                    }
                    else
                    {
                        style.m_Normal.textColor = Color.white;

                        width = (float)(Screen.width * 0.5);
                        height = (float)(Screen.height);
                        x = (float)(Screen.width * 0.25);
                        y = (float)(Screen.height * 0.6);
                    }

                    // Write the subtitle
                    UnityEngine.GUI.Label(new Rect(x, y, width, height), new GUIContent(currentSubtitle), style);
                }

                // Debug subtitle frame counter //
                if (false)
                {
                    string str;
                    int widthSpacer = (Screen.width - 200) / 2;
                    int heightSpacer = (Screen.height - 200) / 2;

                    str = "";

                    switch (Plugin.Instance.lastSoundPlayed)
                    {
                        case "tapeStop":
                            break;
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
                            str = (Plugin.Instance.updateCounter - Plugin.Instance.updateCountAtLastSoundStart).ToString();
                            break;
                    }

                    if (!string.IsNullOrEmpty(str))
                    {
                        UnityEngine.GUI.DoLabel(new Rect(x: 480, y: 648, width: 960, height: 324), new GUIContent(str), (IntPtr)78015920);
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Instance.PrintThisString("Subtitles.OnGUI exception: " + ex);
            }
        }

    }
}
