using MonoDragons.Core.Engine;
using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UI;
using YouReign.UIElements;

namespace YouReign.NewFolder1
{
    public class DialogueMessage : IVisualAutomaton
    {
        private ChatBox _chat;
        private readonly string _imageName;
        private readonly string _soundEffectName;
        private TheUI _TheUI;

        private bool _hasStarted = false;

        public DialogueMessage(string message, TheUI theUI, string imageName = "none", string soundEffectName = "none")
        {
            _TheUI = theUI;
            _chat = new ChatBox(message, 850, DefaultFont.Font);
            _imageName = imageName;
            _soundEffectName = soundEffectName;
            if (_imageName != "none")
                _TheUI.SetCharacter(imageName);
        }

        public void Update(TimeSpan delta)
        {
            if (!_hasStarted && _soundEffectName != "none")
                World.PlaySound(_soundEffectName);
            _hasStarted = true;
            _chat.Update(delta);
        }

        public void Draw(Transform parentTransform)
        {
            _chat.Draw(new Transform());
        }
    }
}
