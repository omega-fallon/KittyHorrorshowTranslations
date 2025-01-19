using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KittyHorrorshowTranslations
{
    public class Pente : MonoBehaviour
    {
        public static Pente Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string[] PenteReplacedImages;
        public Dictionary<string, Texture2D> PenteImages;
        public void AssetLoading()
        {
            // Don't do any asset loads if the language is English or null/empty
            if (Plugin.Instance.gameLanguage == "English" || string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
            {
                return;
            }

            PenteReplacedImages = ["msg fountain","msg henges","msg island","writing1","writing2","writing3","writing4","writing5"];
            if (Plugin.Instance.gameLanguage == "English (UK)") { PenteReplacedImages = [ "msg henges" ]; }
            PenteImages = new Dictionary<string, Texture2D> { };
            foreach (string str in PenteReplacedImages)
            {
                PenteImages.Add(str, Plugin.Instance.GetTexture("Pente", Plugin.Instance.gameLanguage, str + ".png"));
            }
        }

        public UnityEngine.Sprite TextureReplacement(SpriteRenderer spriteRenderer)
        {
            int textureWidth = (int)spriteRenderer.sprite.rect.m_Width;
            int textureHeight = (int)spriteRenderer.sprite.rect.m_Height;

            if (PenteReplacedImages.Contains(spriteRenderer.gameObject.name))
            {
                spriteRenderer.sprite = Plugin.Instance.SpriteReplace(PenteImages[spriteRenderer.gameObject.name], textureWidth, textureHeight);
            }

            return spriteRenderer.sprite;
        }
    }
}
