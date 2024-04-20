using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class ScoreCounter
    {
        static Brush m_brush = new SolidBrush(Color.Black);
        static Font m_font = new Font(FontFamily.GenericSerif, 15);
        static PointF m_point = new PointF(Settings.WindowSize.Width - 50, 10);
        static int m_score = 0;
        public static int Score { get { return m_score; } }

        public static void Hit(int score)
        {
            m_score += score;
        }

        public static void Reset()
        {
            m_score = 0;
        }

        public static void Draw(Graphics g)
        {
            g.DrawString(m_score.ToString(), m_font, m_brush, m_point);
        }
    }
}
