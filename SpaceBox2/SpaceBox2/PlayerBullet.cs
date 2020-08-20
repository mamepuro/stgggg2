﻿using System;
using Altseed2;

namespace SpaceBox2
{
    public class PlayerBullet:SpriteNode
    {
        Vector2F _moveVelocity;
        public PlayerBullet(Vector2F position, Vector2F moveVelocity)
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
