using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    internal class Enemy : Character
    {
        public virtual int Bounty { get; } = 100;

        public Enemy(PointF position, SizeF size, float speed, Color color) : base(position, size, speed, color)
        {
            m_sprite = new Bitmap("media/spritesheets/enemy-big.png");
            m_frameSize = new SizeF(32, 32);
            m_frames = new Bitmap[2];
            RectangleF rect = new RectangleF(0, 0, m_frameSize.Width, m_frameSize.Height);
            m_frames[0] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            rect.X = m_frameSize.Width;
            m_frames[1] = m_sprite.Clone(rect, m_sprite.PixelFormat);

        }

        override public void Move()
        {
            m_position.Y += m_speed;
            if(m_position.Y > Settings.WindowSize.Height + 10)
            {
                LifeCounter.Hit();
            }
        }
    }
}
