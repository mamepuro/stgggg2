using System;
using Altseed2;
using System.Collections.Generic;

namespace SpaceBox2
{
    public class CollidableObject:SpriteNode
    {
        public static HashSet<CollidableObject> objectCollection = new HashSet<CollidableObject>();
        protected RectangleCollider collider = RectangleCollider.Create();
        protected bool doSurvey = false;
        public MainNode _mainNode;
        public CollidableObject(MainNode mainNode, Vector2F position)
        {
            _mainNode = mainNode;
            Position = position;
            collider.Position = position;
        }
        protected override void OnAdded()
        {
            base.OnAdded();
            objectCollection.Add(this);
        }
        protected override void OnRemoved()
        {
            base.OnRemoved();
            objectCollection.Remove(this);
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            if(doSurvey)
            {
                Survey();
            }
            //コライダの座標を更新する
            collider.Position = Position;
        }
        protected void RemoveMyselfIfOutOfWindow()
        {
            var halfSize = Texture.Size / 2;
            if (Position.X < -halfSize.X
                || Position.X > Engine.WindowSize.X + halfSize.X
                || Position.Y < -halfSize.Y
                || Position.Y > Engine.WindowSize.Y + halfSize.Y)
            {
                Parent?.RemoveChildNode(this);
            }
        }
        protected virtual void OnCollide(CollidableObject collidableObject)
        {
            //継承先で処理を実装する
        }
        protected void CollideWith(CollidableObject collidableObject)
        {
            if(collidableObject == null)
            {
                return;
            }
            if(!collidableObject.doSurvey)
            {
                //衝突判定しないオブジェクトに衝突した場合、その判定しないオブジェクトの衝突時の処理を呼び出す
                /*例えば、自機と敵弾が衝突する場合、呼び出されたCollideWith関数の引数は敵弾(=衝突判定しないオブジェクト)になる。
                 すなわち、敵弾が磁気と衝突した際に呼び出すべき処理（OnCollide関数）をcollidableObject.Oncollode(this(自機のこと))で呼び出している
                 */
                collidableObject.OnCollide(this);
            }
            /*上の例に従えば、以下の処理は「自機が敵弾と衝突した際に呼び出す処理」を呼び出すのに相当する。（あくまでOncollideを呼び出したのは自機である)*/
            OnCollide(collidableObject);
        }
        private void Survey()
        {
            foreach(var obj in objectCollection)
            {
                if(collider.GetIsCollidedWith(obj.collider))
                {
                    CollideWith(obj);
                }
            }
        }
    }
}
