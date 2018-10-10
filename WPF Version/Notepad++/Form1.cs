using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad__
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.begin();
            //mw.render = 1;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.end();
            //mw.render = 1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
