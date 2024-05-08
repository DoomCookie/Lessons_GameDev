using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class TripleGun : BaseGun
    {

        float m_offset = 15;
        public TripleGun(float direction) : base(direction)
        {
            m_magazine = 15;
            m_coolDown = 2500;
            m_shootDelay = 1000 / 2f;
            m_speed = 300;
            m_bulletSize = new SizeF(10, 10);
        }

        public override List<Bullet> Shoot(PointF position, Utils.Characters character)
        {
            PointF left = new PointF(position.X - m_bulletSize.Width / 2 - m_offset, position.Y);
            PointF center = new PointF(position.X - m_bulletSize.Width / 2, position.Y);
            PointF right = new PointF(position.X + m_offset - m_bulletSize.Width / 2, position.Y);
            long timerShoot = m_timerShoot;
            List<Bullet> bullets = new List<Bullet>();
            List<Bullet> tmpBullets = base.Shoot(left, character, Utils.Guns.Destroyable);
            if(tmpBullets != null)
            {
                bullets.InsertRange(0, tmpBullets);
                m_timerShoot = timerShoot;
            }
            tmpBullets = base.Shoot(center, character, Utils.Guns.Destroyable);
            if (tmpBullets != null)
            {
                bullets.InsertRange(0, tmpBullets);
                m_timerShoot = timerShoot;
            }
            tmpBullets = base.Shoot(right, character, Utils.Guns.Destroyable);
            if (tmpBullets != null)
            {
                bullets.InsertRange(0, tmpBullets);
            }
            return bullets;
        }
    }
}
