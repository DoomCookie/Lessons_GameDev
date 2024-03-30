using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Lesson02
{
    internal class Bullet : Character
    {
        public Bullet(PointF position, SizeF size, float speed, Color color) : base(position, size, speed, color)
        {
        }

        public override void Move()
        {
            m_position.Y -= m_speed;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(m_brush, m_position.X, m_position.Y, m_size.Width, m_size.Height);
        }
    }
}
