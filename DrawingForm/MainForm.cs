using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobotLib;

namespace DrawingForm
{
    public partial class MainForm : Form
    {
        DrawingTools DT;

        bool mouseIsDown;

        Graphics g;
        Pen pen;
        int x = -100000;
        int y = -100000;

        List<double[]> dotsList = new List<double[]>();
        
        

        public MainForm()
        {
            InitializeComponent();
            SetAppearance();


            int scaleFactor = 2;
            int a = 85*scaleFactor;
            int b = 85*scaleFactor;
            double xMax = (a + b) * scaleFactor;

            g = panel1.CreateGraphics();
            pen = new Pen(Color.Gray, 5);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            

            DT = new DrawingTools(a, b);
            DT.Init();

        }

        private void SetAppearance()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.CenterToScreen();
        }

        public void addPoint(double alfa, double beta)
        {
            double[] position = new double[2];
            position[0] = alfa;
            position[1] = beta;
            dotsList.Add(position);
        }

       
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && !Double.IsNaN(DT.GetBeta(340 - e.Location.Y, e.Location.X)))
            {
                addPoint(x, y);
                x = e.X;
                y = e.Y;
                g.DrawLine(pen, new Point(x+1, y+1), e.Location);
                addPoint(DT.GetAlfa(340 - e.Location.Y, e.Location.X), DT.GetBeta(340 - e.Location.Y, e.Location.X));
                mouseIsDown = true;
                panel1.Cursor = Cursors.Cross;
            }
                
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            x = -100000; y = -100000;
            panel1.Cursor = Cursors.Default;
            addPoint(x, y);
            this.Invalidate();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown && x != -10000 && y != -10000)
            {
                if (Double.IsNaN(DT.GetAlfa(340 - e.Location.Y, e.Location.X))) {
                } else {
                    this.lblAlfa.Text = "Alfa: " + DT.GetAlfa(340 - e.Location.Y, e.Location.X).ToString(); 
                }

                if (Double.IsNaN(DT.GetAlfa(340 - e.Location.Y, e.Location.X))) { 
                } else {
                    this.lblBeta.Text = "Beta: " + DT.GetBeta(340 - e.Location.Y, e.Location.X).ToString(); 
                }

                lblX.Text = "X: " + (340 - e.Location.Y).ToString();
                lblY.Text = "Y: " + (e.Location.X).ToString();

                if (Double.IsNaN(DT.GetBeta(340 - e.Location.Y, e.Location.X)))
                {
                    x = e.X;
                    y = e.Y;
                } else {
                    g.DrawLine(pen,new Point(x,y),e.Location);
                    x = e.X;
                    y = e.Y;
                    addPoint(DT.GetAlfa(340 - e.Location.Y, e.Location.X), DT.GetBeta(340 - e.Location.Y, e.Location.X));
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        #region "Effetti UI"
       



        #endregion

        private void panelDataBloks_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush sb = new SolidBrush(Color.YellowGreen);

            int xStart = panelDataBlocks.Location.X;
            int yStart = panelDataBlocks.Location.Y;

            int xMax = 382;
            int yMax = 280;

            int listCount = 0;
            Rectangle rect;
            lblPoints.Text = dotsList.Count.ToString();
            lblSegments.Text = (dotsList.Count(x=> x[0] == -100000)/2).ToString();
            lblPoints.Refresh();
            lblSegments.Refresh();

            for (int i = xStart; i <= xMax+xStart; i += 6  )
            {
                for (int j = yStart; j <= yMax+yStart; j += 6)
                {
                    if( dotsList.Count > 0)
                    {
                        rect = new Rectangle(i, j, 4, 4);
                        if (dotsList[listCount][0] == -100000) { sb.Color = Color.Red; } else { sb.Color = Color.YellowGreen; };
                        e.Graphics.FillRectangle(sb, rect);
                        listCount++;
                        if (listCount >= dotsList.Count()) return ;
                    }
                }
            }

        }

        private void pbClear_Click(object sender, EventArgs e)
        {
            dotsList.Clear();
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);

            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Refresh();
            panel1.Refresh();
        }
    }
}
