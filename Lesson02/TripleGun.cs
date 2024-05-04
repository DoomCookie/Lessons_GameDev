using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class TripleGun : BaseGun
    {
        public TripleGun()
        {
            m_magazine = 5;
            m_coolDown = 2500;
            m_shootDelay = 1000 / 2f;
        }

        public override List<Bullet> Shoot(PointF position, Utils.Characters character)
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (now - m_timerShoot >= m_shootDelay && !m_isCoolDown)
            {
                m_countShoot++;
                if (m_countShoot == m_magazine)
                {
                    StartReload();
                }
                m_timerShoot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                PointF left = new PointF(position.X - 15, position.Y);
                PointF center = new PointF(position.X, position.Y);
                PointF right = new PointF(position.X + 15, position.Y);
                SizeF size = new Size(10, 10);
                List<Bullet> bullets = new List<Bullet>();
                bullets.Add(new Bullet(left, size, 300, character));
                bullets.Add(new Bullet(center, size, 300, character));
                bullets.Add(new Bullet(right, size, 300, character));
                return bullets;

            }
            return null;
        }
    }
}
