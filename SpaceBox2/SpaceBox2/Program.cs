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
            NomalEnemy nomalEnemy = new NomalEnemy(new Vector2F(200, 100), new Vector2F(0.0f, 0.0f), player);
            Engine.AddNode(nomalEnemy);
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
