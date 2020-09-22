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
                EnemySpawner enemySpawner = new EnemySpawner(this, stageDatas[index].NumberOfEnemies, 30, stageDatas[index], stageDatas[index].EnemyName, player);
                AddChildNode(enemySpawner);
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
            Console.WriteLine(stageCount);
        }
        protected override void OnRemoved()
        {
            //デバック用
            base.OnRemoved();
            CollidableObject.objectCollection.Clear();
        }
    }
}
