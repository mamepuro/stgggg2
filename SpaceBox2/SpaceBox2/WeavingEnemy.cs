using System;
using Altseed2;
using System.Collections.Generic;
using System.Text;

namespace SpaceBox2
{
    class WeavingEnemy:Enemy
    {
        public WeavingEnemy(MainNode mainNode, Vector2F position, Vector2F moveVelocity, Player player)
            : base(mainNode, position, moveVelocity, player)
        {

        }
        protected override void Move()
        {
            Position += (_moveVelocity + new Vector2F(0, (float)Math.Sin((_count/ 5)/Math.PI) * 3));
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            _count++;
            Move();
        }
    }
}
