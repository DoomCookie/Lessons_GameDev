using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class BaseGun
    {
        public virtual int CountShoot { get { return m_magazine - m_countShoot; } }

        protected bool m_isCoolDown;
        protected long m_startReload;
        protected int m_countShoot;
                  
        protected float m_shootDelay;
        protected long m_timerShoot;
        protected long m_coolDown;
        protected int m_magazine;

        protected int m_direction;

        public BaseGun(int direction)
        {
            m_direction = direction;

            m_countShoot = 0;
            m_isCoolDown = false;
            m_timerShoot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            m_startReload = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public virtual void StartReload()
        {
            m_isCoolDown = true;
            m_startReload = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public virtual void Update()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (now - m_startReload >= m_coolDown && m_isCoolDown)
            {
                EndReload();
            }
        }

        public virtual void EndReload()
        {
            m_countShoot = 0;
            m_isCoolDown = false;
        }

        public virtual List<Bullet> Shoot(PointF position, Utils.Characters character)
        {
            throw new NotImplementedException();
        }
    }
}
