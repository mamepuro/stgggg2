using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceBox2
{
    class FreezeBullet:CollidableObject
    {
        Vector2F _moveVelocity;
        public FreezeBullet(MainNode mainNode, Vector2F position, Vector2F moveVelocity)
            :base(mainNode, position)
        {
            _moveVelocity = moveVelocity;
            Texture = Texture2D.LoadStrict("Resources/FreezeBullet.png");
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
        }
    }
}
