using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cube
{
    class Buttons3:Control
    {
        public Button left, stop, right;
        public Buttons3(Point location, Size size)
        {
            this.Size = new Size(size.Width * 3, size.Height);
            this.Location = location;
            left = new Button();
            stop = new Button();
            right = new Button();
            left.Location = new Point(0, 0);
            left.Size = size;
            stop.Location = new Point(size.Width + 1, 0);
            stop.Size = size;
            right.Location = new Point(size.Width * 2 + 1, 0);
            right.Size = size;
            left.Font = new Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            right.Font = new Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            stop.Font = new Font("Wingdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            left.Text = "t";
            stop.Text = "n";
            right.Text = "u";
            Controls.Add(left);
            Controls.Add(stop);
            Controls.Add(right);
        }
    }
}
