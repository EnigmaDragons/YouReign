using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        private readonly MouseIsClicked MouseIsClicked = new MouseIsClicked();
        private TheUI _theUi;

        private Option _currentOption;
        private Message _currentMessage;

        private int _selectedOptionIndex = 0;
        private bool _isSelecting = false;

        public void Init()
        {
            _theUi = new TheUI("throneroom", "none");
            _currentOption = IntroOption();
            _theUi.SetBackground(_currentOption.Background);
            _currentMessage = new Message(_currentOption.Message);
            _theUi.DisplayDialogue(_currentMessage.Text);
            _theUi.SetCharacter(_currentMessage.ImageName);
            Input.ClearBindings();
            Input.On(Control.Start, AdvanceStory);
        }

        private void AdvanceStory()
        {
            if (!_theUi.IsMessageCompletelyDisplayed())
            {
                _theUi.CompletelyDisplayMessage();
            }
            else if (_currentOption.ShouldGetNextMessage())
            {
                _currentMessage = _currentOption.GetNextMessage();
                _theUi.DisplayDialogue(_currentMessage.Text);
                _theUi.SetCharacter(_currentMessage.ImageName);
            }
            else if (_currentOption.DidTheKingDie())
            {
                World.NavigateToScene("GameOver");
            }
            else
            {
                _isSelecting = true;
                _theUi.DisplayOptions(_currentOption.NextOptions);
            }
        }

        public void Update(TimeSpan delta)
        {
            if (_isSelecting)
            {
                if (_currentOption.NextOptions.Count > 0 && Mouse.GetState().X > 300 && Mouse.GetState().X < 1300 && Mouse.GetState().Y > 375 && Mouse.GetState().Y < 525)
                    _selectedOptionIndex = 0;
                if (_currentOption.NextOptions.Count > 1 && Mouse.GetState().X > 300 && Mouse.GetState().X < 1300 && Mouse.GetState().Y > 535 && Mouse.GetState().Y < 685)
                    _selectedOptionIndex = 1;
                if (_currentOption.NextOptions.Count > 2 && Mouse.GetState().X > 300 && Mouse.GetState().X < 1300 && Mouse.GetState().Y > 695 && Mouse.GetState().Y < 845)
                    _selectedOptionIndex = 2;
                _theUi.SetSelectedOptionIndex(_selectedOptionIndex);
            }

            if (MouseIsClicked.Evaluate())
            {
                if (_isSelecting)
                {
                    _isSelecting = false;
                    _currentOption = _currentOption.NextOptions[_selectedOptionIndex];
                    _currentMessage = _currentOption.GetNextMessage();
                    _theUi.SetBackground(_currentOption.Background);
                    _theUi.DisplayDialogue(_currentMessage.Text);
                    _theUi.SetCharacter(_currentMessage.ImageName);
                }
                else
                {
                    AdvanceStory();
                }
            }

            _theUi.Update(delta);
            if (_currentMessage.HasStarted)
                return;
            World.PlaySound(_currentMessage.SoundEffectName);
            _currentMessage.HasStarted = true;
        }

        public void Draw()
        {
            _theUi.Draw(new Transform());
        }

        private static Option IntroOption()
        {
            return new Option("Start", "throneroom", IntroMessages(), new List<Option>
            {
                Option1(),
                Option3()
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
            return new Option("Claim there is treasure in the center of the rock, and anyone can claim it!", "throneroom", Option1Messages(), new List<Option>
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

        private static Option Option3()
        {
            return new Option("Claim that this rock is a sign from the gods that you are to reign forever!", "throneroom", Option3Messages(), new List<Option>
            {
                Option31()
            });
        }

        private static List<Message> Option3Messages()
        {
            return new List<Message>
            {
                new Message("You spread the news far and wide, I mean who who doesn't want to hear how great their king is!"),
                new Message("The mail girl comes in all cheery like", "cheerfulmailwoman"),
                new Message("\"Your three lords, Rajelikeeraleemotopricariousness, guile, and bob, upon hearing you will reign forever have eagerily gathered up many of their subjects and are coming here to celebrate your health\"", "cheerfulmailwoman")
            };
        }

        private static Option Option31()
        {
            return new Option("Open the gates and meet them in the square!", "opensquare", Option31Messages());
        }

        private static List<Message> Option31Messages()
        {
            return new List<Message>
            {
                new Message("As you make it to the square the gates are opened and you watch them enter!"),
                new Message("It's surprising how well armed all their subjects they brought with them are"),
                new Message("If you didn't know better you might think they were going to war"),
                new Message("They start to charge you as you realize they are in fact going to war"),
                new Message("You don't make very far before your pierced with a lot of weapons"),
                new Message("Guile manages to kill the other lords and rule ruthlessly in your stead")
            };
        }
    }
}
