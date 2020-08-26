using System;
using Altseed2;

namespace SpaceBox2
{
    public class PlayerBullet:CollidableObject
    {
        public Vector2F _moveVelocity;
        public Player _playerInfo;
        public PlayerBullet(MainNode mainNode, Vector2F position, Vector2F moveVelocity, Player player, float chargeTime = 1.0f)
            :base(mainNode, position)
        {
            Texture = Texture2D.LoadStrict("Resources/EnemyBullet.png");
           //Position = position;
            _moveVelocity = moveVelocity;
            collider.Size = Texture.Size;
            _playerInfo = player;
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
                _playerInfo.playerBullets.Dequeue();
            }
        }
        protected override void RemoveMyselfIfOutOfWindow()
        {
            var halfSize = Texture.Size / 2;
            if (Position.X < -halfSize.X
                || Position.X > Engine.WindowSize.X + halfSize.X
                || Position.Y < -halfSize.Y
                || Position.Y > Engine.WindowSize.Y + halfSize.Y)
            {
                Parent?.RemoveChildNode(this);
                _playerInfo.playerBullets.Dequeue();
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
