using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class BulletCounter
    {
        static float m_offset = 5;
        static float m_size = 10;
        static SizeF m_frameSize = new SizeF(5, 5);
        static Bitmap m_sprite = new Bitmap("media/spritesheets/laser-bolts.png").Clone(
                new RectangleF(6, 7, m_frameSize.Width, m_frameSize.Height),
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        static PointF m_startPoint = new PointF(Settings.WindowSize.Width * 0.05f, Settings.WindowSize.Height * 0.95f);

        BulletCounter()
        {

        }

        public static void Draw(Graphics g, int count)
        {
            float x = m_startPoint.X;
            for (int i = 0; i < count; i++)
            {
                g.DrawImage(m_sprite, x, m_startPoint.Y, m_size, m_size);
                x += m_size + m_offset;
            }
        }
    }
}
