using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson02
{
    internal class Player
    {
        float m_x;
        float m_y;
        float m_width;
        float m_height;
        float m_speed;

        SolidBrush m_brush;

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

        public Player(float x, float y, float width, float height, float speed, Color color)
        {
            m_x = x;
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

        public bool Collide(Enemy enemy, KeyEventArgs e)
        {
            float tmp_x = m_x;
            float tmp_y = m_y;
            if (e.KeyCode == Keys.Right)
            {
                tmp_x += m_speed;
            }
            if (e.KeyCode == Keys.Down)
            {
                tmp_y += m_speed;
            }
            if (e.KeyCode == Keys.Left)
            {
                tmp_x -= m_speed;
            }
            if (e.KeyCode == Keys.Up)
            {
                tmp_y -= m_speed;
            }

            if(enemy.X <= tmp_x + m_width && 
               enemy.Y <= tmp_y + m_height &&
               tmp_y <= enemy.Y + enemy.Height && 
               tmp_x <= enemy.X + enemy.Width)
            {
                return true;
            }

            return false;
        }

        public void Move(KeyEventArgs e, int width, int height)
        {
            
            if (e.KeyCode == Keys.Right && m_x + m_width + m_speed <= width)
            {
                m_x += m_speed;
            }
            if (e.KeyCode == Keys.Down && m_y + m_height + m_speed <= height)
            {
                m_y += m_speed;
            }
            if (e.KeyCode == Keys.Left && m_x - m_speed > 0)
            {
                m_x -= m_speed;
            }
            if (e.KeyCode == Keys.Up && m_y - m_speed > 0)
            {
                m_y -= m_speed;
            }
        }
    }
}
