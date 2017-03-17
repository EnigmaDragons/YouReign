using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;
using YouReign.NewFolder1;
using MonoDragons.Core.PhysicsEngine;

namespace YouReign.Scenes
{
    public sealed class ThroneRoomScene : IScene
    {
        private readonly Vector2 _charPosition = new Vector2(-300, 28);
        private DialogueMessage message;

        public void Init()
        {
            message = new DialogueMessage(
                "This is a really really really really really really really really really really really really really really long line."
                , "Images/Characters/panickedadvisor");
        }

        public void Update(TimeSpan delta)
        {
            message.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCentered("Images/Backgrounds/throneroom", new Vector2(1600, 900));
            UI.DrawCenteredWithOffset("Images/UI/portraitbackground", new Vector2(240, 320), _charPosition);
            //UI.DrawCenteredWithOffset("Images/Characters/panickedadvisor", new Vector2(175, 240), _charPosition);
            UI.DrawCenteredWithOffset("Images/UI/dialoguebox", new Vector2(0, 310));
            message.Draw(new Transform());
        }
    }
}
