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
            player = new Player(new Vector2F(300, 300));
            characterNode.AddChildNode(player);
            NomalEnemy nomalEnemy = new NomalEnemy(new Vector2F(500, 250), new Vector2F(0.0f, 0.0f), player);
            characterNode.AddChildNode(nomalEnemy);
        }
    }
}
