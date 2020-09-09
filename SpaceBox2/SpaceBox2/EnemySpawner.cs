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
        int _numberOFEnemy;
        int _count;
        //mainNodeへの参照
        MainNode _mainNode;
        //stageDataへの参照
        StageData _stageDatas;
        public EnemySpawner(MainNode mainNode, int numberOfEnemy, int intervalCount, StageData stageData , string EnemyClassName)
        {
            doSpawn = true;
            isInterval = false;
            _mainNode = mainNode;
            _numberOFEnemy = numberOfEnemy;
            _intervalCount = intervalCount;
            _stageDatas = stageData;
            _count = 0;
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
            }else
            {
                _count++;
            }
        }
        public void SpawnEnemy(string enemyName)
        {

        }
    }
}
