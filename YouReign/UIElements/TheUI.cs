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

        private string _backgroundName;
        private string _charName;

        private readonly ChatBox _chatBox;

        private bool _isDisplayingOptions;
        private List<Option> _currentOptions;
        private int _selectedOptionIndex = -1;

        public TheUI(string backgroundName, string characterName)
        {
            _backgroundName = backgroundName;
            _charName = characterName;
            _chatBox = new ChatBox("", 795, DefaultFont.Font);
        }

        public bool IsMessageCompletelyDisplayed() => _chatBox.IsMessageCompletelyDisplayed();

        public void CompletelyDisplayMessage() => _chatBox.CompletelyDisplayMessage();

        public void DisplayOptions(List<Option> options)
        {
            _chatBox.ShowMessage("");
            _isDisplayingOptions = true;
            _currentOptions = options;
        }

        public void DisplayDialogue(string text)
        {
            _isDisplayingOptions = false;
            _selectedOptionIndex = -1;
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
            DrawCharacter();
            DrawDialogue();
            DrawOptions();
        }

        private void DrawOptions()
        {
            if (!_isDisplayingOptions) return;

            var x = 0;
            for (var y = 0; y < 480; y += 160)
            {
                var img = x == _selectedOptionIndex ? "Images/UI/optionbox-hover" : "Images/UI/optionbox";
                UI.DrawCenteredWithOffset(img, new Vector2(0, y));
                UI.DrawText(_currentOptions[x].Message, new Vector2(400, 450 + y - 15), Color.DarkGray);
                x++;
                if (_currentOptions.Count == x)
                    return;
            }
        }

        private void DrawCharacter()
        {
            if (_charName == "none" || _isDisplayingOptions) return;

            UI.DrawCenteredWithOffset("Images/UI/portraitbackground", new Vector2(240, 320), _charPosition);
            UI.DrawCenteredWithOffset($"Images/Characters/{_charName}", new Vector2(175, 240), _charPosition);
        }

        private void DrawDialogue()
        {
            if (_isDisplayingOptions) return;

            UI.DrawCenteredWithOffset("Images/UI/dialoguebox", new Vector2(0, 310));
            _chatBox.Draw(new Transform(new Vector2(400, 700)));
        }

        public void Update(TimeSpan delta)
        {
            _chatBox.Update(delta);
        }

        public void SetSelectedOptionIndex(int selectedOptionIndex)
        {
            _selectedOptionIndex = selectedOptionIndex;
        }
    }
}
