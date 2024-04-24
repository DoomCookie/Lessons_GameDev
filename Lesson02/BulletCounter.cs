using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class BulletCounter
    {
        static float m_size = 10;
        static int m_offset = 5;

        static SizeF m_frameSize = new SizeF(5, 5);
        static Bitmap m_sprite = new Bitmap("media/spritesheets/laser-bolts.png").Clone(
            new RectangleF(6, 6, m_frameSize.Width, m_frameSize.Height),
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        static PointF m_startPoint = new PointF(Settings.WindowSize.Width * 0.05f, Settings.WindowSize.Height * 0.95f);

        BulletCounter() { }

        public static void Draw(Graphics g, int count)
        {
            PointF pos = m_startPoint;
            for(int i = 0; i < count; i++)
            {
                g.DrawImage(m_sprite, pos.X, pos.Y, m_size, m_size);
                pos.X += m_size + m_offset;
            }
        }
    }
}
