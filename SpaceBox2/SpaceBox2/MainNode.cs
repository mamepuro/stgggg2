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
        /// <summary>
        /// 敵出現等を管理するカウンタ
        /// </summary>
        private int stageCount;
        /// <summary>
        /// 敵を出現させるかどうかのフラグ
        /// </summary>
        private bool doSpawn;
        /// <summary>
        /// 出現させた敵の数
        /// </summary>
        private int NumberOfSpawnedEnemy;
        /// <summary>
        /// 読み込んだjsonファイル内の配列の数
        /// </summary>
        private int NumberOfJsonElements;
        /// <summary>
        /// 実行中のJsonの配列のインデックス
        /// </summary>
        private int index;
        private bool isInterval;
        private int intervalCount;
        private int intervalCheckCount;
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
            doSpawn = false;
            isInterval = false;
            NumberOfSpawnedEnemy = 0;
            index = 0;
            intervalCount = 30;
            intervalCheckCount = 0;
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
                doSpawn = true;
            }
            if(doSpawn)
            {
                if(stageDatas[index].NumberOfEnemies <= NumberOfSpawnedEnemy)
                {
                    doSpawn = false;
                    NumberOfSpawnedEnemy = 0;
                    if(stageDatas.Length - 1 > index)
                    {
                        index++;
                    }
                }
                else if(!isInterval)
                {
                    NomalEnemy nomalEnemy = new NomalEnemy(this, new Vector2F(stageDatas[index].PositionX, stageDatas[index].PositionY), new Vector2F(-1.0f, 0.0f), player);
                    AddChildNode(nomalEnemy);
                    NumberOfSpawnedEnemy++;
                    isInterval = true;
                }
                intervalCheckCount++;
                if(intervalCheckCount >= intervalCount)
                {
                    isInterval = false;
                    intervalCheckCount = 0;
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
