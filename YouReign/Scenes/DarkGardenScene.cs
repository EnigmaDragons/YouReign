using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using YouReign.UIElements;

namespace YouReign.Scenes
{
    public sealed class DarkGardenScene : IScene
    {
        private TheUI _theUi;

        public void Init()
        {
            _theUi = new TheUI("darkgarden", "panickedadvisor");
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            _theUi.Draw(new Transform());
        }
    }
}
