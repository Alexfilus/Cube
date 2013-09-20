using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cube
{
    public partial class Form1 : Form
    {
        CubeControls Obj;

        public Form1()
        {
            InitializeComponent();
            Obj = new CubeControls(new Point(405, 0), controlPanel.Size);
            Controls.Add(Obj);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cube.DrawCube(this.CreateGraphics(), Obj.GetVector(), Obj.GetAlpha(), Obj.GetBeta(), Obj.GetGamma(), Obj.GetSigma(), Obj.GetAbs(), Obj.GetOrd(), Obj.GetShowVect(), 3, 400, 400);
            //Cube.DrawCube(this.CreateGraphics(), new Point3D(1, 1, 1),size:panelDraw.Size);
        }
    }
}
