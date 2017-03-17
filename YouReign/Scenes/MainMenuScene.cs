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
            Input.On(Control.Start, () => World.NavigateToScene("GameOver"));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            UI.DrawCentered("Images/MainMenu/background", new Vector2(1600, 900));
            World.DrawRectangle(new Rectangle(0, 0, 1600, 900), Color.FromNonPremultiplied(0, 0, 0, 50));
            //UI.DrawCenteredWithOffset("Images/MainMenu/title", new Vector2(0, -140));
            UI.DrawCenteredWithOffset("Images/MainMenu/clicktostart", new Vector2(0, 400));
        }
    }
}
