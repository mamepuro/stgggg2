using System;
using Altseed2;


namespace SpaceBox2
{
    public class NomalEnemy:Enemy
    {
        public Vector2F _bulletsMoveVelocity;
        public NomalEnemy(Vector2F potision,  Vector2F moveVelociy, Player playerInfo)
            :base(potision,moveVelociy,playerInfo)
        {
            _bulletFireTimeSpen = 90;
            _count = 0;
        }
        public override void Move()
        {
            base.Move();
            Position += _moveVelocity;
        }
        public void Fire()
        {
            _bulletsMoveVelocity = (_playerInfo.Position - Position).Normal * 3.0f;
            EnemyBullet enemyBullet = new EnemyBullet(Position, _bulletsMoveVelocity);
            Engine.AddNode(enemyBullet);
        }
        public void JudgeFireBullet()
        {
            if(_count % 60 == 0)
            {
                Fire();
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
            JudgeFireBullet();
            _count++;
        }
    }
}
