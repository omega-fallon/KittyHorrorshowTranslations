using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class Actias : MonoBehaviour
    {
        public static Actias Instance;
        public void Awake()
        {
            Instance = this;
        }

        public Texture2D title;

        public Texture2D message_1a;
        public Texture2D message_1b;
        public Texture2D message_1c;

        public Texture2D message_2a;
        public Texture2D message_2b;
        public Texture2D message_2c;

        public Texture2D message_3a;
        public Texture2D message_3b;
        public Texture2D message_3c;

        public Texture2D message_4a;
        public Texture2D message_4b;
        public Texture2D message_4c;

        public Texture2D message_5a;
        public Texture2D message_5b;
        public Texture2D message_5c;

        public Texture2D message_6a;
        public Texture2D message_6b;
        public Texture2D message_6c;

        public void AssetLoading()
        {
            try { title = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\title.png"); } catch { }

            try { message_1a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png"); } catch {}
            try { message_1b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1b.png"); } catch{}
            try { message_1c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1c.png"); } catch { }

            try { message_2a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\2a.png"); } catch { }
            try { message_2b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\2b.png"); } catch { }
            try { message_2c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\2c.png"); } catch { }

            try { message_3a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\3a.png"); } catch { }
            try { message_3b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\3b.png"); } catch { }
            try { message_3c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\3c.png"); } catch { }

            try { message_4a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\4a.png"); } catch { }
            try { message_4b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\4b.png"); } catch { }
            try { message_4c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\4c.png"); } catch { }

            try { message_5a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\5a.png"); } catch { }
            try { message_5b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\5b.png"); } catch { }
            try { message_5c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\5c.png"); } catch { }

            try { message_6a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\6a.png"); } catch { }
            try { message_6b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\6b.png"); } catch { }
            try { message_6c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\6c.png"); } catch { }
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                case "6 remain ":
                case "5 remain ":
                case "4 remain ":
                case "3 remain ":
                case "2 remain ":
                case "1 remain ": // In the original game this is grammatically incorrect. To preseve the original, we're keeping this grammatical incorrectness
                case "0 remain ":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = str[0] + " restent "; break;
                        case "Dutch": str = str[0] + " blijven "; break;
                        case "Japanese": str = "残り" + Plugin.Instance.IntToRoman(str[0].ToString()) + " " + "基 "; break; //counter for "big things that are hard to move", specifically listed as being used for Japanese "toro", which are large stone lanterns and fairly analagous to pylons
                    }
                    break;
            }
            return str;
        }

        public UnityEngine.Sprite TextureReplacement(SpriteRenderer spriteRenderer)
        {
            switch (spriteRenderer.gameObject.name)
            {
                case "title":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(title, 1600, 900);
                    break;

                case "1a":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_1a, 1209, 279);
                    break;
                case "1b":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_1b, 1797, 452);
                    break;
                case "1c":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_1c, 1429, 339);
                    break;

                case "2a":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_2a, 1642, 249);
                    break;
                case "2b":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_2b, 1129, 348);
                    break;
                case "2c":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_2c, 1155, 244);
                    break;

                case "3a":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_3a, 1141, 239);
                    break;
                case "3b":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_3b, 895, 401);
                    break;
                case "3c":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_3c, 1230, 401);
                    break;

                case "4a":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_4a, 762, 291);
                    break;
                case "4b":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_4b, 900, 296);
                    break;
                case "4c":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_4c, 1178, 337);
                    break;

                case "5a":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_5a, 1190, 452);
                    break;
                case "5b":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_5b, 1429, 270);
                    break;
                case "5c":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_5c, 1368, 559);
                    break;

                case "6a":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_6a, 534, 222);
                    break;
                case "6b":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_6b, 1034, 230);
                    break;
                case "6c":
                    spriteRenderer.sprite = Plugin.Instance.SpriteReplace(message_6c, 1268, 213);
                    break;
            }
            return spriteRenderer.sprite;
        }
    }
}
