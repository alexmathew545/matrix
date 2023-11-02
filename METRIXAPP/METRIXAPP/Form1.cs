using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace METRIXAPP
{
    public partial class Form1 : Form
    {
        public int m_width; 

        public int m_Height; 

        public int m_NoOfRows; 

        public int m_NoOfCols; 

        public int m_XOffset; 
        public int m_YOffset;

        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 50;
        public const int DEFAULT_NO_ROWS = 2;
        public const int DEFAULT_NO_COLS = 2;
        public const int DEFAULT_WIDTH = 60;
        public const int DEFAULT_HEIGHT = 60;
        public int rc = 8;
        public void Initialize()
        {
            m_NoOfRows = DEFAULT_NO_ROWS;
            m_NoOfCols = DEFAULT_NO_COLS;
            m_width = DEFAULT_WIDTH;
            m_Height = DEFAULT_HEIGHT;
            m_XOffset = DEFAULT_X_OFFSET;
            m_YOffset = DEFAULT_Y_OFFSET;

        }
        public Form1()
        {
            Initialize();
            InitializeComponent();
            status = false;
        }
        void ondraw()
        {

            Graphics boardLayout = this.CreateGraphics();

            Pen layoutPen = new Pen(Color.Black);
            Pen layoutPen1 = new Pen(Color.White);
            layoutPen.Width = 3;
            layoutPen1.Width = 3;
            int counterflag = 2;
            while (counterflag <= rc)
            {
                Thread.Sleep(1000); 
                if (counterflag != rc)
                {
                    m_NoOfRows = counterflag;
                    m_NoOfCols = counterflag;
                    int X = DEFAULT_X_OFFSET;
                    int Y = DEFAULT_Y_OFFSET;
                    
                    for (int i = 0; i <= m_NoOfRows; i++)
                    {
                        boardLayout.DrawLine(layoutPen, X, Y, X + this.m_width * this.m_NoOfCols, Y);
                        Y = Y + m_Height;
                    }

                   
                    X = DEFAULT_X_OFFSET;
                    Y = DEFAULT_Y_OFFSET;
                    for (int j = 0; j <= m_NoOfCols; j++)
                    {
                        boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_Height * this.m_NoOfRows);
                        X = X + this.m_width;
                    }
                    counterflag++;
                }
                else
                {
                    counterflag = 2;

                    Invalidate();


                }


            }

        }
        private void sTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            flag = new Thread(new ThreadStart(ondraw));
            flag.Start();
            Invalidate();
        }

        private void pAUSEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            flag.Suspend();


        }
        public void setselectin(int selection)
        {
            
        }
        private void sTOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag.Resume();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            setselectin(2);
            SELECTION.Text = "2*2";
            rc = 3;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SELECTION.Text = "3*3";
            rc = 4;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SELECTION.Text = "4*4";
            rc = 5;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SELECTION.Text = "5*5";
            rc = 6;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SELECTION.Text = "6*6";
            rc = 7;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            SELECTION.Text = "7*7";
            rc = 8;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            SELECTION.Text = "8*8";
            rc = 9;
        }

        private void sTARTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            flag = new Thread(new ThreadStart(ondraw));
            flag.Start();
            Invalidate();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void mENUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
