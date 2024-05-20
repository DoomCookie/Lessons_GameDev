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
        public TripleGun(Utils.Characters characters) : base(characters)
        {
            m_coolDown = 2500;
            m_magazine = 9;
            m_shootDelay = 1000 / 3f;
            m_bulletSize = new SizeF(10, 10);
            m_speed = 500;
        }

        public override List<Bullet> Shoot(PointF position)
        {
            PointF left = new PointF(position.X - 20, position.Y - 15);
            PointF center = new PointF(position.X - 5, position.Y - 15);
            PointF right = new PointF(position.X + 10, position.Y - 15);
            long timerShoot = m_timerShot;
            List<Bullet> bullets = new List<Bullet>();
            List<Bullet> tmpBullets = base.Shoot(left, Utils.TypeBullet.Destroyable);
            if (tmpBullets != null)
            {
                bullets.InsertRange(0, tmpBullets);
                m_timerShot = timerShoot;
            }
            tmpBullets = base.Shoot(center, Utils.TypeBullet.Destroyable);
            if (tmpBullets != null)
            {
                bullets.InsertRange(0, tmpBullets);
                m_timerShot = timerShoot;
            }
            tmpBullets = base.Shoot(right, Utils.TypeBullet.Destroyable);
            if (tmpBullets != null)
            {
                bullets.InsertRange(0, tmpBullets);
            }
            return bullets;
        }

    }
}
