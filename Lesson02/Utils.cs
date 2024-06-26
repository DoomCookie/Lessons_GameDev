﻿using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace Lesson02
{
    class Settings
    {
        public static SizeF WindowSize { set; get; }
        public static float Interval { get; set; }

        public static void InitSettings(SizeF size, float interval)
        {
            WindowSize = size;
            Interval = interval / 1000;
        }
    }

    class Utils
    {
        public enum GameState
        {
            IsGame,
            Win,
            Lose,
            EndGame
        }

        public static Random rnd = new Random();

        public static Dictionary<string, bool> KeysState { set; get; } = new Dictionary<string, bool>()
        {
            {"Up", false },
            {"Down", false },
            {"Left", false },
            {"Right", false },
            {"Space", false }
        };

        public static void SetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                KeysState["Up"] = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                KeysState["Down"] = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                KeysState["Left"] = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                KeysState["Right"] = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                KeysState["Space"] = true;
            }
        }

        public static void SetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                KeysState["Up"] = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                KeysState["Down"] = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                KeysState["Left"] = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                KeysState["Right"] = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                KeysState["Space"] = false;
            }
        }

        public static void SpawnEnemy(Enemy[] enemys, int i)
        {
            bool isValidSpawn = false;
            PointF spawnPoint = new PointF(0, 0);
            while(!isValidSpawn)
            {
                spawnPoint = new PointF(rnd.Next(20, Convert.ToInt32(Settings.WindowSize.Width - enemys[i].Size.Width - 20)), rnd.Next(-1000, -50));
                PointF centerEnemy = new PointF(spawnPoint.X + enemys[i].Size.Width / 2, spawnPoint.Y + enemys[i].Size.Height / 2);
                isValidSpawn = true;
                for(int j = 0; j < enemys.Length; j++)
                {
                    if (enemys[j] == null || i == j)
                    {
                        continue;
                    }
                    PointF centerOther = new PointF(enemys[j].Position.X + enemys[j].Size.Width / 2, enemys[j].Position.Y + enemys[j].Size.Height / 2);
                    PointF distVec = new PointF(centerEnemy.X - centerOther.X, centerEnemy.Y - centerOther.Y);
                    double dist = Math.Sqrt(distVec.X * distVec.X + distVec.Y * distVec.Y);
                    if(dist < enemys[i].Size.Width + enemys[j].Size.Width)
                    {
                        isValidSpawn = false;
                        break;
                    }
                }

            }
            enemys[i].Position = spawnPoint;
        }

        public static bool IsCollide(Character first, Character second)
        {
            if (first.Position.X <= second.Position.X + second.Size.Width &&
                first.Position.Y <= second.Position.Y + second.Size.Height &&
                second.Position.Y <= first.Position.Y + first.Size.Height &&
                second.Position.X <= first.Position.X + first.Size.Width)
            {
                return true;
            }
            return false;
        }
    }


}
