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
        protected float m_coolDownCoef;
        protected float m_ShootDelayCoef;

        protected float m_direction;
        protected float m_speed;

        protected SizeF m_bulletSize;

        public virtual float CoolDownCoef
        { 
            get
            { 
                return m_coolDownCoef;
            }
            set
            {
                m_coolDownCoef = value;
            } 
        }

        public virtual float ShootDelayCoef
        {
            get
            {
                return m_ShootDelayCoef;
            }
            set
            {
                m_ShootDelayCoef = value;
            }
        }

        public BaseGun(float direction)
        {
            m_direction = direction;

            m_countShoot = 0;
            m_isCoolDown = false;
            m_timerShoot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            m_startReload = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            CoolDownCoef = 1;
            ShootDelayCoef = 1;

        }

        public virtual void StartReload()
        {
            m_isCoolDown = true;
            m_startReload = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public virtual void Update()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (now - m_startReload >= m_coolDown * m_coolDownCoef && m_isCoolDown)
            {
                EndReload();
            }
        }

        public virtual void EndReload()
        {
            m_countShoot = 0;
            m_isCoolDown = false;
        }

        protected List<Bullet> Shoot(PointF position, Utils.Characters character, Utils.Guns gun)
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (now - m_timerShoot >= m_shootDelay * ShootDelayCoef && !m_isCoolDown)
            {
                m_countShoot++;
                if (m_countShoot == m_magazine)
                {
                    StartReload();
                }
                m_timerShoot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                return new List<Bullet> { new Bullet(position, m_bulletSize, m_direction * m_speed, character, gun) };

            }
            return null;
        }

        public virtual List<Bullet> Shoot(PointF position, Utils.Characters character)
        {
            throw new NotImplementedException();
        }
    }
}
