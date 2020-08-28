using System;
using Altseed2;

namespace SpaceBox2
{
    public class MainNode:Node
    {
        private Node characterNode = new Node();
        private Player player;
        public MainNode()
        {
        }
        protected override void OnAdded()
        {
            base.OnAdded();
            AddChildNode(characterNode);
            var uiNode = new Node();
            AddChildNode(uiNode);
            player = new Player(this, new Vector2F(300, 300));
            characterNode.AddChildNode(player);
            //NomalEnemy nomalEnemy = new NomalEnemy(this, new Vector2F(500, 250), new Vector2F(0.0f, 0.0f), player);
            FreezeBulletEnemy freezeBulletEnemy = new FreezeBulletEnemy(this, new Vector2F(500, 250), new Vector2F(0.0f, 0.0f), player);
            characterNode.AddChildNode(freezeBulletEnemy);
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            //デバック用
            Console.WriteLine(player.playerBullets.Count);
        }
        protected override void OnRemoved()
        {
            base.OnRemoved();
            CollidableObject.objectCollection.Clear();
        }
    }
}
