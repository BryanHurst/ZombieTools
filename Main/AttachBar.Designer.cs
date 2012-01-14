namespace ZombieTools
{
    partial class AttachBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.text = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.attachTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 31);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(330, 26);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Location = new System.Drawing.Point(12, 9);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(142, 13);
            this.text.TabIndex = 1;
            this.text.Text = "Please Launch Aion Game...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onCancelClick);
            // 
            // attachTimer
            // 
            this.attachTimer.Enabled = true;
            this.attachTimer.Tick += new System.EventHandler(this.onAttachTick);
            // 
            // AttachBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 102);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text);
            this.Controls.Add(this.progressBar1);
            this.Name = "AttachBar";
            this.Text = "Attaching...";
            this.Load += new System.EventHandler(this.AttachBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer attachTimer;
    }
}