using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceBox2
{
    class FreezeBulletEnemy:Enemy
    {
        public Vector2F _bulletsMoveVelocity;
        public FreezeBulletEnemy(MainNode mainNode, Vector2F position, Vector2F moveVelocity, Player player)
            :base(mainNode,position,moveVelocity,player)
        {
            _bulletFireTimeSpan = 90;
        }
        public void FireFreezeBullet()
        {
            _bulletsMoveVelocity = (_playerInfo.Position - Position).Normal * 3.0f;
            FreezeBullet freezeBullet = new FreezeBullet(_mainNode, Position, _bulletsMoveVelocity);
            Engine.AddNode(freezeBullet);
        }
        public void JudgeFireFreezeBullet(int count)
        {
            if(count % _bulletFireTimeSpan == 0)
            {
                FireFreezeBullet();
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
            JudgeFireFreezeBullet(_count);
            _count++;
        }
    }
}
