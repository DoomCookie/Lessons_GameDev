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
        public ShootEnemy(PointF position, SizeF size, float speed, Color color) : base(position, size, speed, color)
        {
            m_coolDown = Utils.rnd.Next(2000, 3000);
            Bounty = 200;
        }

        public Bullet Shoot()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (now - m_timerShot >= m_coolDown)
            {
                m_timerShot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                return new Bullet(new PointF(Position.X + Size.Width / 2, Position.Y + m_size.Height + 15), new SizeF(5, 10), -200, Color.Red, Utils.Characters.Enemy);
            }
            return null;

        }
    }
}
