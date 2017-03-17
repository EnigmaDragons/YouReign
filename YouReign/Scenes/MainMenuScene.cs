using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.UserInterface;

namespace YouReign.Scenes
{
    public class MainMenuScene : IScene
    {
        public void Init()
        {
            Input.ClearBindings();
            Input.On(Control.Start, () => World.NavigateToScene("CyberRoom1"));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            UI.DrawCentered("Images/MainMenu/background", new Vector2(1200, 800));
            World.DrawRectangle(new Rectangle(0, 0, 1200, 960), Color.FromNonPremultiplied(0, 0, 0, 225));
            UI.DrawCenteredWithOffset("Images/MainMenu/title", new Vector2(0, -140));
            UI.DrawCenteredWithOffset("Images/MainMenu/pressenter", new Vector2(0, 200));
        }
    }
}
