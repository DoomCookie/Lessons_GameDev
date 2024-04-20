using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class Background
    {
        static Bitmap m_sprite = new Bitmap("media/River/PNG/background.png");
        static SizeF m_size = Settings.WindowSize;

        public static void Draw(Graphics g)
        {
            g.DrawImage(m_sprite, 0, 0, m_size.Width, m_size.Height);
        }
    }
}
