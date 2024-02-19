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
        PointF m_position;
        SizeF m_size;
        public PointF Position { get { return m_position; } }
        public SizeF Size { get { return m_size; } }

        float m_speed;

        SolidBrush m_brush;

        public Player(PointF position, SizeF size, float speed, Color color)
        {
            m_position = position;
            m_size = size;
            m_speed = speed * Settings.Interval;
            m_brush = new SolidBrush(color);
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(m_brush, m_position.X,
                            m_position.Y, m_size.Width, m_size.Height);
        }

        public bool Collide(Enemy enemy)
        {
            PointF tmpPoint = m_position;
            if (Utils.KeysState["Right"])
            {
                tmpPoint.X += m_speed;
            }
            if (Utils.KeysState["Down"])
            {
                tmpPoint.Y += m_speed;
            }
            if (Utils.KeysState["Left"])
            {
                tmpPoint.X -= m_speed;
            }
            if (Utils.KeysState["Up"])
            {
                tmpPoint.Y -= m_speed;
            }

            if(enemy.Position.X <= tmpPoint.X + m_size.Width && 
               enemy.Position.Y <= tmpPoint.Y + m_size.Height &&
               tmpPoint.Y <= enemy.Position.Y + enemy.Size.Height && 
               tmpPoint.X <= enemy.Position.X + enemy.Size.Width)
            {
                return true;
            }

            return false;
        }

        public void Move()
        {
            
            if (Utils.KeysState["Right"] && m_position.X + m_size.Width + m_speed <= Settings.WindowSize.Width)
            {
                m_position.X += m_speed;
            }
            if (Utils.KeysState["Down"] && m_position.Y + m_size.Height + m_speed <= Settings.WindowSize.Height)
            {
                m_position.Y += m_speed;
            }
            if (Utils.KeysState["Left"] && m_position.X - m_speed > 0)
            {
                m_position.X -= m_speed;
            }
            if (Utils.KeysState["Up"] && m_position.Y - m_speed > 0)
            {
                m_position.Y -= m_speed;
            }
        }
    }
}
