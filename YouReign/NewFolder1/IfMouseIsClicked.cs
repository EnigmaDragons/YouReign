using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouReign.NewFolder1
{
    class IfMouseIsClicked
    {
        private MouseState prevState;

        public bool Evaluate()
        {
            var x = MouseIsOnScreen() && Mouse.GetState().LeftButton == ButtonState.Released && prevState.LeftButton == ButtonState.Pressed;
            prevState = Mouse.GetState();
            return x;
        }

        private static bool MouseIsOnScreen()
        {
            var mousePos = Mouse.GetState().Position;
            return mousePos.X >= 0 && mousePos.X <= Hack.TheGame.GraphicsDevice.Viewport.Width
                && mousePos.Y >= 0 && mousePos.Y <= Hack.TheGame.GraphicsDevice.Viewport.Height;
        }
    }
}
