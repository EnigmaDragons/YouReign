using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using YouReign.UIElements;

namespace YouReign.Scenes
{
    public sealed class ThroneRoomScene : IScene
    {
        private TheUI _theUi;

        public void Init()
        {
            _theUi = new TheUI("throneroom", "panickedadvisor");
        }

        public void Update(TimeSpan delta)
        {
            _theUi.SetCharacter("Tim");
        }

        public void Draw()
        {
            _theUi.Draw(new Transform());
        }
    }
}
