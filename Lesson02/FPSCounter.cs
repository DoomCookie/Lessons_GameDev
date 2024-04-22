using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class FPSCounter
    {
        static Brush m_brush = new SolidBrush(Color.White);
        static Font m_font = new Font(FontFamily.GenericSerif, 15);
        static long m_lastFrameTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        static long m_fps = 0;
        static int m_fpsCount = 0;
        static long m_fpsSum = 0;

        static void CountFPS()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            long delta = now - m_lastFrameTime + 1;
            m_lastFrameTime = now;
            long fps = 1000 / delta;
            m_fpsCount++;
            m_fpsSum += fps;
            if(m_fpsCount > 30)
            {
                m_fps = m_fpsSum / m_fpsCount;
                m_fpsCount = 0;
                m_fpsSum = 0;
            }
        }

        public static void Draw(Graphics e)
        {
            e.DrawString(m_fps.ToString(), m_font, m_brush, new PointF(10, 10));
            CountFPS();
        }
    }
}
