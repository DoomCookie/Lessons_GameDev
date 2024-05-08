using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class SimpleGun : BaseGun
    {
        public SimpleGun(float direction) : base(direction)
        {
            m_magazine = 5;
            m_coolDown = 1500;
            m_shootDelay = 1000 / 5f;
            m_speed = 500;
            m_bulletSize = new SizeF(10, 10);
        }

        public override List<Bullet> Shoot(PointF position, Utils.Characters character)
        {
            PointF point = new PointF(position.X - m_bulletSize.Width / 2, position.Y);
            return base.Shoot(point, character, Utils.Guns.Destroyable);
        }
    }
}
