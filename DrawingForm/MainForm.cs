using RobotLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketTools;

namespace DrawingForm
{
    public partial class MainForm : Form
    {

        Thread comThread;
        Thread checkConnThread;
        public WebSocket ws;
        Object lockObj = new object();
        Queue<double[]> queue;
        Consumer c1;
        String wemosIp = "";
        bool abort;


        DrawingTools DT;
        bool mouseIsDown;
        Graphics g;
        Pen pen;
        const int penUp = 100000;
        int x = penUp;
        int y = -penUp;



        int xDraw;
        int yDraw;

        List<double[]> dotsList = new List<double[]>();





        public MainForm()
        {
            InitializeComponent();
            SetAppearance();

            queue = new Queue<double[]>();

            InitConnection();

            c1 = new Consumer(queue, lockObj, ws);
            comThread = new Thread(c1.consume);
            comThread.Start();



            int scaleFactor = 2;
            int a = 85 * scaleFactor;
            int b = 85 * scaleFactor;
            double xMax = (a + b) * scaleFactor;

            g = panel1.CreateGraphics();
            pen = new Pen(Color.Gray, 5);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            DT = new DrawingTools(a, b);
            DT.Init();

        }

        public void InitConnection()
        {
            try
            {
                wemosIp = "192.168.1.188";

                using (ws = new WebSocket("wss://echo.websocket.org/"))
                {
                    ws.Connect();
                    ws.OnMessage += (sender, e) =>
                    {
                        updateLabel(e.Data);
                    };

                    abort = true;
                    checkConnThread = new Thread(() => checkConnection());
                    checkConnThread.Start();

                }
            }
            catch
            {

            }

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
                g.DrawLine(pen, new Point(x + 1, y + 1), e.Location);
                addPoint(DT.GetAlfa(340 - e.Location.Y, e.Location.X), DT.GetBeta(340 - e.Location.Y, e.Location.X));
                mouseIsDown = true;
                panel1.Cursor = Cursors.Cross;
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            x = penUp; y = penUp;
            panel1.Cursor = Cursors.Default;
            if (!Double.IsNaN(DT.GetBeta(340 - e.Location.Y, e.Location.X))) addPoint(x, y);
            this.Invalidate();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            xDraw = e.Location.X;
            yDraw = e.Location.Y;

            if (mouseIsDown && x != penUp && y != penUp)
            {


                if (Double.IsNaN(DT.GetBeta(340 - e.Location.Y, e.Location.X)))
                {
                    mouseIsDown = false;
                    if (dotsList.Last()[0] != penUp) addPoint(penUp, penUp);
                    x = e.X; y = e.Y;
                }
                else
                {
                    g.DrawLine(pen, new Point(x, y), e.Location);
                    x = e.X; y = e.Y;
                    addPoint(DT.GetAlfa(340 - e.Location.Y, e.Location.X), DT.GetBeta(340 - e.Location.Y, e.Location.X));
                }
            }

            this.lblAlfa.Text = "Alfa: " + DT.GetAlfa(340 - e.Location.Y, e.Location.X).ToString();
            this.lblBeta.Text = "Beta: " + DT.GetBeta(340 - e.Location.Y, e.Location.X).ToString();

            lblX.Text = "X: " + (340 - e.Location.Y).ToString();
            lblY.Text = "Y: " + (e.Location.X).ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            c1.Stop();
            abort = false;
            ws.Close();
            this.Close();
            this.Dispose();

        }

        #region "UI"

        private void updateLabel(String data)
        {
            if (this.lblDataSent.InvokeRequired)
            {
                this.lblDataSent.BeginInvoke((MethodInvoker)delegate () { this.lblDataSent.Text = data; });
            }
            else
            {
                this.lblDataSent.Text = data;
            }
        }

        private void checkConnection()
        {

            while (abort)
            {
                if (ws.IsAlive)
                {
                    if (this.pbOnline.InvokeRequired)
                    {
                        this.pbOnline.BeginInvoke((MethodInvoker)delegate () { this.pbOnline.Visible = true; });
                        this.pbOffline.BeginInvoke((MethodInvoker)delegate () { this.pbOffline.Visible = false; });
                        this.lblConnecting.BeginInvoke((MethodInvoker)delegate () { this.lblConnecting.Visible = false; });
                    }
                    else
                    {
                        this.pbOnline.Visible = true;
                        this.pbOffline.Visible = false;
                        this.lblConnecting.Visible = false;
                    }

                }
                else
                {
                    if (this.pbOnline.InvokeRequired)
                    {
                        this.pbOnline.BeginInvoke((MethodInvoker)delegate () { this.pbOnline.Visible = false; });
                        this.pbOffline.BeginInvoke((MethodInvoker)delegate () { this.pbOffline.Visible = true; });
                        this.lblConnecting.BeginInvoke((MethodInvoker)delegate () { this.lblConnecting.Visible = false; });
                    }
                    else
                    {
                        this.pbOnline.Visible = false;
                        this.pbOffline.Visible = true;
                        this.lblConnecting.Visible = false;
                    }

                }

                Thread.Sleep(1000);
            }
        }



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
            lblSegments.Text = (dotsList.Count(x => x[0] == penUp) / 2).ToString();
            lblPoints.Refresh();
            lblSegments.Refresh();

            for (int i = xStart; i <= xMax + xStart; i += 6)
            {
                for (int j = yStart; j <= yMax + yStart; j += 6)
                {
                    if (dotsList.Count > 0)
                    {
                        rect = new Rectangle(i, j, 4, 4);
                        if (dotsList[listCount][0] == penUp) { sb.Color = Color.Red; } else { sb.Color = Color.YellowGreen; };
                        e.Graphics.FillRectangle(sb, rect);
                        listCount++;
                        if (listCount >= dotsList.Count()) return;
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

        private void pbSend_Click(object sender, EventArgs e)
        {
            if (ws.IsAlive)
            {
                foreach (double[] dot in dotsList)
                {
                    queue.Enqueue(dot);
                }

                dotsList = new List<double[]>();
                this.Invalidate();
                this.panel1.Invalidate();
            }
            else
            {
                lblConnecting.Visible = false;
                pbOffline.Visible = true;
                pbOnline.Visible = false;
            }
        }

        private void pbOffline_Click(object sender, EventArgs e)
        {
            pbOffline.Visible = false;
            lblConnecting.Visible = true;
            ws.Connect();
        }
    }
}
