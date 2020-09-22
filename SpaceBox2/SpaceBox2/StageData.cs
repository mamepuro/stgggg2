using System;
using Altseed2;
using System.Collections.Generic;
using System.Text;

namespace SpaceBox2
{
    class StageData
    {
        /// <summary>
        /// ステージ開始後何フレーム目で敵を出現させるかを確認
        /// </summary>
        public int SpawnCounter { get; set; }
        /// <summary>
        /// 敵の出現するx座標
        /// </summary>
        public int PositionX { get; set; }
        /// <summary>
        /// 敵の出現するy座標
        /// </summary>
        public int PositionY { get; set; }
        public int MoveVelocityX { get; set; }
        /// <summary>
        /// 出現する敵の数
        /// </summary>
        public int NumberOfEnemies { get; set; }
        /// <summary>
        /// 敵の隊列パターン
        /// </summary>
        public string Platoon { get; set; }
        /// <summary>
        ///　出現する敵の名前
        /// </summary>
        public string EnemyName { get; set; }
    }
}
