using System;
using System.Collections.Generic;
using System.Linq;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using YouReign.NewFolder1;
using YouReign.Story;
using YouReign.UIElements;

namespace YouReign.Scenes
{
    public class StoryScene : IScene
    {
        private TheUI _theUi;

        private Option _currentOption;
        private Message _currentMessage;

        public void Init()
        {
            _currentOption = IntroOption();
            Input.ClearBindings();
            Input.On(Control.Start, AdvanceStory);
            _theUi = new TheUI("throneroom", "none");
        }

        private void AdvanceStory()
        {
            if (_currentOption.ShouldGetNextMessage())
                _currentMessage = _currentOption.GetNextMessage();
            else if (_currentOption.DidTheKingDie())
            {
                World.NavigateToScene("GameOver");
            }
            else
            {
                //TODO: fix this shit
                _currentOption = _currentOption.NextOptions.First();
                _currentMessage = new Message(_currentOption.Message);
            }
        }

        public void Update(TimeSpan delta)
        {
            if (_currentMessage.HasStarted)
                return;
            World.PlaySound(_currentMessage.SoundEffectName);
            _currentMessage.HasStarted = true;
        }

        public void Draw()
        {
            _theUi.Draw(new Transform());
            _theUi.SetCharacter(_currentMessage.ImageName);
            _theUi.SetBackground(_currentOption.Background);
            _theUi.DisplayDialogue(_currentMessage.Text);
        }

        private static Option IntroOption()
        {
            return new Option("Start", "throneroom", IntroMessages(), new List<Option>
            {
                Option1()
            });
        }

        private static List<Message> IntroMessages()
        {
            return new List<Message>
            {
                new Message("You rule a prosperous kingdom"),
                new Message("Your magicians study away"),
                new Message("The markets are buzzing"),
                new Message("The farms are healthy"),
                new Message("Your advisor hurries in looking extremely panicked", "panickedadvisor", "meteorcrash"),
                new Message("\"Sire a glowing rock from the sky has fallen right in the kingdom's garden!\"", "panickedadvisor"),
                new Message("\"And it's in the shape of an apple with a bite out of it\"", "panickedadvisor")
            };
        }

        private static Option Option1()
        {
            return new Option("Claim there is treasure in the center of the rock, and anyone can claim it!", "glowingrock", Option1Messages(), new List<Option>
            {
                Option11()
            });
        }

        public static List<Message> Option1Messages()
        {
            return new List<Message>
            {
                new Message("Your advisor quickly leaves to spread the word"),
                new Message("All the town folk stopped what they were doing to come and try to break this rock."),
                new Message("They tried to break it by throwing smaller rocks, small animals, and even some tried to bribe the rock to open up with gits of food."),
                new Message("The advisor rushes up to you", "panickedadvisor", "rockbreaks"),
                new Message("\"Sire it seems the rock had something strange inside.\"", "panickedadvisor"),
                new Message("\"The townsfolk has start to develop purple spots on their skin and are all dancing around the broken rock\"", "panickedadvisor")
            };
        }

        private static Option Option11()
        {
            return new Option("Kill them all, They are infected!", "throneroom", Option11Messages(), new List<Option>
            {
                Option111()
            });
        }

        private static List<Message> Option11Messages()
        {
            return new List<Message>
            {
                new Message("Your advisor runs in and locks the door", "panickedadvisor", "clashingswords"),
                new Message("\"Sire they stopped dancing and all the guards now have purpole spots too!\""),
                new Message("\"The mages with the purple spots have begun forming a magical circle of some sort!\"")
            };
        }

        private static Option Option111()
        {
            return new Option("Burst forth from your castle shouting \"1v1 me scrubs!\" as you charge them with your sword drawn!", "darkgarden", Option111Messages());
        }

        private static List<Message> Option111Messages()
        {
            return new List<Message>
            {
                new Message("You most assuredly would have beat them if it were not for how unkept this garden was"),
                new Message("You trip on the many vines"),
                new Message("They proceed to pelt you with potato's until you die"),
                new Message("Your kingdom falls to ruin as the cult of the rock spreads throughout your land")
            };
        }
    }
}
