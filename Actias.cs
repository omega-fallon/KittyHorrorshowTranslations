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

        public string[] ActiasReplacedImages;
        public Dictionary<string, Texture2D> ActiasImages;
        public void AssetLoading()
        {
            // Don't do any asset loads if the language is English or null/empty
            if (Plugin.Instance.gameLanguage == "English" || string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
            {
                return;
            }

            ActiasReplacedImages = ["title", "1a", "1b", "1c", "2a", "2b", "2c", "3a", "3b", "3c", "4a", "4b", "4c", "5a", "5b", "5c", "6a", "6b", "6c"];
            ActiasImages = new Dictionary<string, Texture2D> { };
            foreach (string str in ActiasReplacedImages)
            {
                ActiasImages.Add(str, Plugin.Instance.GetTexture("Actias", Plugin.Instance.gameLanguage, str + ".png"));
            }
        }

        public UnityEngine.Sprite TextureReplacement(SpriteRenderer spriteRenderer)
        {
            int textureWidth = (int)spriteRenderer.sprite.rect.m_Width;
            int textureHeight = (int)spriteRenderer.sprite.rect.m_Height;

            if (ActiasReplacedImages.Contains(spriteRenderer.gameObject.name))
            {
                spriteRenderer.sprite = Plugin.Instance.SpriteReplace(ActiasImages[spriteRenderer.gameObject.name], textureWidth, textureHeight);
            }

            return spriteRenderer.sprite;
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
                        case "Japanese": str = "残り" + Plugin.Instance.IntToRoman(str[0].ToString()) + " " + "基 "; break; //counter for "big things that are hard to move", specifically listed as being used for Japanese "toro", which are large stone lanterns and fairly analagous to pylons
                    }
                    break;
            }
            return str;
        }
    }
}
