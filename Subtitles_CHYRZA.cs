using KittyHorrorshowTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OmegaFallon.KittyHorrorshowTranslations
{
    public class Subtitles_CHYRZA : MonoBehaviour
    {
        public static Subtitles_CHYRZA Instance;
        public void Awake()
        {
            Instance = this;
        }

        public Dictionary<double, string> ReturnSubtitles(string str)
        {
            switch (str)
            {
                case "message1":
                    return new Dictionary<double, string>
                        {
                            { 5.0, "We did not know from where the black pyramid had come," },
                            { 8.5, "only that it radiated," },
                            { 10.6, "kept us warm without fire," },
                            { 13.0, "gave us love without demand." },
                            { 16.2, "Everyone in the village felt the voice of the pyramid as a fluttering in their heart," },
                            { 21.4, "softly at first," },
                            { 23.2, "stronger each passing day," },
                            { 25.9, "until it became a triumphant choir that filled us every moment." },
                            { 31.1, "We paid no mind to the gentle stinging of our eyes," },
                            { 34.8, "or the small blisters that would appear on the skin of our arms." },
                            { 38.74, "These pains were unimportant." },
                            { 41.2, "The song of the pyramid had rendered them so." },
                            { 48.065, "" },
                        };
                case "message2":
                    return new Dictionary<double, string>
                        {
                            { 3.27, "We spent months in the pyramid's great shadow," },
                            { 6.6, "not foraging or sculpting or scavenging as we always had," },
                            { 11.0, "simply basking in the warmth and comfort it gave us," },
                            { 14.6, "letting the skin peel on our arms and our legs," },
                            { 18.0, "smiling at the sky as we grew weak and complacent." },
                            { 22.45, "We did not hunger," },
                            { 24.0, "nor did we thirst." },
                            { 26.2, "When the sun would set and the elders would light fires by which to see," },
                            { 30.0, "I would hear them joking that the pyramid was..." },
                            { 32.5, "like a new mother," },
                            { 34.1, "brought up from sand to cradle us." },
                            { 37.37, "These words unnerved me." },
                            { 39.67, "My mother," },
                            { 40.1, "my *real* mother," },
                            { 42.69, "was always beside me," },
                            { 45.48, "and her skin was peeling faster than theirs." },
                            { 50.233, "" },
                        };
                case "message3":
                    return new Dictionary<double, string>
                        {
                            { 3.9, "Six of us went to bed one night." },
                            { 6.95, "When we woke the next morning, we were five." },
                            { 10.6, "A new monument, stark and titanic, and made from the same spit-black stone which composed the pyramid," },
                            { 18.6, "had grown up from the desert floor." },
                            { 21.94, "No-one spoke at all that day." },
                            { 25.1, "My mother's skin was crisp and red," },
                            { 28.2, "and she no longer had the strength to walk." },
                            { 31.63, "I brought her water and bread when I could stand the pain in my eyes for long enough to see." },
                            { 37.0, "Five of us went to bed that night." },
                            { 39.4, "When we woke the next morning," },
                            { 41.58, "we were four." },
                            { 48.065, "" },
                        };
                case "message4":
                    return new Dictionary<double, string>
                        {
                            { 3.8, "Each morning brought us a new structure in the desert," },
                            { 7.3, "a new empty hovel," },
                            { 9.3, "a new trail of footprints leading to the pyramid's great door." },
                            { 14.1, "Those of us who remained would go to the pyramid," },
                            { 16.8, "stare at the door for long hours," },
                            { 18.98, "pushing our hands and shoulders against it," },
                            { 21.8, "but it would not move." },
                            { 24.0, "Some nights I dreamed of the sound of grinding stone," },
                            { 27.96, "and shuffling footsteps," },
                            { 29.7, "and an unbearable light," },
                            { 32.8, "and if ever I woke I would see nothing." },
                            { 35.97, "\"There is nothing to be afraid of,\"" },
                            { 37.9, "my mother would lie without prompting," },
                            { 40.32, "while cloudy fluid went through her eyes." },
                            { 43.47, "She knew what there was to be afraid of." },
                            { 46.56, "What she meant was that there was nothing we could do." },
                            { 51.331, "" },
                        };
                case "message5":
                    return new Dictionary<double, string>
                        {
                            { 4.1, "My mother and I woke on the penultimate morning to find that we were all that remained." },
                            { 9.43, "The hot sand was singing through the empty doors of our village." },
                            { 14.48, "I asked her what the word \"oblation\" meant." },
                            { 18.1, "Though she lacked strength, her head snapped toward me, and she stared." },
                            { 23.6, "Her eyes were yellow and roomy, but I could see her fear." },
                            { 28.55, "She asked me where I had heard the word." },
                            { 31.43, "In truth, I had not heard it at all." },
                            { 34.56, "I had woken with it imprinted upon the backs of my eyelids," },
                            { 38.36, "written on the walls of my veins," },
                            { 40.828, "a sudden clandestine addition," },
                            { 43.55, "like the bite of a nocturnal insect." },
                            { 46.71, "I knew that the pyramid had put it there," },
                            { 49.4, "as a warning," },
                            { 50.8, "perhaps an edict." },
                            { 53.12, "I never answered her, so she never answered me." },
                            { 57.0, "They were the last words I ever heard my mother speak." },
                            { 60.75, "The next morning, she was gone." },
                            { 63.159, "Nothing left of her but a trail of dragging footprints in the sand, leading to the pyramid's closed door." },
                            { 71.94, "" },
                        };
                case "message6":
                    return new Dictionary<double, string>
                        {
                            { 3.6, "I spent what I knew was my final day walking to each of the black structures," },
                            { 8.55, "pressing my hands and lips against their cold stone," },
                            { 12.29, "wishing them goodbye." },
                            { 14.79, "They gave off no warmth," },
                            { 16.56, "and there was nothing in their angles to tell me who they had been." },
                            { 20.49, "I could not tell which one was my mother;" },
                            { 23.1, "the pyramid's incessant singing had clouded my memory." },
                            { 26.899, "I was nearly blind from the pain in my eyes." },
                            { 30.859, "I told each one that I loved them." },
                            { 34.0, "Then, I returned to the village to wait." },
                            { 37.695, "" },
                        };
                case "message7":
                    return new Dictionary<double, string>
                        {
                            { 3.64, "Night has fallen like a stone." },
                            { 6.43, "The doors open." },
                            { 9.36, "I go there now, because there is nowhere else in the desert for me to go." },
                            { 14.1, "My legs obey the will of the pyramid, and the rest of my body is soon to follow." },
                            { 21.3, "I'm afraid because I do not know what shape I will take." },
                            { 25.4, "I wonder if my stone skin will blister in the desert sun," },
                            { 29.8, "if the pain of the hot sand will still rise up through my foundations," },
                            { 35.0, "and if these things will become a comfort," },
                            { 37.43, "or a curse." },
                            { 40.699, "" },
                        };
                case "message8":
                    return new Dictionary<double, string>
                        {
                            { 3.57, "I'm afraid of having no voice and no eyes." },
                            { 7.58, "I'm afraid of the darkness inside the pyramid itself." },
                            { 12.56, "I'm afraid of so many things." },
                            { 18.573, "" },
                        };
                case "message9":
                    return new Dictionary<double, string>
                        {
                            { 0.487, "I wish so badly that my mother were here." },
                            { 8.725, "" },
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
