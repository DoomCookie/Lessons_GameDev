using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class LifeCounter
    {
        static Brush m_brush = new SolidBrush(Color.Red);
        static int m_life = 5;
        static int m_size = 20;
        static int m_offset = 5;
        static PointF m_startPos = new PointF(Settings.WindowSize.Width / 2 - m_size * 2.5f - 2 * m_offset, 10);

        public static void Hit()
        {
            m_life--;
        }

        public static void LifeUp()
        {
            if (m_life < 5)
            {
                m_life++;
            }
        }

        public static bool IsAlive()
        {
            return m_life > 0;
        }

        public static void Reset()
        {
            m_life = 5;
        }

        public static void Draw(Graphics g)
        {
            float x = m_startPos.X;
            for(int i = 0; i < m_life; i++)
            {
                g.FillEllipse(m_brush, x, m_startPos.Y, m_size, m_size);
                x += m_size + m_offset;
            }
        }
    }
}
