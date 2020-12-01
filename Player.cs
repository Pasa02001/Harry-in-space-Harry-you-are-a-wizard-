using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Template
{
    class Player : BaseClass
    {
        Vector2 mousePos;
        public float angle;
        List<Bullet> bulletList;
        KeyboardState oldKState;
        public Player(Texture2D texture, Vector2 texturePos, List<Bullet> bulletList) : base(texture, texturePos)
        {
            this.bulletList = bulletList;
        }
        public override void Update()
        {
            KeyboardState newKState = Keyboard.GetState();
            if (newKState.IsKeyDown(Keys.W))
                texturePos.Y -= 5;
            if (newKState.IsKeyDown(Keys.S))
                texturePos.Y += 5;
            if (newKState.IsKeyDown(Keys.D))
                texturePos.X += 5;
            if (newKState.IsKeyDown(Keys.A))
                texturePos.X -= 5;
            if (newKState.IsKeyDown(Keys.Space)) //&& oldKState.IsKeyUp(Keys.Space))
                Shoot();
            

            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(texturePos.Y - mousePos.Y, texturePos.X - mousePos.X) + (float)(Math.PI);
            oldKState = newKState;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            int width=(int)(Game1.ScreenHeight * .3f);
            int height = (int)(Game1.ScreenHeight * .3f);
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X, (int)texturePos.Y, width, height), null, Color.White, angle, new Vector2(texture.Width/2, texture.Height/2), SpriteEffects.None,0);
        }

        private void Shoot()
        {
            Vector2 dir = Mouse.GetState().Position.ToVector2() - texturePos;
            dir.Normalize();
            bulletList.Add(new Bullet(texture, texturePos, dir));
        }
    }
}
