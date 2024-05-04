using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    internal class TripleGun : BaseGun
    {
        float m_speed = 500;
        public TripleGun(Utils.Characters characters) : base(characters)
        {
            m_coolDown = 2500;
            m_magazine = 3;
            m_shootDelay = 1000 / 3f;
        }

        public override List<Bullet> Shoot(PointF position)
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (now - m_timerShot >= m_shootDelay && !m_isCoolDown)
            {
                CheckReload();
                PointF left = new PointF(position.X - 20, position.Y - 15);
                PointF center = new PointF(position.X - 5, position.Y - 15);
                PointF right = new PointF(position.X + 10, position.Y - 15);
                SizeF size = new SizeF(10, 10);
                float speed = m_ownCharacter == Utils.Characters.Enemy ? m_speed * m_speedCoef : m_speed;
                List<Bullet> bullets = new List<Bullet>();
                bullets.Add(new Bullet(left, size, speed,   m_ownCharacter, Utils.TypeBullet.Destroyable));
                bullets.Add(new Bullet(center, size, speed, m_ownCharacter, Utils.TypeBullet.Destroyable));
                bullets.Add(new Bullet(right, size, speed,  m_ownCharacter, Utils.TypeBullet.Destroyable));
                return bullets;
            }
            return null;
        }

    }
}
