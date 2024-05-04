using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class BigGun : BaseGun
    {
        public BigGun(int direction) : base(direction)
        {
            m_magazine = 3;
            m_coolDown = 2000;
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
                return new List<Bullet> { new Bullet(new PointF(position.X - 15, position.Y), new SizeF(30, 30), m_direction * 150, character, Utils.Guns.Undestroyable) };

            }
            return null;
        }
    }
}
