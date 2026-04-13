namespace MPIF.UI
{
    partial class MainShell
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
            this.tvModules = new System.Windows.Forms.TreeView();
            this.panelMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tvModules
            // 
            this.tvModules.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvModules.Location = new System.Drawing.Point(0, 0);
            this.tvModules.Name = "tvModules";
            this.tvModules.Size = new System.Drawing.Size(190, 470);
            this.tvModules.TabIndex = 0;
            this.tvModules.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModules_AfterSelect);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(190, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(513, 470);
            this.panelMain.TabIndex = 1;
            // 
            // MainShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 470);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.tvModules);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "MainShell";
            this.Text = "MainShell";
            this.Load += new System.EventHandler(this.MainShell_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvModules;
        private System.Windows.Forms.Panel panelMain;
    }
}