namespace Cube
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.panelDraw = new System.Windows.Forms.Panel();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timerDraw
            // 
            this.timerDraw.Enabled = true;
            this.timerDraw.Interval = 20;
            this.timerDraw.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelDraw
            // 
            this.panelDraw.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDraw.Location = new System.Drawing.Point(0, 0);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(400, 400);
            this.panelDraw.TabIndex = 0;
            this.panelDraw.Visible = false;
            // 
            // controlPanel
            // 
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlPanel.Location = new System.Drawing.Point(406, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(450, 400);
            this.controlPanel.TabIndex = 1;
            this.controlPanel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 400);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.panelDraw);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Cube";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerDraw;
        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.Panel controlPanel;
    }
}

