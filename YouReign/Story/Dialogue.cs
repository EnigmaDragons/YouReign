using System.Collections.Generic;
using YouReign.NewFolder1;

namespace YouReign.Story
{
    public static class Dialogue
    {
        public static List<DialogueMessage> Part1()
        {
            return new List<DialogueMessage>
            {
                new DialogueMessage("You rule a prosperous kingdom"),
                new DialogueMessage("Your magicians study away"),
                new DialogueMessage("The markets are buzzing"),
                new DialogueMessage("The farms are healthy"),
                new DialogueMessage("Your advisor hurries in looking extremely panicked", "panickedadvisor", "meteorcrash"),
                new DialogueMessage("\"Sire a glowing rock from the sky has fallen right in the kingdom's garden!\"", "panickedadvisor"),
                new DialogueMessage("\"And it's in the shape of an apple with a bite out of it\"", "panickedadvisor")
            };
        }

        public static List<DialogueMessage> Option1()
        {
            return new List<DialogueMessage>
            {
                new DialogueMessage("Your advisor quickly leaves to spread the word"),
                new DialogueMessage("All the town folk stopped what they were doing to come and try to break this rock."),
                new DialogueMessage("They tried to break it by throwing smaller rocks, small animals, and even some tried to bribe the rock to open up with gits of food."),
                new DialogueMessage("The advisor rushes up to you", "panickedadvisor", "rockbreaks"),
                new DialogueMessage("\"Sire it seems the rock had something strange inside.\"", "panickedadvisor"),
                new DialogueMessage("\"The townsfolk has start to develop purple spots on their skin and are all dancing around the broken rock\"", "panickedadvisor")
            };
        }


    }
}
