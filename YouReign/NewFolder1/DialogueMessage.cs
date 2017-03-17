using Microsoft.Xna.Framework.Audio;
using MonoDragons.Core.Engine;
using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;

namespace YouReign.NewFolder1
{
    public class DialogueMessage : IVisualAutomaton
    {
        private readonly string _message;
        private readonly string _imageName;
        private readonly string _soundEffectName;

        private bool _hasStarted = false;

        public DialogueMessage(string message, string imageName = "none", string soundEffectName = "none")
        {
            _message = message;
            _imageName = imageName;
            _soundEffectName = soundEffectName;
        }

        public void Update(TimeSpan delta)
        {
            if (!_hasStarted)
                World.PlaySound(_soundEffectName);
            _hasStarted = true;


            throw new NotImplementedException();
        }

        public void Draw(Transform parentTransform)
        {
            UI.DrawCenteredWithOffset(_imageName, new Vector2(0, -125));
        }
    }
}
