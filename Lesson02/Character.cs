using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class Character
    {
        SolidBrush m_brush;

        protected PointF m_position;
        protected SizeF m_size;
        protected float m_speed;

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

        public void Draw(Graphics g)
        {
            g.FillRectangle(m_brush, m_position.X, m_position.Y,
                            m_size.Width, m_size.Height);
        }

        virtual public void Move() { }
    }
}
