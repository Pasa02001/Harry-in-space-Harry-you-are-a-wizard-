using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Template
{
    class Bullet : BaseClass
    {
        private Vector2 dir;
        private float speed = 10; 
        public Bullet(Texture2D texture, Vector2 texturePos, Vector2 direction) : base(texture, texturePos)
        {
            dir = direction;
        }
        public override void Update()
        {
            texturePos += dir * speed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(texturePos.ToPoint(), new Point(20,20)), Color.White);
        }
    }
}
