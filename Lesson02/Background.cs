using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class Background
    {
        private Background() { }

        static Bitmap m_sprite = Properties.Resources.background;
        static SizeF m_size = Settings.WindowSize;


        static public void Draw(Graphics g)
        {
            
            g.DrawImage(m_sprite, 0, 0, m_size.Width, m_size.Height);
        }
    }
}
