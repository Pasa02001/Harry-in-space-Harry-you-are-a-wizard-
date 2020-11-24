using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Template
{
    class Timer : GameComponent
    {
        private SpriteFont font;
        private string text;
        private float time;
        private Vector2 position;
        private bool start;
        private bool paus;
        private bool end; 

        public Timer(Game game, float startTime): base(game)
        {
            time = startTime;
            start = false;
            paus = false;
            end = false;
            Text = "";

        }

        #region Properties
        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public bool Start
        {
            get { return start; }
            set { start = value; }
        }

        public bool Paus
        {
            get { return paus; }
            set { paus = value; }

        }

        public bool End
        {
            get { return end; }
            set { end = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion
        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (start)
            {
                if (!paus)
                {
                    if (time > 0)
                        time -= deltaTime;
                    else
                        end = true;
                }
            }
            Text = time.ToString();
            base.Update(gameTime);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Text, Position, Color.White);
        }


    }
}
