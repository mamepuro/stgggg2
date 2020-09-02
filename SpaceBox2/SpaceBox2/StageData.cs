using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceBox2
{
    class StageData
    {
        public int StageNumber { get; set; }
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
        /// <summary>
        /// 敵の隊列パターン
        /// </summary>
        public string Platoon { get; set; }
    }
}
