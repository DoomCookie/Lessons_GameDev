using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    internal class Enemy
    {
        PointF m_position;
        SizeF m_size;
        public PointF Position { get { return m_position; } }
        public SizeF Size { get { return m_size; } }

        float m_speed;

        SolidBrush m_brush;

        public Enemy(PointF position, SizeF size, float speed, Color color)
        {
            m_position = position;
            m_size = size;
            m_speed = speed * Settings.Interval;
            m_brush = new SolidBrush(color);
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(m_brush, m_position.X, m_position.Y,
                            m_size.Width, m_size.Height);
        }

        public bool Collide(Player player)
        {
            float tmp_x = m_position.X + m_speed;
            float tmp_y = m_position.Y;
            if (player.Position.X <= tmp_x + m_size.Width && 
                player.Position.Y <= tmp_y + m_size.Height &&
                tmp_y <= player.Position.Y + player.Size.Height && 
                tmp_x <= player.Position.X + player.Size.Width)
            {
                return true;
            }
            return false;
        }

        public void Move()
        {
            m_position.Y += m_speed;
            if(m_position.Y > Settings.WindowSize.Height + 10)
            {
                Random rnd = new Random();
                m_position.Y = rnd.Next(-1000, -50);
                m_position.X = rnd.Next(0, (int)(Settings.WindowSize.Width - m_size.Width));
            }
        }
    }
}
