using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        static Brush m_redBrush = new SolidBrush(Color.Red);
        static Brush m_brushText = new SolidBrush(Color.Yellow);
        static Font m_font = new Font(FontFamily.GenericSerif, 16);
        static SizeF m_size;

        static int m_current;

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

        public static void Add(string nickname, int score)
        {
            Data newData = new Data { NickName=nickname, Score = score };
            bool isAdded = false;
            for(int i = 0; i < m_data.Count; i++)
            {
                if (m_data[i].Score <= newData.Score)
                {
                    m_data.Insert(i, newData);
                    isAdded = true;
                    m_current = i;
                    break;
                }
            }
            if(!isAdded)
            {
                m_data.Add(newData);
                m_current = m_data.Count - 1;
            }
        }

        public static void Draw(Graphics g)
        {
            g.FillRectangle(m_brush, Settings.WindowSize.Width * 0.2f, Settings.WindowSize.Height * 0.1f, m_size.Width, m_size.Height);
            g.DrawString("Leader Board", new Font(FontFamily.GenericSerif, 20), m_redBrush, new PointF(Settings.WindowSize.Width * 0.22f, Settings.WindowSize.Height * 0.15f));
            PointF curPoint = new PointF(Settings.WindowSize.Width * 0.25f, Settings.WindowSize.Height * 0.25f);
            for(int i = 0; i < 10; i++)
            {
                if(i == 8 && m_current > 10)
                {
                    g.DrawString("...", m_font, m_brushText, curPoint);
                    curPoint.Y += 30;
                    string tmp = $"{m_current + 1}. {m_data[i].NickName} - {m_data[m_current].Score}";
                    g.DrawString(tmp, m_font, m_redBrush, curPoint);
                    break;
                }
                string line = $"{i + 1}. {m_data[i].NickName} - {m_data[i].Score}";
                if(i == m_current)
                {
                    g.DrawString(line, m_font, m_redBrush, curPoint);
                }
                else
                {
                    g.DrawString(line, m_font, m_brushText, curPoint);
                }
                curPoint.Y += 30;
            }
        }

        public static void Save()
        {
            using(StreamWriter sw = new StreamWriter(m_path))
            {
                for(int i = 0; i < m_data.Count; i++)
                {
                    sw.WriteLine($"{i + 1},{m_data[i].NickName},{m_data[i].Score}");
                }
            }
        }
    }
}
