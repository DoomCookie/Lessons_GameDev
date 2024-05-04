using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson02
{
    internal class Player : Character
    {

        public BaseGun m_gun;
        public int CountShoot { get { return m_gun.CountShoot; } }


        public Player(PointF position, SizeF size, float speed) : base(position, size, speed)
        {
            m_sprite = new Bitmap("media/spritesheets/ship.png");
            m_frameRect = new RectangleF(31, 0, 17, 23);
            m_frameSize = new SizeF(16, 24);
            m_frames = new Bitmap[2];
            m_frames[0] = m_sprite.Clone(new RectangleF(m_frameSize.Width * 2, 0, m_frameSize.Width, m_frameSize.Height), m_sprite.PixelFormat);
            m_frames[1] = m_sprite.Clone(new RectangleF(m_frameSize.Width * 2, m_frameSize.Height, m_frameSize.Width, m_frameSize.Height), m_sprite.PixelFormat);

            m_gun = new BigGun(Utils.Characters.Player);
        }


        public void EndReload()
        {
            m_gun.EndReload();
        }

        public void StartReload()
        {
            m_gun.StartReload();
        }

        override public void Move()
        {
            base.Move();
            if (Utils.KeysState["Right"] && m_position.X + m_size.Width + m_speed <= Settings.WindowSize.Width)
            {
                m_position.X += m_speed;
            }
            if (Utils.KeysState["Down"] && m_position.Y + m_size.Height + m_speed <= Settings.WindowSize.Height)
            {
                m_position.Y += m_speed;
            }
            if (Utils.KeysState["Left"] && m_position.X - m_speed > 0)
            {
                m_position.X -= m_speed;
            }
            if (Utils.KeysState["Up"] && m_position.Y - m_speed > Settings.WindowSize.Height / 2)
            {
                m_position.Y -= m_speed;
            }
            m_gun.Update();
        }

        public List<Bullet> Shoot()
        {
            return m_gun.Shoot(new PointF(Position.X + Size.Width / 2, Position.Y));
        }
    }
}
