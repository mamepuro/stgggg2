using System;
using System.Collections.Generic;
using Altseed2;

namespace SpaceBox2
{
    public class MainNode:Node
    {
        public Node characterNode = new Node();
        private Player player;
        private int stageNumber;
        /// <summary>
        /// 読み込んだステージ情報
        /// </summary>
        private StageData[] stageDatas;
        /// <summary>
        /// 敵出現等を管理するカウンタ
        /// </summary>
        public int stageCount;
        /// <summary>
        /// 読み込んだjsonファイル内の配列の数
        /// </summary>
        private int NumberOfJsonElements;
        /// <summary>
        /// 実行中のJsonの配列のインデックス
        /// </summary>
        private int index;
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
            stageNumber = 1;
            stageCount = 0;
            index = 0;
            //jsonの読み込みを行う
            stageDatas = ReadJsonFile("StageConfig/Stage"+stageNumber.ToString()+".json");
            NumberOfJsonElements = stageDatas.Length;
            Console.WriteLine(NumberOfJsonElements);
            //デバック用
                Console.WriteLine($"StageNumber = {stageDatas[index].NumberOfEnemies}");
        }
        private StageData[] ReadJsonFile(string filePath)
        {
            return Json.ReadJsonToArarry(filePath, "utf-8");
        }
        private void SpawnEnemy(int spawnCount)
        {
            if(stageDatas[index].SpawnCounter == spawnCount)
            {
                EnemySpawner enemySpawner = new EnemySpawner(this, stageDatas[index].NumberOfEnemies, 30, stageDatas[index], "dammy", player);
                AddChildNode(enemySpawner);
                //WeavingEnemy weavingEnemy = new WeavingEnemy(this, new Vector2F(stageDatas[index].PositionX, stageDatas[index].PositionY), new Vector2F(-3.0f, 0.0f), player);
                //characterNode.AddChildNode(weavingEnemy);
                if (stageDatas.Length - 1 > index)
                {
                    index++;
                }
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            stageCount++;
            SpawnEnemy(stageCount);
            //デバック用
            Console.WriteLine(stageCount);
        }
        protected override void OnRemoved()
        {
            base.OnRemoved();
            CollidableObject.objectCollection.Clear();
        }
    }
}
