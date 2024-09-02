using KittyHorrorshowTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OmegaFallon.KittyHorrorshowTranslations
{
    public class RainHouseEternity : MonoBehaviour
    {
        public static RainHouseEternity Instance;
        public void Awake()
        {
            Instance = this;
        }

        public string[] rainhouseReplacedImages;
        public Dictionary<string, Texture2D> rainhouseImages;
        public void AssetLoading()
        {
            // Don't do any asset loads if the language is English or null/empty
            if (Plugin.Instance.gameLanguage == "English" || string.IsNullOrEmpty(Plugin.Instance.gameLanguage))
            {
                return;
            }

            rainhouseReplacedImages = ["message1", "message2", "message3", "message4", "message5", "message6", "message7", "message8", "message9", "message10", "message11", "message12", "message13", "message14", "message15", "message16", "message17", "message18", "message19", "message20"];
            rainhouseImages = new Dictionary<string, Texture2D> { };
            foreach (string str in rainhouseReplacedImages)
            {
                rainhouseImages.Add(str, Plugin.Instance.GetTexture("Rain, House, Eternity", Plugin.Instance.gameLanguage, str + ".png"));
            }
        }

        public UnityEngine.Sprite TextureReplacement(SpriteRenderer spriteRenderer)
        {
            int textureWidth = (int)spriteRenderer.sprite.rect.m_Width;
            int textureHeight = (int)spriteRenderer.sprite.rect.m_Height;

            if (rainhouseReplacedImages.Contains(spriteRenderer.gameObject.name))
            {
                spriteRenderer.sprite = Plugin.Instance.SpriteReplace(rainhouseImages[spriteRenderer.gameObject.name], textureWidth, textureHeight);
            }

            return spriteRenderer.sprite;
        }

        public string TextReplacement(string str)
        {
            switch (str)
            {
                case "there is something i want you to see\r\n\r\nlook up":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "j'aimerais vous montrer quelque chose\r\n\r\nlevez les yeux"; break;
                    }
                    break;
                case "i was brought here, just as you\r\nbut i was brought here long agoa\r\nand so you will hear my story, just as yours unfolds\r\ntake no comfort\r\nthere is pain in your immediate future":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "on m'a emmené ici, comme vous\r\non m'y a emmené il y a bien longtemps\r\nécoutez donc mon histoire, alors que la vôtre s'écrit\r\nne prenez pas vos aises\r\nil n'y a que souffrance à l'horizon"; break;
                    }
                    break;
                case "i will take no pleasure from the blood you lay across my stone\r\nbut i do not fault you for your decision\r\nmay the void give you the peace your world denied you":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "je n'ai aucun plaisir à répandre votre sang sur ma pierre\r\nmais je respecte votre décision\r\ndans le vide, trouvez la paix que le monde ne vous a jamais laissé"; break;
                    }
                    break;
                case "are you certain?\r\nthe abyss does not give up its claims":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "est-ce votre dernier mot ?\r\nl'abysse ne lâche jamais prise"; break;
                    }
                    break;
                case "we like to think that when angry hands are\r\nflying across our doors, those who claim to\r\nlove us will risk their flesh to keep us safe\r\nthat they will turn against the narrow-eyed world\r\nand make their arms our sanctuary\r\n\r\nwe are always wrong":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "lorsque l'inconnu frappe à nos portes pour\r\nnous atteindre, nous aimons croire que ceux\r\nqui disent nous aimer risqueraient leur vie pour nous\r\nqu'ils lutteraient contre un monde qui nous\r\nrejette et feraient de leurs bras notre sanctuaire\r\n\r\nc'est un mensonge"; break;
                    }
                    break;
                case "are you certain?\r\nyou will abandon the only shape you've ever known":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "est-ce votre dernier mot ?\r\nvous abandonnerez la seule forme que vous ayez connue"; break;
                    }
                    break;
                case "have you ever been anything else?":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "avez-vous déjà été autre chose ?"; break;
                    }
                    break;
                case "when is the last time someone\r\nwalked their fingertips up\r\nthe crest of your spine?\r\ndo you remember the sensation\r\nwell enough to cherish it?\r\ni hope you do":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "à quand remonte la dernière fois\r\noù quelqu'un a glissé son doigt\r\nle long de votre dos ?\r\nétait-ce marquant ?\r\nest-ce que cette sensation vous manque ?\r\nj'espère que vous vous en souvenez"; break;
                    }
                    break;
                case "the stone you ascend was once my skin, my spine\r\nevery shape you have traversed, i have chosen for myself\r\nmy rebirth has made me undefinable and infinite\r\ni shed the skin of form and became perfect\r\ni am at once the queen and the kingdom":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "cette pierre était ma peau, ma colonne vertébrale\r\nchaque forme est une partie de moi que j'ai choisie\r\nje suis revenue au monde, indescriptible, et infinie\r\nj'ai mué de ma forme, je suis devenue parfaite\r\nje suis à la fois la reine et le royaume"; break;
                    }
                    break;
                case "i understand your fear better than you know\r\nbut in your sacrifice, they have unknowingly given you a gift\r\ni offer you a choice, a kindness none ever showed me\r\nbe it your wish, you may have annihilation\r\nquiet and certain\r\nbut you can be shapeless and eternal\r\nif you open my door":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "je comprends votre peur mieux que vous ne l'imaginiez\r\nmais votre sacrifice vous a pourvu d'un cadeau à leur insu\r\nje vous offre un choix, une faveur que je n'ai jamais connue\r\nou bien vous empruntez la voix de l'annihilation\r\nsilencieuse, certaine\r\nou bien celle de la vie perpétuelle, sans enveloppe charnelle\r\nil vous suffira alors d'ouvrir ma porte"; break;
                    }
                    break;
                case "i will take whatever shape\r\ni choose":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "je prendrai la forme\r\nque je préfère"; break;
                    }
                    break;
                case "it is not the valleys and deserts of our lives that change us\r\nit is the elders who take us to them\r\nand force us to prostrate ourselves across old altars\r\nbut time is all that they can take from you\r\nremember that you are beholden to nothing\r\nyou will choose your shape\r\nyou will grow\r\nand you will ascend":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French": str = "ce ne sont pas les plaines et les déserts qui nous changent\r\nmais les anciens qui nous y emmènent\r\net qui nous font nous prosterner face à de vieux autels\r\nmais le temps est la seule chose qu'ils ne puissent pas vous enlever\r\nplus aucune attache ne vous retient\r\nvous choisirez votre forme\r\nvous grandirez\r\net vous transcenderez"; break;
                    }
                    break;
            }
            return str;
        }
    }
}