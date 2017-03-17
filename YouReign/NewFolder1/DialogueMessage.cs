using Microsoft.Xna.Framework.Audio;
using MonoDragons.Core.Engine;
using System;
using System.Text;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YouReign.UIElements;

namespace YouReign.NewFolder1
{
    public class DialogueMessage : IAutomaton
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

        private string WrapText(SpriteFont spriteFont, string text)
        {
            var words = text.Split(' ');
            var sb = new StringBuilder();
            var lineWidth = 0f;
            var spaceWidth = spriteFont.MeasureString(" ").X;
            foreach (var word in words)
            {
                var size = spriteFont.MeasureString(word);
                if (lineWidth + size.X < maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }
            return sb.ToString();
        }
    }
}
