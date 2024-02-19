using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson02
{
    public partial class Form1 : Form
    {
        // Rectnagle 1
        Player m_player;

        // Rectnagle 2
        Enemy[] m_enemys;
        public Form1()
        {
            InitializeComponent();

            m_player = new Player(50, 50, 40, 40, 100 * Convert.ToSingle(m_timer.Interval) / 1000, Color.Blue);
            m_enemys = new Enemy[10];
            Random rnd = new Random();
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                m_enemys[i] = new Enemy(rnd.Next(0, Width - 17 - 40),
                    rnd.Next(-1000, -50), 40, 40, 100 * Convert.ToSingle(m_timer.Interval) / 1000, Color.Red);
            }

            m_timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            m_player.Draw(e.Graphics);
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                m_enemys[i].Draw(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            m_player.Move(e, Width - 17, Height - 34);
        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            Refresh();
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                m_enemys[i].Move(Width - 17, Height - 34);
            }
        }
    }
}
