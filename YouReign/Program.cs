﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.EngimaDragons;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Navigation;
using YouReign.Scenes;

namespace YouReign
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MainGame("Logo", new ScreenSettings(1600, 900, false), CreateSceneFactory(), CreateKeyboardController()))
                game.Run();
        }

        private static IController CreateKeyboardController()
        {
            return new KeyboardController(new Map<Keys, Control>
            {
                { Keys.Enter, Control.Start },
                { Keys.S, Control.Select }
            });
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(new Dictionary<string, Func<IScene>>
            {
                { "Logo", () => new FadingInScene(new LogoScene()) },
                { "MainMenu", () => new FadingInScene(new MainMenuScene()) },
                { "TimTest", () => new TimTestScene() },
                { "ThroneRoom", () => new FadingInScene(new ThroneRoomScene()) },
                { "DarkGarden", () => new FadingInScene(new DarkGardenScene()) },
                { "StoryScene", () => new FadingInScene(new StoryScene()) },
                { "GameOver", () => new FadingInScene(new GameOverScene()) },
            });
        }
    }
#endif
}
