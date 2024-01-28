namespace GiaoDien
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tv_TreeFolder = new TreeView();
            btn_Scan = new Button();
            SuspendLayout();
            // 
            // tv_TreeFolder
            // 
            tv_TreeFolder.Location = new Point(30, 12);
            tv_TreeFolder.Name = "tv_TreeFolder";
            tv_TreeFolder.Size = new Size(661, 426);
            tv_TreeFolder.TabIndex = 0;
            // 
            // btn_Scan
            // 
            btn_Scan.Location = new Point(697, 409);
            btn_Scan.Name = "btn_Scan";
            btn_Scan.Size = new Size(94, 29);
            btn_Scan.TabIndex = 1;
            btn_Scan.Text = "Scan";
            btn_Scan.UseVisualStyleBackColor = true;
            btn_Scan.Click += btn_Scan_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Scan);
            Controls.Add(tv_TreeFolder);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private TreeView tv_TreeFolder;
        private Button btn_Scan;
    }
}