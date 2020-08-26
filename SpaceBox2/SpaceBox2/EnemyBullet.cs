using System;
using Altseed2;
using System.Collections.Generic;

namespace SpaceBox2
{
    public class EnemyBullet:CollidableObject
    {
        Vector2F _moveVelocity;
        public EnemyBullet(MainNode mainNode, Vector2F position, Vector2F moveVelocity)
            :base(mainNode,position)
        {
            Texture = Texture2D.LoadStrict("Resources/EnemyBullet.png");
            //Position = position;
            _moveVelocity = moveVelocity;
            collider.Size = Texture.Size;
        }
        public void Move()
        {
            Position += _moveVelocity;
        }

        protected override void OnCollide(CollidableObject collidableObject)
        {
            base.OnCollide(collidableObject);
            if(collidableObject is Player)
            {
                Parent.RemoveChildNode(this);
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
            RemoveMyselfIfOutOfWindow();
        }
    }
}
