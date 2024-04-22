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
        int m_framesCount = 0;
        public virtual int Bounty { get; } = 100;

        public Enemy(PointF position, SizeF size, float speed) : base(position, size, speed)
        {
            m_sprite = new Bitmap("media/spritesheets/power-up.png");
            m_frameSize = new SizeF(16, 16);
            m_frameCount = 0;
            m_frames = new Bitmap[2];
            float yOffset = 0;
            if (Utils.rnd.NextDouble() < 0.5)
            {
                yOffset = m_frameSize.Height;
            }
            for(int i = 0; i < m_frames.Length; i++)
            {
                RectangleF rect = new RectangleF(i * m_frameSize.Width, yOffset, m_frameSize.Width, m_frameSize.Height);
                m_frames[i] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            }
        }

        override public void Move()
        {
            base.Move();
            m_position.Y += m_speed;
            if(m_position.Y > Settings.WindowSize.Height + 10)
            {
                LifeCounter.Hit();
            }
        }
    }
}
