using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class BigGun : BaseGun
    {
        public BigGun(Utils.Characters characters) : base(characters)
        {
            m_coolDown = 2500;
            m_magazine = 3;
            m_shootDelay = 1000 / 2f;
            m_speed = 200;
            m_bulletSize = new SizeF(30, 30);
        }

        public override List<Bullet> Shoot(PointF position)
        {
            PointF point = new PointF(position.X - 15, position.Y - 25);
            return base.Shoot(point, Utils.TypeBullet.Undestroyable);
        }
    }
}
