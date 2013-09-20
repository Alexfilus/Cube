using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Cube
{
    class RadioGroup:GroupBox
    {
        List<RadioButton> Items = new List<RadioButton>();
        int selectedItem = -1;
        public RadioGroup(string title, string[] strs, Size size, Point location)
        {
            Text = title;
            Width = size.Width;
            Height = size.Height;
            this.Location = location;
            for (int i = 0; i < strs.Length; i++)
            {
                Items.Add(new RadioButton());
                Items[i].Text = strs[i];
                Items[i].Name = "radioButton" + i.ToString();
                Items[i].Location = new Point(15, 20 + (Width - 20) / strs.Length * i);
                Items[i].CheckedChanged += new EventHandler(CheckedChanged);
                Controls.Add(Items[i]);
            }
        }
        public void Add(string str)
        {
            Items.Add(new RadioButton());
            Items[Items.Count - 1].Text = str;
            ReLocate();
            Controls.Add(Items[Items.Count - 1]);
        }

        private void ReLocate()
        {
            for (int i = 0; i < Items.Count; i++)
                Items[i].Location = new Point(15, 20 + (Width - 20) / Items.Count * i);
        }
        private void CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0;i<Items.Count;i++)
                if (Items[i].Checked)
                {
                    selectedItem = i;
                    break;
                }
        }
        public int GetSelItem()
        {
            return selectedItem;
        }
        public void SetSelItem(int num)
        {
            Items[num].Checked = true;
        }
    }
}
