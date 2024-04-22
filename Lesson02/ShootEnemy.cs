using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class ShootEnemy : Enemy
    {
        public override int Bounty { get; }
        float m_coolDown;
        long m_timerShot;
        public ShootEnemy(PointF position, SizeF size, float speed) : base(position, size, speed)
        {
            m_coolDown = Utils.rnd.Next(2000, 3000);
            Bounty = 200;
            m_sprite = new Bitmap("media/spritesheets/enemy-medium.png");
            m_frameRect = new RectangleF(0, 0, 32, 16);
            m_frameSize = new SizeF(32, 16);
            m_frameCount = 0;
            m_frames = new Bitmap[2];
            for (int i = 0; i < m_frames.Length; i++)
            {
                RectangleF rect = new RectangleF(i * m_frameSize.Width, 0, m_frameSize.Width, m_frameSize.Height);
                m_frames[i] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            }
        }

        public Bullet Shoot()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (now - m_timerShot >= m_coolDown)
            {
                m_timerShot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                return new Bullet(new PointF(Position.X + Size.Width / 2 -5, Position.Y + m_size.Height + 15), new SizeF(10, 10), -200, Utils.Characters.Enemy);
            }
            return null;

        }
    }
}
