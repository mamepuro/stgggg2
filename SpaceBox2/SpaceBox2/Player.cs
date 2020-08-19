using System;
using Altseed2;
using System.Collections.Generic;

namespace SpaceBox2
{
    public class Player:SpriteNode
    {
        public Vector2F _moveDistanceX;
        public Vector2F _moveDistanceY;
        public float chargeTime;
        public Vector2F _position;
        public Player(Vector2F position)
        {
            Texture = Texture2D.LoadStrict("Resources/player.png");
            Position = position;
            _moveDistanceX = new Vector2F(4.0f,0.0f);
            _moveDistanceY = new Vector2F(0.0f,4.0f);
        }
        public void Move()
        {
            if(Engine.Keyboard.GetKeyState(Key.W) == ButtonState.Hold)
            {
                Position -= _moveDistanceY;
            }
            if(Engine.Keyboard.GetKeyState(Key.S) == ButtonState.Hold)
            {
                Position += _moveDistanceY;
            }
            if(Engine.Keyboard.GetKeyState(Key.D) == ButtonState.Hold)
            {
                Position += _moveDistanceX;
            }
            if(Engine.Keyboard.GetKeyState(Key.A) == ButtonState.Hold)
            {
                Position -= _moveDistanceX;
            }
            float playerHalfSizeX = Texture.Size.X / 2.0f;
            _position = Position;
            _position.X = Math.Clamp(_position.X, 0.0f, Engine.WindowSize.X - Texture.Size.X);
            _position.Y = Math.Clamp(_position.Y, 0.0f, Engine.WindowSize.Y - Texture.Size.Y);
            Position = _position;
        }
        public void FireBullet()
        {
            if (Engine.Keyboard.GetKeyState(Key.Space) == ButtonState.Push)
            {
                //PlayerBullet playerBullet = new PlayerBullet(new asd.Vector2DF(position.X + Texture.Size.X + 10.0f, position.Y + Texture.Size.Y / 2.0f));
                //Engine.AddObject2D(playerBullet);
            }
        }
        //public void FireChargeBullet()
        //{
        //    if (asd.Engine.Keyboard.GetKeyState(asd.Keys.N) == asd.KeyState.Hold)
        //    {
        //        chargeTime += 0.2f;
        //        chargeTime = asd.MathHelper.Clamp(chargeTime, 60.0f, 0.0f);
        //    }
        //    if (asd.Engine.Keyboard.GetKeyState(asd.Keys.A) == asd.KeyState.Push && chargeTime > 0.0f)
        //    {
        //        PlayerBullet playerBullet = new PlayerBullet(new asd.Vector2DF(position.X + Texture.Size.X + 10.0f, position.Y + Texture.Size.Y / 2.0f), chargeTime);
        //        playerBullet.Scale = new asd.Vector2DF(chargeTime, chargeTime);
        //        asd.Engine.AddObject2D(playerBullet);
        //        chargeTime = 0.0f;
        //    }
        //}
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
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Move();
            FireBullet();
            //FireChargeBullet();
            //CheckCollision();
        }
    }
}
