using KittyHorrorshowTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OmegaFallon.KittyHorrorshowTranslations
{
    public class CCCCCC : MonoBehaviour
    {
        public static CCCCCC Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string[] CCCCCCReplacedImages;
        public Dictionary<string, Texture2D> CCCCCCImages;
        public void AssetLoading()
        {
            // Don't do any asset loads if the language is English or null/empty
            if (Plugin.Instance.gameLanguage == "English" || string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
            {
                return;
            }

            CCCCCCReplacedImages = ["msg1", "msg2", "scr2", "scr3", "scr4", "scr5"];
            CCCCCCImages = new Dictionary<string, Texture2D> { };
            foreach (string str in CCCCCCReplacedImages)
            {
                CCCCCCImages.Add(str, Plugin.Instance.GetTexture("CCCCCC", Plugin.Instance.gameLanguage, str + ".png"));
            }
        }

        public UnityEngine.Sprite TextureReplacement(SpriteRenderer spriteRenderer)
        {
            int textureWidth = (int)spriteRenderer.sprite.rect.m_Width;
            int textureHeight = (int)spriteRenderer.sprite.rect.m_Height;

            if (CCCCCCReplacedImages.Contains(spriteRenderer.gameObject.name))
            {
                spriteRenderer.sprite = Plugin.Instance.SpriteReplace(CCCCCCImages[spriteRenderer.gameObject.name], textureWidth, textureHeight);
            }

            return spriteRenderer.sprite;
        }
    }
}
