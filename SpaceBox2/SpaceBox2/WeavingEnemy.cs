using System;
using Altseed2;
using System.Collections.Generic;
using System.Text;

namespace SpaceBox2
{
    class WeavingEnemy:Enemy
    {
        public Vector2F _bulletsMoveVelocity;
        public WeavingEnemy(MainNode mainNode, Vector2F position, Vector2F moveVelocity, Player player)
            : base(mainNode, position, moveVelocity, player)
        {

        }
        protected override void Move()
        {
            Position += (_moveVelocity + new Vector2F(0, (float)Math.Sin((_count/ 5)/Math.PI) * 3));
        }
        public void Fire()
        {
            _bulletsMoveVelocity = (_playerInfo.Position - Position).Normal * 3.0f;
            EnemyBullet enemyBullet = new EnemyBullet(_mainNode, Position, _bulletsMoveVelocity);
            Engine.AddNode(enemyBullet);
        }
        public void JudgeFireBullet()
        {
            if (_count % 60 == 0)
            {
                Fire();
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            _count++;
            Move();
            JudgeFireBullet();
        }
    }
}
