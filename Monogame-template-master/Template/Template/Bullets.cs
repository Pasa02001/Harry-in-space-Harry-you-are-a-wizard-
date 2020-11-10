using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Bullets
    {
        Texture2D bullet;
        Vector2 bPos;
        Vector2 bSpeed;
        Vector2 bOrigan;


        bool isVisible;
        public Bullets (Texture2D newTexture)
        {
            bullet = newTexture;
            isVisible = false; 

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bullet, bPos, null, Color.White, 0f, bOrigan, 1f, SpriteEffects.None, 0);
        }

    }
}
