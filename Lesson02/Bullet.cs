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
        public Utils.Characters Owner { get; }
        public Bullet(PointF position, SizeF size, float speed, Color color, Utils.Characters owner) : base(position, size, speed, color)
        {
            Owner = owner;
            m_sprite = new Bitmap("D:/C#/Кириченко Артем/Lesson02/Lesson02/media/spritesheets/laser-bolts.png");
            m_frameRect = new RectangleF(0, 0, 16, 16);
            m_frameSize = new SizeF(16, 16);
            m_frames = new Bitmap[2];
            for (int i = 0; i < m_frames.Length; i++)
            {
                RectangleF rect = new RectangleF(i * m_frameSize.Width, 0, m_frameSize.Width, m_frameSize.Height);
                m_frames[i] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            }
        }

        public override void Move()
        {
            base.Move();
            m_position.Y -= m_speed;
        }

        //public override void Draw(Graphics g)
        //{
        //    g.FillEllipse(m_brush, m_position.X, m_position.Y, m_size.Width, m_size.Height);
        //}
    }
}
