using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WinProj_ProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //模擬進度條
        private void Send() 
        {
            int i = 0;
            while (i <= 100) 
            {
                //顯示進度訊息
                this.ShowPro(i);
                i++; //模擬發送多少
                Thread.Sleep(100);

            }
            Thread.CurrentThread.Abort();
        }
        private delegate void ProgressBarShow(int i);
        private void ShowPro(int value) 
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ProgressBarShow(ShowPro), value);
            }
            else 
            {
                this.progressBar1.Value = value;
                this.label1.Text = value + "% Processing...";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thread=new Thread(new ThreadStart(Send));//模擬進度條
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
