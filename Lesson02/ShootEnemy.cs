using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lesson02
{
    internal class ShootEnemy : Enemy
    {
        float m_coolDown;
        long m_timerShot;
        public override int Bounty { get; } = 200;

        public ShootEnemy(PointF position, SizeF size, float speed, Color color) : base(position, size, speed, color)
        {
            m_coolDown = Utils.rnd.Next(2000, 3000);
            m_timerShot = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            m_sprite = new Bitmap("media/spritesheets/enemy-medium.png");
            m_frameSize = new SizeF(32, 16);
            m_frames = new Bitmap[2];
            RectangleF rect = new RectangleF(0, 0, m_frameSize.Width, m_frameSize.Height);
            m_frames[0] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            rect.X = m_frameSize.Width;
            m_frames[1] = m_sprite.Clone(rect, m_sprite.PixelFormat);
        }

        public Bullet Shoot()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (now - m_timerShot >= m_coolDown)
            {
                m_timerShot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                return new Bullet(new PointF(Position.X + Size.Width / 2 - 5, Position.Y + m_size.Height + 15), new SizeF(10, 10), -200, Color.Red, Utils.Characters.Enemy);
            }
            return null;
        }
    }
}
