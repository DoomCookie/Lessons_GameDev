using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lesson02
{
    internal class Character
    {
        protected Brush m_brush;

        protected PointF m_position;
        protected SizeF m_size;
        protected float m_speed;

        protected Bitmap m_sprite;
        protected RectangleF m_frameRect;
        protected SizeF m_frameSize;
        protected Bitmap[] m_frames;
        protected int m_frameCount = 0;
        int m_framesCount = 0;

        public PointF Position
        {
            get { return m_position; }
            set { m_position = value; }
        }
        public SizeF Size { get { return m_size; } }

        public Character(PointF position, SizeF size, float speed, Color color)
        {
            m_position = position;
            m_size = size;
            m_speed = speed * Settings.Interval;
            m_brush = new SolidBrush(color);
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawImage(m_frames[m_frameCount % m_frames.Length], m_position.X, m_position.Y, m_size.Width, m_size.Height);
            m_framesCount++;
            if (m_framesCount % 15 == 0)
            {
                m_frameCount++;
            }
        }

        virtual public void Move() { }
    }
}
