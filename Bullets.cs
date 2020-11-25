using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Template
{
    class Bullets : BaseClass
    {
        Vector2 bulletDirection; 
        public Bullets(Vector2 bulletDirection) : base()
        {
            this.bulletDirection = bulletDirection;
        }
        public override void Update()
        {
            texturePos += bulletDirection * 5;
        }
    }
}
