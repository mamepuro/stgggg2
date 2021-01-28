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
            //Player player = new Player(new Vector2F(100,100));
            //Engine.AddNode(player);
            //NomalEnemy nomalEnemy = new NomalEnemy(new Vector2F(200, 100), new Vector2F(0.0f, 0.0f), player);
            //Engine.AddNode(nomalEnemy);
            MainNode mainNode = new MainNode();
            Engine.AddNode(mainNode);
            // 音ファイルを読み込みます。
            // 効果音の場合は第2引数を true に設定して事前にファイルを解凍することが推奨されている。

            while (Engine.DoEvents())
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
