using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NewGame.Actor
{
    class BossBullet : GameObject
    {
        public BossBullet(Vector2 position, int width, int height) 
            : base("", position,32, 32)
        {
        }

        public override void Hit(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
