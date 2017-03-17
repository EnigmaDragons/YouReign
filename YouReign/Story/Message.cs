using System.Text;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.UI;

namespace YouReign.Story
{
    public class Message
    {
        public string Text { get; }
        public string ImageName { get; }
        public string SoundEffectName { get; }
        public bool HasStarted { get; set; } = true;

        public Message(string message, string imageName = "none", string soundEffectName = "none")
        {
            Text = message;
            ImageName = imageName;
            SoundEffectName = soundEffectName;
        }
    }
}
