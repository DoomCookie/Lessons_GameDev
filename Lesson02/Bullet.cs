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
            m_frameSize = new SizeF(5, 5);
            m_frames = new Bitmap[2];
            m_frames[0] = m_sprite.Clone(
                new RectangleF(6, 7, 5, 5),
                m_sprite.PixelFormat);
            m_frames[1] = m_sprite.Clone(
                new RectangleF(20, 7, 5, 5),
                m_sprite.PixelFormat);
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
