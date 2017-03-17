using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YouReign.NewFolder1
{
    public class ChatBox : IVisualAutomaton
    {
        private int maxLineWidth;
        private SpriteFont spriteFont;
        private double MillisToCharacter = 35;
        private string currentlyDisplayedMessage;
        private string messageToDisplay;
        private long totalMessageTime;

        public ChatBox(string message, int maxLineWidth, SpriteFont spriteFont)
        {
            this.spriteFont = spriteFont;
            this.maxLineWidth = maxLineWidth;
            currentlyDisplayedMessage = "";
            messageToDisplay = WrapText(message);
        }

        public void ShowMessage(string message)
        {
            currentlyDisplayedMessage = "";
            messageToDisplay = WrapText(message);
            totalMessageTime = 0;
        }

        public void Update(TimeSpan deltaMillis)
        {
            totalMessageTime += deltaMillis.Milliseconds;
            var length = (int)((double)totalMessageTime / (double)MillisToCharacter);
            length = messageToDisplay.Length < length ? messageToDisplay.Length : length;
            currentlyDisplayedMessage = messageToDisplay.Substring(0, length);
        }

        public void Draw(Transform parentTransform)
        {
            UI.DrawText(currentlyDisplayedMessage, parentTransform.Location, Color.White);
        }

        private string WrapText(string text)
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
