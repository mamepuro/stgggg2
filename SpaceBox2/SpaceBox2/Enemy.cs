using System;
using Altseed2;

namespace SpaceBox2
{
    public class Enemy:CollidableObject
    {
        public Vector2F _moveVelocity;
        //プレイヤーへの参照
        public Player _playerInfo;
        protected int _bulletFireTimeSpan;
        protected int _count;
        public Enemy(MainNode mainNode,Vector2F position, Vector2F moveVelocity, Player playerInfo):base(mainNode, position)
        {
            _moveVelocity = moveVelocity;
            _playerInfo = playerInfo;
            Texture = Texture2D.LoadStrict("Resources/Enemy.png");
            doSurvey = true;
            collider.Size = Texture.Size;
        }
        protected virtual void Move()
        {
            Position += _moveVelocity;
        }
        protected override void OnCollide(CollidableObject collidableObject)
        {
            base.OnCollide(collidableObject);
            if(collidableObject is PlayerBullet)
            {
                Parent.RemoveChildNode(this);
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            RemoveMyselfIfOutOfWindow();
        }
    }
}
