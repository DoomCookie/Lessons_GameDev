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
