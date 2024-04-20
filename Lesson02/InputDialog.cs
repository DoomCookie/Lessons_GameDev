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
    public partial class InputDialog : Form
    {
        public string Output { get; set; }

        public InputDialog(string title, string caption)
        {
            InitializeComponent();
            this.Text = title;
            lbl_input.Text = caption;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Approve();
        }

        void Approve()
        {
            Output = tb_input.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void tb_input_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Approve();
            }
        }
    }
}
