using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using YouReign.NewFolder1;
using MonoDragons.Core.UI;
using YouReign.Story;

namespace YouReign.UIElements
{
    public class TheUI : IVisualAutomaton
    {
        private readonly Vector2 _charPosition = new Vector2(-300, 28);

        private string _backgroundName = "throneroom";
        private string _charName = "none";

        private ChatBox _chatBox;

        private bool _isDisplayingOptions;
        private List<Option> _currentOptions;

        public TheUI(string backgroundName, string characterName)
        {
            _backgroundName = backgroundName;
            _charName = characterName;
            _chatBox = new ChatBox("", 850, DefaultFont.Font);
        }

        public void DisplayOptions(List<Option> options)
        {
            _isDisplayingOptions = true;
            _currentOptions = options;
        }

        public void DisplayDialogue(string text)
        {
            _chatBox.ShowMessage(text);
        }

        public void SetCharacter(string characterName)
        {
            _charName = characterName;
        }

        public void SetBackground(string backgroundName)
        {
            _backgroundName = backgroundName;
        }

        public void Draw(Transform parentTransform)
        {
            UI.DrawCentered($"Images/Backgrounds/{_backgroundName}", new Vector2(1600, 900));
            if (_charName != "none")
            {
                UI.DrawCenteredWithOffset("Images/UI/portraitbackground", new Vector2(240, 320), _charPosition);
                UI.DrawCenteredWithOffset($"Images/Characters/{_charName}", new Vector2(175, 240), _charPosition);
            }
            UI.DrawCenteredWithOffset("Images/UI/dialoguebox", new Vector2(0, 310));
            _chatBox.Draw(new Transform(new Vector2(400, 700)));
        }

        public void Update(TimeSpan delta)
        {
            _chatBox.Update(delta);
        }
    }
}
