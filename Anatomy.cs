using HutongGames.PlayMaker.Actions;
using HutongGames.Utility;
using PixelCrushers.DialogueSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
//using UnityEngine.Experimental.Networking;
using static PixelCrushers.DialogueSystem.Articy.ArticyData;

namespace KittyHorrorshowTranslations
{
    public class Anatomy : MonoBehaviour
    {
        public static Anatomy Instance;
        public void Awake()
        {
            Instance = this;
        }

        public UnityEngine.Font vhsfont;

        public string[] anatomyReplacedAudio;
        public Dictionary<string, AudioClip> anatomyAudio;

        public string[] anatomyReplacedImages;
        public Dictionary<string, Texture2D> anatomyImages;
        public void AssetLoading()
        {
            // Loading this font from: sharedassets1.assets
            Plugin.Instance.PrintThisString("Data path: "+Application.dataPath);
            
            try
            {
                //string bundlePath = Path.Combine(Application.dataPath, "sharedassets1.assets").Replace("\\","/");
                //Plugin.Instance.PrintThisString("Attempting to load bundle at the following path: "+bundlePath);
            }
            catch (Exception ex)
            {
                Plugin.Instance.PrintThisString("Error occured while loading vhsfont: " + ex.ToString());
            }

            // Don't do any asset loads if the language is English or null/empty
            if (Plugin.Instance.gameLanguage == "English" || string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
            {
                return;
            }

            // Audio
            anatomyReplacedAudio = ["amen", "finalspeech", "tape1", "tape1_2", "tape1_3", "tape2", "tape2_2", "tape2_3", "tape3", "tape3_2", "tape3_3", "tape4", "tape4_2", "tape4_3", "tape5", "tape5_2", "tape5_3", "tape6", "tape6_2", "tape7", "tape8", "tape9", "tapeX_3"];
            anatomyAudio = new Dictionary<string, AudioClip> { };
            foreach (string str in anatomyReplacedAudio)
            {
                if (Plugin.Instance.gameLanguage == "English-UK") { break; }
                anatomyAudio.Add(str, Plugin.Instance.GetAudio("Anatomy", Plugin.Instance.gameLanguage, str + ".mp3"));
            }

            // Images
            anatomyReplacedImages = ["input", "title1", "title2", "title3", "title4"];
            if (Plugin.Instance.gameLanguage == "English-UK") { anatomyReplacedImages = ["title1", "title2"]; }
            anatomyImages = new Dictionary<string, Texture2D> { };
            foreach (string str in anatomyReplacedImages)
            {
                anatomyImages.Add(str, Plugin.Instance.GetTexture("Anatomy", Plugin.Instance.gameLanguage, str + ".png"));
            }
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                // House 1
                case "THERE IS A TAPE IN THE DINING ROOM":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE CASSETTE DANS LA SALLE À MANGER"; break;
                        case "Dutch": str = "ER IS EEN CASSETTE IN DE EETKAMER"; break;
                        case "Chinese (Simplified)": str = "饭厅里有一把盒带子"; break;
                        case "Chinese (Traditional)": str = "飯廳裡有一把盒帶子"; break;
                        case "Japanese":
                            if (Plugin.Instance.currentLevelIndex > 1)
                            {
                                str = "食堂にカセットがいる";// いる (animate)
                            }
                            else
                            {
                                str = "食堂にカセットがある";// ある (inanimate)
                            }
                            break;
                    }
                    break;
                case "THERE IS A TAPE IN THE DOWNSTAIRS BATHROOM":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE CASSETTE DANS LA SALLE DE BAINS EN BAS"; break;
                        case "Dutch": str = "ER IS EEN CASSETTE IN DE BENEDEN BADKAMER"; break;
                        case "Chinese (Simplified)": str = "楼下浴室里有一把盒带子"; break;
                        case "Chinese (Traditional)": str = "樓下浴室裡有一把盒帶子"; break;
                        case "Japanese":
                            if (Plugin.Instance.currentLevelIndex > 1)
                            {
                                str = "階下の風呂場にカセットがいる";
                            }
                            else
                            {
                                str = "階下の風呂場にカセットがある";
                            }
                            break;
                    }
                    break;
                case "THERE IS A TAPE IN THE GARAGE":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE CASSETTE DANS LE GARAGE"; break;
                        case "Dutch": str = "ER IS EEN CASSETTE IN DE GARAGE"; break;
                        case "Chinese (Simplified)": str = "车库里有一把盒带子"; break;
                        case "Chinese (Traditional)": str = "車庫裡有一把盒帶子"; break;
                        case "Japanese":
                            if (Plugin.Instance.currentLevelIndex > 1)
                            {
                                str = "車庫にカセットがいる";
                            }
                            else
                            {
                                str = "車庫にカセットがある";
                            }
                            break;
                    }
                    break;
                case "THERE IS A TAPE IN THE LIVING ROOM":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE CASSETTE DANS LE SALON"; break;
                        case "Dutch": str = "ER IS EEN CASSETTE IN DE WOONKAMER"; break;
                        case "Chinese (Simplified)": str = "客厅里有一把盒带子"; break;
                        case "Chinese (Traditional)": str = "客廳裡有一把盒帶子"; break;
                        case "Japanese":
                            if (Plugin.Instance.currentLevelIndex > 1)
                            {
                                str = "居間にカセットがいる";
                            }
                            else
                            {
                                str = "居間にカセットがある";
                            }
                            break;
                    }
                    break;
                case "THERE IS A TAPE ON THE STAIRS":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE CASSETTE SUR LES ESCALIERS"; break;
                        case "Dutch": str = "ER IS EEN CASSETTE OP DE TRAP"; break;
                        case "Japanese":
                            if (Plugin.Instance.currentLevelIndex > 1)
                            {
                                str = "階段にカセットがいる";
                            }
                            else
                            {
                                str = "階段にカセットがある";
                            }
                            break;
                    }
                    break;
                case "THERE IS A TAPE IN A BEDROOM":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE CASSETTE DANS UNE CHAMBRE"; break;
                        case "Dutch": str = "ER IS EEN CASSETTE IN EEN SLAAPKAMER"; break;
                        case "Japanese":
                            if (Plugin.Instance.currentLevelIndex > 1)
                            {
                                str = "ある寝室にカセットがいる";
                            }
                            else
                            {
                                str = "ある寝室にカセットがある";
                            }
                            break;
                    }
                    break;
                case "THERE IS A TAPE IN THE BASEMENT":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE CASSETTE DANS LE CAVE"; break;
                        case "Dutch": str = "ER IS EEN CASSETTE IN DE KELDER"; break;
                        case "Chinese (Simplified)": str = "地下室里有一把盒带子"; break;
                        case "Chinese (Traditional)": str = "地下室裡有一把盒帶子"; break;
                        case "Japanese":
                            if (Plugin.Instance.currentLevelIndex > 1)
                            {
                                str = "地下室にカセットがいる";
                            }
                            else
                            {
                                str = "地下室にカセットがある";
                            }
                            break;
                    }
                    break;
                case "THERE IS A TAPE IN THE MASTER BEDROOM":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE CASSETTE DANS LA CHAMBRE PRINCIPALE"; break;
                        case "Dutch": str = "ER IS EEN CASSETTE IN DE HOOFDSLAAPKAMER"; break;
                        case "Chinese (Simplified)": str = "主卧室里有一把盒带子"; break;
                        case "Chinese (Traditional)": str = "主臥室裡有一把盒帶子"; break;
                        case "Japanese":
                            if (Plugin.Instance.currentLevelIndex > 1)
                            {
                                str = "主寝室にカセットがいる";
                            }
                            else
                            {
                                str = "主寝室にカセットがある";
                            }
                            break;
                    }
                    break;

                // House 2+
                case "THERRRRRRRRRRRR       RE IS A TAPE IN THE DINING ROOM":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "ILLLLLLLLLLLLLL       Ÿ A UNE CASSETTE DANS LA SALLE À MANGER"; break;
                        case "Dutch": str = "ERRRRRRRRRRRRRR       IS EEN CASSETTE IN DE EETKAMER"; break;
                        case "Japanese": str = "食堂にiiiiiiiiiiiiii       カセットがいる"; break;
                    }
                    break;
                case "THERE IS A TA   A A  AAAA  A         DOOrRS ARE UnNLOCKED":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE CA   A A  AAAA  A         POrTES SONT DéVERROUILLÉES"; break;
                        case "Dutch": str = "ER IS EEN CA   A A  AAAA  A         DEuREN ZIJN ONTGRENDELD"; break;
                        case "Japanese": str = "カセットがいi   i i  iiii  i         すべてnoドアはロックされていない"; break;
                    }
                    break;
                case "THERE IS A TTHERE IS A TTHERE IS A TTHERE IS A TTHERE IS A TTHERE IS A TTHERE IS A TTHERE IS A T":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "IL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE IIL Y A UNE C"; break;
                        case "Dutch": str = "ER IS EEN EER IS EEN EER IS EEN EER IS EEN EER IS EEN EER IS EEN EER IS EEN EER IS EEN C"; break;
                        case "Japanese": str = "トがいる gがいる gがいる gがいる gがいる gがいる gがいる gがいる"; break;
                    }
                    break;
                case "THHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "ILLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL"; break;
                        case "Dutch": str = "ERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR"; break;
                        case "Japanese": str = "がいrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr"; break;
                    }
                    break;
                case "                                                                          HHHHHHHHHHHHHHHHHHHHHHHURTS":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "                                                                          FFFFFFFFFFFFFFFFFFFFAIT MAL"; break;
                        case "Dutch": str = "                                                                          DDDDDDDDDDDDDDDDDDDOET PIJN"; break;
                        case "Japanese": str = "                                                                          iiiiiiiiiiiiiiiiiiiiii痛い"; break;
                    }
                    break;
            }
            return str;
        }

        public UnityEngine.Object AudioReplacement(UnityEngine.Object audioClip)
        {
            string startingName = audioClip.name;
            if (anatomyReplacedAudio.Contains(audioClip.name))
            {
                audioClip = anatomyAudio[audioClip.name];
                audioClip.name = startingName+"_TRANSLATED";
            }

            return audioClip;
        }

        public UnityEngine.Sprite TextureReplacement(SpriteRenderer spriteRenderer)
        {
            int textureWidth = (int)spriteRenderer.sprite.rect.m_Width;
            int textureHeight = (int)spriteRenderer.sprite.rect.m_Height;

            if (anatomyReplacedImages.Contains(spriteRenderer.gameObject.name))
            {
                spriteRenderer.sprite = Plugin.Instance.SpriteReplace(anatomyImages[spriteRenderer.gameObject.name], textureWidth, textureHeight);
            }

            return spriteRenderer.sprite;
        }
    }
}
