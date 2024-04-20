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
        
        public Form1()
        {
            InitializeComponent();
            Settings.InitSettings(new SizeF(Width - 17, Height - 34), m_timer.Interval);
            
        }

        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Game.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Utils.SetKeyDown(e);
        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            Refresh();
            Game.Update();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Utils.SetKeyUp(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InputDialog id = new InputDialog("Nickname", "Введите ваш Nickname");
            if (id.ShowDialog() == DialogResult.Cancel)
            {
                Close();
            };
            Settings.NickName = id.Nickname;
            id.Dispose();
            Game.Start();

            m_timer.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.Close();
        }
    }
}
