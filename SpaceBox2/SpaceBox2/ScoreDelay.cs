using System;
using Altseed2;
using System.Collections.Generic;
using System.Text;

namespace SpaceBox2
{
    class ScoreDelay:TextNode
    {
        /// <summary>
        /// スコアを表示するフレーム数
        /// </summary>
        private const int livingFrame = 30;
        private Vector2F moveVelocity;

        IEnumerator<int> coroutine;
        public ScoreDelay(Vector2F position)
        {
            this.Position = position;
        }
        protected override void OnAdded()
        {
            base.OnAdded();
            moveVelocity = new Vector2F(0, -1);
            coroutine = GetCoroutine();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            coroutine?.MoveNext();
        }
        void Move()
        {
            this.Position += moveVelocity;
        }

        IEnumerator<int> GetCoroutine()
        {
            float alpha_delta = 1 / (float)livingFrame;
            for(int i = 0; i < livingFrame; i++)
            {
                Move();
                //this.Color = new Color(100, 255, 100, (int)((float)255 - (float)((float)i) / (float)livingFrame)) ;
                float alpha = 255 * (float)(i * alpha_delta);
                //Console.WriteLine(alpha);
                //this.Color = new Color(100, 255, 100, 255 - (int)alpha);
                if(i % 10 < 5)
                {
                    this.Color = new Color(100, 255, 100, 255 - (int)alpha);
                }
                else
                {
                    this.Color = new Color(100, 255, 100, 0);
                }
                yield return i;
            }            
            Parent.RemoveChildNode(this);
        }
    }
}
