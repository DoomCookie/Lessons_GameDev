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
            Settings.InitSettings(new SizeF(Width - 17, Height - 34), m_timer.Interval);

            m_player = new Player(new PointF(50, 50), new SizeF(50, 50), 100, Color.Blue);

            m_enemys = new Enemy[10];
            Random rnd = new Random();
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                PointF spawnPoint = new PointF(rnd.Next(0, Width - 17 - 40),
                    rnd.Next(-1000, -50));
                SizeF spawnSize = new SizeF(40, 40);
                m_enemys[i] = new Enemy(spawnPoint, spawnSize, 100, Color.Red);
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
            Utils.SetKeyDown(e);
        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            Refresh();
            PointF lastPosition = m_player.Position;
            m_player.Move();
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                if(Utils.IsCollide(m_player, m_enemys[i]))
                {
                    m_player.Position = lastPosition;
                    break;
                }
            }
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                PointF lastPostion = m_enemys[i].Position;
                m_enemys[i].Move();
                if (Utils.IsCollide(m_enemys[i], m_player))
                {
                    m_enemys[i].Position = lastPostion;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Utils.SetKeyUp(e);
        }
    }
}
