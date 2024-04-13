﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    internal class Enemy : Character
    {
        int m_framesCount = 0;
        public virtual int Bounty { get; } = 100;

        public Enemy(PointF position, SizeF size, float speed, Color color) : base(position, size, speed, color)
        {
            m_sprite = new Bitmap("D:/C#/Кириченко Артем/Lesson02/Lesson02/media/spritesheets/enemy-big.png");
            m_frameSize = new SizeF(32, 32);
            m_frameRect = new RectangleF(0, 0, 32, 32);
            m_frameCount = 0;
            m_frames = new Bitmap[2];
            for(int i = 0; i < m_frames.Length; i++)
            {
                RectangleF rect = new RectangleF(i * m_frameSize.Width, 0, m_frameSize.Width, m_frameSize.Height);
                m_frames[i] = m_sprite.Clone(rect, m_sprite.PixelFormat);
            }
        }

        override public void Move()
        {
            base.Move();
            m_position.Y += m_speed;
            if(m_position.Y > Settings.WindowSize.Height + 10)
            {
                LifeCounter.Hit();
            }
        }
    }
}
