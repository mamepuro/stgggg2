using System;
using Altseed2;

namespace SpaceBox2
{
    public class Enemy:CollidableObject
    {
        public Vector2F _moveVelocity;
        //プレイヤーへの参照
        protected Player _playerInfo;
        protected int _bulletFireTimeSpan;
        protected int _count;
        protected int Score
        {
            get;
            set;
        }
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

        protected void AddScore(int score)
        {
            ScoreDelay scoreNode = new ScoreDelay(this.Position);
            scoreNode.Font = Font.LoadDynamicFontStrict("Resources/Square.ttf", 20);
            scoreNode.Text = score.ToString();
            //scoreNode.Color = new Color(255, 0, 0);
            _mainNode.AddChildNode(scoreNode);
        }
        protected override void OnCollide(CollidableObject collidableObject)
        {
            base.OnCollide(collidableObject);
            if(collidableObject is PlayerBullet)
            {
                AddScore(Score);
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
