using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;

namespace YouReign.NewFolder1
{
    public class ChatBox : IVisualAutomaton
    {
        private double MillisToCharacter = 35;
        private string currentlyDisplayedMessage;
        private string messageToDisplay;
        private long totalMessageTime;

        public ChatBox(string message)
        {
            currentlyDisplayedMessage = "";
            messageToDisplay = message;
        }

        public void ShowMessage(string message)
        {
            currentlyDisplayedMessage = "";
            messageToDisplay = message;
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
            UI.DrawText(currentlyDisplayedMessage, parentTransform.Location, Color.Blue);
        }
    }
}
