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
        static int m_score = 0;
        static public int Score
        {
            get
            {
                return m_score;
            }
        }

        ScoreCounter()
        {

        }

        static public void AddScore(int score)
        {
            m_score += score;
            if(m_score < 0)
            {
                m_score = 0;
            }
        }

        static public void Reset()
        {
            m_score = 0;
        }

        static public void Draw(Graphics g)
        {
            g.DrawString(m_score.ToString(), m_font, m_brush, Settings.WindowSize.Width - 100, 10);
        }

    }
}
