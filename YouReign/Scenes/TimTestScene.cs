using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouReign.NewFolder1;

namespace YouReign.Scenes
{
    public class TimTestScene : IScene
    {
        private ChatBox x;

        public void Init()
        {
            Input.ClearBindings();
            x = new ChatBox("This is a test scene. Lot more text in this line and I am trying to see how fast this draws.");
        }

        public void Update(TimeSpan delta)
        {
            x.Update(delta);
        }

        public void Draw()
        {
            x.Draw(new Transform());
            //UI.DrawCentered("Images/MainMenu/background", new Vector2(1600, 900));
            //World.DrawRectangle(new Rectangle(0, 0, 1600, 900), Color.FromNonPremultiplied(0, 0, 0, 50));
            //UI.DrawCenteredWithOffset("Images/MainMenu/title", new Vector2(0, -140));
            //UI.DrawCenteredWithOffset("Images/MainMenu/pressenter", new Vector2(0, 400));
        }
    }
}
