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
        public Utils.Characters CharacterOwner { get; }

        public Bullet(PointF position, SizeF size, float speed, Color color, Utils.Characters characterOwner) : base(position, size, speed, color)
        {
            CharacterOwner = characterOwner;
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
