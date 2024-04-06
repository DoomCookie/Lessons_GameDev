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
        Utils.GameState m_gameState = Utils.GameState.IsGame;
        // Rectnagle 2
        Enemy[] m_enemys;
        List<Bullet> m_bullets;

        PointF m_titlePos;
        Brush m_brush;
        Font m_font;
        public Form1()
        {
            InitializeComponent();
            Settings.InitSettings(new SizeF(Width - 17, Height - 34), m_timer.Interval);

            m_titlePos = new PointF((Width / 2) - 80, (Height / 4) - 0);
            m_brush = new SolidBrush(Color.Red);
            m_font = new Font(FontFamily.GenericSerif, 28);
            m_player = new Player(new PointF(50, Height - 150), new SizeF(50, 50), 250, Color.Blue);

            m_bullets = new List<Bullet>();
            m_enemys = new Enemy[10];
            Random rnd = new Random();
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                PointF spawnPoint = new PointF(rnd.Next(0, Width - 17 - 40),
                    rnd.Next(-1000, -50));
                SizeF spawnSize = new SizeF(40, 40);
                m_enemys[i] = new Enemy(spawnPoint, spawnSize, 100, Color.Green);
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
            List<Bullet> delete = new List<Bullet>();
            foreach (Bullet bullet in m_bullets)
            {
                bullet.Draw(e.Graphics);
                if (bullet.Position.Y < -15)
                {
                    delete.Add(bullet);
                }
            }
            foreach (Bullet bullet in delete)
            {
                m_bullets.Remove(bullet);
            }
            FPSCounter.Draw(e.Graphics);
            ScoreCounter.Draw(e.Graphics);
            LifeCounter.Draw(e.Graphics);
            if (m_gameState != Utils.GameState.IsGame)
            {
                e.Graphics.DrawString("You Lose!", m_font, m_brush, m_titlePos);
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
            switch(m_gameState)
            {
                case Utils.GameState.IsGame:
                    for (int i = 0; i < m_enemys.Length; ++i)
                    {
                        m_enemys[i].Move();
                    }
                    m_player.Move();
                    for (int i = 0; i < m_enemys.Length; ++i)
                    {
                        if(Utils.IsCollide(m_player, m_enemys[i]))
                        {
                            m_gameState = Utils.GameState.Lose;
                            break;
                        }
                    }
                    if (Utils.KeysState["Space"])
                    {
                        Bullet bullet = m_player.Shoot();
                        if(bullet != null)
                        {
                            m_bullets.Add(bullet);
                        }
                    }
                    List<Bullet> delete = new List<Bullet>();
                    
                    for (int i = 0; i < m_bullets.Count; i++)
                    {
                        m_bullets[i].Move();
                        for(int j = 0; j < m_enemys.Length; j++)
                        {
                            if (Utils.IsCollide(m_bullets[i], m_enemys[j]))
                            {
                                ScoreCounter.Hit(m_enemys[j].Bounty); 
                                delete.Add(m_bullets[i]);
                                Random rnd = new Random();
                                PointF spawnPoint = new PointF(rnd.Next(0, Width - 17 - 40), rnd.Next(-1000, -50));
                                m_enemys[j].Position = spawnPoint;
                            }
                        }
                    }
                    foreach (Bullet bullet in delete)
                    {
                        m_bullets.Remove(bullet);
                    }
                    if(!LifeCounter.IsAlive())
                    {
                        m_gameState = Utils.GameState.Lose;
                    }
                    break;
                case Utils.GameState.Lose:
                    m_gameState = Utils.GameState.EndGame;
                    break;
                case Utils.GameState.EndGame:
                    if (Utils.KeysState["Space"])
                    {
                        Restart();
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Utils.SetKeyUp(e);
        }

        void Restart()
        {
            LifeCounter.Reset();
            m_bullets.Clear();
            ScoreCounter.Reset();
            m_player.Position = new PointF((Width / 2) - m_player.Size.Width / 2, Height - 150);
            Random rnd = new Random();
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                PointF spawnPoint = new PointF(rnd.Next(0, Width - 17 - 40),
                    rnd.Next(-1000, -50));
                m_enemys[i].Position = spawnPoint;
            }
            m_gameState = Utils.GameState.IsGame;
        }
    }
}
