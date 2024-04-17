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

            m_sprite = new Bitmap("media/spritesheets/laser-bolts.png");
            m_frameSize = new SizeF(5, 5);
            m_frames = new Bitmap[2];
            RectangleF rect = new RectangleF(6, 7, m_frameSize.Width, m_frameSize.Height);
            m_frames[0] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            rect.X = 20;
            m_frames[1] = m_sprite.Clone(rect, m_sprite.PixelFormat);
        }

        public override void Move()
        {
            m_position.Y -= m_speed;
        }
    }
}
