using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using YouReign.NewFolder1;

namespace YouReign.Scenes
{
    public sealed class ThroneRoomScene : IScene
    {
        private readonly Vector2 _charPosition = new Vector2(-300, 28);

        private ChatBox _chatBox;

        public void Init()
        {
            _chatBox = new ChatBox("This is a sample message");
        }

        public void Update(TimeSpan delta)
        {
            _chatBox.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCentered("Images/Backgrounds/throneroom", new Vector2(1600, 900));
            UI.DrawCenteredWithOffset("Images/UI/portraitbackground", new Vector2(240, 320), _charPosition);
            UI.DrawCenteredWithOffset("Images/Characters/panickedadvisor", new Vector2(175, 240), _charPosition);
            UI.DrawCenteredWithOffset("Images/UI/dialoguebox", new Vector2(0, 310));
            _chatBox.Draw(new Transform(new Vector2(400, 700)));
        }
    }
}
