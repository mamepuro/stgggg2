using System;
using Altseed2;
using System.Collections.Generic;

namespace SpaceBox2
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize("SpaceBox", 960, 720);
            Player player = new Player(new Vector2F(100,100));
            Engine.AddNode(player);
            while(Engine.DoEvents())
            {
                Engine.Update();
                if(Engine.Keyboard.GetKeyState(Key.Escape) == ButtonState.Push)
                {
                    break;
                }
            }
            Engine.Terminate();
        }
    }
}
