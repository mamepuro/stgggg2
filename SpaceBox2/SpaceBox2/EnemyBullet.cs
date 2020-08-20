using System;
using Altseed2;
using System.Collections.Generic;

namespace SpaceBox2
{
    public class EnemyBullet:SpriteNode
    {
        Vector2F _moveVelocity;
        public EnemyBullet(Vector2F position, Vector2F moveVelocity)
        {
            Texture = Texture2D.LoadStrict("Resources/EnemyBullet.png");
            Position = position;
            _moveVelocity = moveVelocity;
        }
        public void Move()
        {
            Position += _moveVelocity;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
        }
    }
}
