using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class SimpleGun : BaseGun
    {
        public SimpleGun()
        {
            m_magazine = 5;
            m_coolDown = 1500;
            m_shootDelay = 1000 / 5f;
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
                return new List<Bullet> { new Bullet(new PointF(position.X, position.Y), new SizeF(10, 10), 500, character) };

            }
            return null;
        }
    }
}
