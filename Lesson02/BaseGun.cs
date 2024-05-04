using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class BaseGun
    {
        public int CountShoot { get { return m_magazine - m_countShoot; } }

        protected float m_shootDelay;
        protected long m_timerShot;

        protected int m_countShoot;
        protected int m_magazine;
        protected float m_coolDown;
        protected bool m_isCoolDown;
        protected long m_startReload;
        protected float m_speedCoef = -0.5f;

        protected Utils.Characters m_ownCharacter;

        public BaseGun(Utils.Characters ownCharacter)
        {
            m_countShoot = 0;
            m_isCoolDown = false;
            m_timerShot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            m_ownCharacter = ownCharacter;
        }

        public virtual void Update()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (now - m_startReload > m_coolDown && m_isCoolDown)
            {
                EndReload();
            }
        }

        public virtual void EndReload()
        {
            m_isCoolDown = false;
            m_countShoot = 0;
        }

        public virtual void StartReload()
        {
            m_startReload = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            m_isCoolDown = true;
        }

        public virtual List<Bullet> Shoot(PointF position)
        {
            throw new NotImplementedException();
        }

        protected virtual void CheckReload()
        {
            m_timerShot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            m_countShoot++;
            if (m_countShoot == m_magazine)
            {
                StartReload();
            }
        }

    }
}
