using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace SpaceBox2
{
    /// <summary>
    /// MainNodeから敵のスポーン情報を受け取り、敵のスポーン処理を行うクラスです。
    /// </summary>
    class EnemySpawner:Node
    {
        /// <summary>
        /// 敵をスポーンさせるかを管理するフラグ
        /// </summary>
        bool doSpawn;
        /// <summary>
        /// インターバル中（連隊を出現させる途中かどうか）のフラグ
        /// </summary>
        bool isInterval;
        int spawnCount;
        /// <summary>
        /// インターバル時間を管理するカウンタ
        /// </summary>
        readonly int _intervalCount;
        /// <summary>
        /// 出現させる敵の数
        /// </summary>
        int _numberOfEnemy;
        int _count;
        //mainNodeへの参照
        MainNode _mainNode;
        //stageDataへの参照
        StageData _stageDatas;
        Player _player;
        public EnemySpawner(MainNode mainNode, int numberOfEnemy, int intervalCount, StageData stageData , string EnemyClassName, Player player)
        {
            isInterval = false;
            _mainNode = mainNode;
            _numberOfEnemy = numberOfEnemy;
            _intervalCount = intervalCount;
            _stageDatas = stageData;
            _count = 0;
            _player = player;
        }
        public void CheckSpawnEnemy(string enemyName)
        {
            if(_count > _intervalCount)
            {
                isInterval = false;
                _count = 0;
            }
            if(!isInterval)
            {
                SpawnEnemy(enemyName);
                isInterval = true;
                RemoveThisIfNumberOfEnemyIsZero(_numberOfEnemy);
            }else
            {
                _count++;
            }
        }
        public void SpawnEnemy(string enemyName)
        {
            WeavingEnemy weavingEnemy = new WeavingEnemy(_mainNode, new Vector2F(_stageDatas.PositionX, _stageDatas.PositionY), new Vector2F(-3.0f, 0.0f), _player);
            _mainNode.characterNode.AddChildNode(weavingEnemy);
            _numberOfEnemy--;
        }
        public void RemoveThisIfNumberOfEnemyIsZero(int enemyNumber)
        {
            if (enemyNumber <= 0)
            {
                Parent.RemoveChildNode(this);
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            CheckSpawnEnemy("dammy");
        }
    }
}
