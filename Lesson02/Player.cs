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

        BaseGun gun;

        public int CountShoot { get { return gun.CountShoot; } }

        public Player(PointF position, SizeF size, float speed) : base(position, size, speed)
        {
            gun = new BigGun(1);

            m_sprite = new Bitmap("media/spritesheets/ship.png");
            m_frameSize = new SizeF(16, 24);
            m_frames = new Bitmap[2];
            RectangleF rect = new RectangleF(32, 0, m_frameSize.Width, m_frameSize.Height);
            m_frames[0] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            rect.Y = m_frameSize.Height;
            m_frames[1] = m_sprite.Clone(rect, m_sprite.PixelFormat);
        }


        override public void Move()
        {
            
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

            gun.Update();
        }

        public void StartReload()
        {
            gun.StartReload();
        }

        public void EndReload()
        {
            gun.EndReload();
        }

        public List<Bullet> Shoot()
        {
            return gun.Shoot(new PointF(Position.X + Size.Width / 2, Position.Y - 15), Utils.Characters.Player);
        }
    }
}
