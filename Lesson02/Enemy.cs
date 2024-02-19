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
        float m_x;
        float m_y;
        float m_width;
        float m_height;
        float m_speed;

        float m_startY;

        public float X
        {
            get { return m_x; }
        }

        public float Y
        {
            get { return m_y; }
        }

        public float Width { get { return m_width; } }
        public float Height { get { return m_height; } }

        SolidBrush m_brush;

        public Enemy(float x, float y, float width, float height, float speed, Color color)
        {
            m_x = x;
            m_startY = y;
            m_y = y;
            m_width = width;
            m_height = height;
            m_speed = speed;
            m_brush = new SolidBrush(color);
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(m_brush, m_x, m_y, m_width, m_height);
        }

        public bool Collide(Player player)
        {
            float tmp_x = m_x + m_speed;
            float tmp_y = m_y;
            if (player.X <= tmp_x + m_width && player.Y <= tmp_y + m_height &&
                tmp_y <= player.Y + player.Height && tmp_x <= player.X + player.Width)
            {
                return true;
            }
            return false;
        }

        public void Move(int width, int height)
        {
            m_y += m_speed;
            if(m_y > height + 10)
            {
                Random rnd = new Random();
                m_y = rnd.Next(-1000, -50);
                m_x = rnd.Next(0, width - Convert.ToInt32(m_width));
            }
        }
    }
}
