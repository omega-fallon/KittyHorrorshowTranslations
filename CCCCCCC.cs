using KittyHorrorshowTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OmegaFallon.KittyHorrorshowTranslations
{
    public class Ccccccc : MonoBehaviour
    {
        public static Ccccccc Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string[] CccccccReplacedImages;
        public Dictionary<string, Texture2D> CccccccImages;
        public void AssetLoading()
        {
            // Don't do any asset loads if the language is English or null/empty
            if (Plugin.Instance.gameLanguage == "English" || string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
            {
                return;
            }

            CccccccReplacedImages = ["msg1", "msg2", "scr2", "scr3", "scr4", "scr5"];
            CccccccImages = new Dictionary<string, Texture2D> { };
            foreach (string str in CccccccReplacedImages)
            {
                CccccccImages.Add(str, Plugin.Instance.GetTexture("Ccccccc", Plugin.Instance.gameLanguage, str + ".png"));
            }
        }

        public UnityEngine.Sprite TextureReplacement(SpriteRenderer spriteRenderer)
        {
            int textureWidth = (int)spriteRenderer.sprite.rect.m_Width;
            int textureHeight = (int)spriteRenderer.sprite.rect.m_Height;

            if (CccccccReplacedImages.Contains(spriteRenderer.gameObject.name))
            {
                spriteRenderer.sprite = Plugin.Instance.SpriteReplace(CccccccImages[spriteRenderer.gameObject.name], textureWidth, textureHeight);
            }

            return spriteRenderer.sprite;
        }
    }
}
