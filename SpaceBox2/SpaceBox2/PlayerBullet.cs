using System;
using Altseed2;

namespace SpaceBox2
{
    public class PlayerBullet:CollidableObject
    {
        public Vector2F _moveVelocity;
        public PlayerBullet(MainNode mainNode, Vector2F position, Vector2F moveVelocity, float chargeTime = 1.0f)
            :base(mainNode, position)
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
            if(collidableObject is Enemy)
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
