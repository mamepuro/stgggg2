using System;
using Altseed2;
using System.Collections.Generic;

namespace SpaceBox2
{
    public class Player:CollidableObject
    {
        public Vector2F _moveDistanceX;
        public Vector2F _moveDistanceY;
        public float chargeTime;
        public Vector2F _position;
        public int _maxBulletCountInWindow;
        public  Queue<PlayerBullet> playerBullets = new Queue<PlayerBullet>();
        public Player(MainNode mainNode, Vector2F position):base(mainNode,position)
        {
            Texture = Texture2D.LoadStrict("Resources/player.png");
            doSurvey = true;
            //Position = position;
            _moveDistanceX = new Vector2F(4.0f,0.0f);
            _moveDistanceY = new Vector2F(0.0f,4.0f);
            chargeTime = 0.0f;
            collider.Size = Texture.Size;
            _maxBulletCountInWindow = 3;
        }
        public void Move()
        {
            if(Engine.Keyboard.GetKeyState(Key.W) == ButtonState.Hold || Engine.Keyboard.GetKeyState(Key.Up) == ButtonState.Hold)
            {
                Position -= _moveDistanceY;
            }
            if(Engine.Keyboard.GetKeyState(Key.S) == ButtonState.Hold || Engine.Keyboard.GetKeyState(Key.Down) == ButtonState.Hold)
            {
                Position += _moveDistanceY;
            }
            if(Engine.Keyboard.GetKeyState(Key.D) == ButtonState.Hold || Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold)
            {
                Position += _moveDistanceX;
            }
            if(Engine.Keyboard.GetKeyState(Key.A) == ButtonState.Hold || Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold)
            {
                Position -= _moveDistanceX;
            }
            //float playerHalfSizeX = Texture.Size.X / 2.0f;
            _position = Position;
            _position.X = Math.Clamp(_position.X, 0.0f, Engine.WindowSize.X - Texture.Size.X);
            _position.Y = Math.Clamp(_position.Y, 0.0f, Engine.WindowSize.Y - Texture.Size.Y);
            Position = _position;
        }
        public void FireBullet()
        {
            if (Engine.Keyboard.GetKeyState(Key.Space) == ButtonState.Push && playerBullets.Count < _maxBulletCountInWindow)
            {
                PlayerBullet playerBullet = new PlayerBullet(_mainNode, new Vector2F(Position.X + Texture.Size.X + 10.0f, Position.Y + Texture.Size.Y / 2.0f), new Vector2F(10.0f,0.0f),this);
                Engine.AddNode(playerBullet);
                playerBullets.Enqueue(playerBullet);
            }
        }
        public void FireChargeBullet()
        {
            if (Engine.Keyboard.GetKeyState(Key.N) == ButtonState.Hold)
            {
                chargeTime += 0.2f;
                chargeTime = Math.Clamp(chargeTime, 0.0f, 60.0f);
            }
            if (Engine.Keyboard.GetKeyState(Key.I) == ButtonState.Push && chargeTime > 0.0f)
            {
                PlayerBullet playerBullet = new PlayerBullet(_mainNode, new Vector2F(Position.X + Texture.Size.X + 10.0f, Position.Y + Texture.Size.Y / 2.0f), new Vector2F(10.0f, 0.0f), this, chargeTime);
                playerBullet.Scale = new Vector2F(chargeTime, chargeTime);
                Engine.AddNode(playerBullet);
                chargeTime = 0.0f;
            }
        }
        //public override void OnCollided(CollidableObject collidableObject)
        //{
        //    if (collidableObject is FreezeBullet)
        //    {
        //        base.OnCollided(collidableObject);
        //        if (playersHealth == PlayersHealth.Nomal)
        //        {
        //            this.playersHealth = PlayersHealth.Frozen;
        //            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/Frozenplayer.png");
        //        }
        //    }
        //    else
        //    {
        //        base.OnCollided(collidableObject);
        //        Dispose();
        //    }
        //}
        //public override void CollideWithObject(CollidableObject collidableObject)
        //{
        //    if (collidableObject == null)
        //    {
        //        return;
        //    }
        //    if (collidableObject is Enemy)
        //    {
        //        CollidableObject enemy = collidableObject;//衝突したオブジェクトがEnemyである事を明示する
        //        if (IsCollide(enemy))
        //        {
        //            OnCollided(enemy);
        //        }
        //    }
        //    if (collidableObject is EnemyBullet)
        //    {
        //        CollidableObject enemyBullet = collidableObject;
        //        if (IsCollide(enemyBullet))
        //        {
        //            OnCollided(enemyBullet);
        //            enemyBullet.OnCollided(this);
        //        }
        //    }
        //    if (collidableObject is FreezeBullet)
        //    {
        //        CollidableObject freezeBullet = collidableObject;
        //        if (IsCollide(freezeBullet))
        //        {
        //            OnCollided(freezeBullet);
        //            freezeBullet.OnCollided(this);
        //        }
        //    }
        //}
        protected override void OnCollide(CollidableObject collidableObject)
        {
            base.OnCollide(collidableObject);
            if(collidableObject is NomalEnemy || collidableObject is EnemyBullet)
            {
                Parent.RemoveChildNode(this);
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
            FireBullet();
            FireChargeBullet();
            //FireChargeBullet();
            //CheckCollision();
        }
    }
}
