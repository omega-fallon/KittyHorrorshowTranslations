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
            title = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\title.png");

            message_1a = Plugin.Instance.GetTexture("Actias\\"+Plugin.Instance.gameLanguage+"\\1a.png");
            message_1b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_1c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");

            message_2a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_2b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_2c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");

            message_3a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_3b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_3c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");

            message_4a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_4b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_4c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");

            message_5a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_5b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_5c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");

            message_6a = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_6b = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
            message_6c = Plugin.Instance.GetTexture("Actias\\" + Plugin.Instance.gameLanguage + "\\1a.png");
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
                        case "Japanese": str = "残り" + str[0] + "基 "; break; //counter for "big things that are hard to move", specifically listed as being used for Japanese "toro", which are large stone lanterns and fairly analagous to pylons
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
                    spriteRenderer.sprite = Sprite.Create(title, new Rect(0.0f, 0.0f, 1600, 900), new Vector2(0.5f, 0.5f), 100.0f);
                    break;

                case "1a":
                    spriteRenderer.sprite = Sprite.Create(message_1a, new Rect(0.0f, 0.0f, 1209, 279), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "1b":
                    spriteRenderer.sprite = Sprite.Create(message_1b, new Rect(0.0f, 0.0f, 1797, 452), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "1c":
                    spriteRenderer.sprite = Sprite.Create(message_1c, new Rect(0.0f, 0.0f, 1429, 339), new Vector2(0.5f, 0.5f), 100.0f);
                    break;

                case "2a":
                    spriteRenderer.sprite = Sprite.Create(message_2a, new Rect(0.0f, 0.0f, 1642, 249), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "2b":
                    spriteRenderer.sprite = Sprite.Create(message_2b, new Rect(0.0f, 0.0f, 1129, 348), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "2c":
                    spriteRenderer.sprite = Sprite.Create(message_2c, new Rect(0.0f, 0.0f, 1155, 244), new Vector2(0.5f, 0.5f), 100.0f);
                    break;

                case "3a":
                    spriteRenderer.sprite = Sprite.Create(message_3a, new Rect(0.0f, 0.0f, 1141, 239), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "3b":
                    spriteRenderer.sprite = Sprite.Create(message_3b, new Rect(0.0f, 0.0f, 895, 401), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "3c":
                    spriteRenderer.sprite = Sprite.Create(message_3c, new Rect(0.0f, 0.0f, 1230, 401), new Vector2(0.5f, 0.5f), 100.0f);
                    break;

                case "4a":
                    spriteRenderer.sprite = Sprite.Create(message_4a, new Rect(0.0f, 0.0f, 762, 291), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "4b":
                    spriteRenderer.sprite = Sprite.Create(message_4b, new Rect(0.0f, 0.0f, 900, 296), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "4c":
                    spriteRenderer.sprite = Sprite.Create(message_4c, new Rect(0.0f, 0.0f, 1178, 337), new Vector2(0.5f, 0.5f), 100.0f);
                    break;

                case "5a":
                    spriteRenderer.sprite = Sprite.Create(message_5a, new Rect(0.0f, 0.0f, 1190, 452), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "5b":
                    spriteRenderer.sprite = Sprite.Create(message_5b, new Rect(0.0f, 0.0f, 1429, 270), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "5c":
                    spriteRenderer.sprite = Sprite.Create(message_5c, new Rect(0.0f, 0.0f, 1368, 559), new Vector2(0.5f, 0.5f), 100.0f);
                    break;

                case "6a":
                    spriteRenderer.sprite = Sprite.Create(message_6a, new Rect(0.0f, 0.0f, 534, 222), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "6b":
                    spriteRenderer.sprite = Sprite.Create(message_6b, new Rect(0.0f, 0.0f, 1034, 230), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
                case "6c":
                    spriteRenderer.sprite = Sprite.Create(message_6c, new Rect(0.0f, 0.0f, 1268, 213), new Vector2(0.5f, 0.5f), 100.0f);
                    break;
            }
            return spriteRenderer.sprite;
        }
    }
}
