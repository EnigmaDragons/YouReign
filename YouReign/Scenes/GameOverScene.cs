using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.UserInterface;

namespace YouReign.Scenes
{
    public class GameOverScene : IScene
    {
        public void Init()
        {
            Input.ClearBindings();
            Input.On(Control.Start, () => World.NavigateToScene("MainMenu"));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            UI.DrawCentered("Images/Backgrounds/youdied", new Vector2(1600, 900));
            World.DrawRectangle(new Rectangle(0, 0, 1600, 900), Color.FromNonPremultiplied(0, 0, 0, 200));
            UI.DrawCenteredWithOffset("Images/Text/youdiedtext", new Vector2(0, -300));
            UI.DrawCenteredWithOffset("Images/MainMenu/clicktoreturn", new Vector2(0, 400));
        }
    }
}
