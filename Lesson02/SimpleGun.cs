using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    internal class SimpleGun : BaseGun
    {
        float m_speed = 500;
       
        public SimpleGun(Utils.Characters characters) : base(characters)
        {
            m_coolDown = 1500;
            m_magazine = 5;
            m_shootDelay = 1000 / 5f;
        }

        public override List<Bullet> Shoot(PointF position)
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (now - m_timerShot >= m_shootDelay && !m_isCoolDown)
            {
                CheckReload();
                float speed = m_ownCharacter == Utils.Characters.Enemy ? m_speed * m_speedCoef : m_speed;
                return new List<Bullet> { new Bullet(new PointF(position.X - 5, position.Y - 15), new SizeF(10, 10), speed, m_ownCharacter, Utils.TypeBullet.Destroyable) };
            }
            return null;
        }
    }
}
