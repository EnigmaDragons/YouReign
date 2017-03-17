using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;
using YouReign.NewFolder1;
using MonoDragons.Core.PhysicsEngine;
using YouReign.UIElements;
using Microsoft.Xna.Framework;

namespace YouReign.Scenes
{
    public sealed class ThroneRoomScene : IScene
    {
        private readonly Vector2 _charPosition = new Vector2(-300, 28);
        private DialogueMessage message;        
	    private TheUI _theUi;

        public void Init()
        {
            _theUi = new TheUI("throneroom", "panickedadvisor");
            message = new DialogueMessage(
                "This is a really really really really really really really really really really really really really really long line.",
                _theUi, "panickedadvisor", "none");
        }

        public void Update(TimeSpan delta)
        {
            message.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCentered("Images/Backgrounds/throneroom", new Vector2(1600, 900));
            UI.DrawCenteredWithOffset("Images/UI/portraitbackground", new Vector2(240, 320), _charPosition);
            UI.DrawCenteredWithOffset("Images/UI/dialoguebox", new Vector2(0, 310));
            
            _theUi.Draw(new Transform());
            message.Draw(new Transform());


        }
    }
}
