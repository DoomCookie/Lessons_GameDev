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
        public int Bounty { get; } = 100;

        public Enemy(PointF position, SizeF size, float speed, Color color) : base(position, size, speed, color)
        {
        }

        override public void Move()
        {
            m_position.Y += m_speed;
            if(m_position.Y > Settings.WindowSize.Height + 10)
            {
                LifeCounter.Hit();
                Random rnd = new Random();
                m_position.Y = rnd.Next(-1000, -50);
                m_position.X = rnd.Next(0, (int)(Settings.WindowSize.Width - m_size.Width));
            }
        }
    }
}
