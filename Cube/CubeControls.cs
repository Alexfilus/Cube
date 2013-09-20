using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Cube
{
    class CubeControls:Control
    {
        RadioGroup RG_Abs;
        RadioGroup RG_Ord;
        TrackBar[] tBars;
        Buttons3[] buttons;
        Label[] labels;
        TextBox[] tB;
        CheckBox cB;
        Timer timer;
        int[] rot = new int[4];
        public CubeControls(Point location, Size size)
        {
            Location = location;
            Size = size;
            string[] strs = { "X", "Y", "Z" };
            RG_Abs = new RadioGroup("Ось асбцисс", strs, new Size(100, 100), new Point(20, 250));
            RG_Abs.SetSelItem(0);
            RG_Ord = new RadioGroup("Ось ординат", strs, new Size(100, 100), new Point(150, 250));
            RG_Ord.SetSelItem(2);
            tBars = new TrackBar[4];
            for (int i = 0; i < tBars.Length; i++)
            {
                tBars[i] = new TrackBar();
                tBars[i].Location = new Point(40, 15 + i * 50);
                tBars[i].Maximum = 360;
                tBars[i].Size = new Size(320, 45);
            }
            buttons = new Buttons3[4];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Buttons3(new Point(370, 15 + i * 50), new Size(25, 25));
                buttons[i].left.Click += new System.EventHandler(left_Click);
                buttons[i].stop.Click += new System.EventHandler(stop_Click);
                buttons[i].right.Click += new System.EventHandler(right_Click);
            }
            labels = new Label[4];
            
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Location = new Point(1, 15 + i * 50);
            }
            labels[0].Text = "Alpha";
            labels[1].Text = "Beta";
            labels[2].Text = "Gamma";
            labels[3].Text = "Sigma";
            tB = new TextBox[3];
            for (int i = 0; i < tB.Length; i++)
            {
                tB[i] = new TextBox();
                tB[i].Text = "1";
                tB[i].Location = new Point(140 + 25 * i, 210);
                tB[i].TextAlign = HorizontalAlignment.Center;
                tB[i].Size = new Size(20, 20);
            }
            cB = new CheckBox();
            cB.Text = "Отображать вектор";
            cB.TextAlign = ContentAlignment.BottomCenter;
            cB.Location = new Point(10, 210);

            timer = new Timer();
            timer.Interval = 10;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            Controls.Add(cB);
            Controls.AddRange(tB);
            Controls.AddRange(tBars);
            Controls.AddRange(buttons);
            Controls.AddRange(labels);
            Controls.Add(RG_Abs);
            Controls.Add(RG_Ord);
        }
        public int GetAlpha()
        {
            return tBars[0].Value;
        }
        public int GetBeta()
        {
            return tBars[1].Value;
        }
        public int GetGamma()
        {
            return tBars[2].Value;
        }
        public int GetSigma()
        {
            return tBars[3].Value;
        }
        public Point3D GetVector()
        {
            return new Point3D(Convert.ToInt32(tB[0].Text), Convert.ToInt32(tB[1].Text), Convert.ToInt32(tB[2].Text));
        }
         public bool GetShowVect()
         {
             return cB.Checked;
         }
         public int GetAbs()
         {
             return RG_Abs.GetSelItem();
         }
         public int GetOrd()
         {
             return RG_Ord.GetSelItem();
         }
         private void left_Click(object sender, EventArgs e)
         {
             for(int i=0;i<buttons.Length;i++)
                 if ((sender as Button) == buttons[i].left) rot[i] = -1;
         }
         private void right_Click(object sender, EventArgs e)
         {
             for (int i = 0; i < buttons.Length; i++)
                 if ((sender as Button) == buttons[i].right) rot[i] = 1;
         }
         private void stop_Click(object sender, EventArgs e)
         {
             for (int i = 0; i < buttons.Length; i++)
                 if ((sender as Button) == buttons[i].stop) rot[i] = 0;
         }
         private void timer_Tick(object sender, EventArgs e)
         {
             for (int i = 0; i < tBars.Length; i++)
                 if ((rot[i] > 0) && (tBars[i].Value == tBars[i].Maximum)) tBars[i].Value = tBars[i].Minimum;
                 else if ((rot[i] < 0) && (tBars[i].Value == tBars[i].Minimum)) tBars[i].Value = tBars[i].Maximum;
                 else tBars[i].Value += rot[i];
         }
    }
}
