using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class ShootEnemy : Enemy
    {
        public override int Bounty { get; }
        BaseGun m_gun;
        public ShootEnemy(PointF position, SizeF size, float speed) : base(position, size, speed)
        {
            m_gun = new SimpleGun(Utils.Characters.Enemy);
            m_gun.CoolDownCoef = 0;
            m_gun.ShootDelayCoef = Convert.ToSingle(Utils.rnd.NextDouble() * 5 + 10);
            Bounty = 200;
            m_sprite = new Bitmap("media/spritesheets/enemy-medium.png");
            m_frameRect = new RectangleF(0, 0, 32, 16);
            m_frameSize = new SizeF(32, 16);
            m_frameCount = 0;
            m_frames = new Bitmap[2];
            for (int i = 0; i < m_frames.Length; i++)
            {
                RectangleF rect = new RectangleF(i * m_frameSize.Width, 0, m_frameSize.Width, m_frameSize.Height);
                m_frames[i] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            }
        }

        public override void Move()
        {
            base.Move();
            m_gun.Update();
        }

        public List<Bullet> Shoot()
        {
            return m_gun.Shoot(new PointF(Position.X + Size.Width / 2, Position.Y + Size.Height));

        }
    }
}
