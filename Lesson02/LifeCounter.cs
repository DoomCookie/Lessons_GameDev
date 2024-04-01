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
        static int m_size = 25;
        static int m_life = 5;
        public static int Life
        { 
            get
            {
                return m_life;
            }
        }

        public static void Reset()
        {
            m_life = 5;
        }

        public static void Hit()
        {
            m_life--;
        }

        public static bool IsAlive()
        {
            return m_life > 0;
        }

        public static void Draw(Graphics g)
        {

            float startPos = Settings.WindowSize.Width / 2 - 2.5f * m_size - 20;
            for(int i = 0; i < m_life; i++)
            {
                g.FillEllipse(m_brush, startPos, 10, m_size, m_size);
                startPos += m_size + 10;
            }
        }
    }
}
