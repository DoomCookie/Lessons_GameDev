using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lesson02
{
    internal class Game
    {
        // Rectnagle 1
        static Player m_player;
        static Utils.GameState m_gameState = Utils.GameState.IsGame;
        // Rectnagle 2
        static Enemy[] m_enemys;
        static List<Bullet> m_bullets;

        static PointF m_titlePos;
        static Brush m_brush;
        static Font m_font;

        private Game() { }

        public static void Start()
        {
            m_titlePos = new PointF((Settings.WindowSize.Width / 2) - 80, (Settings.WindowSize.Height / 4) - 0);
            m_brush = new SolidBrush(Color.Red);
            m_font = new Font(FontFamily.GenericSerif, 28);
            m_player = new Player(new PointF(50, Settings.WindowSize.Height - 150), new SizeF(50, 50), 250, Color.Blue);

            m_bullets = new List<Bullet>();
            m_enemys = new Enemy[10];
            SizeF spawnSize = new SizeF(40, 40);
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                if (Utils.rnd.NextDouble() <= 0.3)
                {
                    m_enemys[i] = new ShootEnemy(new PointF(0, 0), spawnSize, 100, Color.Brown);
                }
                else
                {
                    m_enemys[i] = new Enemy(new PointF(0, 0), spawnSize, 100, Color.Green);
                }
                Utils.SpawnEnemy(m_enemys, i);
            }
        }

        public static void Draw(Graphics g)
        {
            m_player.Draw(g);
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                m_enemys[i].Draw(g);
            }
            List<Bullet> delete = new List<Bullet>();
            foreach (Bullet bullet in m_bullets)
            {
                bullet.Draw(g);
                if (bullet.Position.Y < -15)
                {
                    delete.Add(bullet);
                }
            }
            foreach (Bullet bullet in delete)
            {
                m_bullets.Remove(bullet);
            }
            FPSCounter.Draw(g);
            ScoreCounter.Draw(g);
            LifeCounter.Draw(g);
            if (m_gameState != Utils.GameState.IsGame)
            {
                g.DrawString("You Lose!", m_font, m_brush, m_titlePos);
            }
        }

        public static void Update()
        {
            switch (m_gameState)
            {
                case Utils.GameState.IsGame:
                    for (int i = 0; i < m_enemys.Length; ++i)
                    {
                        m_enemys[i].Move();
                        if (m_enemys[i] is ShootEnemy shootEnemy)
                        {
                            Bullet bullet = shootEnemy.Shoot();
                            if (bullet != null)
                            {
                                m_bullets.Add(bullet);
                            }
                        }
                        if (m_enemys[i].Position.Y > Settings.WindowSize.Height + 10)
                        {
                            Utils.SpawnEnemy(m_enemys, i);
                        }
                    }
                    m_player.Move();
                    for (int i = 0; i < m_enemys.Length; ++i)
                    {
                        //if(Utils.IsCollide(m_player, m_enemys[i]))
                        //{
                        //    m_gameState = Utils.GameState.Lose;
                        //    break;
                        //}
                    }
                    if (Utils.KeysState["Space"])
                    {
                        Bullet bullet = m_player.Shoot();
                        if (bullet != null)
                        {
                            m_bullets.Add(bullet);
                        }
                    }
                    List<Bullet> delete = new List<Bullet>();

                    for (int i = 0; i < m_bullets.Count; i++)
                    {
                        m_bullets[i].Move();
                        for (int j = 0; j < m_enemys.Length; j++)
                        {
                            if (Utils.IsCollide(m_bullets[i], m_enemys[j]) && m_bullets[i].CharacterOwner == Utils.Characters.Player)
                            {
                                ScoreCounter.Hit(m_enemys[j].Bounty);
                                delete.Add(m_bullets[i]);
                                Utils.SpawnEnemy(m_enemys, j);
                            }
                        }
                        if (Utils.IsCollide(m_player, m_bullets[i]) && m_bullets[i].CharacterOwner == Utils.Characters.Enemy)
                        {
                            m_gameState = Utils.GameState.Lose;
                        }
                    }
                    foreach (Bullet bullet in delete)
                    {
                        m_bullets.Remove(bullet);
                    }
                    if (!LifeCounter.IsAlive())
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

        static void Restart()
        {
            LifeCounter.Reset();
            m_bullets.Clear();
            ScoreCounter.Reset();
            m_player.Position = new PointF((Settings.WindowSize.Width / 2) - m_player.Size.Width / 2, Settings.WindowSize.Height - 150);
            Random rnd = new Random();
            for (int i = 0; i < m_enemys.Length; ++i)
            {
                Utils.SpawnEnemy(m_enemys, i);
            }
            m_gameState = Utils.GameState.IsGame;
        }
    }
}
