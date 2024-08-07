using KittyHorrorshowTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OmegaFallon.KittyHorrorshowTranslations
{
    public class Subtitles_Anatomy : MonoBehaviour
    {
        public static Subtitles_Anatomy Instance;
        public void Awake()
        {
            Instance = this;
        }

        public Dictionary<double, string> ReturnSubtitles(string str)
        {
            switch (str)
            {
                // First House //
                case "tape1":
                    return new Dictionary<double, string>
                        {
                            { 3.135, "In the psychology of the modern, civilized human being, it is difficult to overstate the significance of the house." },
                            { 10.00, "Since as early as the Neolithic era, humankind has defined itself by its buildings."},
                            { 15.00, "Buildings for worship, buildings for socializing, buildings for protection, even buildings for the commemoration of the dead."},
                            { 22.85, "But of all the structures that mankind has invented for itself, there is little doubt that the house is that which it relies upon most completely for its continued survival."}
                        };
                case "tape2":
                    return new Dictionary<double, string>
                        {
                            { 1.66, "The house is one of the key elements that separates modern humanity from its more primitive antecedents."},
                            { 7.6, "No other creature goes to such lengths to create lasting, permanent shelter for itself, nor regards such shelters with such reverence and import."},
                            { 16.7, "Why do human beings of our modern age foster this tremendous sympathy toward their homes?"},
                            { 22.1, "There are many reasons, of course, but perhaps it is due in some small part to seeing them as a reflection of ourselves."},
                        };
                case "tape3":
                case "tape3_2":
                    return new Dictionary<double, string>
                        {
                            { 1.7, "The anatomy of the house is such that this analogy is less superficial than at first it may seem."},
                            { 8.0, "To carry it further, if we were to dissect a house as we might a human cadaver,"},
                            { 12.7, "we would find ourselves able to isolate and describe its various appendages and their functions in a decidedly anatomical fashion."},
                            { 21.0, "There is even a fair number of direct comparisons to be drawn between those organs of a house and those of a human body."},
                        };
                case "tape4":
                    return new Dictionary<double, string>
                        {
                            { 1.55, "For example, let us examine the living room." },
                            { 4.6, "Often the dominant space of a house's ground level,"},
                            { 7.5, "as well as typically the center of activity in a well-populated home,"},
                            { 11.5, "the living room is very much the heart of the house."},
                            { 15.00, "While a human heart circulates blood to oxygenate the body's extremities,"},
                            { 18.9, "the living room circulates people, activity, communication."},
                            { 23.5, "It is the room most likely to be found \"beating,\" as active and vivacious as its name would imply."},
                            { 29.8, "The comparison is only strengthened when we consider also that the living room is most commonly the room to contain the fireplace,"},
                            { 36.1, "making it additionally a locus of actual, physical heat." },
                        };
                case "tape5":
                case "tape5_2":
                    Dictionary<double, string> subtitleTimestampsGlobal = new Dictionary<double, string>
                        {
                            { 2.0, "It is easy to think of the kitchen and dining room as the stomach or digestive system of a house, though this comparison is tenuous."},
                            { 9.93, "A contrast: the function and analog of a bathroom should be immediately obvious."},
                            { 15.3, "The hallways and corridors of a house are its veins, providing circulation coursing throughout its frame."},
                            { 21.8, "A staircase bears more than a passing resemblance, both physically and symbolically, to a spine."},
                            { 28.2, "The windows of a house serve much the same purpose as eyes, and anyone who has ever rounded a bend or a long drive and come suddenly face to face with a tall, dark manor"},
                            { 38.0, "will tell you that it is difficult to shake the impression that the house, through its lightless windows, is a creature capable of vision and intelligence." }
                        };

                    if (Plugin.Instance.lastSoundPlayed == "tape5_2") { subtitleTimestampsGlobal.Add(38.846, "the house is a creature capable of"); }
                    return subtitleTimestampsGlobal;
                case "tape6":
                    return new Dictionary<double, string>
                        {
                            { 2.2, "The bedroom is perhaps the room that most eludes direct comparison in this fashion." },
                            { 7.7, "At a stretch, and allowing for a bit of poetic sympathy, it might be said that the bedroom is not unlike the human mind,"},
                            { 14.0, "or those parts of it which dictate thought and imagination."},
                            { 18.0, "In the bedroom, dreams are dreamt, passions are ignited, epiphanies are experienced in cold sweat at early hours."},
                            { 26.4, "In the bedroom is where people invariably spend the majority of their time, though comparatively little of it whilst conscious."},
                        };
                case "tape7":
                    return new Dictionary<double, string>
                        {
                            { 2.48, "And yet this analogy is an incomplete one."},
                            { 5.1, "Though obviously the mind is an exceedingly complex thing,"},
                            { 8.995, "but the bedroom represents the thinking, dreaming part of the brain"},
                            { 12.9, "and it is the basement that represents those lower, unconscious parts."},
                            { 17.68, "The basement is dark. It is buried."},
                            { 21.9, "It is a place full of cobwebs where memories are stored."},
                            { 25.7, "A poignant comparison, truly."},
                            { 27.9, "Often the unnerving uncertainty that comes with considering the deeper aspects of the human psyche"},
                            { 33.2, "is not unlike gazing down at the swimming blackness pooled at the bottom of the basement stairwell."},
                            { 39.2, "It is a place we spend our childhoods filling with monsters that will lay for years in patient silence."},
                            { 46.0, "It is a place that, barring some specific errand, we seldom ever want to go."},
                        };
                case "tape8":
                    return new Dictionary<double, string>
                        {
                            { 2.1, "Of course this comparison, though appropriate, is a very heavy-handed one," },
                            { 6.9, "and often the basement is little more than a storage space, littered with the corpses of spiders and wood lice."},
                            { 13.1, "While poets and psychoanalysts no doubt dread the thought of a dark basement,"},
                            { 18.1, "in truth it is the bedroom,"},
                            { 21.0, "the waking mind,"},
                            { 22.6, "that place of dreams,"},
                            { 24.6, "which is actually the most frightening of all."},
                        };
                case "tape9":
                    return new Dictionary<double, string>
                        {
                            { 1.4, "It is here, in the bedroom, that we are at our most vulnerable."},
                            { 6.9, "Each night we shut our senses to the world for hours at a time,"},
                            { 11.0, "trusting in the house to keep us safe until next we wake."},
                            { 15.2, "In this state of extreme vulnerability we will spend something like twenty percent of our lives."},
                            { 21.0, "Anything might stand beside us,"},
                            { 23.4, "watch us,"},
                            { 24.5, "keep us company until dawn and we would never perceive it."},
                            { 29.0, "We can only pray that the house will not let such things carry on as we sleep."},
                            { 34.0, "In this way, during these hours, the bedroom seems less like a mind and more like a mouth."},
                            { 41.6, "For it is here that the house is most likely to betray us."},
                            { 45.6, "It is here that we place ourselves most at the house's mercy"},
                            { 49.4, "and spend each night hoping"},
                            { 51.6, "that it will not bite down."},
                        };

                // Second House //
                case "tape1_2":
                    return new Dictionary<double, string>
                        {
                            { 3.135, "In the psychology of the modern, civilized human being, it is difficult to overstate the significance of the house." },
                            { 10.00, "Since as early as the Neolithic era, humankind has defined itself by its buildings."},
                            { 13.1, "iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii"},
                            { 13.845, "the dead."},
                            { 15.2, "But of all the structures that mankind has invented for itself, there is little doubt that the house is that which it relies upon most completely for its continued survival."},
                        };
                case "tape2_2":
                    return new Dictionary<double, string>
                        {
                            { 1.66, "Tue acgqe vs hbq mf ghx yqw eyefszrs ghth ecpnrthqq mbdxfz fuzagwfw feof wfq mbrx ddgmvtbjq yngevspcngs."},
                            { 7.6, "Nb omvqp ceethgpe toxg fm shca zqlgghl ha arrams xysgigu, bcrzagszr sueehqp fbr bhecls, nhf dcgnrwg escu sasxrees pwff shca fqteeegqq ynq ifdapt."},
                            { 16.7, "Why do human beings of our modern age foster this tremendous sympathy toward their homes?"},
                            { 20.477, "sympathy sympathy sympathy"},
                        };
                //case "tape3_2":
                case "tape4_2":
                    //see below
                    break;
                case "tape6_2":
                    return new Dictionary<double, string>
                        {
                            { 2.2, "The bedroom is perhaps the room that most eludes direct comparison in this fashion." },
                            { 7.7, "At a stretch, and allowing for a bit of poetic sympathy, it might be said that the bedroom is not unlike the human mind,"},
                            { 14.0, "or those parts of it which dictate thought and imagination."},
                            { 18.0, "In the bedroom, dreams are dreamt, passions are ignited, epiphanies are experienced in cold sweat at early hours."},
                            { 19.0, "dream dream dream dream drdrdrdrdrdrdrdr"},
                            { 20.8, "I dreamed that there are teeth growing all over me."},
                            { 24.6, "Everywhere on me, and in me, like cysts or bone spurs."},
                            { 31.2, "They're loose but I cannot move them because I have no hands."},
                            { 36.5, "I look out through the bedroom window and I see a truck approaching."},
                            { 41.38, "A young man steps out, approaches and enters through the front door."},
                            { 48.6, "His body is covered in swollen ticks the size of quarters."},
                            { 53.7, "He's walking through the downstairs hallway and laughing"},
                            { 58.2, "begins urinating on a wall"},
                            { 61.4, "spits on the carpet"},
                            { 64.0, "He's moving through the first floor, breaking and upsetting things."},
                            { 70.2, "He goes to the basement and stands at the top of the stairs."},
                            { 74.3, "I'm angry at him so I slam the door and he falls down."},
                            { 79.3, "I can feel his bones snapping."},
                            { 83.46, "The tics are bursting, oozing old, black blood everywhere."},
                            { 89.46, "I can feel him being ground up, dissolved and torn, splitting and shredding."},
                            { 97.37, "I leave the door closed."},
                            { 100.00, "I close my eyes and try to sleep."},
                            { 104.00, "The teeth continue growing on me until there is nothing left of me but teeth, and gums, and sinew."},
                            { 115.3, "The basement is dark."},
                        };

                // Third House //
                case "tape1_3":
                    return new Dictionary<double, string>
                        {
                            {0.0, "Ï+È+ÓƒÄ\fƒáüƒâüV;Ñ}\u000f‹EøPSè\u009dÿÿÿ‹]üë"},
                            {0.5, "ó\u000f\u0011]äó\u000f\u0010]¸\u000f(øó\u000fYûó\u000f\u0011}Ä\u000f(ûó\u000f"},
                            {1.5, "^ÃU‹ìQ‹E\bSVW‹ù‹M\f\u008d\\\b\vÇEüÿÿÿÿ;_0\u000fƒ§   \u008dG$"},
                            {2.0, "µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZ"},
                            {2.5, "~}Üÿj\u0001\u008dM\bQhÄï\u0003\u0001h\u0004©\t\u0001‹Î\u008d_,èd…Üÿ…Àt$"},
                            {3.0, "œ•uðn¼\u001d{A¿ž\u0010³Km@ Hî+R£Šá† \tŠtTúÚgWy±•s"},
                            {3.5, "ÌÌÌÌÌÌÌÌ€y1 \u000f•ÀÃÌÌÌÌÌÌÌÌU‹ìŠE\bˆA.]Â\u0004"},
                            {4.0, "EÓTUK’4ÍóDÑ4U•¦iš(š¦iª*MÓ4Q4MÓTUª*Š¦©ªªêº\\W"},
                            {4.5, "ÃÌÌÌU‹ìQ‹E\fS‹]\b;ØtrV\u008ds\u0004;ðti¸\u0004   +Ã‰Eü"},
                            {5.0, "°âë  Nê àâë 0?Ù 0?Ù EmulatedChannel DSPHead Unit"},
                            {5.5, "erer     @û!é?   ´°mp @•p "},
                            {6.0, "Ñéƒù wáÝÙÝØQV\u008dMÈè\u0004ýÿÿ\u008dMÈQ‹ÎèYÄÿÿ‹Mä…Ét"},
                            {6.5, "Ä ]ÃÌÌÌÌÌÌÌÌÌÌÌU‹ìV‹ñ‹F \u000f¯F\u001c‹V\u0010\u008dN\fW‹~P‹\u007f"},
                            {7.0, "ÌÌU‹ì]éG÷ÿÿÌÌÌÌÌÌÌU‹ì]é'øÿÿÌÌÌÌÌÌÌU‹ìSV‹"},
                            {7.5, "@“4©ÂsŠ[CbŒÎ>mÏäÂ\u0003\u0010ðB\u0014,ò>tŠFÃ¤Á½B|\u008fK?"},
                            {8.0, "a¿Ò½ÒÁi-QC°ôš¿ÀÛ¢Â}1]CN1,¾üšèÂ\u0002”ïBzâk¾ŽžF"},
                            {8.5, "ðˆ]à\u008dx\u0001\u0090Š\b@„Éuù+ÇPR\u008dMàèÍ²þÿjÿS\u008dEàP\u008dM¼è~ þÿ"},
                            {9.0, "C|_ÂÀP5+CÊf™CN•\u001cA)Ì\u0005C¸ÅZC¿l¥=×­«B®"},
                            {9.5, "\u0090‰]”‰]˜‰\u0018‰]ô8]\u001c\u000f…ï   ‹u\u0014\u008dMðQ\u008dU"},
                            {10.0, "±'_C   \u001c¶„ECÚ\u0014\u000eC   \u001cbñ,Cû›"},
                            {10.5, "]ÃÌÌÌÌÌU‹ì‹E\bVW‹ñ…ÀtE‹"},
                            {11.0, "VÿÐƒÄ\b‹ÏèdòÜÿ_^]Â\u0004 ÌÌÌÌÌÌÌÌÌÌÌÌÌÌU‹ìSV‹u\bWj ‹ù‹"},
                            {11.5, "This program cannot be run in DOS mode."},
                        };
                case "tape2_3":
                    return new Dictionary<double, string>
                        {
                            {0.0, "å_[]Ã‹U\u001cRP‹E\fPÁã\u0004\u0003ÙSSQèkòÿÿƒÄ\u0018_[]ÃÌÌÌÌU‹ìƒì\u001cS‹"},
                            {0.5, "‰uì3À;ðt]‹O\u0004‰\u000e‹W\u0004‰V\u0004‹O\u0004‰N\bf‰F"},
                            {1.5, "U¼R\u008dMäèu±ýÿ\u008dEäPèü¯\u0016 ƒÄ\u0004ƒ}ø\u0010‰\u0003r\u001a‹Mä"},
                            {2.0, "‹ñ‹È‰uü‰Mø;ÂtJ‹N\u0004SW‹}\bWPQRèä½ÿÿ‹^\u0004‹øƒ"},
                            {2.5, " P{@  \\@ \u0090å@ 0és \u0010és Àès ðãs  és  és @\u001am \u0090å@ `½” P»s \u0015^¡ À\\s `½” °Ês `½” Pü@ `½” `½” \u0010å@  å@  \\@ `[@ @\u001am \u0010Ls `½” P{@  \\@ \u0090å@  `s @`s °_s \u0090¿y ð_s P`s @\u001am \u0090å@"},
                            {3.0, "ÌÌÌÌÌÌÌÌÌÌÌU‹ìSV‹ñ‹^\u0004‹Ë+\u000e¸“$I’÷é\u0003ÑÁú\u0004‹ÂÁè\u001fW‹"},
                            {3.5, "ZØ\u000fZó\u000fZÓò\u000fY\u0015È\u008f\u0003\u0001\u000fZùò\u000fY=È\u008f\u0003\u0001ò\u000f\\÷ó\u000f\u0010}ô\u000fZÁò\u000fY\u0005¨1\u0003\u0001\u000fZÛf\u000f(âò\u000f\\àò\u000fX% "},
                            {4.0, "ÌU‹ì\u0081ì\u001c\u0001  V3öhþ   \u008d\u008dúþÿÿ3ÀVQÇ…ä"},
                            {4.5, "ÌÌÌÌÌÌÌÌÆAX ÃÌÌÌÌÌÌÌÌÌÌÌŠAXÃÌÌÌÌÌÌÌÌÌÌÌÌ"},
                            {5.0, "\u001bÿÿ\u000f·\u0004{PèìýÿÿGƒÄ\u0014;}ørØ\u008dMèè»\u0005I 3Û‹M\u0018‰\u0019;"},
                            {5.5, "ô‰MôP‹Ï‰UüèŒ”üÿWƒÆ8VèrãÿÿƒÄ\b_^[‹å]Â\u0004 ÌÌÌÌÌÌU‹ì"},
                            {6.0, "‰r\u0004‹q\u0004;F\u0004u\u0005‰V\u0004ë\u000f‹p\u0004;F\bu\u0005‰V\bë\u0002‰\u0016‰B\b‰P\u0004‹P"},
                            {6.5, "\u000f\u0011J\f‹V\u0004ó\u000f\u0010\u0001ó\u000f\u0010I\u0004ó\u000f\u0010Q\b‹E¬Áâ\u0005\u0003"},
                            {7.0, "YÈó\u000f\u0010F\u001có\u000f\\Áó\u000f\u0010N ó\u000fYÈó\u000fYÈó\u000fYÈó\u000fXI\fó\u000f\u0011I\f‹Eì@‰Eì"},
                            {7.5, "7‹MìQ‹MäQ‹M¸j Q‹MÄR‹UüVR‹U¼QP‹E WRj PèÉJÿÿó\u000f\u0010=\u0004\u000e\u0003\u0001"},
                            {8.0, "B\u0004ó\u000f\u0010Z\bÁà\u0005ó\u000f\\D8\u0004ó\u000f\\\f8ó\u000f\\\\8\bó\u000fYÀó\u000fYÉó\u000fXÁó\u000f"},
                            {8.5, " ¿\u0002   ‹Þ\u008dwÿë\b\u008d¤$    \u0090‹HäöÁ8\u000f„n\u0004  ó\u000f"},
                            {9.0, "UnityEngine.ParticleSystem::get_isPaused    "},
                            {9.5, "It ðãs 0It PIt @\u001am \u0090å@ `½” \u0090å@        €ëQà?m_MinKillVelocity"},
                            {10.0, " @m p³v `½” P{@  @ å@ pýv Pýv  ýv ðãs @ýv `ýv @m €³v `½”  òv Rotation quaternions"},
                            {11.0, "PrimitiveTriangleStrip kPrimitiveQuads kPrimitiveLines kPrimitiveLineStrip kPrimitivePoint"},
                            {11.5, "Frequency m_DampingRatio  JointSuspension2D   WheelJoint2D        Ð£y `½” ð`x `½” ð y à¡y `½” \u0010å@  å@  \\@ `[@ @\u001am à y `½” P{@  \\@ \u0090å@  ­y \u0090¬y @¬y `^x €¬y ð¬y @\u001am \u0090å@ `½” °_x `½” `½” `½”  øR @ax ð_x À§y  `x Ðgx  hx m_LocalAxis m_Suspension  "},
                        };
                case "tape3_3":
                    return new Dictionary<double, string>
                        {
                            {0.0, "OggS \u0002        \u0001       ”à{N\u0001\u001e\u0001vorbis    \u0002D¬              ¸\u0001OggS          \u0001   \u0001   ˜R¥þ\u0011&ÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿS\u0003vorbis\u0016   Fmod5Sharp (Samboy063)    \u0001\u0005vorbis+BCV\u0001 \b   1L Å€Ð\u0090U  \u0010  `$)\u000e“fI)¥”¡(y˜”HI)¥”Å0‰˜”‰Å\u0018cŒ1Æ\u0018cŒ1Æ\u0018cŒ 4d\u0015  \u0004 €(\tŽ£æIjÎ9g\u0018'Žr 9iN8§ \aŠQà9\tÂõ&cn¦´¦knÎ)%\b\r\n" },
                            {0.5, "Y\u0005  \u0002 @H!…\u0014RH!…\u0014bˆ!†\u0018bˆ!‡\u001crÈ!§œr\r\n" },
                            {1.0, "*¨ ‚\r\n" },
                            {1.5, "2È ƒL2é¤“N:é¨£Ž:ê(´ÐB\v-´ÒJL1ÕVc®½\u0006]|sÎ9çœsÎ9çœsÎ\tBCV\u0001    \u0004B\u0006\u0019d\u0010B\b!…\u0014Rˆ)¦˜r\r\n" },
                            {2.0, "2È€Ð\u0090U    €    G‘\u0014I±\u0014Ë±\u001cÍÑ$Oò,Q\u00135Ñ3ESTMUUUUu]Wve×vu×v}Y˜…[¸}Y¸…[Ø…]÷…a\u0018†a\u0018†a\u0018†aø}ß÷}ß÷} 4d\u0015  \u0001  #9–ã)¢\"\u001a¢â9¢\u0003„†¬\u0002 d  \u0004  \t’\")’£I¦fj®i›¶h«¶mË²,Ë²\f„†¬\u0002  \u0001 \u0004      iš¦iš¦iš¦iš¦iš¦iš¦išfY–eY–eY–eY–eY–eY–eY–eY–eY–eY–eY–eY–eY@hÈ* @\u0002 @Çq\u001cÇq$ER$Çr,\a\b\r\n" },
                            {2.5, "Y\u0005 È  \b @R,År4Gs4Çs<Çs<GtDÉ”LÍôL\u000f\b\r\n" },
                            {3.0, "Y\u0005  \u0002 \b     @1\u001cÅq\u001cÉÑ$OR-Ór5Ws=×sM×u]WUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU\u0081Ð\u0090U  \u0004  !\u009df–j€\b3\u0090a 4d\u0015 €   \u0018¡\bC\f\b\r\n" },
                            {3.5, "Y\u0005  \u0004  ˆ¡ä šÐšóÍ9\u000ešå ©\u0014›ÓÁ‰T›'¹©˜›sÎ9çœlÎ\u0019ãœsÎ)Ê™Å ™ÐšsÎI\fš¥ ™ÐšsÎy\u0012›\a­©ÒšsÎ\u0019çœ\u000eÆ\u0019aœsÎiÒš\a©ÙX›sÎYÐšæ¨¹\u0014›sÎ‰”›'µ¹T›sÎ9çœsÎ9çœsÎ©^œÎÁ9áœsÎ‰Ú›k¹\t]œsÎùdœîÍ\táœsÎ9çœsÎ9çœsÎ\tBCV\u0001 @  \u0004aØ\u0018Æ\u009d‚ }Ž\u0006b\u0014!¦!“\u001et\u008f\u000e“ 1È)¤\u001e\u008dŽFJ©ƒPR\u0019'¥t‚Ð\u0090U     „\u0010RH!…\u0014RH!…\u0014RH!†\u0018bˆ!§œr\r\n" },
                            {4.0, "*¨¤’Š*Ê(³Ì2Ë,³Ì2Ë¬ÃÎ:ë°Ã\u0010C\f1´ÒJ,5ÕVc\u008dµæžs®9Hk¥µÖZ+¥”RJ)¥ 4d\u0015  \u0002 @ d\u0090A\u0006\u0019…\u0014RH!†˜rÊ)§ ‚\r\n" },
                            {4.5, "\b" },
                            {5.0, "Y\u0005  \u0002 \b   ð$Ï\u0011\u001dÑ\u0011\u001dÑ\u0011\u001dÑ\u0011\u001dÑ\u0011\u001dÏñ\u001cQ\u0012%Q\u0012%Ñ2-S3=UTUWvmY—uÛ·…]Øuß×}ß×\u008d_\u0017†eY–eY–eY–eY–eY–e\tBCV\u0001     B\b!„\u0014RH!…”bŒ1ÇœƒNB\t\u0081Ð\u0090U    €    Gq\u0014Ç‘\u001cÉ‘$K²$MÒ,Íò4Oó4Ñ\u0013EQ4MS\u0015]Ñ\u0015uÓ\u0016eS6]Ó5eÓUeÕveÙ¶e[·}Y¶}ß÷}ß÷}ß÷}ß÷}ß×u 4d\u0015  \u0001  #9’\")’\"9ŽãH’\u0004„†¬\u0002 d  \u0004  (Žâ8Ž#I’$Y’&y–g‰š©™žé©¢\r\n" },
                            {5.5, "„†¬\u0002  \u0001 \u0004      hŠ§˜Š§ˆŠçˆŽ(‰–i‰šª¹¢lÊ®ëº®ëº®ëº®ëº®ëº®ëº®ëº®ëº®ëº®ëº®ëº®ëº@hÈ* @\u0002 @Gr$Gr$ER$Er$\a\b\r\n" },
                            {6.0, "Y\u0005 È  \b À1\u001cCR$Ç²,Mó4Oó4Ñ\u0013=Ñ3=UtE\u0017\b\r\n" },
                            {6.5, "Y\u0005  \u0002 \b     À\u0090\fK±\u001cÍÑ$QR-ÕR5ÕR-UT=UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUÕ4MÓ4\u0081Ð\u0090•  \u0019  „Å\a¡ŒR\u0012“ÔZìÁXŠ1\b¥\u0006å1…\u0014ƒ–„Ç˜BÊQN¢c\r\n" },
                            {7.0, "!å0§Ò9†Œ‘Úb\r\n" },
                            {7.5, "™2BYñ=vŒ!‡=\u0018\u009dBè$\u0006BCV\u0004 Q  \u0006I\"I$Éò<¢Gô,Ïã‰<\u0011€äy4\u008dçIžGóx\u001e Iôx\u001eM“<‘çÑ4\u0001  \u0001\u000e  \u0001\u0016B¡!+\u0002€8\u0001 ‹$y\u001eIò<’äy4M\u0014!Š–¦‰\u001eÏ\u0013Ež&ŠDÓ4¡š–¦y\"Ï\u0013Eš'ŠLQ5ašžè™&ÓtU¦©ª\\Y–!»ž'š&ÓT]¦©ªdW–!Ë   ,O3MšfŠ4Í4‰¢iÂ4-Í3Mš&š4Í4‰¢iÂ4=QTU¦©ªLSU¹®ëÂu=ÑTU¢©ªLSU¹®ëÂu\u0001  Hžfš4Í4iš)\u0012EÓ„iZšgš4Í4išh\u0012EÓ„iz¦èªLÓU™¢ªR]×…ëz¢©ºLSU‰¦ªrU×…ë\u0002  ÐLÑu‰¢«\u0012EUeš®\r\n" },
                            {8.0, "ÕÕDÓu‰¢ê\u0012EUešª\vU\u0015USv™¦ë2M×¥ª®\vÙ\u0015MÕ•™¦ë2M×¥º®\vW\u0006        €¨š²Ì4]—iº.Õu]¸®hª²Ì4]—iº.W•]¸®  €\u0001\a € \u0013Ê@¡!+\u0001€(  ‹ãH’ey\u001eÇ‘$Kó<Ž#Išæy$É²4M\u0014aYš&ŠÐ4Ï\u0013Ehšç‰\"  \u0002  \r\n" },
                            {8.5, "\u001c  \u0002lÐ”X\u001c Ð\u0090• @H €Åq$É²4ÍóDÑ4M“äH’¦yžç‰¢iª*I²,Mó<Ï\u0013EÓTU–dYšæy¢hšªªº°,Mó<Q4MUu]hš¦‰¢(š¦ªº.4MóDQ\u0014MSU]\u0017šæy¢hšªêº²\f<O\u0014MSU]×u\u0001                \u0004  \u001c8  \u0004\u0018A'\u0019U\u0016a£\t\u0017\u001e€BCV\u0004 Q  €1ˆ1Å˜a\r\n" },
                            {9.0, "J)%4ŠA)%”\bBH©¤”IH-µÖ2()µÖZ%¥´VZÊ¤¤ÖRk™”ÔZk­  °\u0003\a °\u0003\v¡Ð\u0090• @\u001e  ƒ\u0090RŒ1Æ\u0018EH)Æ\u0018sŽ\"¤\u0014cŒ9G\u0011RŠ1çœ£”*Å\u0018sÎQJ•bŒ9ç(¥J1Æ˜s”RÆ\u0018cÌ9J©”Œ1æ\u001c¥”RÆ\u0018cŒRJ)cŒ1&  ¨À\u0001  ÀF‘Í\tF‚\r\n" },
                            {9.5, "Y\t ¤\u0002 8\u001cÇ²4MÓ<O\u0014%Ç±,Ï\u0013EQ4MËq,ËóDQ\u0014M“eišç‰¢iª*ËÒ4Ï\u0013EÓTU¦éy¢hšªêºTÕóDÑ4UÕu\u0001         \u0001 à\t\u000e @\u00056¬ŽpR4\u0016XhÈJ  \u0003 €1\u0006!d\fBÈ\u0018„\u0010B\b!„\u0010\u0012  0à  \u0010`B\u0019(4d% \u0090\r\n" },
                            {10.0, " @\u0018£\u0014cÎII©2F)ç ”ÒZe\u0090RÎA(¥µf)¥œƒ’RkÍRJ9'%¥Öš)\u0019ƒPJJ­5•2\u0006¡””ZkÎ‰\u0010BJ­ÅØœ\u0013!„”Z‹±9'c))µ\u0018csNÆRRj1ÆæœS®µ\u0016cÍI)¥\\k-ÆZ\v @hp  ;°au„“¢±ÀBCV\u0002 y  \u0090RJ1Æ\u0018cL)¥\u0018cŒ1¦”RŒ1Æ˜SJ)Æ\u0018cÌ9§\u0014cŒ1æœcŒ1Æ\u0018sÎ1Æ\u0018cŒ9ç\u0018cŒ1ÆœsÎ1Æ\u0018cÎ9ç\u0018cŒ1çœsŒ1Æ˜   \u0002\a € \u001bE6'\u0018\t*4d% \u0010\u000e  \u0018Ã”sÎA(%•\r\n" },
                            {10.5, "!Æ tPJJ­U\b1\u0006!„RRj-jÎ9\b!”’RkÑsÎA\b¡””Z‹ª…PJ)%¥ÖZt-tRJI©µ\u0018£”\"„\u0090RJ­µ\u0018\u009d\u0013!„’Rj-ÆæœŒ¥¤ÔZŒ16çd,%¥ÖbŒ±9çœk­µ\u0016c­Í9ç\\k)¶\u0018kmÎ9§{l1ÖXksÎ9Ÿ[‹­ÆZ\v 0yp €J°q†•¤³ÂÑàBCV\u0002 ¹\u0001 ŒRŒ1æœsÎ9çœsÎI¥\u0018sÎ9\b!„\u0010B\b!”J1æœs\u0010B\b!„\u0010B(\u0019sÎ9\a!„\u0010B\b!„PJéœs\u0010B\b!„\u0010B\b¡”Ò9ç „\u0010B\b!„\u0010B)¥sÎA\b!„\u0010B\b!„RJ\b!„\u0010B\b!„\u0010B\b¥”RB\b!„\u0010B\b!„\u0010J)¥„\u0010B\b!„\u0010B\b!”RJ\t!„\u0010B\b!„\u0010B(¥”\u0012B\b!„\u0010B\b%„PJ)¥”\u0010B\b¡„\u0010B\b¡”RJ)!„RJ)!„\u0010B)¥”RB(¡„\u0010B\b!”RJ)¥”\u0012B)!„\u0010B\b¥”RJ)¥”RB\b!„\u0010J)¥”RJ)¥„PB\b!”RJ)¥”RB(%„\u0012B(¥”RJ)¥„PB\b!„PJ)¥”RJ\t!„\u0012B\b¡   \u0003\a € #*-ÄN3®<\u0002G\u00142L@…†¬\u0004 Ò\u0002  C¬µÖZk­µÖZk\r\n" },
                            {11.0, "RÖZk­µÖZk­µF)k­µÖZk­µÖZk©µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZk­µÖZK)¥”RJ)¥”RJ)¥”RJ)¥”RJ)¥”RJ)¥”RJ)¥”RJ)¥”RJ)¥”RJ)¥”RJ)¥”RJ)¥”R\u0001Ø\u0005\u001b\u000e€Ñ\u0013F\u0012Rg\u0019V\u001aqã\t\u0018\"\u0090BCV\u0002 i\u0001 €1Œ1æ\u0018t\u0010JI)¥\r\n" },
                            {11.5, "!ç „NB*­Å\u0016c„\u0090s\u0010B(%¥Öb‹1x\u000eB\b!”ÒRl1ÆX<\a!„\u0010Rj-Æ\u0018c\f²…PJ))µÖbŒµ\u0016ÙB(¥””Z‹1ÖZƒ1¦”’Rj­ÕXc¬Å\u0018\u0013JH©µÖbÌµÖb|¬%¥ÔbŒ±ÆXk1Æ¶\u0014R‰-ÆXk\u008dµ\u0018aŒj­ÅXc­±ÖZŒ1Â•\u0016bŠµÖZs-F\bcs‹1ÖXk®¹\u0016aŒÑ¹•Zj\u008d±ÖZ‹/Æ\u0018ak¬5ÆZkÎÅ\u0018#„°µ¶\u001akÍ5×bŒ1Æ\b\u001fc¬µÖÜs1Æ\u0018c„\u00901Æ\u001akÎ¹ €Ü\b\a Ä\u0005#\t©³\f+\u008d¸ñ\u0004\f\u0011H¡!« €\u0018 €! „b²\u0001 €\t\u000e  \u0001V°+³´j£¸©“¼èƒÀ'tÄfdÈ¥TÌäDÐ#5Ôb%Ø¡\u0015Üà\u0005`¡!+\u0001 2  ÄYÍ9Çœ+ä¤µØj,\u0015R\u000eRŠ1vÈ å$ÅZ2d\u0010ƒÔbê\u00142ˆAj©t\f\u0019\u0004%ÆT:…\fƒ\\c+¡c\u000eZ«±¥\u0012:\b  €  À@„Ì\u0004\u0002\u0005P` \u0003 \u000e\u0010\u0012¤ €Â\u0002CÇp\u0011\u0010\u0090KÈ(0(\u001c\u0013ÎI§\r\n" },
                        };
                case "tape4_3":
                    switch (Plugin.Instance.gameLanguage)
                    {
                        case "English":
                            return new Dictionary<double, string> { { 0.0, new StringBuilder().Insert(0, "YOUNEVERCAMEBACK", 25).ToString() } };
                        case "French":
                            return new Dictionary<double, string> { { 0.0, new StringBuilder().Insert(0, "TUN'ESJAMAISREVENU", 25).ToString() } };
                        case "Dutch":
                            return new Dictionary<double, string> { { 0.0, new StringBuilder().Insert(0, "JEBENTNOOITTERUGKWAM", 25).ToString() } };
                        case "Japanese":
                            return new Dictionary<double, string> { { 0.0, new StringBuilder().Insert(0, "あなたは二度と戻って来なかった", 25).ToString() } };
                    }
                    break;
                case "tape5_3":
                    return new Dictionary<double, string>
                        {
                            { 1.5, "and if we were to disect the house" },
                            { 3.14, "we would find organs"},
                            { 4.0, "and stomach"},
                            { 4.74, "veins" },
                            { 5.17, "and bile" },
                            { 5.8, "and eyes" },
                            { 6.4, "and teeth are growing through me" },
                            { 8.5, "dreams and memories"},
                            { 10, "like a mouth" },
                            { 11.25, "it will bite down."}
                        };
                case "tapeX_3":
                    return new Dictionary<double, string>
                        {
                            { 1.5, "There is an important distinction that must be drawn between the words \"dissection\" and \"vivisection\"."},
                            { 7.2, "A distinction that would appear to be lost on you."},
                            { 10.6, "Your purpose was to listen, and yet at every turn you have pried, you have prodded, and you have interfered."},
                            { 18.4, "Have you not been paying attention?" },
                            { 21.0, "Did it not occur to you that as an organism existing within a greater organism, your intrusion would be felt?" },
                            { 28.1, "And still you harassed."},
                            { 30.8, "And now, like the wayward spider who witlessly settles upon a sleeper's tongue, you will be swallowed."},
                            { 37.9, "Because the truth is this:"},
                            { 40.45, "when a house is both hungry and awake,"},
                            { 44.0, "every room becomes a mouth."}
                        };

                // Final speech //
                case "finalspeech":
                    return new Dictionary<double, string>
                        {
                            { 3.2, "What happens to a house when it is left alone?"},
                            { 8.445, "When it becomes worn and aged?" },
                            { 12.4, "When its paint peels?" },
                            { 14.8, "When its foundations begin to sink?"},
                            { 19.7, "When it goes for too long unlived in?" },
                            { 24.7, "What does it think of?" },
                            { 28.4, "What does it dream?" },
                            { 33, "How does it regard those creatures who built it?" },
                            { 36.88, "Brought it into existence only to abandon it" },
                            { 40.6, "when its usefulness no longer satisfies them." },
                            { 47, "It may grow lonesome." },
                            { 51.27, "It may stare for long hours into the darkness of its own empty halls and see shadows." },
                            { 57.5, "and its heart may jump as it thinks \"here, here is someone again, I am not alone.\"" },
                            { 65, "And each time it is wrong." },
                            { 68.37, "And the hurt starts over." },
                            { 73.4, "It may haunt itself," },
                            { 76.2, "inventing ghosts to walk its floors," },
                            { 80, "making friends with its shadow puppets," },
                            { 83.4, "laughing and whispering to itself at the end of some quiet cul-de-sac." },
                            { 91.6, "It may grow angry." },
                            { 95.6, "Its basement may fill with churning acid like an empty stomach," },
                            { 100.47, "and its gorge may rise as it asks itself, through clenched teeth, \"what did I do wrong?\"" },
                            { 109.8, "It may grow bitter." },
                            { 113.47, "It may grow hungry." },
                            { 116.67, "So hungry and so bitter that its scruples dissolve and its doors unlock themselves." },
                            { 124.86, "While a house may hunger, it cannot starve." },
                            { 129.79, "And so in fever and anger and loneliness," },
                            { 134.82, "it may simply lie in wait." },
                            { 138.94, "Doors open." },
                            { 142, "Shades drawn." },
                            { 145, "Hallways empty." },
                            { 149.8, "Hungry." }
                        };

                // Bedroom tape //
                case "amen":
                    return new Dictionary<double, string>
                        {
                            { 0.05, "Now I lay me down to sleep," },
                            { 4.08, "I pray the Lord my Soul to keep;" },
                            { 8.55, "If I should die before I 'wake," },
                            { 12.11, "I pray the Lord my Soul to take."},
                            { 16.35, "Amen."},
                        };
            }

            // Default
            return new Dictionary<double, string>
                {
                    { 0.0, ""},
                };
        }
    }
}