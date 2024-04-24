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

        float m_shootDelay;
        long m_timerShot;

        int m_countShoot;
        int m_magazine;
        int m_coolDown;
        bool m_isCoolDown;
        long m_startReload;

        public int CountShoot { get { return m_magazine - m_countShoot; } }

        public Player(PointF position, SizeF size, float speed) : base(position, size, speed)
        {
            m_countShoot = 0;
            m_magazine = 5;
            m_coolDown = 1500;
            m_isCoolDown = false;

            m_shootDelay = 1000 / 5f;
            m_timerShot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            m_startReload = DateTimeOffset.Now.ToUnixTimeMilliseconds();

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

            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (now - m_startReload >= m_coolDown && m_isCoolDown)
            {
                EndReload();
            }
        }

        public void StartReload()
        {
            m_isCoolDown = true;
            m_startReload = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public void EndReload()
        {
            m_countShoot = 0;
            m_isCoolDown = false;
        }

        public Bullet Shoot()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            
            if (now - m_timerShot >= m_shootDelay && !m_isCoolDown)
            {
                m_countShoot++;
                if(m_countShoot == m_magazine)
                {
                    StartReload();
                }
                m_timerShot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                return new Bullet(new PointF(Position.X + Size.Width / 2 - 5, Position.Y - 15), new SizeF(10, 10), 500, Utils.Characters.Player);

            }
            return null;
        }
    }
}
