using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace Lesson02
{
    class Data
    {
        public string NickName { get; set; }
        public int Score { get; set; }
    }

    internal class LeaderBoard
    {
        /* TODO:
         *  Обновлять данные после проигрыша
         *  обновлять данные в файле
         *  
         * 
         * 
         */
        static string m_path = "LeaderBoard.txt";
        static List<Data> m_data = new List<Data>();


        static Brush m_brush = new SolidBrush(Color.FromArgb(180, 60, 60, 60));
        static Brush m_brushText = new SolidBrush(Color.Yellow);
        static Font m_font = new Font(FontFamily.GenericSerif, 16);
        static SizeF m_size;

        private LeaderBoard() { }

        public static void Start()
        {
            m_size = new SizeF(Settings.WindowSize.Width * 0.6f, Settings.WindowSize.Height * 0.8f);
            if (!File.Exists(m_path))
            {
                FileStream s = File.Create(m_path);
                s.Close();
            }
            using (StreamReader sr = new StreamReader(m_path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    Data data = new Data { NickName = columns[1], Score = Convert.ToInt32(columns[2]) };
                    m_data.Add(data);
                }
            }

        }

        public static void AddScore(string nickname, int score)
        {
            Data newData = new Data { NickName = nickname, Score = score };
            for(int i = 0; i < m_data.Count; i++)
            {
                if (m_data[i].Score <= score)
                {
                    m_data.Insert(i, newData);
                    break;
                }
            }
        }

        public static void Draw(Graphics g)
        {
            g.FillRectangle(m_brush, Settings.WindowSize.Width * 0.2f, Settings.WindowSize.Height * 0.1f, m_size.Width, m_size.Height);
            g.DrawString("Leader Board", new Font(FontFamily.GenericSerif, 20), new SolidBrush(Color.Red), new PointF(Settings.WindowSize.Width * 0.22f, Settings.WindowSize.Height * 0.15f));
            PointF curPoint = new PointF(Settings.WindowSize.Width * 0.25f, Settings.WindowSize.Height * 0.25f);
            for (int i = 0; i < m_data.Count; ++i)
            {

                string line = $"{i}. {m_data[i].NickName} - {m_data[i].Score}";
                g.DrawString(line, m_font, m_brushText, curPoint);
                curPoint.Y += 30;
            }
        }

        public static void Save()
        {
            using (StreamWriter sw = new StreamWriter(m_path))
            {
                for(int i = 0; i < m_data.Count; i++)
                {
                    sw.WriteLine($"{i + 1},{m_data[i].NickName},{m_data[i].Score}");
                }
            }
        }
    }
}
