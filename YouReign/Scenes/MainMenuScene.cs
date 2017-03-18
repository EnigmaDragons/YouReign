using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.UserInterface;
using YouReign.NewFolder1;

namespace YouReign.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly MouseIsClicked MouseIsClicked = new MouseIsClicked();

        public void Init()
        {
            Input.ClearBindings();
            Input.On(Control.Start, () => World.NavigateToScene("StoryScene"));
        }

        public void Update(TimeSpan delta)
        {
            if (MouseIsClicked.Evaluate())
                World.NavigateToScene("StoryScene");
        }

        public void Draw()
        {
            UI.DrawCentered("Images/MainMenu/background", new Vector2(1600, 900));
            World.DrawRectangle(new Rectangle(0, 0, 1600, 900), Color.FromNonPremultiplied(0, 0, 0, 80));
            UI.DrawCenteredWithOffset("Images/MainMenu/youreignlogo", new Vector2(0, -260));
            UI.DrawCenteredWithOffset("Images/MainMenu/clicktostart", new Vector2(0, 400));
        }
    }
}
