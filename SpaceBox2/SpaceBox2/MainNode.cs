using System;
using Altseed2;

namespace SpaceBox2
{
    public class MainNode:Node
    {
        private Node characterNode = new Node();
        private Player player;
        private int stageNumber;
        private StageData[] stageDatas;
        public MainNode()
        {
        }
        protected override void OnAdded()
        {
            base.OnAdded();
            AddChildNode(characterNode);
            var uiNode = new Node();
            AddChildNode(uiNode);
            player = new Player(this, new Vector2F(300, 300));
            characterNode.AddChildNode(player);
            //NomalEnemy nomalEnemy = new NomalEnemy(this, new Vector2F(500, 250), new Vector2F(0.0f, 0.0f), player);
            FreezeBulletEnemy freezeBulletEnemy = new FreezeBulletEnemy(this, new Vector2F(500, 250), new Vector2F(0.0f, 0.0f), player);
            characterNode.AddChildNode(freezeBulletEnemy);
            stageNumber = 1;
            stageDatas = ReadJsonFile("StageConfig/Stage1.json");
            //デバック用
            foreach(var item in stageDatas)
            {
                Console.WriteLine($"StageNumber = {item.StageNumber}");
                Console.WriteLine($"PositionX= {item.PositionX}");
                Console.WriteLine($"PositionY={item.PositionY}");
                Console.WriteLine($"SpawnCounter={item.SpawnCounter}");
                Console.WriteLine($"Platoon={item.Platoon}");
            }
        }
        private StageData[] ReadJsonFile(string filePath)
        {
            return Json.ReadJsonToArarry(filePath, "utf-8");
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            //デバック用
            //Console.WriteLine(player.playerBullets.Count);
        }
        protected override void OnRemoved()
        {
            base.OnRemoved();
            CollidableObject.objectCollection.Clear();
        }
    }
}
