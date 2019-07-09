using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NewGame.Actor
{
    class Boss : GameObject
    {
        public Boss(string name, Vector2 position, int width, int height)
            : base("bosstest", position, 128, 128)
        {
          
        }

        public override void Hit(GameObject gameObject)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw (Renderer renderer)
        {
            renderer.DrawTexture(name, position);
        }
  
    }
}
