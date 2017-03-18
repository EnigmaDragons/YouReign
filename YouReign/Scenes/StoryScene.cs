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
        private long _millisSpentSelecting = 0;
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
            Input.On(Control.Select, SkipToDecision);
        }

        private void SkipToDecision()
        {
            if (_currentOption.DidTheKingDie())
            {
                World.NavigateToScene("GameOver");
            }
            else
            {
                _isSelecting = true;
                _theUi.DisplayOptions(_currentOption.NextOptions);
            }
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
                _millisSpentSelecting += delta.Milliseconds;
                if (_millisSpentSelecting >= 60000)
                {
                    _isSelecting = false;
                    _currentOption = Backstabbed();
                    _currentMessage = new Message(_currentOption.Message);
                    _theUi.SetBackground(_currentOption.Background);
                    _theUi.DisplayDialogue(_currentMessage.Text);
                    _theUi.SetCharacter(_currentMessage.ImageName);
                }
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
                    _selectedOptionIndex = 0;
                    _theUi.SetSelectedOptionIndex(_selectedOptionIndex);
                    _millisSpentSelecting = 0;
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
            return new Option("Start, press S to skip to next decision point.", "throneroom", IntroMessages(), new List<Option>
            {
                Option1(),
                Option2(),
                Option3()
            });
        }

        private static List<Message> IntroMessages()
        {
            return new List<Message>
            {
                new Message("You rule a prosperous kingdom."),
                new Message("Your magicians study away."),
                new Message("The markets are buzzing."),
                new Message("The farms are healthy."),
                new Message("Your advisor hurries in looking extremely panicked.", "panickedadvisor", "meteorcrash"),
                new Message("\"Sire a glowing rock from the sky has fallen right in the kingdom's garden!\"", "panickedadvisor"),
                new Message("\"And it's in the shape of an apple with a bite out of it\"", "panickedadvisor")
            };
        }

        private static Option Backstabbed()
        {
            return new Option("You took too long, candies gone, that's what happens!", "throneroom"/*TODO*/, BackstabbedMessages());
        }

        private static List<Message> BackstabbedMessages()
        {
            return new List<Message>
            {
            };
        }

        #region Opt1
        private static Option Option1()
        {
            return new Option("Claim there is treasure in the center of the rock, and anyone can claim it!", "throneroom", Option1Messages(), new List<Option>
            {
                Option11(),
                Option13()
            });
        }

        public static List<Message> Option1Messages()
        {
            return new List<Message>
            {
                new Message("Your advisor quickly leaves to spread the word."),
                new Message("All the town folk stopped what they were doing to come and try to break this rock."),
                new Message("They tried to break it by throwing smaller rocks, small animals, and even some tried to bribe the rock to open up with gits of food."),
                new Message("The advisor rushes up to you.", "panickedadvisor", "rockbreaks"),
                new Message("\"Sire it seems the rock had something strange inside.\"", "panickedadvisor"),
                new Message("\"The townsfolk has start to develop purple spots on their skin and are all dancing around the broken rock.\"", "panickedadvisor")
            };
        }

        #region Opt1
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
                new Message("Your advisor runs in and locks the door.", "panickedadvisor", "clashingswords"),
                new Message("\"Sire they stopped dancing and all the guards now have purpole spots too!\""),
                new Message("\"The mages with the purple spots have begun forming a magical circle of some sort!\"")
            };
        }

        #region Opt1
        private static Option Option111()
        {
            return new Option("Burst forth from your castle shouting \"1v1 me scrubs!\" as you charge them with your sword drawn!", "darkgarden", Option111Messages());
        }

        private static List<Message> Option111Messages()
        {
            return new List<Message>
            {
                new Message("You most assuredly would have beat them if it were not for how unkept this garden was."),
                new Message("You trip on the many vines."),
                new Message("They proceed to pelt you with potato's until you die."),
                new Message("Your kingdom falls to ruin as the cult of the rock spreads throughout your land.")
            };
        }
        #endregion
        #endregion

        #region Opt3
        public static Option Option13()
        {
            return new Option("This is a joyous occasion, my people have never danced like this before. We shall celebrate this with a feast!", "throneroom"/*TODO*/, Option13Messages(), new List<Option>
            {
                Option131()
            });
        }

        public static List<Message> Option13Messages()
        {
            return new List<Message>
            {
                new Message("All the people join you in your throne room and your all having a good time."),
                new Message("You notice your skin gain purple spots but no worries all the cool kids have that these days"),
                new Message("You feel an immense desire to leave your castle to explore new places.")
            };
        }

        #region Opt1
        public static Option Option131()
        {
            return new Option("Resist the urge to explore, your home is the best place to be.", "throneroom"/*TODO*/, Option131Messages());
        }

        public static List<Message> Option131Messages()
        {
            return new List<Message>
            {
                new Message("Upon resisting the party stops, and all your subjects look towards you hostilly."),
                new Message("At some point you get the strange feeling you're not very welcome anymore."),
                new Message("It might be because the begin to crowd around you and beat you to death or could just be your making it up in your head.")
            };
        }
        #endregion
        #endregion
        #endregion

        #region Opt2
        private static Option Option2()
        {
            return new Option("Put up red tape all around the rock and let no none go near it!", "throneroom", Option2Message());
        }

        private static List<Message> Option2Message()
        {
            return new List<Message>
            {
                new Message("Your guards stand around the rock wearing dark sunglasses and glaring anyone down who so much as looks at the rock."),
                new Message("In the local tavern, news spread about a top-secret rock that has shown up in the garden."),
                new Message("The king must be planning on enslaving all of his people with this rock."),
                new Message("As soon as the mage guild started calling up their friends in the other towns the kingdom was in a buzz."),
                new Message("The mail girl comes in cheerily with three letters.", "cheerfulmailwoman"),
                new Message("She Opens the first letter."),
                new Message("\"From the lord of villagetown, master of diplomacy, slayer of the unreasonably large dragon, hoarder of shiny things, holder of too many titles... bob.\""),
                new Message("\"All my people are very upset over this secret monster that you are growing in your garden we demand it be thrown off a cliff.\""),
                new Message("She opens the second letter."),
                new Message("\"From Lord Guile\""),
                new Message("\"I know about your mind control rock and I would like to use it on my people as well, they constantly drive their carts around these beautiful roads which damages them and I want to put an end to it.\""),
                new Message("She opens the third letter."),
                new Message("\"From Lord Rajelikeeraleemotopricariousness\""),
                new Message("\"We must celebrate *hic* this glowing stone *hic* with a great feast and lots of drinking! *hic*\"")
            };
        }
        #endregion

        #region Opt3
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
                new Message("The mail girl comes in all cheery like.", "cheerfulmailwoman"),
                new Message("\"Your three lords, Rajelikeeraleemotopricariousness, guile, and bob, upon hearing you will reign forever have eagerily gathered up many of their subjects and are coming here to celebrate your health.\"", "cheerfulmailwoman")
            };
        }

        #region Opt1
        private static Option Option31()
        {
            return new Option("Open the gates and meet them in the square!", "opensquare", Option31Messages());
        }

        private static List<Message> Option31Messages()
        {
            return new List<Message>
            {
                new Message("As you make it to the square the gates are opened and you watch them enter!"),
                new Message("It's surprising how well armed all their subjects they brought with them are."),
                new Message("If you didn't know better you might think they were going to war."),
                new Message("They start to charge you as you realize they are in fact going to war."),
                new Message("You don't make very far before your pierced with a lot of weapons."),
                new Message("Guile manages to kill the other lords and rule ruthlessly in your stead.")
            };
        }
        #endregion
        #endregion
    }
}
