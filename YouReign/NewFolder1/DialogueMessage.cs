using Microsoft.Xna.Framework.Audio;
using MonoDragons.Core.Engine;
using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;
using MonoDragons.Core.UI;

namespace YouReign.NewFolder1
{
    public class DialogueMessage : IVisualAutomaton
    {
        private ChatBox _chat;
        private readonly string _imageName;
        private readonly string _soundEffectName;

        private bool _hasStarted = false;

        public DialogueMessage(string message, string imageName = "none", string soundEffectName = "none")
        {
            _chat = new ChatBox(message, 850, DefaultFont.Font);
            _imageName = imageName;
            _soundEffectName = soundEffectName;
            
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
            _chat.Draw(new Transform(new Vector2(360,690), Rotation.Default, 1));
            if (_imageName != "none")
                UI.DrawCenteredWithOffset(_imageName, new Vector2(0, -125));
        }
    }
}
