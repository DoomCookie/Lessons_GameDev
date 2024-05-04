using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lesson02
{
    internal class ShootEnemy : Enemy
    {
        BaseGun gun;
        public override int Bounty { get; } = 200;

        public ShootEnemy(PointF position, SizeF size, float speed) : base(position, size, speed)
        {
            gun = new SimpleGun(-1);

            m_sprite = new Bitmap("media/spritesheets/enemy-medium.png");
            m_frameSize = new SizeF(32, 16);
            m_frames = new Bitmap[2];
            RectangleF rect = new RectangleF(0, 0, m_frameSize.Width, m_frameSize.Height);
            m_frames[0] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            rect.X = m_frameSize.Width;
            m_frames[1] = m_sprite.Clone(rect, m_sprite.PixelFormat);
        }

        public override void Move()
        {
            base.Move();
            gun.Update();
        }

        public List<Bullet> Shoot()
        {
            return gun.Shoot(new PointF(Position.X + Size.Width / 2, Position.Y + m_size.Height + 15), Utils.Characters.Enemy);
        }
    }
}
