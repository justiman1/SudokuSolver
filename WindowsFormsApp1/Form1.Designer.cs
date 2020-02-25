namespace WindowsFormsApp1
{
    partial class Form1
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
            this.lboxQBs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lboxQBs
            // 
            this.lboxQBs.FormattingEnabled = true;
            this.lboxQBs.ItemHeight = 20;
            this.lboxQBs.Items.AddRange(new object[] {
            "Tanner Mangum",
            "Zach Wilson",
            "Joe Critchlow",
            "Beau Hoge",
            "Austin Kafentzis"});
            this.lboxQBs.Location = new System.Drawing.Point(58, 62);
            this.lboxQBs.Name = "lboxQBs";
            this.lboxQBs.Size = new System.Drawing.Size(230, 284);
            this.lboxQBs.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 902);
            this.Controls.Add(this.lboxQBs);
            this.Name = "Form1";
            this.Text = "BYU Quarterbacks";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lboxQBs;
    }
}

