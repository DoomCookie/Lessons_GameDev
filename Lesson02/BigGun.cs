using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class BigGun : BaseGun
    {
        public BigGun(float direction) : base(direction)
        {
            m_magazine = 3;
            m_coolDown = 2000;
            m_shootDelay = 1000 / 2f;
            m_speed = 150;
            m_bulletSize = new SizeF(30, 30);
        }

        public override List<Bullet> Shoot(PointF position, Utils.Characters character)
        {
            PointF point = new PointF(position.X - m_bulletSize.Width / 2, position.Y);
            return base.Shoot(point, character, Utils.Guns.Undestroyable);
        }
    }
}
