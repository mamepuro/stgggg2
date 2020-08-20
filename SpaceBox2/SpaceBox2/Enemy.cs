using System;
using Altseed2;

namespace SpaceBox2
{
    public class Enemy:SpriteNode
    {
        Vector2F _moveVelocity;
        //プレイヤーへの参照
        public Player _playerInfo;
        public Enemy(Vector2F position, Vector2F moveVelocity, Player playerInfo)
        {
            _moveVelocity = moveVelocity;
            _playerInfo = playerInfo;
            Texture = Texture2D.LoadStrict("Resources/Enemy.png");
            Position = position;
        }
        public virtual void Move()
        {
        }
        //public Enemy(asd.Vector2DF position, Player player)
        //{
        //    Texture = asd.Engine.Graphics.CreateTexture2D("Resources/Enemy.png");
        //    //position = new asd.Vector2DF(650.0f, 330.0f);
        //    Position = position;
        //    CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
        //    playerInfo = player;
        //    radius = Texture.Size.X / 2.0f;
        //}
        //public virtual void Move()
        //{
        //}
        //public void DisposeEnemy()
        //{
        //    if (Position.X > (asd.Engine.WindowSize.X + Texture.Size.X / 2.0f) || Position.X < -Texture.Size.X / 2.0f || Position.Y > (asd.Engine.WindowSize.Y + Texture.Size.Y / 2.0f) || Position.Y < -Texture.Size.Y / 2.0f)
        //    {
        //        Dispose();
        //    }
        //}
        //public override void OnCollided(CollidableObject collidableObject)
        //{
        //    base.OnCollided(collidableObject);
        //    Dispose();
        //}
        //public override void CollideWithObject(CollidableObject collidableObject)
        //{
        //    base.CollideWithObject(collidableObject);
        //    if (collidableObject == null)
        //    {
        //        return;
        //    }
        //    if (collidableObject is PlayerBullet)
        //    {
        //        CollidableObject playerbullet = collidableObject;
        //        if (IsCollide(playerbullet))
        //        {
        //            OnCollided(playerbullet);
        //            playerbullet.OnCollided(this);
        //        }
        //    }
        //}
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
        //    DisposeEnemy();
        //    CheckCollision();
        }
    }
}
