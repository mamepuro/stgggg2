﻿using System;
using Altseed2;


namespace SpaceBox2
{
    public class NomalEnemy:Enemy
    {
        public Vector2F _bulletsMoveVelocity;
        public NomalEnemy(MainNode mainNode,Vector2F potision,  Vector2F moveVelociy, Player playerInfo)
            :base(mainNode,potision,moveVelociy,playerInfo)
        {
            _bulletFireTimeSpan = 90;
            _count = 0;
            Score = 100;
        }
        protected override void Move()
        {
            base.Move();
            Position += _moveVelocity;
        }
        public void Fire()
        {
            _bulletsMoveVelocity = (_playerInfo.Position - Position).Normal * 3.0f;
            EnemyBullet enemyBullet = new EnemyBullet(_mainNode,Position, _bulletsMoveVelocity);
            Parent.AddChildNode(enemyBullet);
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
