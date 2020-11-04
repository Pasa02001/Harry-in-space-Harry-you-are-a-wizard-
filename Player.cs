using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Player
    {
        Texture2D player;
        Vector2 playerPos = new Vector2(40,100);
        Vector2 mousePos;
        public float angle; 

        public Player(Texture2D player)
        {
            this.player = player; 

        }
        public void Update()
        {
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.W))
                playerPos.Y -= 5;
            if (kState.IsKeyDown(Keys.S))
                playerPos.Y += 5;
            if (kState.IsKeyDown(Keys.D))
                playerPos.X += 5;
            if (kState.IsKeyDown(Keys.A))
                playerPos.X -= 5;

            mousePos = Mouse.GetState().Position.ToVector2();
            angle = (float)Math.Atan2(playerPos.Y - mousePos.Y, playerPos.X - mousePos.X) + (float)(Math.PI);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width=(int)(Game1.ScreenHeight * .3f);
            int height = (int)(Game1.ScreenHeight * .3f);
            spriteBatch.Draw(player, new Rectangle((int)playerPos.X, (int)playerPos.Y, width, height), null, Color.White, angle, new Vector2(player.Width/2, player.Height/2), SpriteEffects.None,0);


        }
    }
}
