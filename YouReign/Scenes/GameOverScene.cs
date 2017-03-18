using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.UserInterface;
using YouReign.NewFolder1;

namespace YouReign.Scenes
{
    public class GameOverScene : IScene
    {
        private readonly MouseIsClicked MouseIsClicked = new MouseIsClicked();

        public void Init()
        {
            Input.ClearBindings();
            Input.On(Control.Start, () => World.NavigateToScene("MainMenu"));
        }

        public void Update(TimeSpan delta)
        {
            if (MouseIsClicked.Evaluate())
                World.NavigateToScene("MainMenu");
        }

        public void Draw()
        {
            UI.DrawCentered("Images/Backgrounds/youdied", new Vector2(1600, 900));
            World.DrawRectangle(new Rectangle(0, 0, 1600, 900), Color.FromNonPremultiplied(0, 0, 0, 180));
            UI.DrawCenteredWithOffset("Images/Text/youdiedtext", new Vector2(0, -300));
            UI.DrawCenteredWithOffset("Images/MainMenu/clicktoreturn", new Vector2(0, 380));
        }
    }
}
