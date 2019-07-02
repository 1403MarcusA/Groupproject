using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NewGame;
namespace NewGame.Actor
{
    abstract class GameObject
    {
        protected string name;
        protected Vector2 position;
        protected int width;
        protected int height;
        protected bool isDeadFlag = false;

        public GameObject(string name, Vector2 position, int width, int height)
        {
            this.name = name;
            this.position = position;
            this.width = width;
            this.height = height;

        }
        public void SetPosition ( Vector2 position)
        {
            this.position = position;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        public int GetWidth()
        {
            return width;
        }
        public int GetHeight()
        {
            return height;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Hit(GameObject gameObject);

        public virtual void Draw (Renderer renderer)
        {
            renderer.DrawTexture(name, position);
        }
    }
}
