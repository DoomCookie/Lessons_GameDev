using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class BigGun : BaseGun
    {
        float m_speed = 200;
        public BigGun(Utils.Characters characters) : base(characters)
        {
            m_coolDown = 2500;
            m_magazine = 3;
            m_shootDelay = 1000 / 2f;
        }

        public override List<Bullet> Shoot(PointF position)
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (now - m_timerShot >= m_shootDelay && !m_isCoolDown)
            {
                CheckReload();
                SizeF size = new SizeF(30, 30);
                PointF point = new PointF(position.X - 15, position.Y - 25);
                float speed = m_ownCharacter == Utils.Characters.Enemy ? m_speed * m_speedCoef : m_speed;
                List<Bullet> bullets = new List<Bullet>();
                bullets.Add(new Bullet(point, size, speed, m_ownCharacter, Utils.TypeBullet.Undestroyable));
                return bullets;
            }
            return null;
        }
    }
}
