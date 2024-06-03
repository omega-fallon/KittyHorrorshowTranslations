using HarmonyLib;
using HutongGames.PlayMaker.Actions;
using PixelCrushers.DialogueSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static PixelCrushers.DialogueSystem.Articy.ArticyData;

namespace KittyHorrorshowTranslations
{
    public class Gloompuke : MonoBehaviour
    {
        public static Gloompuke Instance;
        public void Awake()
        {
            Instance = this;
        }

        public void EditObjectNames()
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                string translatedName = obj.name;
                translatedName = Gloompuke.Instance.NameTranslation(translatedName);
                obj.name = translatedName;
            }
        }

        [HarmonyPatch]
        public class MyPatchClass
        {
            // Promity popup overriding
            [HarmonyPrefix]
            [HarmonyPatch(typeof(PixelCrushers.DialogueSystem.Usable), nameof(PixelCrushers.DialogueSystem.Usable.GetName))]
            public static void ProximityPopupOverride(Usable __instance)
            {
                Plugin.Instance.PrintThisString("overrideName is: " + __instance.overrideName);
                Plugin.Instance.PrintThisString("overrideUseMessage is: " + __instance.overrideUseMessage);

                __instance.overrideName = Gloompuke.Instance.NameTranslation(__instance.overrideName);
                switch (__instance.overrideUseMessage)
                {
                    case "Click to talk":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __instance.overrideUseMessage = "Cliquez pour parler";
                                break;
                            case "Dutch":
                                __instance.overrideUseMessage = "Klik om te praten";
                                break;
                            case "Japanese":
                                __instance.overrideUseMessage = "（クリックして話す）";
                                break;
                        }
                        break;
                }
            }

            // Dialogue overriding
            [HarmonyPrefix]
            [HarmonyPatch(typeof(PixelCrushers.DialogueSystem.DialogueEntry), nameof(PixelCrushers.DialogueSystem.DialogueEntry.DialogueText), MethodType.Getter)]
            public static bool DialogueTextOverride(ref string __result, DialogueEntry __instance)
            {
                __result = Field.FieldValue(Field.AssignedField(__instance.fields, Localization.Language) ?? Field.Lookup(__instance.fields, "Dialogue Text"));

                Plugin.Instance.PrintThisString("Dialogue is: " + __result);

                switch (__result)
                {
                    case "What can I do ya for?":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __result = "Que puis-je faire pour tu?";
                                break;
                            case "Dutch":
                                __result = "Wat kan ik voor je doen?";
                                break;
                            case "Japanese":
                                __result = "どういうご用件ですか？";
                                break;
                        }
                        break;
                }

                return false;
            }

            // Menu text overriding
            [HarmonyPrefix]
            [HarmonyPatch(typeof(PixelCrushers.DialogueSystem.DialogueEntry), nameof(PixelCrushers.DialogueSystem.DialogueEntry.MenuText), MethodType.Getter)]
            public static bool MenuTextOverride(ref string __result, DialogueEntry __instance)
            {
                __result = Field.FieldValue(Field.AssignedField(__instance.fields, Field.LocalizedTitle("Menu Text")) ?? Field.Lookup(__instance.fields, "Menu Text"));

                Plugin.Instance.PrintThisString("MenuText is: " + __result);

                switch (__result)
                {
                    // Gregory
                    case "what is this place?":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __result = "quel est cet endroit ?";
                                break;
                            case "Dutch":
                                __result = "wat is deze plek?";
                                break;
                            case "Japanese":
                                __result = "この場所は何ですか？";
                                break;
                        }
                        break;
                    case "who are you?":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __result = "qui es-tu ?";
                                break;
                            case "Dutch":
                                __result = "wie ben je?";
                                break;
                            case "Japanese":
                                __result = "あなたは誰ですか？";
                                break;
                        }
                        break;
                    case "what's going on around here?":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __result = "que se passe-t-il par ici ?";
                                break;
                            case "Dutch":
                                __result = "wat is hier aan de hand?";
                                break;
                            case "Japanese":
                                __result = "この辺りで何が起こっているんですか？";
                                break;
                        }
                        break;
                    case "get me outta here":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __result = "fais-moi sortir d'ici";
                                break;
                            case "Dutch":
                                __result = "haal me hier weg";
                                break;
                            case "Japanese":
                                __result = "ここから連れ出して";
                                break;
                        }
                        break;
                    case "seeya":
                        switch (Plugin.Instance.gameLanguage)
                        {
                            case "French":
                                __result = "à plus";
                                break;
                            case "Dutch":
                                __result = "tot ziens";
                                break;
                            case "Japanese":
                                __result = "じゃあ";
                                break;
                        }
                        break;
                }

                return false;
            }
        }

        public string NameTranslation(string name)
        {
            switch (name)
            {
                case "Ezekiel":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Ézéchiel";
                            break;
                        case "Dutch":
                            name = "Ezechiël";
                            break;
                        case "Japanese":
                            name = "エゼキエル";
                            break;
                    }
                    break;
                case "Gregory":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Grégoire";
                            break;
                        case "Dutch":
                            name = "Gregoor";
                            break;
                        case "Japanese":
                            name = "グレゴリー";
                            break;
                    }
                    break;
                case "Roderick":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Rodérick";
                            break;
                        case "Dutch":
                            name = "Roderik";
                            break;
                        case "Japanese":
                            name = "ロデリック";
                            break;
                    }
                    break;
                case "Torvald":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "Japanese":
                            name = "トールバルド";
                            break;
                    }
                    break;
                case "Bethany & Ursula":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Béthanie & Ursule";
                            break;
                        case "Dutch":
                            name = "Bethanië & Ursula";
                            break;
                        case "Japanese":
                            name = "ベタニアとウルスラ";
                            break;
                    }
                    break;
                case "Bethany":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Béthanie";
                            break;
                        case "Dutch":
                            name = "Bethanië";
                            break;
                        case "Japanese":
                            name = "ベタニア";
                            break;
                    }
                    break;
                case "Ursula":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Ursule";
                            break;
                        case "Dutch":
                            name = "Ursula";
                            break;
                        case "Japanese":
                            name = "ウルスラ";
                            break;
                    }
                    break;
                case "Vivian":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Viviane";
                            break;
                        case "Dutch":
                            name = "Vivian";
                            break;
                        case "Japanese":
                            name = "ビビアン";
                            break;
                    }
                    break;
                case "Catherine":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Catherine";
                            break;
                        case "Dutch":
                            name = "Catharijne";
                            break;
                        case "Japanese":
                            name = "キャサリン";
                            break;
                    }
                    break;
                case "Gwynevere":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Gwynevere";
                            break;
                        case "Dutch":
                            name = "Gwynevere";
                            break;
                        case "Japanese":
                            name = "グウィネヴィア"; // name of the character from Dark Souls in Japanese
                            break;
                    }
                    break;
                case "Margaret":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Marguerite";
                            break;
                        case "Dutch":
                            name = "Margreet";
                            break;
                        case "Japanese":
                            name = "マーガレット";
                            break;
                    }
                    break;
                case "Mildred":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Mildred";
                            break;
                        case "Dutch":
                            name = "Mildred";
                            break;
                        case "Japanese":
                            name = "ミルドレッド";
                            break;
                    }
                    break;
                case "Saxtus":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Saxtus";
                            break;
                        case "Dutch":
                            name = "Saxtus";
                            break;
                        case "Japanese":
                            name = "サクツ";
                            break;
                    }
                    break;
                case "Theresa":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Thérèse";
                            break;
                        case "Dutch":
                            name = "Trees";
                            break;
                        case "Japanese":
                            name = "テレサ";
                            break;
                    }
                    break;
                case "Uther":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "French":
                            name = "Uther";
                            break;
                        case "Dutch":
                            name = "Uther";
                            break;
                        case "Japanese":
                            name = "ユーサー";
                            break;
                    }
                    break;
            }

            return name;
        }
    }
}
