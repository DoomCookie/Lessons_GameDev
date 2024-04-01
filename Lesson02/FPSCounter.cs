using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class FPSCounter
    {
        long m_lastFrameTime;
        double m_fpsSum;
        int m_countFrame;
        int m_fps;
        Font m_font;

        Brush m_brush;

        public FPSCounter()
        {
            m_fpsSum = 0;
            m_countFrame = 0;
            m_brush = new SolidBrush(Color.Green);
            m_lastFrameTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            m_font = new Font(FontFamily.GenericSerif, 15);
        }

        void CountFPS()
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            long delta = now - m_lastFrameTime;
            m_lastFrameTime = now;
            double fps = 1000.0 / delta;
            m_fpsSum += fps;
            m_countFrame++;
            if (m_countFrame >= 30)
            {

                m_fps = Convert.ToInt32(m_fpsSum / m_countFrame);

                m_fpsSum = 0;
                m_countFrame = 0;
            }
        }

        public void Draw(Graphics g)
        {
            CountFPS();
            g.DrawString(Convert.ToInt32(m_fps).ToString(), m_font, m_brush, 10, 10);
        }
    }
}
